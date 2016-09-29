namespace WebScrap.View
{
    partial class FrmInsiderScreener
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsiderScreener));
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonStopUpdate = new System.Windows.Forms.Button();
            this.buttonDeleteData = new System.Windows.Forms.Button();
            this.labelUpdateStatus = new System.Windows.Forms.Label();
            this.labelUpdateStatusContent = new System.Windows.Forms.Label();
            this.groupBoxOversold = new System.Windows.Forms.GroupBox();
            this.textBoxResultOS = new System.Windows.Forms.TextBox();
            this.buttonIPurchPriceOS = new System.Windows.Forms.Button();
            this.buttonTppOs = new System.Windows.Forms.Button();
            this.groupBoxOverBought = new System.Windows.Forms.GroupBox();
            this.textBoxResultOB = new System.Windows.Forms.TextBox();
            this.IPurchasePriceOB = new System.Windows.Forms.Button();
            this.buttonTppOb = new System.Windows.Forms.Button();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.labelLastInsSaleVal = new System.Windows.Forms.Label();
            this.comboBoxLasInsidSaleVal = new System.Windows.Forms.ComboBox();
            this.lblNumRDInsPurchases = new System.Windows.Forms.Label();
            this.comboBoxNumRDInsPurchases = new System.Windows.Forms.ComboBox();
            this.lblNumRDInsSales = new System.Windows.Forms.Label();
            this.comboBoxNumRDInsSales = new System.Windows.Forms.ComboBox();
            this.lblNumRInsPurchases = new System.Windows.Forms.Label();
            this.comboBoxNumRInsPurchases = new System.Windows.Forms.ComboBox();
            this.labelNumRSales = new System.Windows.Forms.Label();
            this.comboBoxNumRInsSales = new System.Windows.Forms.ComboBox();
            this.lblOwnerSale = new System.Windows.Forms.Label();
            this.comboBoxOwnerSale = new System.Windows.Forms.ComboBox();
            this.lblOwnerPurchase = new System.Windows.Forms.Label();
            this.comboBoxOwnerPurchase = new System.Windows.Forms.ComboBox();
            this.buttonSaveDataScreener = new System.Windows.Forms.Button();
            this.labelVolume = new System.Windows.Forms.Label();
            this.comboBoxVolume = new System.Windows.Forms.ComboBox();
            this.labelLastInsPurVal = new System.Windows.Forms.Label();
            this.comboBoxLasInsidPurVal = new System.Windows.Forms.ComboBox();
            this.labelDividend = new System.Windows.Forms.Label();
            this.comboBoxDividend = new System.Windows.Forms.ComboBox();
            this.labelInsiOwn = new System.Windows.Forms.Label();
            this.comboBoxInsiOwn = new System.Windows.Forms.ComboBox();
            this.labelInstitOwn = new System.Windows.Forms.Label();
            this.comboBoxInstOwn = new System.Windows.Forms.ComboBox();
            this.labelDebEq = new System.Windows.Forms.Label();
            this.comboBoxDebtEq = new System.Windows.Forms.ComboBox();
            this.labelCashSh = new System.Windows.Forms.Label();
            this.comboBoxCash = new System.Windows.Forms.ComboBox();
            this.PtoB = new System.Windows.Forms.Label();
            this.comboBoxPB = new System.Windows.Forms.ComboBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.comboBoxPrice = new System.Windows.Forms.ComboBox();
            this.labelAnalyReco = new System.Windows.Forms.Label();
            this.comboBoxAnaReco = new System.Windows.Forms.ComboBox();
            this.labelOptionable = new System.Windows.Forms.Label();
            this.comboBoxOptionable = new System.Windows.Forms.ComboBox();
            this.label52wl = new System.Windows.Forms.Label();
            this.comboBox52wl = new System.Windows.Forms.ComboBox();
            this.label52wh = new System.Windows.Forms.Label();
            this.comboBox52wh = new System.Windows.Forms.ComboBox();
            this.labelSector = new System.Windows.Forms.Label();
            this.comboBoxSector = new System.Windows.Forms.ComboBox();
            this.labelIndustry = new System.Windows.Forms.Label();
            this.comboBoxIndustry = new System.Windows.Forms.ComboBox();
            this.labelRSI14 = new System.Windows.Forms.Label();
            this.comboBoxRSI = new System.Windows.Forms.ComboBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.buttonReinit = new System.Windows.Forms.Button();
            this.checkBoxOpenUrl = new System.Windows.Forms.CheckBox();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.buttonGetRatios = new System.Windows.Forms.Button();
            this.labelCurDate = new System.Windows.Forms.Label();
            this.labelCurDateTxt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTicker = new System.Windows.Forms.Label();
            this.textBoxRatios = new System.Windows.Forms.TextBox();
            this.textBoxTicker = new System.Windows.Forms.TextBox();
            this.buttonTransactionsIndustSector = new System.Windows.Forms.Button();
            this.btnTopTransactions = new System.Windows.Forms.Button();
            this.groupBoxOversold.SuspendLayout();
            this.groupBoxOverBought.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(114, 15);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update data";
            this.toolTipInfo.SetToolTip(this.buttonUpdate, "Update Database from finviz");
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonStopUpdate
            // 
            this.buttonStopUpdate.Enabled = false;
            this.buttonStopUpdate.Location = new System.Drawing.Point(205, 14);
            this.buttonStopUpdate.Name = "buttonStopUpdate";
            this.buttonStopUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonStopUpdate.TabIndex = 1;
            this.buttonStopUpdate.Text = "Stop Update";
            this.toolTipInfo.SetToolTip(this.buttonStopUpdate, "ancel update process");
            this.buttonStopUpdate.UseVisualStyleBackColor = true;
            this.buttonStopUpdate.Click += new System.EventHandler(this.buttonStopUpdate_Click);
            // 
            // buttonDeleteData
            // 
            this.buttonDeleteData.Location = new System.Drawing.Point(12, 15);
            this.buttonDeleteData.Name = "buttonDeleteData";
            this.buttonDeleteData.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteData.TabIndex = 3;
            this.buttonDeleteData.Text = "Delete data";
            this.toolTipInfo.SetToolTip(this.buttonDeleteData, "Clear database");
            this.buttonDeleteData.UseVisualStyleBackColor = true;
            this.buttonDeleteData.Click += new System.EventHandler(this.buttonDeleteData_Click);
            // 
            // labelUpdateStatus
            // 
            this.labelUpdateStatus.AutoSize = true;
            this.labelUpdateStatus.Location = new System.Drawing.Point(296, 19);
            this.labelUpdateStatus.Name = "labelUpdateStatus";
            this.labelUpdateStatus.Size = new System.Drawing.Size(67, 13);
            this.labelUpdateStatus.TabIndex = 4;
            this.labelUpdateStatus.Text = "Data status :";
            // 
            // labelUpdateStatusContent
            // 
            this.labelUpdateStatusContent.AutoSize = true;
            this.labelUpdateStatusContent.ForeColor = System.Drawing.Color.Red;
            this.labelUpdateStatusContent.Location = new System.Drawing.Point(369, 19);
            this.labelUpdateStatusContent.Name = "labelUpdateStatusContent";
            this.labelUpdateStatusContent.Size = new System.Drawing.Size(0, 13);
            this.labelUpdateStatusContent.TabIndex = 5;
            // 
            // groupBoxOversold
            // 
            this.groupBoxOversold.Controls.Add(this.textBoxResultOS);
            this.groupBoxOversold.Controls.Add(this.buttonIPurchPriceOS);
            this.groupBoxOversold.Controls.Add(this.buttonTppOs);
            this.groupBoxOversold.Location = new System.Drawing.Point(12, 42);
            this.groupBoxOversold.Name = "groupBoxOversold";
            this.groupBoxOversold.Size = new System.Drawing.Size(184, 628);
            this.groupBoxOversold.TabIndex = 7;
            this.groupBoxOversold.TabStop = false;
            this.groupBoxOversold.Text = "Bullish ratios";
            // 
            // textBoxResultOS
            // 
            this.textBoxResultOS.Location = new System.Drawing.Point(7, 57);
            this.textBoxResultOS.Multiline = true;
            this.textBoxResultOS.Name = "textBoxResultOS";
            this.textBoxResultOS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResultOS.Size = new System.Drawing.Size(172, 564);
            this.textBoxResultOS.TabIndex = 2;
            // 
            // buttonIPurchPriceOS
            // 
            this.buttonIPurchPriceOS.Location = new System.Drawing.Point(103, 19);
            this.buttonIPurchPriceOS.Name = "buttonIPurchPriceOS";
            this.buttonIPurchPriceOS.Size = new System.Drawing.Size(75, 23);
            this.buttonIPurchPriceOS.TabIndex = 1;
            this.buttonIPurchPriceOS.Text = "InsidPur/P";
            this.toolTipInfo.SetToolTip(this.buttonIPurchPriceOS, "(Last insider Purchase less than 1 year ago / current Price), Oversold");
            this.buttonIPurchPriceOS.UseVisualStyleBackColor = true;
            this.buttonIPurchPriceOS.Click += new System.EventHandler(this.buttonIPurchPriceOS_Click);
            // 
            // buttonTppOs
            // 
            this.buttonTppOs.Location = new System.Drawing.Point(8, 19);
            this.buttonTppOs.Name = "buttonTppOs";
            this.buttonTppOs.Size = new System.Drawing.Size(75, 23);
            this.buttonTppOs.TabIndex = 0;
            this.buttonTppOs.Text = "TP/P";
            this.toolTipInfo.SetToolTip(this.buttonTppOs, "(Average Analyst Target Price / Current Price), Oversold");
            this.buttonTppOs.UseVisualStyleBackColor = true;
            this.buttonTppOs.Click += new System.EventHandler(this.buttonTppOs_Click);
            // 
            // groupBoxOverBought
            // 
            this.groupBoxOverBought.Controls.Add(this.textBoxResultOB);
            this.groupBoxOverBought.Controls.Add(this.IPurchasePriceOB);
            this.groupBoxOverBought.Controls.Add(this.buttonTppOb);
            this.groupBoxOverBought.Location = new System.Drawing.Point(251, 41);
            this.groupBoxOverBought.Name = "groupBoxOverBought";
            this.groupBoxOverBought.Size = new System.Drawing.Size(184, 629);
            this.groupBoxOverBought.TabIndex = 8;
            this.groupBoxOverBought.TabStop = false;
            this.groupBoxOverBought.Text = "Bearish ratios";
            // 
            // textBoxResultOB
            // 
            this.textBoxResultOB.Location = new System.Drawing.Point(4, 57);
            this.textBoxResultOB.Multiline = true;
            this.textBoxResultOB.Name = "textBoxResultOB";
            this.textBoxResultOB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResultOB.Size = new System.Drawing.Size(172, 565);
            this.textBoxResultOB.TabIndex = 3;
            // 
            // IPurchasePriceOB
            // 
            this.IPurchasePriceOB.Location = new System.Drawing.Point(103, 19);
            this.IPurchasePriceOB.Name = "IPurchasePriceOB";
            this.IPurchasePriceOB.Size = new System.Drawing.Size(75, 23);
            this.IPurchasePriceOB.TabIndex = 2;
            this.IPurchasePriceOB.Text = "IinsidPur/P";
            this.toolTipInfo.SetToolTip(this.IPurchasePriceOB, "(Last insider Purchase less than 1 year ago / Current Price), Overbought");
            this.IPurchasePriceOB.UseVisualStyleBackColor = true;
            this.IPurchasePriceOB.Click += new System.EventHandler(this.IPurchasePriceOB_Click);
            // 
            // buttonTppOb
            // 
            this.buttonTppOb.Location = new System.Drawing.Point(8, 19);
            this.buttonTppOb.Name = "buttonTppOb";
            this.buttonTppOb.Size = new System.Drawing.Size(75, 23);
            this.buttonTppOb.TabIndex = 0;
            this.buttonTppOb.Text = "TP/P";
            this.toolTipInfo.SetToolTip(this.buttonTppOb, "(Average Analyst Target Price / current Price), Overbought");
            this.buttonTppOb.UseVisualStyleBackColor = true;
            this.buttonTppOb.Click += new System.EventHandler(this.buttonTppOb_Click);
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.labelLastInsSaleVal);
            this.groupBoxFilters.Controls.Add(this.comboBoxLasInsidSaleVal);
            this.groupBoxFilters.Controls.Add(this.lblNumRDInsPurchases);
            this.groupBoxFilters.Controls.Add(this.comboBoxNumRDInsPurchases);
            this.groupBoxFilters.Controls.Add(this.lblNumRDInsSales);
            this.groupBoxFilters.Controls.Add(this.comboBoxNumRDInsSales);
            this.groupBoxFilters.Controls.Add(this.lblNumRInsPurchases);
            this.groupBoxFilters.Controls.Add(this.comboBoxNumRInsPurchases);
            this.groupBoxFilters.Controls.Add(this.labelNumRSales);
            this.groupBoxFilters.Controls.Add(this.comboBoxNumRInsSales);
            this.groupBoxFilters.Controls.Add(this.lblOwnerSale);
            this.groupBoxFilters.Controls.Add(this.comboBoxOwnerSale);
            this.groupBoxFilters.Controls.Add(this.lblOwnerPurchase);
            this.groupBoxFilters.Controls.Add(this.comboBoxOwnerPurchase);
            this.groupBoxFilters.Controls.Add(this.buttonSaveDataScreener);
            this.groupBoxFilters.Controls.Add(this.labelVolume);
            this.groupBoxFilters.Controls.Add(this.comboBoxVolume);
            this.groupBoxFilters.Controls.Add(this.labelLastInsPurVal);
            this.groupBoxFilters.Controls.Add(this.comboBoxLasInsidPurVal);
            this.groupBoxFilters.Controls.Add(this.labelDividend);
            this.groupBoxFilters.Controls.Add(this.comboBoxDividend);
            this.groupBoxFilters.Controls.Add(this.labelInsiOwn);
            this.groupBoxFilters.Controls.Add(this.comboBoxInsiOwn);
            this.groupBoxFilters.Controls.Add(this.labelInstitOwn);
            this.groupBoxFilters.Controls.Add(this.comboBoxInstOwn);
            this.groupBoxFilters.Controls.Add(this.labelDebEq);
            this.groupBoxFilters.Controls.Add(this.comboBoxDebtEq);
            this.groupBoxFilters.Controls.Add(this.labelCashSh);
            this.groupBoxFilters.Controls.Add(this.comboBoxCash);
            this.groupBoxFilters.Controls.Add(this.PtoB);
            this.groupBoxFilters.Controls.Add(this.comboBoxPB);
            this.groupBoxFilters.Controls.Add(this.labelPrice);
            this.groupBoxFilters.Controls.Add(this.comboBoxPrice);
            this.groupBoxFilters.Controls.Add(this.labelAnalyReco);
            this.groupBoxFilters.Controls.Add(this.comboBoxAnaReco);
            this.groupBoxFilters.Controls.Add(this.labelOptionable);
            this.groupBoxFilters.Controls.Add(this.comboBoxOptionable);
            this.groupBoxFilters.Controls.Add(this.label52wl);
            this.groupBoxFilters.Controls.Add(this.comboBox52wl);
            this.groupBoxFilters.Controls.Add(this.label52wh);
            this.groupBoxFilters.Controls.Add(this.comboBox52wh);
            this.groupBoxFilters.Controls.Add(this.labelSector);
            this.groupBoxFilters.Controls.Add(this.comboBoxSector);
            this.groupBoxFilters.Controls.Add(this.labelIndustry);
            this.groupBoxFilters.Controls.Add(this.comboBoxIndustry);
            this.groupBoxFilters.Controls.Add(this.labelRSI14);
            this.groupBoxFilters.Controls.Add(this.comboBoxRSI);
            this.groupBoxFilters.Controls.Add(this.labelCountry);
            this.groupBoxFilters.Controls.Add(this.comboBoxCountry);
            this.groupBoxFilters.Location = new System.Drawing.Point(441, 41);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(756, 396);
            this.groupBoxFilters.TabIndex = 9;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            this.groupBoxFilters.Enter += new System.EventHandler(this.groupBoxFilters_Enter);
            // 
            // labelLastInsSaleVal
            // 
            this.labelLastInsSaleVal.AutoSize = true;
            this.labelLastInsSaleVal.Location = new System.Drawing.Point(2, 288);
            this.labelLastInsSaleVal.Name = "labelLastInsSaleVal";
            this.labelLastInsSaleVal.Size = new System.Drawing.Size(112, 13);
            this.labelLastInsSaleVal.TabIndex = 51;
            this.labelLastInsSaleVal.Text = "LastInsiderSale$Value";
            this.toolTipInfo.SetToolTip(this.labelLastInsSaleVal, "Last Insider Sale Value ");
            // 
            // comboBoxLasInsidSaleVal
            // 
            this.comboBoxLasInsidSaleVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLasInsidSaleVal.FormattingEnabled = true;
            this.comboBoxLasInsidSaleVal.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxLasInsidSaleVal.Location = new System.Drawing.Point(127, 285);
            this.comboBoxLasInsidSaleVal.Name = "comboBoxLasInsidSaleVal";
            this.comboBoxLasInsidSaleVal.Size = new System.Drawing.Size(116, 21);
            this.comboBoxLasInsidSaleVal.TabIndex = 50;
            // 
            // lblNumRDInsPurchases
            // 
            this.lblNumRDInsPurchases.AutoSize = true;
            this.lblNumRDInsPurchases.Location = new System.Drawing.Point(520, 328);
            this.lblNumRDInsPurchases.Name = "lblNumRDInsPurchases";
            this.lblNumRDInsPurchases.Size = new System.Drawing.Size(109, 13);
            this.lblNumRDInsPurchases.TabIndex = 49;
            this.lblNumRDInsPurchases.Text = "NumRDInsPurchases";
            this.toolTipInfo.SetToolTip(this.lblNumRDInsPurchases, "Number of Recent Different Insider Purchases");
            // 
            // comboBoxNumRDInsPurchases
            // 
            this.comboBoxNumRDInsPurchases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumRDInsPurchases.FormattingEnabled = true;
            this.comboBoxNumRDInsPurchases.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxNumRDInsPurchases.Location = new System.Drawing.Point(630, 325);
            this.comboBoxNumRDInsPurchases.Name = "comboBoxNumRDInsPurchases";
            this.comboBoxNumRDInsPurchases.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNumRDInsPurchases.TabIndex = 48;
            // 
            // lblNumRDInsSales
            // 
            this.lblNumRDInsSales.AutoSize = true;
            this.lblNumRDInsSales.Location = new System.Drawing.Point(216, 328);
            this.lblNumRDInsSales.Name = "lblNumRDInsSales";
            this.lblNumRDInsSales.Size = new System.Drawing.Size(176, 13);
            this.lblNumRDInsSales.TabIndex = 47;
            this.lblNumRDInsSales.Text = "NumberRecentDifferentInsiderSales";
            this.toolTipInfo.SetToolTip(this.lblNumRDInsSales, "Number of Recent Different Insider Sales");
            // 
            // comboBoxNumRDInsSales
            // 
            this.comboBoxNumRDInsSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumRDInsSales.FormattingEnabled = true;
            this.comboBoxNumRDInsSales.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxNumRDInsSales.Location = new System.Drawing.Point(398, 324);
            this.comboBoxNumRDInsSales.Name = "comboBoxNumRDInsSales";
            this.comboBoxNumRDInsSales.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNumRDInsSales.TabIndex = 46;
            // 
            // lblNumRInsPurchases
            // 
            this.lblNumRInsPurchases.AutoSize = true;
            this.lblNumRInsPurchases.Location = new System.Drawing.Point(520, 287);
            this.lblNumRInsPurchases.Name = "lblNumRInsPurchases";
            this.lblNumRInsPurchases.Size = new System.Drawing.Size(101, 13);
            this.lblNumRInsPurchases.TabIndex = 45;
            this.lblNumRInsPurchases.Text = "NumRInsPurchases";
            this.toolTipInfo.SetToolTip(this.lblNumRInsPurchases, "Number of Recent Insider Purchases");
            // 
            // comboBoxNumRInsPurchases
            // 
            this.comboBoxNumRInsPurchases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumRInsPurchases.FormattingEnabled = true;
            this.comboBoxNumRInsPurchases.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxNumRInsPurchases.Location = new System.Drawing.Point(630, 285);
            this.comboBoxNumRInsPurchases.Name = "comboBoxNumRInsPurchases";
            this.comboBoxNumRInsPurchases.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNumRInsPurchases.TabIndex = 44;
            // 
            // labelNumRSales
            // 
            this.labelNumRSales.AutoSize = true;
            this.labelNumRSales.Location = new System.Drawing.Point(246, 288);
            this.labelNumRSales.Name = "labelNumRSales";
            this.labelNumRSales.Size = new System.Drawing.Size(136, 13);
            this.labelNumRSales.TabIndex = 43;
            this.labelNumRSales.Text = "NumberRecentInsiderSales";
            this.toolTipInfo.SetToolTip(this.labelNumRSales, "Number of Recent Insider Sales");
            // 
            // comboBoxNumRInsSales
            // 
            this.comboBoxNumRInsSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumRInsSales.FormattingEnabled = true;
            this.comboBoxNumRInsSales.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxNumRInsSales.Location = new System.Drawing.Point(398, 284);
            this.comboBoxNumRInsSales.Name = "comboBoxNumRInsSales";
            this.comboBoxNumRInsSales.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNumRInsSales.TabIndex = 42;
            // 
            // lblOwnerSale
            // 
            this.lblOwnerSale.AutoSize = true;
            this.lblOwnerSale.Location = new System.Drawing.Point(519, 250);
            this.lblOwnerSale.Name = "lblOwnerSale";
            this.lblOwnerSale.Size = new System.Drawing.Size(99, 13);
            this.lblOwnerSale.TabIndex = 39;
            this.lblOwnerSale.Text = "LastInsSalByOwner";
            this.toolTipInfo.SetToolTip(this.lblOwnerSale, "Last Insider Sale By Owner ");
            // 
            // comboBoxOwnerSale
            // 
            this.comboBoxOwnerSale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOwnerSale.FormattingEnabled = true;
            this.comboBoxOwnerSale.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxOwnerSale.Location = new System.Drawing.Point(629, 247);
            this.comboBoxOwnerSale.Name = "comboBoxOwnerSale";
            this.comboBoxOwnerSale.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOwnerSale.TabIndex = 38;
            // 
            // lblOwnerPurchase
            // 
            this.lblOwnerPurchase.AutoSize = true;
            this.lblOwnerPurchase.Location = new System.Drawing.Point(243, 250);
            this.lblOwnerPurchase.Name = "lblOwnerPurchase";
            this.lblOwnerPurchase.Size = new System.Drawing.Size(154, 13);
            this.lblOwnerPurchase.TabIndex = 37;
            this.lblOwnerPurchase.Text = "LastInsiderPurchaseIsByOwner";
            this.toolTipInfo.SetToolTip(this.lblOwnerPurchase, "Last Insider Purchase By Owner");
            // 
            // comboBoxOwnerPurchase
            // 
            this.comboBoxOwnerPurchase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOwnerPurchase.FormattingEnabled = true;
            this.comboBoxOwnerPurchase.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxOwnerPurchase.Location = new System.Drawing.Point(397, 243);
            this.comboBoxOwnerPurchase.Name = "comboBoxOwnerPurchase";
            this.comboBoxOwnerPurchase.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOwnerPurchase.TabIndex = 36;
            // 
            // buttonSaveDataScreener
            // 
            this.buttonSaveDataScreener.Location = new System.Drawing.Point(12, 328);
            this.buttonSaveDataScreener.Name = "buttonSaveDataScreener";
            this.buttonSaveDataScreener.Size = new System.Drawing.Size(132, 42);
            this.buttonSaveDataScreener.TabIndex = 17;
            this.buttonSaveDataScreener.Text = "Save screens";
            this.buttonSaveDataScreener.UseVisualStyleBackColor = true;
            this.buttonSaveDataScreener.Click += new System.EventHandler(this.buttonSaveDataScreener_Click);
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(7, 206);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(42, 13);
            this.labelVolume.TabIndex = 33;
            this.labelVolume.Text = "Volume";
            this.toolTipInfo.SetToolTip(this.labelVolume, "Institutional Ownership");
            // 
            // comboBoxVolume
            // 
            this.comboBoxVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVolume.FormattingEnabled = true;
            this.comboBoxVolume.Items.AddRange(new object[] {
            "",
            "<20000",
            ">20000",
            ">50000",
            ">100000",
            ">200000",
            ">500000",
            ">1000000",
            ">5000000",
            ">50000000"});
            this.comboBoxVolume.Location = new System.Drawing.Point(56, 203);
            this.comboBoxVolume.Name = "comboBoxVolume";
            this.comboBoxVolume.Size = new System.Drawing.Size(230, 21);
            this.comboBoxVolume.TabIndex = 32;
            // 
            // labelLastInsPurVal
            // 
            this.labelLastInsPurVal.AutoSize = true;
            this.labelLastInsPurVal.Location = new System.Drawing.Point(2, 251);
            this.labelLastInsPurVal.Name = "labelLastInsPurVal";
            this.labelLastInsPurVal.Size = new System.Drawing.Size(119, 13);
            this.labelLastInsPurVal.TabIndex = 31;
            this.labelLastInsPurVal.Text = "LastInsPurchase$Value";
            this.toolTipInfo.SetToolTip(this.labelLastInsPurVal, "Last Insider Purchase Value ");
            // 
            // comboBoxLasInsidPurVal
            // 
            this.comboBoxLasInsidPurVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLasInsidPurVal.FormattingEnabled = true;
            this.comboBoxLasInsidPurVal.Items.AddRange(new object[] {
            "",
            ">25000",
            ">50000",
            ">100000",
            ">200000",
            ">400000",
            ">1000000"});
            this.comboBoxLasInsidPurVal.Location = new System.Drawing.Point(127, 247);
            this.comboBoxLasInsidPurVal.Name = "comboBoxLasInsidPurVal";
            this.comboBoxLasInsidPurVal.Size = new System.Drawing.Size(116, 21);
            this.comboBoxLasInsidPurVal.TabIndex = 30;
            // 
            // labelDividend
            // 
            this.labelDividend.AutoSize = true;
            this.labelDividend.Location = new System.Drawing.Point(565, 169);
            this.labelDividend.Name = "labelDividend";
            this.labelDividend.Size = new System.Drawing.Size(49, 13);
            this.labelDividend.TabIndex = 29;
            this.labelDividend.Text = "Dividend";
            // 
            // comboBoxDividend
            // 
            this.comboBoxDividend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDividend.FormattingEnabled = true;
            this.comboBoxDividend.Items.AddRange(new object[] {
            "",
            "<5",
            ">5",
            "<10",
            ">10",
            "<15",
            ">15"});
            this.comboBoxDividend.Location = new System.Drawing.Point(629, 166);
            this.comboBoxDividend.Name = "comboBoxDividend";
            this.comboBoxDividend.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDividend.TabIndex = 28;
            // 
            // labelInsiOwn
            // 
            this.labelInsiOwn.AutoSize = true;
            this.labelInsiOwn.Location = new System.Drawing.Point(348, 169);
            this.labelInsiOwn.Name = "labelInsiOwn";
            this.labelInsiOwn.Size = new System.Drawing.Size(45, 13);
            this.labelInsiOwn.TabIndex = 27;
            this.labelInsiOwn.Text = "InsiOwn";
            this.toolTipInfo.SetToolTip(this.labelInsiOwn, "Insider Ownership");
            // 
            // comboBoxInsiOwn
            // 
            this.comboBoxInsiOwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInsiOwn.FormattingEnabled = true;
            this.comboBoxInsiOwn.Items.AddRange(new object[] {
            "",
            "<5",
            ">5",
            "<10",
            ">10",
            "<30",
            ">30",
            "<50",
            ">50"});
            this.comboBoxInsiOwn.Location = new System.Drawing.Point(397, 166);
            this.comboBoxInsiOwn.Name = "comboBoxInsiOwn";
            this.comboBoxInsiOwn.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInsiOwn.TabIndex = 26;
            // 
            // labelInstitOwn
            // 
            this.labelInstitOwn.AutoSize = true;
            this.labelInstitOwn.Location = new System.Drawing.Point(7, 169);
            this.labelInstitOwn.Name = "labelInstitOwn";
            this.labelInstitOwn.Size = new System.Drawing.Size(46, 13);
            this.labelInstitOwn.TabIndex = 25;
            this.labelInstitOwn.Text = "InstOwn";
            this.toolTipInfo.SetToolTip(this.labelInstitOwn, "Institutional Ownership");
            // 
            // comboBoxInstOwn
            // 
            this.comboBoxInstOwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstOwn.FormattingEnabled = true;
            this.comboBoxInstOwn.Items.AddRange(new object[] {
            "",
            "<5",
            ">5",
            "<10",
            ">10",
            "<30",
            ">30",
            "<50",
            ">50"});
            this.comboBoxInstOwn.Location = new System.Drawing.Point(56, 166);
            this.comboBoxInstOwn.Name = "comboBoxInstOwn";
            this.comboBoxInstOwn.Size = new System.Drawing.Size(230, 21);
            this.comboBoxInstOwn.TabIndex = 24;
            // 
            // labelDebEq
            // 
            this.labelDebEq.AutoSize = true;
            this.labelDebEq.Location = new System.Drawing.Point(565, 132);
            this.labelDebEq.Name = "labelDebEq";
            this.labelDebEq.Size = new System.Drawing.Size(48, 13);
            this.labelDebEq.TabIndex = 23;
            this.labelDebEq.Text = "Debt/Eq";
            this.toolTipInfo.SetToolTip(this.labelDebEq, "Dept/Equity");
            // 
            // comboBoxDebtEq
            // 
            this.comboBoxDebtEq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDebtEq.FormattingEnabled = true;
            this.comboBoxDebtEq.Items.AddRange(new object[] {
            "",
            "<0.5",
            ">0.5",
            "<2",
            ">2",
            "<5",
            ">5"});
            this.comboBoxDebtEq.Location = new System.Drawing.Point(629, 129);
            this.comboBoxDebtEq.Name = "comboBoxDebtEq";
            this.comboBoxDebtEq.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDebtEq.TabIndex = 22;
            // 
            // labelCashSh
            // 
            this.labelCashSh.AutoSize = true;
            this.labelCashSh.Location = new System.Drawing.Point(348, 132);
            this.labelCashSh.Name = "labelCashSh";
            this.labelCashSh.Size = new System.Drawing.Size(44, 13);
            this.labelCashSh.TabIndex = 21;
            this.labelCashSh.Text = "CashSh";
            this.toolTipInfo.SetToolTip(this.labelCashSh, "Cash Per Share");
            // 
            // comboBoxCash
            // 
            this.comboBoxCash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCash.FormattingEnabled = true;
            this.comboBoxCash.Items.AddRange(new object[] {
            "",
            "<0.5",
            ">0.5",
            "<2",
            ">2",
            "<5",
            ">5"});
            this.comboBoxCash.Location = new System.Drawing.Point(397, 129);
            this.comboBoxCash.Name = "comboBoxCash";
            this.comboBoxCash.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCash.TabIndex = 20;
            // 
            // PtoB
            // 
            this.PtoB.AutoSize = true;
            this.PtoB.Location = new System.Drawing.Point(7, 132);
            this.PtoB.Name = "PtoB";
            this.PtoB.Size = new System.Drawing.Size(30, 13);
            this.PtoB.TabIndex = 19;
            this.PtoB.Text = "PtoB";
            this.toolTipInfo.SetToolTip(this.PtoB, "Price to Book");
            // 
            // comboBoxPB
            // 
            this.comboBoxPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPB.FormattingEnabled = true;
            this.comboBoxPB.Items.AddRange(new object[] {
            "",
            "<0.5",
            ">0.5",
            "<2",
            ">2",
            "<5",
            ">5"});
            this.comboBoxPB.Location = new System.Drawing.Point(56, 129);
            this.comboBoxPB.Name = "comboBoxPB";
            this.comboBoxPB.Size = new System.Drawing.Size(230, 21);
            this.comboBoxPB.TabIndex = 18;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(565, 96);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 17;
            this.labelPrice.Text = "Price";
            // 
            // comboBoxPrice
            // 
            this.comboBoxPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrice.FormattingEnabled = true;
            this.comboBoxPrice.Location = new System.Drawing.Point(629, 93);
            this.comboBoxPrice.Name = "comboBoxPrice";
            this.comboBoxPrice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPrice.TabIndex = 16;
            // 
            // labelAnalyReco
            // 
            this.labelAnalyReco.AutoSize = true;
            this.labelAnalyReco.Location = new System.Drawing.Point(565, 60);
            this.labelAnalyReco.Name = "labelAnalyReco";
            this.labelAnalyReco.Size = new System.Drawing.Size(61, 13);
            this.labelAnalyReco.TabIndex = 15;
            this.labelAnalyReco.Text = "Ana. Reco.";
            this.toolTipInfo.SetToolTip(this.labelAnalyReco, "Analyst Recommendation");
            // 
            // comboBoxAnaReco
            // 
            this.comboBoxAnaReco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnaReco.FormattingEnabled = true;
            this.comboBoxAnaReco.Location = new System.Drawing.Point(629, 57);
            this.comboBoxAnaReco.Name = "comboBoxAnaReco";
            this.comboBoxAnaReco.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAnaReco.TabIndex = 14;
            // 
            // labelOptionable
            // 
            this.labelOptionable.AutoSize = true;
            this.labelOptionable.Location = new System.Drawing.Point(565, 24);
            this.labelOptionable.Name = "labelOptionable";
            this.labelOptionable.Size = new System.Drawing.Size(58, 13);
            this.labelOptionable.TabIndex = 13;
            this.labelOptionable.Text = "Optionable";
            // 
            // comboBoxOptionable
            // 
            this.comboBoxOptionable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptionable.FormattingEnabled = true;
            this.comboBoxOptionable.Location = new System.Drawing.Point(629, 19);
            this.comboBoxOptionable.Name = "comboBoxOptionable";
            this.comboBoxOptionable.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOptionable.TabIndex = 12;
            // 
            // label52wl
            // 
            this.label52wl.AutoSize = true;
            this.label52wl.Location = new System.Drawing.Point(349, 63);
            this.label52wl.Name = "label52wl";
            this.label52wl.Size = new System.Drawing.Size(29, 13);
            this.label52wl.TabIndex = 11;
            this.label52wl.Text = "52wl";
            // 
            // comboBox52wl
            // 
            this.comboBox52wl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox52wl.FormattingEnabled = true;
            this.comboBox52wl.Location = new System.Drawing.Point(397, 60);
            this.comboBox52wl.Name = "comboBox52wl";
            this.comboBox52wl.Size = new System.Drawing.Size(121, 21);
            this.comboBox52wl.TabIndex = 10;
            // 
            // label52wh
            // 
            this.label52wh.AutoSize = true;
            this.label52wh.Location = new System.Drawing.Point(349, 96);
            this.label52wh.Name = "label52wh";
            this.label52wh.Size = new System.Drawing.Size(33, 13);
            this.label52wh.TabIndex = 9;
            this.label52wh.Text = "52wh";
            // 
            // comboBox52wh
            // 
            this.comboBox52wh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox52wh.FormattingEnabled = true;
            this.comboBox52wh.Location = new System.Drawing.Point(397, 93);
            this.comboBox52wh.Name = "comboBox52wh";
            this.comboBox52wh.Size = new System.Drawing.Size(121, 21);
            this.comboBox52wh.TabIndex = 8;
            // 
            // labelSector
            // 
            this.labelSector.AutoSize = true;
            this.labelSector.Location = new System.Drawing.Point(7, 96);
            this.labelSector.Name = "labelSector";
            this.labelSector.Size = new System.Drawing.Size(38, 13);
            this.labelSector.TabIndex = 7;
            this.labelSector.Text = "Sector";
            // 
            // comboBoxSector
            // 
            this.comboBoxSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSector.FormattingEnabled = true;
            this.comboBoxSector.Location = new System.Drawing.Point(56, 93);
            this.comboBoxSector.Name = "comboBoxSector";
            this.comboBoxSector.Size = new System.Drawing.Size(230, 21);
            this.comboBoxSector.TabIndex = 6;
            // 
            // labelIndustry
            // 
            this.labelIndustry.AutoSize = true;
            this.labelIndustry.Location = new System.Drawing.Point(7, 60);
            this.labelIndustry.Name = "labelIndustry";
            this.labelIndustry.Size = new System.Drawing.Size(44, 13);
            this.labelIndustry.TabIndex = 5;
            this.labelIndustry.Text = "Industry";
            // 
            // comboBoxIndustry
            // 
            this.comboBoxIndustry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIndustry.FormattingEnabled = true;
            this.comboBoxIndustry.Location = new System.Drawing.Point(56, 57);
            this.comboBoxIndustry.Name = "comboBoxIndustry";
            this.comboBoxIndustry.Size = new System.Drawing.Size(230, 21);
            this.comboBoxIndustry.TabIndex = 4;
            // 
            // labelRSI14
            // 
            this.labelRSI14.AutoSize = true;
            this.labelRSI14.Location = new System.Drawing.Point(349, 22);
            this.labelRSI14.Name = "labelRSI14";
            this.labelRSI14.Size = new System.Drawing.Size(37, 13);
            this.labelRSI14.TabIndex = 3;
            this.labelRSI14.Text = "RSI14";
            // 
            // comboBoxRSI
            // 
            this.comboBoxRSI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRSI.FormattingEnabled = true;
            this.comboBoxRSI.Location = new System.Drawing.Point(397, 19);
            this.comboBoxRSI.Name = "comboBoxRSI";
            this.comboBoxRSI.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRSI.TabIndex = 2;
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(9, 24);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(43, 13);
            this.labelCountry.TabIndex = 1;
            this.labelCountry.Text = "Country";
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(58, 21);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(228, 21);
            this.comboBoxCountry.TabIndex = 0;
            // 
            // buttonReinit
            // 
            this.buttonReinit.Location = new System.Drawing.Point(1064, 15);
            this.buttonReinit.Name = "buttonReinit";
            this.buttonReinit.Size = new System.Drawing.Size(120, 23);
            this.buttonReinit.TabIndex = 13;
            this.buttonReinit.Text = "Reinit";
            this.toolTipInfo.SetToolTip(this.buttonReinit, "Reinitiliaze GUI");
            this.buttonReinit.UseVisualStyleBackColor = true;
            this.buttonReinit.Click += new System.EventHandler(this.buttonReinit_Click);
            // 
            // checkBoxOpenUrl
            // 
            this.checkBoxOpenUrl.AutoSize = true;
            this.checkBoxOpenUrl.Location = new System.Drawing.Point(900, 19);
            this.checkBoxOpenUrl.Name = "checkBoxOpenUrl";
            this.checkBoxOpenUrl.Size = new System.Drawing.Size(65, 17);
            this.checkBoxOpenUrl.TabIndex = 14;
            this.checkBoxOpenUrl.Text = "OpenUrl";
            this.toolTipInfo.SetToolTip(this.checkBoxOpenUrl, "Check to display results in finviz");
            this.checkBoxOpenUrl.UseVisualStyleBackColor = true;
            // 
            // buttonGetRatios
            // 
            this.buttonGetRatios.Location = new System.Drawing.Point(148, 173);
            this.buttonGetRatios.Name = "buttonGetRatios";
            this.buttonGetRatios.Size = new System.Drawing.Size(75, 23);
            this.buttonGetRatios.TabIndex = 0;
            this.buttonGetRatios.Text = "Get Ratios";
            this.toolTipInfo.SetToolTip(this.buttonGetRatios, "Get RECENT insider\'s trades buy/sell ratio");
            this.buttonGetRatios.UseVisualStyleBackColor = true;
            this.buttonGetRatios.Click += new System.EventHandler(this.buttonGetRatios_Click);
            // 
            // labelCurDate
            // 
            this.labelCurDate.AutoSize = true;
            this.labelCurDate.Location = new System.Drawing.Point(521, 19);
            this.labelCurDate.Name = "labelCurDate";
            this.labelCurDate.Size = new System.Drawing.Size(68, 13);
            this.labelCurDate.TabIndex = 15;
            this.labelCurDate.Text = "Current date:";
            // 
            // labelCurDateTxt
            // 
            this.labelCurDateTxt.AutoSize = true;
            this.labelCurDateTxt.ForeColor = System.Drawing.Color.Red;
            this.labelCurDateTxt.Location = new System.Drawing.Point(595, 19);
            this.labelCurDateTxt.Name = "labelCurDateTxt";
            this.labelCurDateTxt.Size = new System.Drawing.Size(0, 13);
            this.labelCurDateTxt.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTicker);
            this.groupBox1.Controls.Add(this.textBoxRatios);
            this.groupBox1.Controls.Add(this.textBoxTicker);
            this.groupBox1.Controls.Add(this.buttonGetRatios);
            this.groupBox1.Location = new System.Drawing.Point(461, 467);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 203);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Individual/list of stock ratios";
            // 
            // labelTicker
            // 
            this.labelTicker.AutoSize = true;
            this.labelTicker.Location = new System.Drawing.Point(15, 33);
            this.labelTicker.Name = "labelTicker";
            this.labelTicker.Size = new System.Drawing.Size(37, 13);
            this.labelTicker.TabIndex = 4;
            this.labelTicker.Text = "Ticker";
            // 
            // textBoxRatios
            // 
            this.textBoxRatios.Location = new System.Drawing.Point(56, 56);
            this.textBoxRatios.Multiline = true;
            this.textBoxRatios.Name = "textBoxRatios";
            this.textBoxRatios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRatios.Size = new System.Drawing.Size(271, 101);
            this.textBoxRatios.TabIndex = 3;
            // 
            // textBoxTicker
            // 
            this.textBoxTicker.Location = new System.Drawing.Point(56, 30);
            this.textBoxTicker.Name = "textBoxTicker";
            this.textBoxTicker.Size = new System.Drawing.Size(271, 20);
            this.textBoxTicker.TabIndex = 1;
            this.textBoxTicker.MouseHover += new System.EventHandler(this.textBoxTicker_MouseHover);
            // 
            // buttonTransactionsIndustSector
            // 
            this.buttonTransactionsIndustSector.Location = new System.Drawing.Point(865, 523);
            this.buttonTransactionsIndustSector.Name = "buttonTransactionsIndustSector";
            this.buttonTransactionsIndustSector.Size = new System.Drawing.Size(137, 60);
            this.buttonTransactionsIndustSector.TabIndex = 21;
            this.buttonTransactionsIndustSector.Text = "Transactions by industry / sector";
            this.buttonTransactionsIndustSector.UseVisualStyleBackColor = true;
            this.buttonTransactionsIndustSector.Click += new System.EventHandler(this.buttonTransactionsIndustSector_Click);
            // 
            // btnTopTransactions
            // 
            this.btnTopTransactions.Location = new System.Drawing.Point(1032, 523);
            this.btnTopTransactions.Name = "btnTopTransactions";
            this.btnTopTransactions.Size = new System.Drawing.Size(137, 60);
            this.btnTopTransactions.TabIndex = 22;
            this.btnTopTransactions.Text = "Top transactions";
            this.btnTopTransactions.UseVisualStyleBackColor = true;
            this.btnTopTransactions.Click += new System.EventHandler(this.btnTopTransactions_Click);
            // 
            // FrmInsiderScreener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1203, 682);
            this.Controls.Add(this.btnTopTransactions);
            this.Controls.Add(this.buttonTransactionsIndustSector);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelCurDateTxt);
            this.Controls.Add(this.labelCurDate);
            this.Controls.Add(this.checkBoxOpenUrl);
            this.Controls.Add(this.buttonReinit);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.groupBoxOverBought);
            this.Controls.Add(this.groupBoxOversold);
            this.Controls.Add(this.labelUpdateStatusContent);
            this.Controls.Add(this.labelUpdateStatus);
            this.Controls.Add(this.buttonDeleteData);
            this.Controls.Add(this.buttonStopUpdate);
            this.Controls.Add(this.buttonUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInsiderScreener";
            this.Text = "Insiders tracker: insider screener";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScreener_FormClosed);
            this.Load += new System.EventHandler(this.FrmScreener_Load);
            this.groupBoxOversold.ResumeLayout(false);
            this.groupBoxOversold.PerformLayout();
            this.groupBoxOverBought.ResumeLayout(false);
            this.groupBoxOverBought.PerformLayout();
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonStopUpdate;
        private System.Windows.Forms.Button buttonDeleteData;
        private System.Windows.Forms.Label labelUpdateStatus;
        private System.Windows.Forms.Label labelUpdateStatusContent;
        private System.Windows.Forms.GroupBox groupBoxOversold;
        private System.Windows.Forms.Button buttonTppOs;
        private System.Windows.Forms.GroupBox groupBoxOverBought;
        private System.Windows.Forms.Button buttonTppOb;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.ComboBox comboBoxPrice;
        private System.Windows.Forms.Label labelAnalyReco;
        private System.Windows.Forms.ComboBox comboBoxAnaReco;
        private System.Windows.Forms.Label labelOptionable;
        private System.Windows.Forms.ComboBox comboBoxOptionable;
        private System.Windows.Forms.Label label52wl;
        private System.Windows.Forms.ComboBox comboBox52wl;
        private System.Windows.Forms.Label label52wh;
        private System.Windows.Forms.ComboBox comboBox52wh;
        private System.Windows.Forms.Label labelSector;
        private System.Windows.Forms.ComboBox comboBoxSector;
        private System.Windows.Forms.Label labelIndustry;
        private System.Windows.Forms.ComboBox comboBoxIndustry;
        private System.Windows.Forms.Label labelRSI14;
        private System.Windows.Forms.ComboBox comboBoxRSI;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Button buttonReinit;
        private System.Windows.Forms.Button buttonIPurchPriceOS;
        private System.Windows.Forms.Button IPurchasePriceOB;
        private System.Windows.Forms.Label labelDividend;
        private System.Windows.Forms.ComboBox comboBoxDividend;
        private System.Windows.Forms.Label labelInsiOwn;
        private System.Windows.Forms.ComboBox comboBoxInsiOwn;
        private System.Windows.Forms.Label labelInstitOwn;
        private System.Windows.Forms.ComboBox comboBoxInstOwn;
        private System.Windows.Forms.Label labelDebEq;
        private System.Windows.Forms.ComboBox comboBoxDebtEq;
        private System.Windows.Forms.Label labelCashSh;
        private System.Windows.Forms.ComboBox comboBoxCash;
        private System.Windows.Forms.Label PtoB;
        private System.Windows.Forms.ComboBox comboBoxPB;
        private System.Windows.Forms.Label labelLastInsPurVal;
        private System.Windows.Forms.ComboBox comboBoxLasInsidPurVal;
        private System.Windows.Forms.TextBox textBoxResultOS;
        private System.Windows.Forms.CheckBox checkBoxOpenUrl;
        private System.Windows.Forms.TextBox textBoxResultOB;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.ComboBox comboBoxVolume;
        private System.Windows.Forms.Label labelCurDate;
        private System.Windows.Forms.Label labelCurDateTxt;
        private System.Windows.Forms.Button buttonSaveDataScreener;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTicker;
        private System.Windows.Forms.TextBox textBoxRatios;
        private System.Windows.Forms.TextBox textBoxTicker;
        private System.Windows.Forms.Button buttonGetRatios;
        private System.Windows.Forms.Button buttonTransactionsIndustSector;
        private System.Windows.Forms.Label lblOwnerSale;
        private System.Windows.Forms.ComboBox comboBoxOwnerSale;
        private System.Windows.Forms.Label lblOwnerPurchase;
        private System.Windows.Forms.ComboBox comboBoxOwnerPurchase;
        private System.Windows.Forms.Label labelNumRSales;
        private System.Windows.Forms.ComboBox comboBoxNumRInsSales;
        private System.Windows.Forms.Label lblNumRInsPurchases;
        private System.Windows.Forms.ComboBox comboBoxNumRInsPurchases;
        private System.Windows.Forms.Label lblNumRDInsPurchases;
        private System.Windows.Forms.ComboBox comboBoxNumRDInsPurchases;
        private System.Windows.Forms.Label lblNumRDInsSales;
        private System.Windows.Forms.ComboBox comboBoxNumRDInsSales;
        private System.Windows.Forms.Button btnTopTransactions;
        private System.Windows.Forms.Label labelLastInsSaleVal;
        private System.Windows.Forms.ComboBox comboBoxLasInsidSaleVal;

    }
}