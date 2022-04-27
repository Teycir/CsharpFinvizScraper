#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using WebScrap.Model;

#endregion

namespace WebScrap.View
{
    public partial class FrmInsidersAlert : Form
    {
        private readonly string _file =  FileHelper.GetRoot() +
                                        "//InsidersTracker//" + "tickers.txt";


        private readonly List<string> _purchases = new List<string>();
        private readonly List<string> _sales = new List<string>();
        public Thread ThreadMain;

        public FrmInsidersAlert(Thread threadMain)
        {
            ThreadMain = threadMain;
        }

        private bool _allTickers;

        private bool _listboxthreadInsidersActive = true;
        private bool _mailAlert;
        private bool _openUrl;
        private int _selectedval;
        private bool _soundAlert;
        private bool _tweetAlert;

        #region Logic

        private void DesactivateAlerts()
        {
            _listboxthreadInsidersActive = false;
            if (ThreadMain == null) return;
            if (ThreadMain.IsAlive)
                ThreadMain.Abort();
            ThreadMain = null;
            labelStatus1.Text = "Inactive";
            labelStatus1.ForeColor = Color.Red;
            _purchases.Clear();
            _sales.Clear();
        }

        private void ActivateAlerts()
        {
            if (checkBoxAlertAll.Checked)
            {
                _listboxthreadInsidersActive = true;
                ThreadMain = new Thread(InitTimerListboxInsiders);
                ThreadMain.Start();
                labelStatus1.Text = "Active";
                labelStatus1.ForeColor = Color.Green;
            }
            else
            {
                if (listBoxTickers == null) return;
                if (listBoxTickers.Items.Count <= 0)
                {
                    MessageBox.Show("No tickers selected", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _listboxthreadInsidersActive = true;
                    ThreadMain = new Thread(InitTimerListboxInsiders);
                    ThreadMain.Start();
                    labelStatus1.Text = "Active";
                    labelStatus1.ForeColor = Color.Green;
                }
            }
        }

        private int SelectedValue()
        {
            string value = ThreadHelper.GetControlText(comboBoxTransactionValue);
            if (!String.IsNullOrEmpty(value))
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return 0;
            }
        }


        private void ReadTextData(string filename)
        {
            try
            {
                listBoxTickers.Items.Clear();
                string[] text = File.ReadAllLines(filename);

                List<string> tickers = new List<string>();

                foreach (string ticker in text)
                {
                    if (!tickers.Contains(ticker))
                    {
                        tickers.Add(ticker);
                        string newTicker = ticker.Trim();
                        listBoxTickers.Items.Add(newTicker);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("FrmInsidersAlert ReadTextData");
                Log.WriteLog(ex.ToString());
            }
        }

        #endregion

        #region Events

        public FrmInsidersAlert()
        {
            InitializeComponent();

            comboBoxTransactionValue.SelectedIndex = 0;
            _allTickers = checkBoxAlertAll.Checked;
            ReadTextData(_file);

            Directory.CreateDirectory(FileHelper.GetRoot()  +"//InsidersTracker");

            ScrapInsiderAlert scrap = new ScrapInsiderAlert();

            scrap.GetInsidersTickers("Purchase");
        }


        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = fd.FileName;

                ReadTextData(fileToOpen);
            }
        }


        private void buttonSaveTickers_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxTickers == null) return;
                if (listBoxTickers.Items.Count <= 0)
                {
                    MessageBox.Show("No tickers selected", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    File.WriteAllText(_file, String.Empty);
                    StreamWriter filewrite = new StreamWriter(_file);
                    foreach (var ticker in listBoxTickers.Items)
                    {
                        filewrite.WriteLine(ticker);
                    }
                    filewrite.Close();
                    MessageBox.Show("Tickers saved", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("FormInsidersAlertMain_FormClosing");
                Log.WriteLog(ex.ToString());
            }
        }

        private void buttonInsiderTrades_Click(object sender, EventArgs e)
        {
            listBoxInsiderTrades.Items.Clear();
            ActivateAlerts();
        }

        private void InitTimerListboxInsiders()
        {
            ScrapInsiderAlert scrap = new ScrapInsiderAlert();
            while (_listboxthreadInsidersActive)
            {
                Thread.Sleep(5000);
                _selectedval = SelectedValue();
                if (_allTickers)
                {
                    if (listBoxTickers.Items.Count > 0)

                    {
                        scrap.ScrapData(this, listBoxInsiderTrades, scrap.GetItems(listBoxTickers),
                                        _soundAlert, _mailAlert, _tweetAlert,
                                        _openUrl, _purchases, _sales, _selectedval, "Purchase",
                                        " Insider just bought at ", "Insiders purchase of ", "t=p");

                        scrap.ScrapData(this, listBoxInsiderTrades, scrap.GetItems(listBoxTickers),
                                        _soundAlert,
                                        _mailAlert, _tweetAlert,
                                        _openUrl, _purchases, _sales, _selectedval, "Sale", " Insider just sold at ",
                                        "Insiders sale of ", "t=s");
                    }


                    List<string> purchases = scrap.GetInsidersTickers("Purchase");
                    if (purchases == null) continue;
                    if (purchases.Count > 0)
                        scrap.ScrapData(this, listBoxInsiderTrades, purchases, _soundAlert, _mailAlert,
                                        _tweetAlert,
                                        _openUrl, _purchases, _sales, _selectedval, "Purchase",
                                        " Insider just bought at ", "Insiders purchase of ", "t=p");
                    List<string> sales = scrap.GetInsidersTickers("Sale");
                    if (sales == null) continue;
                    if (sales.Count > 0)
                        scrap.ScrapData(this, listBoxInsiderTrades, sales, _soundAlert, _mailAlert, _tweetAlert,
                                        _openUrl, _purchases, _sales, _selectedval, "Sale", " Insider just sold at ",
                                        "Insiders sale of ", "t=s");
                }
                else
                {
                    if (listBoxTickers == null) return;
                    if (listBoxTickers.Items.Count > 0)
                    {
                        scrap.ScrapData(this, listBoxInsiderTrades, scrap.GetItems(listBoxTickers),
                                        _soundAlert, _mailAlert, _tweetAlert,
                                        _openUrl, _purchases, _sales, _selectedval, "Purchase",
                                        " Insider just bought at ", "Insiders purchase of ", "t=p");

                        scrap.ScrapData(this, listBoxInsiderTrades, scrap.GetItems(listBoxTickers),
                                        _soundAlert, _mailAlert, _tweetAlert,
                                        _openUrl, _purchases, _sales, _selectedval, "Sale", " Insider just sold at ",
                                        "Insiders sale of ", "t=s");
                    }
                }
            }
        }


        private void buttonClearAlerts_Click(object sender, EventArgs e)
        {
            listBoxInsiderTrades.Items.Clear();
        }


        private void FormInsidersAlertMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DesactivateAlerts();
            }
            catch (Exception ex)
            {
                Log.WriteLog("FormInsidersAlertMain_FormClosing");
                Log.WriteLog(ex.ToString());
            }
        }


        private void buttonDesactivate_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxTransactionValue.SelectedItem = "";
                DesactivateAlerts();
            }
            catch (Exception ex)
            {
                Log.WriteLog("FormInsidersAlert buttonDesactivate_Click");
                Log.WriteLog(ex.ToString());
            }
        }

        #endregion

        private void comboBoxTransactionValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedval = SelectedValue();
        }


        private void checkBoxEmail_Click(object sender, EventArgs e)
        {
            List<string> emailData = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
            if (emailData == null)
            {
                MessageBox.Show("Missing email data, go to Email administration and provide the data.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxEmail.Checked = false;
                return;
            }

            if (emailData[1] == "")
            {
                MessageBox.Show("Missing email data (from)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxEmail.Checked = false;
                return;
            }

            if (emailData[2] == "")
            {
                MessageBox.Show("Missing email data (to)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxEmail.Checked = false;
                return;
            }

            if (emailData[3] == "")
            {
                MessageBox.Show("Missing email data (from password)", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                checkBoxEmail.Checked = false;
                return;
            }

            if (emailData[4] == "")
            {
                MessageBox.Show("Missing email data (host)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxEmail.Checked = false;
                return;
            }

            if (emailData[5] == "")
            {
                MessageBox.Show("Missing email data (port)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                checkBoxEmail.Checked = false;
            }
        }

        private void checkBoxTwitterAlert_CheckedChanged(object sender, EventArgs e)
        {
            _tweetAlert = checkBoxTwitterAlert.Checked;
        }

        private void checkBoxEmail_CheckedChanged(object sender, EventArgs e)
        {
            _mailAlert = checkBoxEmail.Checked;
        }

        private void checkBoxOpenUrl_CheckedChanged(object sender, EventArgs e)
        {
            _openUrl = checkBoxOpenUrl.Checked;
        }

        private void checkBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            _soundAlert = checkBoxSound.Checked;
        }

        private void checkBoxAlertAll_CheckedChanged(object sender, EventArgs e)
        {
            _allTickers = checkBoxAlertAll.Checked;
        }


        private void buttonOpenInsider_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.http://openinsider.com/");
        }
    }
}