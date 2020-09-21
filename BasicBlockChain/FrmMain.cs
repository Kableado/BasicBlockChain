using System;
using System.IO;
using System.Windows.Forms;
using BasicBlockChain.Core;
using VAR.Json;

namespace BasicBlockChain
{
    public partial class FrmMain : Form
    {
        private BlockChain _nullCoin = null;

        public FrmMain()
        {
            InitializeComponent();
            InitBlockChain();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTo.Text) || string.IsNullOrEmpty(txtFrom.Text)) { return; }
            long amount = (long)numAmount.Value;
            _nullCoin.AddTransaction(new Transaction(txtFrom.Text, txtTo.Text, amount, DateTime.UtcNow));
            txtTo.Text = string.Empty;
            txtFrom.Text = string.Empty;
            numAmount.Value = 0;
            Lists_Update();
        }

        private void btnMine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMinerName.Text)) { return; }
            _nullCoin.ProcessPendingTransactions(DateTime.UtcNow, txtMinerName.Text);
            Lists_Update();
        }

        private void btnClearFrom_Click(object sender, EventArgs e)
        {
            txtFrom.Text = string.Empty;
        }

        private void btnClearTo_Click(object sender, EventArgs e)
        {
            txtTo.Text = string.Empty;
        }

        private void btnClearAmount_Click(object sender, EventArgs e)
        {
            numAmount.Value = 0;
        }

        private void lsbUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Wallet wallet = (Wallet)lsbUsers.SelectedItem;
            if (wallet == null) { return; }
            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                txtFrom.Text = wallet.User;
                return;
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                txtTo.Text = wallet.User;
                return;
            }
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveBlockChain();
        }

        private void Lists_Update()
        {
            lsbTransactions.Items.Clear();
            foreach (Block block in _nullCoin.Chain)
            {
                foreach (Transaction transaction in block.Transactions)
                {
                    lsbTransactions.Items.Add(Transaction_ToString(transaction));
                }
            }

            lsbPendingTransactions.Items.Clear();
            foreach (Transaction transaction in _nullCoin.PendingTransactions)
            {
                lsbPendingTransactions.Items.Add(Transaction_ToString(transaction));
            }

            lsbUsers.Items.Clear();
            foreach (string user in _nullCoin.Users)
            {
                long amount = _nullCoin.GetMicroCoinBalance(user);
                lsbUsers.Items.Add(new Wallet { User = user, Amount = amount });
            }
        }

        public class Wallet
        {
            public string User { get; set; }
            public long Amount { get; set; }

            public override string ToString()
            {
                return string.Format("{0} - {1}", User, Amount);
            }
        }

        private string Transaction_ToString(Transaction transaction)
        {
            return string.Format("{0} - {1} - {2} - {3}", transaction.Date, transaction.Sender, transaction.Receiver, transaction.MicroCoinAmount);
        }

        private const string BlockChainFile = "BlockChain.{0}.json";
        private const string BlockChainLock = "BlockChain.{0}.lock";
        private int _currentFile = 0;

        private void InitBlockChain()
        {
            FrmMainBlockChain blockChain = null;

            string blockChainLock;
            do
            {
                blockChainLock = string.Format(BlockChainLock, _currentFile);
                if (File.Exists(blockChainLock) == false) { break; }
                _currentFile++;
            } while (true);
            File.WriteAllText(blockChainLock, "Lock");

            string blockChainFile = string.Format(BlockChainFile, _currentFile);
            if (File.Exists(blockChainFile))
            {
                string contentBlockChainFile = File.ReadAllText(blockChainFile);
                blockChain = JsonParser.ParseText(contentBlockChainFile, typeof(FrmMainBlockChain), typeof(BlockChain), typeof(Block), typeof(Transaction)) as FrmMainBlockChain;
            }

            if (blockChain != null)
            {
                _nullCoin = blockChain.BlockChain;
                txtMinerName.Text = blockChain.Miner;
            }
            else
            {
                _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1), difficulty: 2);
                txtMinerName.Text = string.Empty;
            }
            Lists_Update();
        }

        private void SaveBlockChain()
        {
            string blockChainFile = string.Format(BlockChainFile, _currentFile);
            if (File.Exists(blockChainFile))
            {
                File.Delete(blockChainFile);
            }
            FrmMainBlockChain blockChain = new FrmMainBlockChain
            {
                BlockChain = _nullCoin,
                Miner = txtMinerName.Text,
            };
            string strBlockChain = JsonWriter.WriteObject(blockChain, indent: true);
            File.WriteAllText(blockChainFile, strBlockChain);

            string blockChainLock = string.Format(BlockChainLock, _currentFile);
            if (File.Exists(blockChainLock))
            {
                File.Delete(blockChainLock);
            }
        }

        public class FrmMainBlockChain
        {
            public BlockChain BlockChain { get; set; }
            public string Miner { get; set; }

        };
    }
}
