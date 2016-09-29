#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;
using WebScrap.Model;

#endregion

namespace WebScrap.View
{
    public partial class FrmAdministration : Form
    {
        public FrmAdministration()
        {
            InitializeComponent();
            labelResultDb.Text = null;
            labelResultEmail.Text = null;
        }

        private void FrmAdministration_Load(object sender, EventArgs e)
        {
            labelResultDb.Text = null;
            List<string> dbData = XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");
            if (dbData != null)
            {
                if (dbData.Any())
                {
                    textBoxServer.Text = dbData[1];
                    textBoxPort.Text = dbData[2];
                    textBoxDb.Text = dbData[3];
                    textBoxUid.Text = dbData[4];
                    string crypt = StringCipherHelper.Decrypt(dbData[5], "Cirtey1979!");
                    textBoxPassword.Text = crypt;
                }
            }


            labelResultEmail.Text = null;
            List<string> emailData = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
            if (emailData != null)
            {
                if (emailData.Any())
                {
                    textBoxFromEmail.Text = emailData[1];
                    textBoxToEmail.Text = emailData[2];
                    string crypt = StringCipherHelper.Decrypt(emailData[3], "Cirtey1979!");
                    textBoxFromEmailPassword.Text = crypt;
                    textBoxHostEmail.Text = emailData[4];
                    textBoxPortEmail.Text = emailData[5];
                }
            }


            labelResultTwitterMoneyFlow.Text = null;
            List<string> twitterMoneyFlow = XmlReadWrite.ReadXMLData("TwitterMoneyFlow", "//Insiderstracker//");
            if (twitterMoneyFlow != null)
            {
                if (twitterMoneyFlow.Any())
                {
                    textBoxcKeyMoneyFlow.Text = twitterMoneyFlow[1];
                    textBoxcSecretMoneyFlow.Text = twitterMoneyFlow[2];
                    textBoxAccessTokenMoneyFlow.Text = twitterMoneyFlow[3];
                    string crypt = StringCipherHelper.Decrypt(twitterMoneyFlow[4], "Cirtey1979!");
                    textBoxTokenSecretMoneyFlow.Text = crypt;
                }
            }


            labelResultTwitterFutures.Text = null;
            List<string> twitterFutures = XmlReadWrite.ReadXMLData("TwitterFutures", "//Insiderstracker//");
            if (twitterFutures != null)
            {
                if (twitterFutures.Any())
                {
                    textBoxcKeyFutures.Text = twitterFutures[1];
                    textBoxcSecretFutures.Text = twitterFutures[2];
                    textBoxAccessTokenFutures.Text = twitterFutures[3];
                    string crypt = StringCipherHelper.Decrypt(twitterFutures[4], "Cirtey1979!");
                    textBoxTokenSecretFutures.Text = crypt;
                }
            }


            labelResultTwitterInsiders.Text = null;
            List<string> twitterInsiders = XmlReadWrite.ReadXMLData("TwitterInsiders", "//Insiderstracker//");
            if (twitterInsiders != null)
            {
                if (twitterInsiders.Any())
                {
                    textBoxcKeyInsiders.Text = twitterInsiders[1];
                    textBoxcSecretInsiders.Text = twitterInsiders[2];
                    textBoxAccessTokenInsiders.Text = twitterInsiders[3];
                    string crypt = StringCipherHelper.Decrypt(twitterInsiders[4], "Cirtey1979!");
                    textBoxTokenSecretInsiders.Text = crypt;
                }
            }
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            labelResultDb.Text = null;
            string crypt = null;
            if (!String.IsNullOrEmpty(textBoxPassword.Text))
            {
                crypt = StringCipherHelper.Encrypt(textBoxPassword.Text, "Cirtey1979!");
            }
            labelResultDb.Text = WebScrapWriteData.WriteDbData(textBoxServer.Text, textBoxPort.Text, textBoxDb.Text,
                                                               textBoxUid.Text,
                                                               crypt);
        }

        private void buttonValidateEmail_Click(object sender, EventArgs e)
        {
            if (!CheckValues())
            {
                return;
            }

            labelResultEmail.Text = null;
            string crypt = null;
            if (!String.IsNullOrEmpty(textBoxFromEmailPassword.Text))
            {
                crypt = StringCipherHelper.Encrypt(textBoxFromEmailPassword.Text, "Cirtey1979!");
            }

            labelResultEmail.Text = null;
            labelResultEmail.Text = WebScrapWriteData.WriteEmailData(textBoxFromEmail.Text, textBoxToEmail.Text,
                                                                     crypt, textBoxHostEmail.Text,
                                                                     textBoxPortEmail.Text);
        }


        /// <summary>
        /// 	Checks the values.
        /// </summary>
        /// <returns> </returns>
        private bool CheckValues()
        {
            bool validFromEmail = RegexHelper.ValidEmail(textBoxFromEmail.Text);
            if (!validFromEmail)
            {
                MessageBox.Show("From Email not valid format");
                textBoxFromEmail.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(textBoxToEmail.Text))
            {
                MessageBox.Show("To Email : no data");
                textBoxToEmail.Focus();
                return false;
            }

            int characters = RegexHelper.CountCharacters('@', textBoxToEmail.Text);

            if (characters < 1)
            {
                MessageBox.Show("To Email : invalid format");
                textBoxToEmail.Focus();
                return false;
            }

            if (characters > 1)
            {
                int commas = RegexHelper.CountCharacters(',', textBoxToEmail.Text);
                if (commas < (characters - 1))
                {
                    MessageBox.Show("Use ',' as a separator between e-mail adresses");
                    textBoxToEmail.Focus();
                    return false;
                }
            }


            if (String.IsNullOrEmpty(textBoxHostEmail.Text) || String.IsNullOrEmpty(textBoxHostEmail.Text))
            {
                MessageBox.Show("Host : no data");
                textBoxHostEmail.Focus();
                return false;
            }


            int host;
            bool result = Int32.TryParse(textBoxPortEmail.Text, out host);

            if (!result)
            {
                MessageBox.Show("Port not valid");
                textBoxPortEmail.Focus();
                return false;
            }
            return true;
        }

        private void buttonValidateTwitter_Click(object sender, EventArgs e)
        {
            labelResultTwitterMoneyFlow.Text = null;
            if (string.IsNullOrEmpty(textBoxcKeyMoneyFlow.Text) || string.IsNullOrEmpty(textBoxcSecretMoneyFlow.Text) ||
                string.IsNullOrEmpty(textBoxAccessTokenMoneyFlow.Text) ||
                string.IsNullOrEmpty(textBoxTokenSecretMoneyFlow.Text))
            {
                MessageBox.Show("You must enter all values of the witter application");
                return;
            }


            string crypt = null;
            if (!String.IsNullOrEmpty(textBoxTokenSecretMoneyFlow.Text))
            {
                crypt = StringCipherHelper.Encrypt(textBoxTokenSecretMoneyFlow.Text, "Cirtey1979!");
            }

            labelResultTwitterMoneyFlow.Text = WebScrapWriteData.WriteTwitterData(textBoxcKeyMoneyFlow.Text,
                                                                                  textBoxcSecretMoneyFlow.Text,
                                                                                  textBoxAccessTokenMoneyFlow.Text,
                                                                                  crypt, textBoxTwitterMoneyFlow.Text
                );
        }

        private void buttonValidateTwitterFutures_Click(object sender, EventArgs e)
        {
            labelResultTwitterFutures.Text = null;
            if (string.IsNullOrEmpty(textBoxcKeyFutures.Text) || string.IsNullOrEmpty(textBoxcSecretFutures.Text) ||
                string.IsNullOrEmpty(textBoxAccessTokenFutures.Text) ||
                string.IsNullOrEmpty(textBoxTokenSecretFutures.Text))
            {
                MessageBox.Show("You must enter all values of the witter application");
                return;
            }


            string crypt = null;
            if (!String.IsNullOrEmpty(textBoxTokenSecretFutures.Text))
            {
                crypt = StringCipherHelper.Encrypt(textBoxTokenSecretFutures.Text, "Cirtey1979!");
            }

            labelResultTwitterFutures.Text = WebScrapWriteData.WriteTwitterData(textBoxcKeyFutures.Text,
                                                                                textBoxcSecretFutures.Text,
                                                                                textBoxAccessTokenFutures.Text, crypt,
                                                                                textBoxTwitterFutures.Text
                );
        }

        private void buttonValidateTwitterInsiders_Click(object sender, EventArgs e)
        {
            labelResultTwitterInsiders.Text = null;
            if (string.IsNullOrEmpty(textBoxcKeyInsiders.Text) || string.IsNullOrEmpty(textBoxcSecretInsiders.Text) ||
                string.IsNullOrEmpty(textBoxAccessTokenInsiders.Text) ||
                string.IsNullOrEmpty(textBoxTokenSecretInsiders.Text))
            {
                MessageBox.Show("You must enter all values of the witter application");
                return;
            }
            string crypt = null;
            if (!String.IsNullOrEmpty(textBoxTokenSecretInsiders.Text))
            {
                crypt = StringCipherHelper.Encrypt(textBoxTokenSecretInsiders.Text, "Cirtey1979!");
            }

            labelResultTwitterInsiders.Text = WebScrapWriteData.WriteTwitterData(textBoxcKeyInsiders.Text,
                                                                                 textBoxcSecretInsiders.Text,
                                                                                 textBoxAccessTokenInsiders.Text, crypt,
                                                                                 textBoxTwitterInsiders.Text
                );
        }
    }
}