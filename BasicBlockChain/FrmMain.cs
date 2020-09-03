using System;
using System.Windows.Forms;
using BasicBlockChain.Core;

namespace BasicBlockChain
{
    public partial class FrmMain : Form
    {
        private BlockChain _nullCoin = null;

        public FrmMain()
        {
            InitializeComponent();
            _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1), difficulty: 2);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTo.Text) || string.IsNullOrEmpty(txtFrom.Text) || string.IsNullOrEmpty(txtAmount.Text)) { return; }
            long amount = Convert.ToInt64(txtAmount.Text);
            _nullCoin.AddTransaction(new Transaction(txtFrom.Text, txtTo.Text, amount, DateTime.UtcNow));
            txtTo.Text = string.Empty;
            txtFrom.Text = string.Empty;
            txtAmount.Text = string.Empty;
            Lists_Update();
        }

        private void btnMine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMinerName.Text)) { return; }
            _nullCoin.ProcessPendingTransactions(DateTime.UtcNow, txtMinerName.Text);
            Lists_Update();
        }

        private void Lists_Update()
        {
            lsbTransactions.Items.Clear();
            foreach (Block block in _nullCoin.Chain)
            {
                foreach (Transaction transaction in block.Transactions)
                {
                    lsbTransactions.Items.Add(Transaction_ToString(transaction));
                }
            }

            lsbPendingTransactions.Items.Clear();
            foreach (Transaction transaction in _nullCoin.PendingTransactions)
            {
                lsbPendingTransactions.Items.Add(Transaction_ToString(transaction));
            }
        }

        private string Transaction_ToString(Transaction transaction)
        {
            return string.Format("{0} - {1} - {2} - {3}", transaction.Date, transaction.Sender, transaction.Receiver, transaction.MicroCoinAmount);
        }
    }
}
