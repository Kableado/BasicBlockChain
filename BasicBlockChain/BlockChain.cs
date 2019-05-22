using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBlockChain
{
    public class BlockChain
    {
        public List<Block> Chain { get; } = new List<Block>();
        public int Difficulty { get; set; } = 2;

        public BlockChain(DateTime? genesisDate = null, int difficulty = 2)
        {
            Block genesisBlock = new Block(genesisDate ?? DateTime.UtcNow, null, "{}");
            genesisBlock.Mine(difficulty);
            Difficulty = difficulty;
            Chain.Add(genesisBlock);
        }

        public void AddData(DateTime date, string data)
        {
            Block lastBlock = Chain.Last();
            Block newBlock = new Block(date, lastBlock, data);
            newBlock.Mine(Difficulty);
            Chain.Add(newBlock);
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
    }
}
