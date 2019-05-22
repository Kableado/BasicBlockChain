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
            Console.WriteLine("#### BlockChain with sample data");
            BlockChain nullCoin = new BlockChain(new DateTime(2000, 1, 1));
            nullCoin.AddData(new DateTime(2000, 1, 2), "{ sender: VAR, receiver: NAM, amount: 10.00}");
            nullCoin.AddData(new DateTime(2000, 1, 3), "{ sender: NAM, receiver: VAR, amount: 5.00}");
            nullCoin.AddData(new DateTime(2000, 1, 4), "{ sender: NAM, receiver: VAR, amount: 5.00}");
            Console.WriteLine(jsonWriter.Write(nullCoin));

            // Verify
            Console.WriteLine("BlockChain is Valid? {0}", nullCoin.Verify() ? "True" : "False");

            // Tamper with the data
            Console.WriteLine();
            Console.WriteLine("#### Tampering with the data");
            nullCoin.Chain[1].Data = "{ sender: VAR, receiver: NAM, amount: 1000.00}";
            Console.WriteLine(jsonWriter.Write(nullCoin));

            // Verify
            Console.WriteLine("BlockChain is Valid? {0}", nullCoin.Verify() ? "True" : "False");

            Console.Read();
        }
    }
}
