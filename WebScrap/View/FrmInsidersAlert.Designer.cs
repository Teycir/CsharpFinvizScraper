namespace WebScrap.View
{
    partial class FrmInsidersAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsidersAlert));
            this.buttonBrowser = new System.Windows.Forms.Button();
            this.listBoxTickers = new System.Windows.Forms.ListBox();
            this.buttonSaveTickers = new System.Windows.Forms.Button();
            this.buttonInsiderTrades = new System.Windows.Forms.Button();
            this.listBoxInsiderTrades = new System.Windows.Forms.ListBox();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.checkBoxEmail = new System.Windows.Forms.CheckBox();
            this.buttonClearAlerts = new System.Windows.Forms.Button();
            this.buttonDesactivate = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatus1 = new System.Windows.Forms.Label();
            this.checkBoxOpenUrl = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxTransactionValue = new System.Windows.Forms.ComboBox();
            this.checkBoxAlertAll = new System.Windows.Forms.CheckBox();
            this.checkBoxTwitterAlert = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpenInsider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowser
            // 
            this.buttonBrowser.Location = new System.Drawing.Point(14, 29);
            this.buttonBrowser.Name = "buttonBrowser";
            this.buttonBrowser.Size = new System.Drawing.Size(121, 23);
            this.buttonBrowser.TabIndex = 0;
            this.buttonBrowser.Text = "Browse to get tickers";
            this.toolTip1.SetToolTip(this.buttonBrowser, "Import tickers from a .TXT file");
            this.buttonBrowser.UseVisualStyleBackColor = true;
            this.buttonBrowser.Click += new System.EventHandler(this.buttonBrowser_Click);
            // 
            // listBoxTickers
            // 
            this.listBoxTickers.FormattingEnabled = true;
            this.listBoxTickers.Location = new System.Drawing.Point(15, 66);
            this.listBoxTickers.Name = "listBoxTickers";
            this.listBoxTickers.Size = new System.Drawing.Size(120, 563);
            this.listBoxTickers.TabIndex = 1;
            // 
            // buttonSaveTickers
            // 
            this.buttonSaveTickers.Location = new System.Drawing.Point(15, 645);
            this.buttonSaveTickers.Name = "buttonSaveTickers";
            this.buttonSaveTickers.Size = new System.Drawing.Size(120, 23);
            this.buttonSaveTickers.TabIndex = 2;
            this.buttonSaveTickers.Text = "Save tickers";
            this.toolTip1.SetToolTip(this.buttonSaveTickers, "Save the tickers imported for further use");
            this.buttonSaveTickers.UseVisualStyleBackColor = true;
            this.buttonSaveTickers.Click += new System.EventHandler(this.buttonSaveTickers_Click);
            // 
            // buttonInsiderTrades
            // 
            this.buttonInsiderTrades.Location = new System.Drawing.Point(154, 29);
            this.buttonInsiderTrades.Name = "buttonInsiderTrades";
            this.buttonInsiderTrades.Size = new System.Drawing.Size(166, 23);
            this.buttonInsiderTrades.TabIndex = 3;
            this.buttonInsiderTrades.Text = "Activate Insiders alerts";
            this.buttonInsiderTrades.UseVisualStyleBackColor = true;
            this.buttonInsiderTrades.Click += new System.EventHandler(this.buttonInsiderTrades_Click);
            // 
            // listBoxInsiderTrades
            // 
            this.listBoxInsiderTrades.FormattingEnabled = true;
            this.listBoxInsiderTrades.Location = new System.Drawing.Point(154, 141);
            this.listBoxInsiderTrades.Name = "listBoxInsiderTrades";
            this.listBoxInsiderTrades.Size = new System.Drawing.Size(390, 485);
            this.listBoxInsiderTrades.TabIndex = 4;
            // 
            // checkBoxSound
            // 
            this.checkBoxSound.AutoSize = true;
            this.checkBoxSound.Location = new System.Drawing.Point(154, 105);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(80, 17);
            this.checkBoxSound.TabIndex = 5;
            this.checkBoxSound.Text = "Sound alert";
            this.toolTip1.SetToolTip(this.checkBoxSound, "Check if you want sound alert");
            this.checkBoxSound.UseVisualStyleBackColor = true;
            this.checkBoxSound.CheckedChanged += new System.EventHandler(this.checkBoxSound_CheckedChanged);
            // 
            // checkBoxEmail
            // 
            this.checkBoxEmail.AutoSize = true;
            this.checkBoxEmail.Location = new System.Drawing.Point(259, 105);
            this.checkBoxEmail.Name = "checkBoxEmail";
            this.checkBoxEmail.Size = new System.Drawing.Size(74, 17);
            this.checkBoxEmail.TabIndex = 6;
            this.checkBoxEmail.Text = "Email alert";
            this.toolTip1.SetToolTip(this.checkBoxEmail, "check if you want to receive an email alert");
            this.checkBoxEmail.UseVisualStyleBackColor = true;
            this.checkBoxEmail.CheckedChanged += new System.EventHandler(this.checkBoxEmail_CheckedChanged);
            this.checkBoxEmail.Click += new System.EventHandler(this.checkBoxEmail_Click);
            // 
            // buttonClearAlerts
            // 
            this.buttonClearAlerts.Location = new System.Drawing.Point(381, 645);
            this.buttonClearAlerts.Name = "buttonClearAlerts";
            this.buttonClearAlerts.Size = new System.Drawing.Size(163, 23);
            this.buttonClearAlerts.TabIndex = 7;
            this.buttonClearAlerts.Text = "Clear Listbox Alerts";
            this.buttonClearAlerts.UseVisualStyleBackColor = true;
            this.buttonClearAlerts.Click += new System.EventHandler(this.buttonClearAlerts_Click);
            // 
            // buttonDesactivate
            // 
            this.buttonDesactivate.Location = new System.Drawing.Point(375, 29);
            this.buttonDesactivate.Name = "buttonDesactivate";
            this.buttonDesactivate.Size = new System.Drawing.Size(166, 23);
            this.buttonDesactivate.TabIndex = 8;
            this.buttonDesactivate.Text = "Desactivate insider alerts";
            this.buttonDesactivate.UseVisualStyleBackColor = true;
            this.buttonDesactivate.Click += new System.EventHandler(this.buttonDesactivate_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(289, 74);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(43, 13);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Status: ";
            // 
            // labelStatus1
            // 
            this.labelStatus1.AutoSize = true;
            this.labelStatus1.ForeColor = System.Drawing.Color.Red;
            this.labelStatus1.Location = new System.Drawing.Point(358, 74);
            this.labelStatus1.Name = "labelStatus1";
            this.labelStatus1.Size = new System.Drawing.Size(45, 13);
            this.labelStatus1.TabIndex = 11;
            this.labelStatus1.Text = "Inactive";
            // 
            // checkBoxOpenUrl
            // 
            this.checkBoxOpenUrl.AutoSize = true;
            this.checkBoxOpenUrl.Location = new System.Drawing.Point(464, 105);
            this.checkBoxOpenUrl.Name = "checkBoxOpenUrl";
            this.checkBoxOpenUrl.Size = new System.Drawing.Size(77, 17);
            this.checkBoxOpenUrl.TabIndex = 12;
            this.checkBoxOpenUrl.Text = "Open URL";
            this.toolTip1.SetToolTip(this.checkBoxOpenUrl, "Check if you want to open openinsider\'s webpage with the ticker alerted on");
            this.checkBoxOpenUrl.UseVisualStyleBackColor = true;
            this.checkBoxOpenUrl.CheckedChanged += new System.EventHandler(this.checkBoxOpenUrl_CheckedChanged);
            // 
            // comboBoxTransactionValue
            // 
            this.comboBoxTransactionValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransactionValue.FormattingEnabled = true;
            this.comboBoxTransactionValue.Items.AddRange(new object[] {
            "",
            "10000",
            "25000",
            "50000",
            "100000",
            "200000",
            "300000",
            "500000",
            "1000000",
            "5000000"});
            this.comboBoxTransactionValue.Location = new System.Drawing.Point(381, 683);
            this.comboBoxTransactionValue.Name = "comboBoxTransactionValue";
            this.comboBoxTransactionValue.Size = new System.Drawing.Size(163, 21);
            this.comboBoxTransactionValue.TabIndex = 13;
            this.toolTip1.SetToolTip(this.comboBoxTransactionValue, "Scroll and choose $ value");
            this.comboBoxTransactionValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransactionValue_SelectedIndexChanged);
            // 
            // checkBoxAlertAll
            // 
            this.checkBoxAlertAll.AutoSize = true;
            this.checkBoxAlertAll.Checked = true;
            this.checkBoxAlertAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlertAll.Location = new System.Drawing.Point(154, 70);
            this.checkBoxAlertAll.Name = "checkBoxAlertAll";
            this.checkBoxAlertAll.Size = new System.Drawing.Size(109, 17);
            this.checkBoxAlertAll.TabIndex = 16;
            this.checkBoxAlertAll.Text = "Alert on all tickers";
            this.toolTip1.SetToolTip(this.checkBoxAlertAll, "Check if you want to be alerted on all new insider purchases/sales");
            this.checkBoxAlertAll.UseVisualStyleBackColor = true;
            this.checkBoxAlertAll.CheckedChanged += new System.EventHandler(this.checkBoxAlertAll_CheckedChanged);
            // 
            // checkBoxTwitterAlert
            // 
            this.checkBoxTwitterAlert.AutoSize = true;
            this.checkBoxTwitterAlert.Location = new System.Drawing.Point(358, 105);
            this.checkBoxTwitterAlert.Name = "checkBoxTwitterAlert";
            this.checkBoxTwitterAlert.Size = new System.Drawing.Size(81, 17);
            this.checkBoxTwitterAlert.TabIndex = 17;
            this.checkBoxTwitterAlert.Text = "Twitter alert";
            this.toolTip1.SetToolTip(this.checkBoxTwitterAlert, "check if you want to receive an email alert");
            this.checkBoxTwitterAlert.UseVisualStyleBackColor = true;
            this.checkBoxTwitterAlert.CheckedChanged += new System.EventHandler(this.checkBoxTwitterAlert_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 686);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Minimum transaction $ value";
            // 
            // buttonOpenInsider
            // 
            this.buttonOpenInsider.Location = new System.Drawing.Point(154, 645);
            this.buttonOpenInsider.Name = "buttonOpenInsider";
            this.buttonOpenInsider.Size = new System.Drawing.Size(163, 23);
            this.buttonOpenInsider.TabIndex = 18;
            this.buttonOpenInsider.Text = "Go to open insider";
            this.buttonOpenInsider.UseVisualStyleBackColor = true;
            this.buttonOpenInsider.Click += new System.EventHandler(this.buttonOpenInsider_Click);
            // 
            // FrmInsidersAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 722);
            this.Controls.Add(this.buttonOpenInsider);
            this.Controls.Add(this.checkBoxTwitterAlert);
            this.Controls.Add(this.checkBoxAlertAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTransactionValue);
            this.Controls.Add(this.checkBoxOpenUrl);
            this.Controls.Add(this.labelStatus1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDesactivate);
            this.Controls.Add(this.buttonClearAlerts);
            this.Controls.Add(this.checkBoxEmail);
            this.Controls.Add(this.checkBoxSound);
            this.Controls.Add(this.listBoxInsiderTrades);
            this.Controls.Add(this.buttonInsiderTrades);
            this.Controls.Add(this.buttonSaveTickers);
            this.Controls.Add(this.listBoxTickers);
            this.Controls.Add(this.buttonBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInsidersAlert";
            this.Text = "Insiders tracker: insiders trades alert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInsidersAlertMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowser;
        private System.Windows.Forms.ListBox listBoxTickers;
        private System.Windows.Forms.Button buttonSaveTickers;
        private System.Windows.Forms.Button buttonInsiderTrades;
        private System.Windows.Forms.ListBox listBoxInsiderTrades;
        private System.Windows.Forms.CheckBox checkBoxSound;
        private System.Windows.Forms.CheckBox checkBoxEmail;
        private System.Windows.Forms.Button buttonClearAlerts;
        private System.Windows.Forms.Button buttonDesactivate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatus1;
        private System.Windows.Forms.CheckBox checkBoxOpenUrl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxTransactionValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAlertAll;
        private System.Windows.Forms.CheckBox checkBoxTwitterAlert;
        private System.Windows.Forms.Button buttonOpenInsider;
    }
}

