using Xunit;

namespace BasicBlockChain.Core.Tests
{
    public class BlockChainTests
    {
        #region Test Data

        private BlockChain GenerateTestData()
        {
            BlockChain nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1), difficulty: 2);
            nullCoin.AddTransaction(new Transaction("VAR", "NAM", 10_000_000, new DateTime(2000, 1, 2)));
            nullCoin.ProcessPendingTransactions(new DateTime(2000, 1, 2), "Kable");
            nullCoin.AddTransaction(new Transaction("NAM", "VAR", 5_000_000, new DateTime(2000, 1, 3)));
            nullCoin.ProcessPendingTransactions(new DateTime(2000, 1, 3), "Kable");
            nullCoin.AddTransaction(new Transaction("NAM", "VAR", 5_000_000, new DateTime(2000, 1, 4)));
            nullCoin.ProcessPendingTransactions(new DateTime(2000, 1, 4), "Kable");
            return nullCoin;
        }

        #endregion Test Data

        #region Verify

        [Fact]
        public void Verify__Null()
        {
            BlockChain nullCoin = new BlockChain();

            bool result = nullCoin.Verify();

            Assert.True(result);
        }

        [Fact]
        public void Verify__Valid()
        {
            BlockChain nullCoin = GenerateTestData();

            bool result = nullCoin.Verify();

            Assert.True(result);
        }

        [Fact]
        public void Verify__Tampered()
        {
            BlockChain nullCoin = GenerateTestData();
            nullCoin.Chain[1].Transactions[0].MicroCoinAmount = 1000_000_000;

            bool result = nullCoin.Verify();

            Assert.False(result);
        }

        #endregion Verify

        #region GetMicroCoinBalance

        [Fact]
        public void GetMicroCoinBalance__Test()
        {
            BlockChain nullCoin = GenerateTestData();

            long balanceVAR = nullCoin.GetMicroCoinBalance("VAR");
            long balanceNAM = nullCoin.GetMicroCoinBalance("NAM");
            long balanceKable = nullCoin.GetMicroCoinBalance("Kable");
            long expectedBlananceKable = nullCoin.Reward * 3;

            Assert.Equal(0, balanceVAR);
            Assert.Equal(0, balanceNAM);
            Assert.Equal(expectedBlananceKable, balanceKable);
        }

        #endregion GetMicroCoinBalance
    }
}