// SerializableBlockChain.cs
using BasicBlockChain.Core;

namespace BasicBlockChain.AvaloniaUI.Models
{
    public class SerializableBlockChain
    {
        public BlockChain? BlockChain { get; set; }
        public string? Miner { get; set; }
    }
}
