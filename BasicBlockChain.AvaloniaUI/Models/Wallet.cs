// Wallet.cs
namespace BasicBlockChain.AvaloniaUI.Models
{
    public class Wallet
    {
        public string? User { get; set; }
        public long Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", User, Amount);
        }
    }
}
