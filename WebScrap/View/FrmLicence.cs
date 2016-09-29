#region

using System;
using System.Linq;
using System.Windows.Forms;
using Helpers;
using WebScrap.Model;

#endregion

namespace WebScrap.View
{
    public partial class FrmLicence : Form
    {
        private readonly FrmMain _frmMain;

        public FrmLicence()
        {
            InitializeComponent();
        }

        public FrmLicence(FrmMain form)
        {
            InitializeComponent();
            _frmMain = form;
        }


        public String KeyLicence { get; set; }

        private void buttonValidateLicence_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxKeyword.Text))
            {
                MessageBox.Show("Enter a key!",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            if (textBoxKeyword.Text.Length != 44 || RegexHelper.NumberOfletters(textBoxKeyword.Text) == 0)
            {
                MessageBox.Show("Incorrect key, all keys have 44 letters!",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            KeyLicence = textBoxKeyword.Text;
            string plaintext = StringCipherHelper.Decrypt(KeyLicence, "Cirtey1979!");

            if (plaintext == null)
            {
                MessageBox.Show("Incorrect key!",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }


            if (!plaintext.Contains('*'))
            {
                MessageBox.Show("Incorrect key!",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }


            if (!String.IsNullOrEmpty(KeyLicence))
            {
                WebScrapWriteData.WriteExpirationData(KeyLicence);
            }

            Close();

            _frmMain.buttonFlowsScreener.Enabled = true;
            _frmMain.buttonFinviz.Enabled = true;
            _frmMain.buttonFuturesAlerts.Enabled = true;
            _frmMain.buttonInsiderTradesAlert.Enabled = true;
            _frmMain.Show();
        }
    }
}