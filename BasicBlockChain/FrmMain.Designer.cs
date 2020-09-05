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
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.btnClearFrom = new System.Windows.Forms.Button();
            this.btnClearTo = new System.Windows.Forms.Button();
            this.btnClearAmount = new System.Windows.Forms.Button();
            this.lsbUsers = new System.Windows.Forms.ListBox();
            this.grpAddTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbTransactions
            // 
            this.lsbTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbTransactions.FormattingEnabled = true;
            this.lsbTransactions.Location = new System.Drawing.Point(12, 129);
            this.lsbTransactions.Name = "lsbTransactions";
            this.lsbTransactions.Size = new System.Drawing.Size(225, 368);
            this.lsbTransactions.TabIndex = 0;
            // 
            // lsbPendingTransactions
            // 
            this.lsbPendingTransactions.FormattingEnabled = true;
            this.lsbPendingTransactions.Location = new System.Drawing.Point(12, 12);
            this.lsbPendingTransactions.Name = "lsbPendingTransactions";
            this.lsbPendingTransactions.Size = new System.Drawing.Size(225, 82);
            this.lsbPendingTransactions.TabIndex = 1;
            // 
            // btnMine
            // 
            this.btnMine.Location = new System.Drawing.Point(162, 100);
            this.btnMine.Name = "btnMine";
            this.btnMine.Size = new System.Drawing.Size(75, 23);
            this.btnMine.TabIndex = 2;
            this.btnMine.Text = "Mine";
            this.btnMine.UseVisualStyleBackColor = true;
            this.btnMine.Click += new System.EventHandler(this.btnMine_Click);
            // 
            // grpAddTransaction
            // 
            this.grpAddTransaction.Controls.Add(this.btnClearAmount);
            this.grpAddTransaction.Controls.Add(this.btnClearTo);
            this.grpAddTransaction.Controls.Add(this.btnClearFrom);
            this.grpAddTransaction.Controls.Add(this.numAmount);
            this.grpAddTransaction.Controls.Add(this.txtTo);
            this.grpAddTransaction.Controls.Add(this.txtFrom);
            this.grpAddTransaction.Controls.Add(this.lblAmount);
            this.grpAddTransaction.Controls.Add(this.lblTo);
            this.grpAddTransaction.Controls.Add(this.lblFrom);
            this.grpAddTransaction.Controls.Add(this.btnAdd);
            this.grpAddTransaction.Location = new System.Drawing.Point(243, 12);
            this.grpAddTransaction.Name = "grpAddTransaction";
            this.grpAddTransaction.Size = new System.Drawing.Size(175, 132);
            this.grpAddTransaction.TabIndex = 3;
            this.grpAddTransaction.TabStop = false;
            this.grpAddTransaction.Text = "Add transaction";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(94, 97);
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
            this.txtMinerName.Location = new System.Drawing.Point(69, 103);
            this.txtMinerName.Name = "txtMinerName";
            this.txtMinerName.Size = new System.Drawing.Size(87, 20);
            this.txtMinerName.TabIndex = 4;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(47, 19);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(95, 20);
            this.txtFrom.TabIndex = 4;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(47, 45);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(95, 20);
            this.txtTo.TabIndex = 5;
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(47, 71);
            this.numAmount.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(95, 20);
            this.numAmount.TabIndex = 7;
            // 
            // btnClearFrom
            // 
            this.btnClearFrom.Location = new System.Drawing.Point(148, 19);
            this.btnClearFrom.Name = "btnClearFrom";
            this.btnClearFrom.Size = new System.Drawing.Size(21, 20);
            this.btnClearFrom.TabIndex = 8;
            this.btnClearFrom.Text = "X";
            this.btnClearFrom.UseVisualStyleBackColor = true;
            this.btnClearFrom.Click += new System.EventHandler(this.btnClearFrom_Click);
            // 
            // btnClearTo
            // 
            this.btnClearTo.Location = new System.Drawing.Point(148, 45);
            this.btnClearTo.Name = "btnClearTo";
            this.btnClearTo.Size = new System.Drawing.Size(21, 20);
            this.btnClearTo.TabIndex = 9;
            this.btnClearTo.Text = "X";
            this.btnClearTo.UseVisualStyleBackColor = true;
            this.btnClearTo.Click += new System.EventHandler(this.btnClearTo_Click);
            // 
            // btnClearAmount
            // 
            this.btnClearAmount.Location = new System.Drawing.Point(148, 71);
            this.btnClearAmount.Name = "btnClearAmount";
            this.btnClearAmount.Size = new System.Drawing.Size(21, 20);
            this.btnClearAmount.TabIndex = 10;
            this.btnClearAmount.Text = "X";
            this.btnClearAmount.UseVisualStyleBackColor = true;
            this.btnClearAmount.Click += new System.EventHandler(this.btnClearAmount_Click);
            // 
            // lsbUsers
            // 
            this.lsbUsers.FormattingEnabled = true;
            this.lsbUsers.Location = new System.Drawing.Point(243, 150);
            this.lsbUsers.Name = "lsbUsers";
            this.lsbUsers.Size = new System.Drawing.Size(175, 134);
            this.lsbUsers.TabIndex = 5;
            this.lsbUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbUsers_MouseDoubleClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 521);
            this.Controls.Add(this.lsbUsers);
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
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbTransactions;
        private System.Windows.Forms.ListBox lsbPendingTransactions;
        private System.Windows.Forms.Button btnMine;
        private System.Windows.Forms.GroupBox grpAddTransaction;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMinerName;
        private System.Windows.Forms.Button btnClearAmount;
        private System.Windows.Forms.Button btnClearTo;
        private System.Windows.Forms.Button btnClearFrom;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.ListBox lsbUsers;
    }
}