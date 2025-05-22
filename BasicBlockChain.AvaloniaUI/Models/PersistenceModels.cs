using BasicBlockChain.Core;

namespace BasicBlockChain.AvaloniaUI.Models
{
    public class BlockChainSaveData
    {
        public BlockChain? BlockChain { get; set; } // Made nullable
        public string? Miner { get; set; } // Made nullable
    }
}
