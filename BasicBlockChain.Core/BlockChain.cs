using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBlockChain.Core
{
    public class BlockChain
    {
        public List<Transaction> PendingTransactions { get; } = new List<Transaction>();
        public List<Block> Chain { get; set; } = new List<Block>();
        public int Difficulty { get; set; } = 2;
        public int Reward { get; set; } = 1_000_000;

        private List<string> _users = null;

        public List<string> Users
        {
            get
            {
                if (_users == null)
                {
                    InitUsers();
                }
                return _users;
            }
            set
            {
                _users = value;
            }
        }

        private void InitUsers()
        {
            _users = new List<string>();
            foreach (Block block in Chain)
            {
                foreach (Transaction transaction in block.Transactions)
                {
                    AddUser(transaction.Sender, false);
                    AddUser(transaction.Receiver, false);
                }
            }
        }

        private void AddUser(string user, bool init = true)
        {
            if (string.IsNullOrEmpty(user)) { return; }
            if (_users == null)
            {
                if (init)
                {
                    InitUsers();
                }
                else
                {
                    return;
                }
            }
            if (_users.Contains(user)) { return; }
            _users.Add(user);
        }

        private void AddUsersOfBlock(Block block)
        {
            foreach (Transaction transaction in block.Transactions)
            {
                AddUser(transaction.Sender);
                AddUser(transaction.Receiver);
            }
        }

        public BlockChain() { }

        public BlockChain(DateTime? genesisDate = null, int difficulty = 2, int reward = 1_000_000)
        {
            Block genesisBlock = new Block(genesisDate ?? DateTime.UtcNow, null, null);
            genesisBlock.Mine(difficulty);
            Difficulty = difficulty;
            Reward = reward;
            Chain.Add(genesisBlock);
        }

        public void AddBlock(DateTime date, IList<Transaction> transactions)
        {
            Block lastBlock = Chain.Last();
            Block newBlock = new Block(date, lastBlock, transactions);
            newBlock.Mine(Difficulty);
            AddUsersOfBlock(newBlock);
            Chain.Add(newBlock);
        }

        public void AddTransaction(Transaction transaction)
        {
            PendingTransactions.Add(transaction);
        }

        public void ProcessPendingTransactions(DateTime date, string miner)
        {
            Block lastBlock = Chain.Last();
            Block newBlock = new Block(date, lastBlock, PendingTransactions);
            newBlock.Transactions.Add(new Transaction(null, miner, Reward, date));
            newBlock.Mine(Difficulty);
            AddUsersOfBlock(newBlock);
            Chain.Add(newBlock);
            PendingTransactions.Clear();
        }

        public bool Verify()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                string currentBlockHashRecalculated = currentBlock.CalculateHash();
                if (currentBlock.Hash != currentBlockHashRecalculated || currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }

        public long GetMicroCoinBalance(string receiver)
        {
            long microCoinBalance = 0;

            for (int i = 0; i < Chain.Count; i++)
            {
                for (int j = 0; j < Chain[i].Transactions.Count; j++)
                {
                    var transaction = Chain[i].Transactions[j];

                    if (transaction.Sender == receiver)
                    {
                        microCoinBalance -= transaction.MicroCoinAmount;
                    }

                    if (transaction.Receiver == receiver)
                    {
                        microCoinBalance += transaction.MicroCoinAmount;
                    }
                }
            }

            return microCoinBalance;
        }
    }
}
