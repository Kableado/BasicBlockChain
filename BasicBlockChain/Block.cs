using System;
using System.Security.Cryptography;
using System.Text;

namespace BasicBlockChain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Date { get; set; }
        public string PreviousHash { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
        public int Nonce { get; set; }

        public Block(DateTime date, Block previousBlock, string data)
        {
            Index = (previousBlock?.Index ?? -1) + 1;
            Date = date;
            PreviousHash = previousBlock?.Hash;
            Data = data;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] dataBytes = Encoding.UTF8.GetBytes(string.Format("{0}-{1}-{2}-{3}", Date, PreviousHash, Data, Nonce));
            byte[] hashBytes = sha256.ComputeHash(dataBytes);

            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }

        public void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);
            while (Hash.Substring(0, difficulty) != leadingZeros)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
