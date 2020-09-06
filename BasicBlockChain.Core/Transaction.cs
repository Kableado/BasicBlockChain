using System;

namespace BasicBlockChain.Core
{
    public class Transaction
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public long MicroCoinAmount { get; set; }
        public DateTime Date { get; set; }

        public Transaction() { }

        public Transaction(string sender, string receiver, long microCoinAmount, DateTime date)
        {
            Sender = sender;
            Receiver = receiver;
            MicroCoinAmount = microCoinAmount;
            Date = date;
        }
    }
}
