using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using BasicBlockChain.Core;
using BasicBlockChain.AvaloniaUI.Services;
using BasicBlockChain.AvaloniaUI.Initialization;
using BasicBlockChain.AvaloniaUI.Models; // For Wallet

namespace BasicBlockChain.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly BlockChainService? _blockChainService;

        // Properties for UI Binding
        private string _fromText = string.Empty;
        public string FromText
        {
            get => _fromText;
            set => SetProperty(ref _fromText, value);
        }

        private string _toText = string.Empty;
        public string ToText
        {
            get => _toText;
            set => SetProperty(ref _toText, value);
        }

        private decimal _amountValue; // Using decimal for NumericUpDown compatibility
        public decimal AmountValue
        {
            get => _amountValue;
            set => SetProperty(ref _amountValue, value);
        }

        private string _minerNameText = string.Empty;
        public string MinerNameText
        {
            get => _minerNameText;
            set
            {
                SetProperty(ref _minerNameText, value);
                if (_blockChainService != null)
                {
                    _blockChainService.MinerName = value; // Keep service updated
                }
            }
        }

        public ObservableCollection<string> PendingTransactionsItems { get; } = new();
        public ObservableCollection<string> BlocksItems { get; } = new();
        public ObservableCollection<Wallet> UserWalletItems { get; } = new();

        private Wallet? _selectedUserWallet;
        public Wallet? SelectedUserWallet
        {
            get => _selectedUserWallet;
            set => SetProperty(ref _selectedUserWallet, value);
        }

        // Commands
        public ICommand AddTransactionCommand { get; }
        public ICommand MineCommand { get; }
        public ICommand ClearFromCommand { get; }
        public ICommand ClearToCommand { get; }
        public ICommand ClearAmountCommand { get; }
        public ICommand UserDoubleClickCommand { get; }


        public MainWindowViewModel()
        {
            _blockChainService = AppInitializer.BlockChainServiceInstance;

            if (_blockChainService == null)
            {
                Console.WriteLine("FATAL: BlockChainService not initialized in MainWindowViewModel!");
                // Handle this case, maybe set a status property to show an error in UI
            }
            else
            {
                MinerNameText = _blockChainService.MinerName ?? string.Empty;
            }

            // Initialize Commands
            AddTransactionCommand = new RelayCommand(AddTransaction);
            MineCommand = new RelayCommand(Mine, CanMine);
            ClearFromCommand = new RelayCommand(ClearFrom);
            ClearToCommand = new RelayCommand(ClearTo);
            ClearAmountCommand = new RelayCommand(ClearAmount);
            UserDoubleClickCommand = new RelayCommand(UserDoubleClick); // Removed CanUserDoubleClick
            
            Lists_Update();
        }

        private bool CanMine(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(MinerNameText) && 
                   _blockChainService?.NullCoin?.PendingTransactions?.Any() == true;
        }
        
        // Removed CanUserDoubleClick method as it's no longer used by UserDoubleClickCommand

        private void AddTransaction(object? parameter)
        {
            if (_blockChainService == null || _blockChainService.NullCoin == null) return;
            if (string.IsNullOrWhiteSpace(ToText))
            {
                Console.WriteLine("Receiver address (ToText) cannot be empty.");
                return; 
            }
            if (AmountValue <= 0)
            {
                 Console.WriteLine("Amount must be greater than zero.");
                return;
            }

            _blockChainService.NullCoin.AddTransaction(new Transaction(FromText, ToText, (long)AmountValue, DateTime.Now));
            
            // Clear inputs after adding
            FromText = string.Empty;
            ToText = string.Empty;
            AmountValue = 0;
            
            Lists_Update();
            CommandManager.InvalidateRequerySuggested(); // For CanMine
        }

        private void Mine(object? parameter)
        {
            if (_blockChainService == null || _blockChainService.NullCoin == null) return;
            if (string.IsNullOrWhiteSpace(MinerNameText))
            {
                 Console.WriteLine("Miner name cannot be empty for mining.");
                return;
            }
            // MinerNameText property setter already updates _blockChainService.MinerName

            _blockChainService.NullCoin.ProcessPendingTransactions(DateTime.Now, MinerNameText);
            Lists_Update();
            CommandManager.InvalidateRequerySuggested(); // For CanMine
        }

        private void ClearFrom(object? parameter) => FromText = string.Empty;
        private void ClearTo(object? parameter) => ToText = string.Empty;
        private void ClearAmount(object? parameter) => AmountValue = 0;

        private void UserDoubleClick(object? parameter) // Parameter is not used, relies on SelectedUserWallet
        {
            if (SelectedUserWallet?.User == null) return;

            if (string.IsNullOrWhiteSpace(FromText))
            {
                FromText = SelectedUserWallet.User;
                return; // Added return to prevent filling both if FromText was empty
            }
            
            if (string.IsNullOrWhiteSpace(ToText)) // Changed to separate if
            {
                ToText = SelectedUserWallet.User;
            }
        }

        private string Transaction_ToString(Transaction transaction, bool isPending)
        {
            string strIsPending = isPending ? "PENDING" : "CONFIRMED";
            if (string.IsNullOrEmpty(transaction.Sender)) // Reward transaction
            {
                return string.Format("{0} : -> {1} : {2:N0} NC",
                    strIsPending,
                    transaction.Receiver,
                    transaction.MicroCoinAmount);
            }
            return string.Format("{0} : {1} -> {2} : {3:N0} NC",
                strIsPending,
                transaction.Sender,
                transaction.Receiver,
                transaction.MicroCoinAmount);
        }

        private void Lists_Update()
        {
            if (_blockChainService == null || _blockChainService.NullCoin == null)
            {
                Console.WriteLine("Lists_Update skipped: BlockChainService or NullCoin is null.");
                return;
            }

            PendingTransactionsItems.Clear();
            if (_blockChainService.NullCoin.PendingTransactions != null)
            {
                foreach (var transaction in _blockChainService.NullCoin.PendingTransactions)
                {
                    PendingTransactionsItems.Add(Transaction_ToString(transaction, true));
                }
            }

            BlocksItems.Clear();
            if (_blockChainService.NullCoin.Chain != null)
            {
                foreach (var block in _blockChainService.NullCoin.Chain)
                {
                    BlocksItems.Add($"Block: {block.Index} | Hash: {block.Hash?.Substring(0, 10)}... | Nonce: {block.Nonce} | Date: {block.Date.ToShortTimeString()}"); // ToShortTimeString for brevity
                    if (block.Transactions != null)
                    {
                        foreach (var transaction in block.Transactions)
                        {
                            BlocksItems.Add($"  {Transaction_ToString(transaction, false)}");
                        }
                    }
                }
            }
            
            UserWalletItems.Clear();
            if (_blockChainService.NullCoin.Users != null)
            {
                foreach (var user in _blockChainService.NullCoin.Users)
                {
                    if (user != null) // Ensure user is not null before getting balance
                    {
                         UserWalletItems.Add(new Wallet { User = user, Amount = _blockChainService.NullCoin.GetMicroCoinBalance(user) });
                    }
                }
            }
            CommandManager.InvalidateRequerySuggested(); // Update CanExecute for commands
        }
    }
}
