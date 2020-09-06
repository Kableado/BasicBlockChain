using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using VAR.Json;

namespace BasicBlockChain.Core
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Date { get; set; }
        public string PreviousHash { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public string Hash { get; set; }
        public int Nonce { get; set; }

        public Block() { }

        public Block(DateTime date, Block previousBlock, IList<Transaction> transactions)
        {
            Index = (previousBlock?.Index ?? -1) + 1;
            Date = date;
            PreviousHash = previousBlock?.Hash;
            if (transactions != null) { Transactions.AddRange(transactions); }
            Nonce = 0;
            Hash = CalculateHash();
        }

        private string GetData()
        {
            return JsonWriter.WriteObject(Transactions);
        }

        public string CalculateHash(string data = null, SHA256 sha256 = null)
        {
            if (sha256 == null) { sha256 = SHA256.Create(); }
            if (data == null)
            {
                data = GetData();
            }
            byte[] dataBytes = Encoding.UTF8.GetBytes(string.Format("{0}-{1}-{2}-{3}",
                Date,
                PreviousHash,
                data,
                Nonce));
            byte[] hashBytes = sha256.ComputeHash(dataBytes);

            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }

        public void Mine(int difficulty)
        {
            SHA256 sha256 = SHA256.Create();
            var leadingZeros = new string('0', difficulty);
            string data = GetData();
            while (Hash.Substring(0, difficulty) != leadingZeros)
            {
                Nonce++;
                Hash = CalculateHash(data, sha256);
            }
        }
    }
}
