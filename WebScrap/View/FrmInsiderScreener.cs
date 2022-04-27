#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using WebScrap.Presenter;

#endregion

namespace WebScrap.View
{
    public partial class FrmInsiderScreener : Form, IViewScreener
    {
        private readonly PresMain _pres;

        public Thread ThreadMain;
        private string _connectionstring;
        private bool _obLiClick;
        private bool _obTpClick;
        private bool _osLiClick;
        private bool _osTpClick;

        public FrmInsiderScreener()
        {
            _pres = new PresMain(this);
            InitializeComponent();
            labelCurDateTxt.Text = DateTime.Now.ToShortDateString();
        }

        public bool ExceptionDb { get; set; }

        #region IViewScreener Members

        /// <summary>
        /// 	Views the label.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="values"> The values. </param>
        public void FillCombobox(object obj, List<string> values)
        {
            ComboBox combo = null;
            if (obj is ComboBox)
            {
                combo = obj as ComboBox;
            }
            if (combo != null)
            {
                combo.DataSource = values;
            }
        }


        /// <summary>
        /// 	Views the label
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="s"> The s. </param>
        public void ViewLabel(object obj, string s)
        {
            Label label = null;
            if (obj is Label)
            {
                label = obj as Label;
            }
            if (label != null)
            {
                ThreadHelper.SetText(this, label, s);
            }
        }

        #endregion

        private void FrmScreener_FormClosed(object sender, FormClosedEventArgs e)
        {
            labelUpdateStatusContent.Text = null;
            if (ThreadMain != null)
            {
                ThreadMain.Abort();
                ThreadMain = null;
            }
        }

        private void buttonStopUpdate_Click(object sender, EventArgs e)
        {
            labelUpdateStatusContent.Text = null;
            buttonUpdate.Enabled = true;
            if (ThreadMain != null)
            {
                ThreadMain.Abort();
                ThreadMain = null;
            }
        }

        private void buttonDeleteData_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = true;
            _pres.DeleteFinvizData(labelUpdateStatusContent, "Data deleted");
        }

        /// <summary>
        /// 	Fills the comboboxes.
        /// </summary>
        private void FillComboboxes()
        {
            _pres.FillDropDownList("select distinct country from finviz.findata order by country;", comboBoxCountry,
                                   "country",
                                   _connectionstring);

            _pres.FillDropDownList("select distinct sector from finviz.findata order by sector;", comboBoxSector,
                                   "sector",
                                   _connectionstring);


            _pres.FillDropDownList(
                "select distinct industry from finviz.findata  where trim(industry) <> 'Exchange Traded Fund' order by industry;",
                comboBoxIndustry,
                "industry",
                _connectionstring);

            List<object> combos = new List<object>();
            combos.Add(comboBoxOptionable);
            combos.Add(comboBoxRSI);
            combos.Add(comboBoxAnaReco);
            combos.Add(comboBoxPrice);
            combos.Add(comboBox52wl);
            combos.Add(comboBox52wh);

            combos.Add(comboBoxOwnerPurchase);
            combos.Add(comboBoxOwnerSale);

            combos.Add(comboBoxNumRInsPurchases);
            combos.Add(comboBoxNumRInsSales);
            combos.Add(comboBoxNumRDInsPurchases);
            combos.Add(comboBoxNumRDInsSales);
            _pres.FillDropDownlist(combos);
        }


        private void FrmScreener_Load(object sender, EventArgs e)
        {
            List<string> dbData =
                XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");

  
            if (dbData != null)
            {
                string server = dbData[1];
                string database = dbData[2];


                _connectionstring = "Data Source = " + server + "; Initial Catalog = " + database + ";Integrated Security = True";

                DbConnect dbc = new DbConnect(server,database);
                bool isconnected=dbc.OpenConnection();
                if(isconnected)
                {
                    dbc.CloseConnection();
                }
                else
                {
                    MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                              "Database error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            FillComboboxes();
        }


        private string GetWhereQuery()
        {
            string wherequ = null;
            if (comboBox52wh.Text != "")
            {
                wherequ += " and 52whigh  " + comboBox52wh.Text + " ";
            }
            if (comboBox52wl.Text != "")
            {
                wherequ += " and 52wlow  " + comboBox52wl.Text + " ";
            }
            if (comboBoxOptionable.Text != "")
            {
                wherequ += " and optionable = '" + comboBoxOptionable.Text + "' ";
            }
            if (comboBoxRSI.Text != "")
            {
                wherequ += " and rsi14  " + comboBoxRSI.Text + " ";
            }
            if (comboBoxCountry.Text != "")
            {
                wherequ += " and country = '" + comboBoxCountry.Text + "' ";
            }
            if (comboBoxIndustry.Text != "")
            {
                wherequ += " and industry = '" + comboBoxIndustry.Text + "' ";
            }
            if (comboBoxSector.Text != "")
            {
                wherequ += " and sector = '" + comboBoxSector.Text + "' ";
            }
            if (comboBoxAnaReco.Text != "")
            {
                wherequ += " and reco  " + comboBoxAnaReco.Text + " ";
            }
            if (comboBoxPrice.Text != "")
            {
                wherequ += " and price " + comboBoxPrice.Text + " ";
            }
            if (comboBoxPB.Text != "")
            {
                wherequ += " and pricetobook " + comboBoxPB.Text + " ";
            }
            if (comboBoxCash.Text != "")
            {
                wherequ += " and cashsh " + comboBoxCash.Text + " ";
            }
            if (comboBoxDebtEq.Text != "")
            {
                wherequ += " and debteq " + comboBoxDebtEq.Text + " ";
            }
            if (comboBoxInstOwn.Text != "")
            {
                wherequ += " and instown " + comboBoxInstOwn.Text + " ";
            }
            if (comboBoxInsiOwn.Text != "")
            {
                wherequ += " and insidown " + comboBoxInsiOwn.Text + " ";
            }
            if (comboBoxDividend.Text != "")
            {
                wherequ += " and dividendpercent " + comboBoxDividend.Text + " ";
            }

            if (comboBoxVolume.Text != "")
            {
                wherequ += " and volume " + comboBoxVolume.Text + " ";
            }


            if (comboBoxLasInsidPurVal.Text != "")
            {
                wherequ += " and lastinsiderpurchasevalue " + comboBoxLasInsidPurVal.Text + " ";
            }

            if (comboBoxLasInsidSaleVal.Text != "")
            {
                wherequ += " and lastinsidersalevalue " + comboBoxLasInsidSaleVal.Text + " ";
            }


            if (comboBoxOwnerPurchase.Text != "")
            {
                wherequ += " and lastinsiderpurchaseisbyowner = '" + comboBoxOwnerPurchase.Text + "' ";
            }
            if (comboBoxOwnerSale.Text != "")
            {
                wherequ += " and lastinsidersaleisbyowner = '" + comboBoxOwnerSale.Text + "' ";
            }


            if (comboBoxNumRInsSales.Text != "")
            {
                wherequ += " and numrecentinsidersales  " + comboBoxNumRInsSales.Text + " ";
            }
            if (comboBoxNumRInsPurchases.Text != "")
            {
                wherequ += " and numrecentinsiderpurchases  " + comboBoxNumRInsPurchases.Text + " ";
            }
            if (comboBoxNumRDInsSales.Text != "")
            {
                wherequ += " and numrecentdifferentinsidersales  " + comboBoxNumRDInsSales.Text + " ";
            }

            if (comboBoxNumRDInsPurchases.Text != "")
            {
                wherequ += " and numrecentdifferentinsiderpurchases  " + comboBoxNumRDInsPurchases.Text + " ";
            }


            return wherequ;
        }

        private void ReinitCombos()
        {
            _pres.FillDropDownList("select distinct country from finviz.findata order by country;", comboBoxCountry,
                                   "country",
                                   _connectionstring);

            _pres.FillDropDownList("select distinct sector from finviz.findata order by sector;", comboBoxSector,
                                   "sector",
                                   _connectionstring);

            _pres.FillDropDownList(
                "select distinct industry from finviz.findata where trim(industry) <> 'Exchange Traded Fund'  order by industry;",
                comboBoxIndustry,
                "industry",
                _connectionstring);

            comboBox52wh.SelectedItem = "";
            comboBox52wl.SelectedItem = "";
            comboBoxOptionable.SelectedItem = "";
            comboBoxRSI.SelectedItem = "";
            comboBoxCountry.SelectedItem = "";
            comboBoxIndustry.SelectedItem = "";
            // comboBoxIndustry.Items.Remove("Exchange traded fund");
            comboBoxSector.SelectedItem = "";
            comboBoxAnaReco.SelectedItem = "";
            comboBoxPrice.SelectedItem = "";
            comboBoxPB.SelectedItem = "";
            comboBoxCash.SelectedItem = "";
            comboBoxInstOwn.SelectedItem = "";
            comboBoxInsiOwn.SelectedItem = "";
            comboBoxDividend.SelectedItem = "";
            comboBoxDebtEq.SelectedItem = "";
            comboBoxVolume.SelectedItem = "";

            comboBoxLasInsidPurVal.SelectedItem = "";
            comboBoxLasInsidSaleVal.SelectedItem = "";

            comboBoxOwnerPurchase.SelectedItem = "";
            comboBoxOwnerSale.SelectedItem = "";

            comboBoxNumRInsSales.SelectedItem = "";
            comboBoxNumRInsPurchases.SelectedItem = "";
            comboBoxNumRDInsSales.SelectedItem = "";
            comboBoxNumRDInsPurchases.SelectedItem = "";
        }

        private void buttonSaveDataScreener_Click(object sender, EventArgs e)
        {
            string dataOb = null;
            string dataOs = null;
            if (_obLiClick) dataOb = "LIP";
            if (_obTpClick) dataOb = "TPP";
            if (_osLiClick) dataOs = "LIP";
            if (_osTpClick) dataOs = "TPP";

            if (!String.IsNullOrEmpty(textBoxResultOB.Text))
            {
                string result = FileHelper.SaveTextBox(textBoxResultOB, dataOb + "txtBxOB", dataOb + " OB data saved");
                if (result != null)
                {
                    MessageBox.Show(result);
                }
            }

            if (!String.IsNullOrEmpty(textBoxResultOS.Text))
            {
                string result1 = FileHelper.SaveTextBox(textBoxResultOS, dataOs + "txtBxOS", dataOs + " OS data saved");
                if (result1 != null)
                {
                    MessageBox.Show(result1);
                }
            }
        }

        private void buttonReinit_Click(object sender, EventArgs e)
        {
            textBoxResultOS.Clear();
            textBoxResultOB.Clear();
            textBoxRatios.Clear();
            textBoxTicker.Clear();
            ReinitCombos();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ThreadMain = new Thread(state => _pres.UpdateFinvizDb(labelUpdateStatusContent, "Data updated"));
            ThreadMain.IsBackground = true;
            ThreadMain.Start();
            buttonStopUpdate.Enabled = true;
            buttonUpdate.Enabled = false;
        }


        private void buttonTppOb_Click(object sender, EventArgs e)
        {
            _obTpClick = true;
            _obLiClick = false;
            string query;
            string query1;


            query = @"select distinct  concat(ticker,':  ',left((targetprice / price),6),' =>                     ',industry) as ticker
            from finviz.findata where (price > 0.2 and targetprice <> 0 and volume>10000 " +
                    GetWhereQuery() +
                    " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                    +
                    ") order by (targetprice / price) asc limit 30;";
            query1 =
                @"select  ticker
            from finviz.findata where (price > 0.2 and targetprice <> 0 and volume>10000 " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                +
                ") order by (targetprice / price) asc limit 30;";


            if (checkBoxOpenUrl.Checked)
                _pres.LaunchPage(query1, "ticker", _connectionstring, "-rsi");
            List<string> values;
            bool dbconnect = DbConnect.GetValue(query, "ticker", _connectionstring, out values);
            if (!dbconnect)
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxResultOB.Clear();
            textBoxResultOB.AppendText("Bottom Avg.Analy.Targ.Price/Price" + "\r\n");
            textBoxResultOB.AppendText("\r\n");
            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBoxResultOB.AppendText(i + "- " + value + "\r\n");
                i++;
            }
        }


        private void buttonTppOs_Click(object sender, EventArgs e)
        {
            _osTpClick = true;
            _osLiClick = false;

            string query;
            string query1;

            query =
                @"select  distinct concat(ticker,':  ',left((targetprice / price),6),' =>                     ',industry) as ticker
             from finviz.findata where (price > 0.2 and targetprice <> 0 and volume>10000 and ((targetprice / price) < 40) " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                +
                ") order by (targetprice / price) desc limit 30;";
            query1 =
                @"select ticker
             from finviz.findata where (price > 0.2 and targetprice <> 0 and volume>10000 " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                +
                ") order by (targetprice / price) desc limit 30;";


            if (checkBoxOpenUrl.Checked)
                _pres.LaunchPage(query1, "ticker", _connectionstring, "rsi");
            List<string> values;
            bool dbconnect = DbConnect.GetValue(query, "ticker", _connectionstring, out values);
            if (!dbconnect)
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxResultOS.Clear();
            textBoxResultOS.AppendText("Top Avg.Analy.Targ.Price/Price" + "\r\n");
            textBoxResultOS.AppendText("\r\n");
            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBoxResultOS.AppendText(i + "- " + value + "\r\n");
                i++;
            }
        }


        private void buttonIPurchPriceOS_Click(object sender, EventArgs e)
        {
            _osTpClick = false;
            _osLiClick = true;
            string query;
            string query1;

            query =
                @"select distinct concat(ticker,':  ',left((lastinsiderpurchaseprice / price),6),' =>                     ',industry) as ticker
             from finviz.findata where (price > 0.2 and lastinsiderpurchaseprice <> 0 and volume>10000 and ((lastinsiderpurchaseprice / price) < 40) " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                + ") order by (lastinsiderpurchaseprice / price) desc limit 30;";
            query1 =
                @"select ticker 
             from finviz.findata where (price > 0.2 and lastinsiderpurchaseprice <> 0 and volume>10000 and ((lastinsiderpurchaseprice / price) < 40) " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                + ") order by (lastinsiderpurchaseprice / price) desc limit 30;";


            if (checkBoxOpenUrl.Checked)
                _pres.LaunchPage(query1, "ticker", _connectionstring, "rsi");
            List<string> values;
            bool dbconnect = DbConnect.GetValue(query, "ticker", _connectionstring, out values);
            if (!dbconnect)
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxResultOS.Clear();
            textBoxResultOS.AppendText("Top Last.Ins.Purch.Price/Price" + "\r\n");
            textBoxResultOS.AppendText("\r\n");
            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBoxResultOS.AppendText(i + "- " + value + "\r\n");
                i++;
            }
        }

        private void IPurchasePriceOB_Click(object sender, EventArgs e)
        {
            _obTpClick = false;
            _obLiClick = true;
            string query;
            string query1;

            query =
                @"select distinct concat(ticker,':  ',left((lastinsiderpurchaseprice / price),6),' =>                     ',industry) as ticker
            from finviz.findata where (price > 0.2 and lastinsiderpurchaseprice <> 0 and volume>10000 " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)"
                + ") order by (lastinsiderpurchaseprice / price) asc limit 30;";

            query1 =
                @"select  ticker
            from finviz.findata where (price > 0.2 and lastinsiderpurchaseprice <> 0 and volume>10000 " +
                GetWhereQuery() +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)" + " )"
                + " order by (lastinsiderpurchaseprice / price) asc limit 30;";


            if (checkBoxOpenUrl.Checked)
                _pres.LaunchPage(query1, "ticker", _connectionstring, "-rsi");
            List<string> values;
            bool dbconnect = DbConnect.GetValue(query, "ticker", _connectionstring, out values);
            if (!dbconnect)
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxResultOB.Clear();
            textBoxResultOB.AppendText("Bottom Last.Ins.Purch.Price/Price" + "\r\n");
            textBoxResultOB.AppendText("\r\n");
            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBoxResultOB.AppendText(i + "- " + value + "\r\n");
                i++;
            }
        }


        private void buttonGetRatios_Click(object sender, EventArgs e)
        {
            string query;


            query =
                @"select distinct concat(ticker,':  ',left((lastinsiderpurchaseprice / price),6),' => ',industry) as ticker
            from finviz.findata where (price > 0.2 and lastinsiderpurchaseprice <> 0 and volume>10000 " +
                "and ticker in (" + FitForQuery(textBoxTicker.Text.ToUpper()) + ")" +
                " and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)" +
                ") order by (last" +
                "insiderpurchaseprice / price) desc;";

            List<string> values;
            bool dbconnect = DbConnect.GetValue(query, "ticker", _connectionstring, out values);
            if (!dbconnect)
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBoxRatios.Clear();
            textBoxRatios.AppendText("Last.Ins.Purch.Price/Price" + "\r\n");

            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBoxRatios.AppendText("- " + value + "\r\n");
                i++;
            }
        }

        private string FitForQuery(string data)
        {
            string finaldata = null;

            var data2 = data.Split(' ');
            foreach (var s in data2)
            {
                string data3 = "'" + s + "'" + ",";
                finaldata += data3;
            }

            if (finaldata != null) finaldata = finaldata.Remove(finaldata.Length - 1);
            return finaldata;
        }

        private void textBoxTicker_MouseHover(object sender, EventArgs e)
        {
            toolTipInfo.SetToolTip(textBoxTicker, "Type a stock ticker and separate with space. Ex: msft aapl xom");
        }


        private void buttonTransactionsIndustSector_Click(object sender, EventArgs e)
        {
            FrmSectorialInsiderTransactions insiderTransactions = new FrmSectorialInsiderTransactions();
            insiderTransactions.Show();
        }

        private void groupBoxFilters_Enter(object sender, EventArgs e)
        {
        }

        private void btnTopTransactions_Click(object sender, EventArgs e)
        {
            FrmTopInsiderTrades toptrades = new FrmTopInsiderTrades();
            toptrades.Show();
        }
    }
}