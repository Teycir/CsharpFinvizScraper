#region

using System;
using System.Drawing;
using System.Windows.Forms;
using Helpers;
using WebScrap.Model;

#endregion

namespace WebScrap.View
{
    public partial class FrmMain : Form
    {
        private FrmInsidersAlert _frmInsidersAlert;
        private FrmInsiderScreener _frmInsidersScreener;
        private FrmMoneyFlow _frmMflow;
        private FrmFuturesAlerts _frmfutures;


        public FrmMain()
        {
           
            InitializeComponent();
        }

        private void InitUsagePeriod()
        {
            string crypt = StringCipherHelper.Encrypt(DateTime.Now.ToString() + "*" + "366", "Cirtey1979!");
            string test = crypt;
            labelDaysLeft.Text = null;

            bool licenceisvalid = WebScrapLicence.LicenceFileValid();
            if (!licenceisvalid)
            {
                buttonFlowsScreener.Enabled = false;
                buttonFinviz.Enabled = false;
                buttonFuturesAlerts.Enabled = false;
                buttonInsiderTradesAlert.Enabled = false;


                FrmLicence frmLicence = new FrmLicence(this);
                frmLicence.Show();
                string cryptentered = frmLicence.KeyLicence;

                if (!String.IsNullOrEmpty(cryptentered))
                {
                    WebScrapWriteData.WriteExpirationData(cryptentered);
                }
            }

            string[] getdata = WebScrapLicence.GetLicence();

            if (getdata == null || getdata.Length != 2)
            {
                MessageBox.Show("Invalid licence!",
                                "Not allowed!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);

                buttonFlowsScreener.Enabled = false;
                buttonFinviz.Enabled = false;
                buttonFuturesAlerts.Enabled = false;
                buttonInsiderTradesAlert.Enabled = false;
                return;
            }


            string message;
            double daysago;
            double daysleft;
            string datestart = getdata[0];
            double days = Convert.ToDouble(getdata[1]);
            Expiration.GetExpirationDate(days, datestart, out daysago, out daysleft, "Days left before expiration: ",
                                         out message);
            labelDaysLeft.Text = message;


            if (daysleft < 1)
            {
                MessageBox.Show("Expired subscription.",
                                "Important Note",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                buttonFlowsScreener.Enabled = false;
                buttonFinviz.Enabled = false;
                buttonFuturesAlerts.Enabled = false;
                buttonInsiderTradesAlert.Enabled = false;
                labelDaysLeft.Font = new Font(Font.FontFamily.Name, 20);
            }
        }

        private void buttonAvafin_Click(object sender, EventArgs e)
        {
            if (_frmMflow != null)
            {
                MessageBox.Show("Screen money flow already open",
                                "Not allowed!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            _frmMflow = new FrmMoneyFlow();
            _frmMflow.Show();
            _frmMflow = null;
        }

        private void buttonFinviz_Click(object sender, EventArgs e)
        {
            if (_frmInsidersScreener != null)
            {
                MessageBox.Show("Screener already open",
                                "Not allowed!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            _frmInsidersScreener = new FrmInsiderScreener();
            _frmInsidersScreener.Show();
            _frmInsidersScreener = null;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContact form = new FrmContact();
            form.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHelp form = new FrmHelp();
            form.Show();
        }

        private void administrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministration form = new FrmAdministration();
            form.ShowDialog();
        }

        private void buttonFuturesScreener_Click(object sender, EventArgs e)
        {
            if (_frmfutures != null)
            {
                MessageBox.Show("Screen futures screener already open",
                                "Not allowed!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            _frmfutures = new FrmFuturesAlerts();
            _frmfutures.Show();
            _frmfutures = null;
        }

        private void buttonInsiderTradesAlert_Click(object sender, EventArgs e)
        {
            if (_frmInsidersAlert != null)
            {
                MessageBox.Show("Futures alert already open!",
                                "Not allowed!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            _frmInsidersAlert = new FrmInsidersAlert();
            _frmInsidersAlert.Show();
            _frmInsidersAlert = null;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            InitUsagePeriod();
        }
    }
}