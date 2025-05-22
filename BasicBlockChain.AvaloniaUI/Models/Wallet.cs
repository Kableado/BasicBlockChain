namespace BasicBlockChain.AvaloniaUI.Models
{
    public class Wallet
    {
        public string? User { get; set; } // Made nullable to align with <Nullable>enable</Nullable>
        public long Amount { get; set; }

        public override string ToString()
        {
            return $"{User} - {Amount}";
        }
    }
}
