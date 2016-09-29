namespace WebScrap.View
{
    partial class FrmSectorialInsiderTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSectorialInsiderTransactions));
            this.groupBoxTransactions = new System.Windows.Forms.GroupBox();
            this.textBoxTotalBuySell = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBuysSector = new System.Windows.Forms.TextBox();
            this.textBoxSalesIndust = new System.Windows.Forms.TextBox();
            this.textBoxBuysSalesIndust = new System.Windows.Forms.TextBox();
            this.textBoxSalesSector = new System.Windows.Forms.TextBox();
            this.textBoxBuySalesSector = new System.Windows.Forms.TextBox();
            this.textBoxBuysIndust = new System.Windows.Forms.TextBox();
            this.groupBoxTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTransactions
            // 
            this.groupBoxTransactions.Controls.Add(this.textBoxTotalBuySell);
            this.groupBoxTransactions.Controls.Add(this.label7);
            this.groupBoxTransactions.Controls.Add(this.label6);
            this.groupBoxTransactions.Controls.Add(this.label5);
            this.groupBoxTransactions.Controls.Add(this.label4);
            this.groupBoxTransactions.Controls.Add(this.label3);
            this.groupBoxTransactions.Controls.Add(this.label2);
            this.groupBoxTransactions.Controls.Add(this.label1);
            this.groupBoxTransactions.Controls.Add(this.textBoxBuysSector);
            this.groupBoxTransactions.Controls.Add(this.textBoxSalesIndust);
            this.groupBoxTransactions.Controls.Add(this.textBoxBuysSalesIndust);
            this.groupBoxTransactions.Controls.Add(this.textBoxSalesSector);
            this.groupBoxTransactions.Controls.Add(this.textBoxBuySalesSector);
            this.groupBoxTransactions.Controls.Add(this.textBoxBuysIndust);
            this.groupBoxTransactions.Location = new System.Drawing.Point(12, 23);
            this.groupBoxTransactions.Name = "groupBoxTransactions";
            this.groupBoxTransactions.Size = new System.Drawing.Size(1011, 776);
            this.groupBoxTransactions.TabIndex = 0;
            this.groupBoxTransactions.TabStop = false;
            this.groupBoxTransactions.Text = "Recent insider transactions, ordered by sum $ amount";
            // 
            // textBoxTotalBuySell
            // 
            this.textBoxTotalBuySell.Location = new System.Drawing.Point(679, 478);
            this.textBoxTotalBuySell.Name = "textBoxTotalBuySell";
            this.textBoxTotalBuySell.Size = new System.Drawing.Size(294, 20);
            this.textBoxTotalBuySell.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(676, 458);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Total insider (buys / sales) ratio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(680, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Sector insider (buys / sales) ratio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(347, 525);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Sector insider sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(20, 525);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Sector insider buys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(676, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Industry insider (buys / sales) ratio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(337, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Industry insider sales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Industry insider buys";
            // 
            // textBoxBuysSector
            // 
            this.textBoxBuysSector.Location = new System.Drawing.Point(19, 549);
            this.textBoxBuysSector.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBuysSector.Multiline = true;
            this.textBoxBuysSector.Name = "textBoxBuysSector";
            this.textBoxBuysSector.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBuysSector.Size = new System.Drawing.Size(294, 208);
            this.textBoxBuysSector.TabIndex = 23;
            // 
            // textBoxSalesIndust
            // 
            this.textBoxSalesIndust.Location = new System.Drawing.Point(340, 63);
            this.textBoxSalesIndust.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSalesIndust.Multiline = true;
            this.textBoxSalesIndust.Name = "textBoxSalesIndust";
            this.textBoxSalesIndust.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSalesIndust.Size = new System.Drawing.Size(294, 435);
            this.textBoxSalesIndust.TabIndex = 22;
            // 
            // textBoxBuysSalesIndust
            // 
            this.textBoxBuysSalesIndust.Location = new System.Drawing.Point(679, 63);
            this.textBoxBuysSalesIndust.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBuysSalesIndust.Multiline = true;
            this.textBoxBuysSalesIndust.Name = "textBoxBuysSalesIndust";
            this.textBoxBuysSalesIndust.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBuysSalesIndust.Size = new System.Drawing.Size(294, 378);
            this.textBoxBuysSalesIndust.TabIndex = 21;
            // 
            // textBoxSalesSector
            // 
            this.textBoxSalesSector.Location = new System.Drawing.Point(344, 549);
            this.textBoxSalesSector.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSalesSector.Multiline = true;
            this.textBoxSalesSector.Name = "textBoxSalesSector";
            this.textBoxSalesSector.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSalesSector.Size = new System.Drawing.Size(294, 208);
            this.textBoxSalesSector.TabIndex = 20;
            // 
            // textBoxBuySalesSector
            // 
            this.textBoxBuySalesSector.Location = new System.Drawing.Point(683, 549);
            this.textBoxBuySalesSector.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBuySalesSector.Multiline = true;
            this.textBoxBuySalesSector.Name = "textBoxBuySalesSector";
            this.textBoxBuySalesSector.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBuySalesSector.Size = new System.Drawing.Size(294, 208);
            this.textBoxBuySalesSector.TabIndex = 19;
            // 
            // textBoxBuysIndust
            // 
            this.textBoxBuysIndust.Location = new System.Drawing.Point(15, 63);
            this.textBoxBuysIndust.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBuysIndust.Multiline = true;
            this.textBoxBuysIndust.Name = "textBoxBuysIndust";
            this.textBoxBuysIndust.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBuysIndust.Size = new System.Drawing.Size(294, 435);
            this.textBoxBuysIndust.TabIndex = 18;
            // 
            // FrmSectorialInsiderTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1043, 811);
            this.Controls.Add(this.groupBoxTransactions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSectorialInsiderTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insiders tracker: insider trades by sector and industry";
            this.groupBoxTransactions.ResumeLayout(false);
            this.groupBoxTransactions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTransactions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBuysSector;
        private System.Windows.Forms.TextBox textBoxSalesIndust;
        private System.Windows.Forms.TextBox textBoxBuysSalesIndust;
        private System.Windows.Forms.TextBox textBoxSalesSector;
        private System.Windows.Forms.TextBox textBoxBuySalesSector;
        private System.Windows.Forms.TextBox textBoxBuysIndust;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTotalBuySell;


    }
}