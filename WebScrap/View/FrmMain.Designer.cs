namespace WebScrap.View
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
            this.buttonFlowsScreener = new System.Windows.Forms.Button();
            this.buttonFinviz = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDaysLeft = new System.Windows.Forms.Label();
            this.buttonFuturesAlerts = new System.Windows.Forms.Button();
            this.buttonInsiderTradesAlert = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFlowsScreener
            // 
            this.buttonFlowsScreener.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFlowsScreener.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFlowsScreener.Location = new System.Drawing.Point(45, 49);
            this.buttonFlowsScreener.Name = "buttonFlowsScreener";
            this.buttonFlowsScreener.Size = new System.Drawing.Size(168, 45);
            this.buttonFlowsScreener.TabIndex = 0;
            this.buttonFlowsScreener.Text = "$ flows screener";
            this.buttonFlowsScreener.UseVisualStyleBackColor = true;
            this.buttonFlowsScreener.Click += new System.EventHandler(this.buttonAvafin_Click);
            // 
            // buttonFinviz
            // 
            this.buttonFinviz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinviz.ForeColor = System.Drawing.Color.Black;
            this.buttonFinviz.Location = new System.Drawing.Point(254, 48);
            this.buttonFinviz.Name = "buttonFinviz";
            this.buttonFinviz.Size = new System.Drawing.Size(168, 45);
            this.buttonFinviz.TabIndex = 1;
            this.buttonFinviz.Text = "Insiders screener";
            this.buttonFinviz.UseVisualStyleBackColor = true;
            this.buttonFinviz.Click += new System.EventHandler(this.buttonFinviz_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.administrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(461, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.contactToolStripMenuItem.Text = "Contact";
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.administrationToolStripMenuItem.Text = "Administration";
            this.administrationToolStripMenuItem.Click += new System.EventHandler(this.administrationToolStripMenuItem_Click);
            // 
            // labelDaysLeft
            // 
            this.labelDaysLeft.AutoSize = true;
            this.labelDaysLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDaysLeft.ForeColor = System.Drawing.Color.Red;
            this.labelDaysLeft.Location = new System.Drawing.Point(12, 177);
            this.labelDaysLeft.Name = "labelDaysLeft";
            this.labelDaysLeft.Size = new System.Drawing.Size(62, 12);
            this.labelDaysLeft.TabIndex = 3;
            this.labelDaysLeft.Text = "labelDaysLeft";
            // 
            // buttonFuturesAlerts
            // 
            this.buttonFuturesAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFuturesAlerts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFuturesAlerts.Location = new System.Drawing.Point(45, 113);
            this.buttonFuturesAlerts.Name = "buttonFuturesAlerts";
            this.buttonFuturesAlerts.Size = new System.Drawing.Size(168, 45);
            this.buttonFuturesAlerts.TabIndex = 4;
            this.buttonFuturesAlerts.Text = "Futures alerts";
            this.buttonFuturesAlerts.UseVisualStyleBackColor = true;
            this.buttonFuturesAlerts.Click += new System.EventHandler(this.buttonFuturesScreener_Click);
            // 
            // buttonInsiderTradesAlert
            // 
            this.buttonInsiderTradesAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsiderTradesAlert.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonInsiderTradesAlert.Location = new System.Drawing.Point(254, 113);
            this.buttonInsiderTradesAlert.Name = "buttonInsiderTradesAlert";
            this.buttonInsiderTradesAlert.Size = new System.Drawing.Size(168, 45);
            this.buttonInsiderTradesAlert.TabIndex = 5;
            this.buttonInsiderTradesAlert.Text = "Insider trades alerts";
            this.buttonInsiderTradesAlert.UseVisualStyleBackColor = true;
            this.buttonInsiderTradesAlert.Click += new System.EventHandler(this.buttonInsiderTradesAlert_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 212);
            this.Controls.Add(this.buttonInsiderTradesAlert);
            this.Controls.Add(this.buttonFuturesAlerts);
            this.Controls.Add(this.labelDaysLeft);
            this.Controls.Add(this.buttonFinviz);
            this.Controls.Add(this.buttonFlowsScreener);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Insiders tracker: home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonFlowsScreener;
        public System.Windows.Forms.Button buttonFinviz;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.Label labelDaysLeft;
        public System.Windows.Forms.Button buttonFuturesAlerts;
        public System.Windows.Forms.Button buttonInsiderTradesAlert;
    }
}