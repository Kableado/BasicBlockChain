namespace BasicBlockChain
{
    public class Transaction
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public long MicroCoinAmount { get; set; }

        public Transaction(string sender, string receiver, long microCoinAmount)
        {
            Sender = sender;
            Receiver = receiver;
            MicroCoinAmount = microCoinAmount;
        }
    }
}
