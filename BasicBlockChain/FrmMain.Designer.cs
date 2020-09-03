namespace BasicBlockChain
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lsbTransactions = new System.Windows.Forms.ListBox();
            this.lsbPendingTransactions = new System.Windows.Forms.ListBox();
            this.btnMine = new System.Windows.Forms.Button();
            this.grpAddTransaction = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtMinerName = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.grpAddTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbTransactions
            // 
            this.lsbTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbTransactions.FormattingEnabled = true;
            this.lsbTransactions.Location = new System.Drawing.Point(12, 12);
            this.lsbTransactions.Name = "lsbTransactions";
            this.lsbTransactions.Size = new System.Drawing.Size(225, 303);
            this.lsbTransactions.TabIndex = 0;
            // 
            // lsbPendingTransactions
            // 
            this.lsbPendingTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbPendingTransactions.FormattingEnabled = true;
            this.lsbPendingTransactions.Location = new System.Drawing.Point(243, 12);
            this.lsbPendingTransactions.Name = "lsbPendingTransactions";
            this.lsbPendingTransactions.Size = new System.Drawing.Size(225, 277);
            this.lsbPendingTransactions.TabIndex = 1;
            // 
            // btnMine
            // 
            this.btnMine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMine.Location = new System.Drawing.Point(393, 297);
            this.btnMine.Name = "btnMine";
            this.btnMine.Size = new System.Drawing.Size(75, 23);
            this.btnMine.TabIndex = 2;
            this.btnMine.Text = "Mine";
            this.btnMine.UseVisualStyleBackColor = true;
            this.btnMine.Click += new System.EventHandler(this.btnMine_Click);
            // 
            // grpAddTransaction
            // 
            this.grpAddTransaction.Controls.Add(this.txtAmount);
            this.grpAddTransaction.Controls.Add(this.txtTo);
            this.grpAddTransaction.Controls.Add(this.txtFrom);
            this.grpAddTransaction.Controls.Add(this.lblAmount);
            this.grpAddTransaction.Controls.Add(this.lblTo);
            this.grpAddTransaction.Controls.Add(this.lblFrom);
            this.grpAddTransaction.Controls.Add(this.btnAdd);
            this.grpAddTransaction.Location = new System.Drawing.Point(474, 12);
            this.grpAddTransaction.Name = "grpAddTransaction";
            this.grpAddTransaction.Size = new System.Drawing.Size(155, 135);
            this.grpAddTransaction.TabIndex = 3;
            this.grpAddTransaction.TabStop = false;
            this.grpAddTransaction.Text = "Add transaction";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(72, 97);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(6, 48);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 74);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount";
            // 
            // txtMinerName
            // 
            this.txtMinerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMinerName.Location = new System.Drawing.Point(287, 300);
            this.txtMinerName.Name = "txtMinerName";
            this.txtMinerName.Size = new System.Drawing.Size(100, 20);
            this.txtMinerName.TabIndex = 4;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(47, 19);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 4;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(47, 45);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 5;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(47, 71);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 338);
            this.Controls.Add(this.txtMinerName);
            this.Controls.Add(this.grpAddTransaction);
            this.Controls.Add(this.btnMine);
            this.Controls.Add(this.lsbPendingTransactions);
            this.Controls.Add(this.lsbTransactions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "BasicBlockChain";
            this.grpAddTransaction.ResumeLayout(false);
            this.grpAddTransaction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbTransactions;
        private System.Windows.Forms.ListBox lsbPendingTransactions;
        private System.Windows.Forms.Button btnMine;
        private System.Windows.Forms.GroupBox grpAddTransaction;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMinerName;
    }
}