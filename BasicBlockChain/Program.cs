using System;

namespace BasicBlockChain
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            VAR.Json.JsonWriter jsonWriter = new VAR.Json.JsonWriter(1);

            // Example BlockChain with some example data
            Console.WriteLine();
            Console.WriteLine("#### Mining BlockChain with sample data");
            var startTime = DateTime.UtcNow;
            BlockChain nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1), difficulty: 2);
            nullCoin.AddTransaction(new Transaction("VAR", "NAM", 10_000_000, new DateTime(2000, 1, 2)));
            nullCoin.ProcessPendingTransactions(new DateTime(2000, 1, 2), "Kable");
            nullCoin.AddTransaction(new Transaction("NAM", "VAR", 5_000_000, new DateTime(2000, 1, 3)));
            nullCoin.ProcessPendingTransactions(new DateTime(2000, 1, 3), "Kable");
            nullCoin.AddTransaction(new Transaction("NAM", "VAR", 5_000_000, new DateTime(2000, 1, 4)));
            nullCoin.ProcessPendingTransactions(new DateTime(2000, 1, 4), "Kable");
            Console.WriteLine(jsonWriter.Write(nullCoin));
            var endTime = DateTime.UtcNow;
            Console.WriteLine($"Duration: {endTime - startTime}");

            // Verify
            Console.WriteLine("BlockChain is Valid? {0}", nullCoin.Verify() ? "True" : "False");

            // Show balance
            Console.WriteLine("Balance of \"{0}\": {1}", "VAR", nullCoin.GetMicroCoinBalance("VAR"));
            Console.WriteLine("Balance of \"{0}\": {1}", "NAM", nullCoin.GetMicroCoinBalance("NAM"));
            Console.WriteLine("Balance of \"{0}\": {1}", "Kable", nullCoin.GetMicroCoinBalance("Kable"));

            // Tamper with the data
            Console.WriteLine();
            Console.WriteLine("#### Tampering with the data");
            nullCoin.Chain[1].Transactions[0].MicroCoinAmount = 1000_000_000;
            Console.WriteLine(jsonWriter.Write(nullCoin));

            // Verify
            Console.WriteLine("BlockChain is Valid? {0}", nullCoin.Verify() ? "True" : "False");
            Console.WriteLine("Balance of \"{0}\": {1}", "VAR", nullCoin.GetMicroCoinBalance("VAR"));
            Console.WriteLine("Balance of \"{0}\": {1}", "NAM", nullCoin.GetMicroCoinBalance("NAM"));
            Console.WriteLine("Balance of \"{0}\": {1}", "Kable", nullCoin.GetMicroCoinBalance("Kable"));

            Console.Read();
        }
    }
}
