using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBlockChain
{
    public class BlockChain
    {
        private List<Transaction> _pendingTransactions = new List<Transaction>();
        public List<Block> Chain { get; } = new List<Block>();
        public int Difficulty { get; set; } = 2;
        public int Reward { get; set; } = 1_000_000;

        public BlockChain(DateTime? genesisDate = null, int difficulty = 2, int reward = 1_000_000)
        {
            Block genesisBlock = new Block(genesisDate ?? DateTime.UtcNow, null, null);
            genesisBlock.Mine(difficulty);
            Difficulty = difficulty;
            Reward = 1_000_000;
            Chain.Add(genesisBlock);
        }

        public void AddBlock(DateTime date, IList<Transaction> transactions)
        {
            Block lastBlock = Chain.Last();
            Block newBlock = new Block(date, lastBlock, transactions);
            newBlock.Mine(Difficulty);
            Chain.Add(newBlock);
        }

        public void AddTransaction(Transaction transaction)
        {
            _pendingTransactions.Add(transaction);
        }

        public void ProcessPendingTransactions(DateTime date, string miner)
        {
            Block lastBlock = Chain.Last();
            Block newBlock = new Block(date, lastBlock, _pendingTransactions);
            newBlock.Transactions.Add(new Transaction(null, miner, Reward, date));
            newBlock.Mine(Difficulty);
            Chain.Add(newBlock);
            _pendingTransactions.Clear();
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
