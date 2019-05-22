using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBlockChain
{
    public class BlockChain
    {
        public List<Block> Chain { get; } = new List<Block>();

        public BlockChain(DateTime? genesisDate = null)
        {
            Block genesisBlock = new Block(genesisDate ?? DateTime.UtcNow, null, "{}");
            Chain.Add(genesisBlock);
        }

        public void AddData(DateTime date, string data)
        {
            Block lastBlock = Chain.Last();
            Block newBlock = new Block(date, lastBlock, data);
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
