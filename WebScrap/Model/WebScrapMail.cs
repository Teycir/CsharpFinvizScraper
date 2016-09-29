#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.Model
{
    public class WebScrapMail
    {
        /// <summary>
        /// 	Sends the tweet.
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <param name="twitteraccount"> The twitteraccount. </param>
        public static void SendTweet(string message, string twitteraccount)
        {
            List<string> twitterData = XmlReadWrite.ReadXMLData(twitteraccount, "//Insiderstracker//");
            if (twitterData == null) return;
            if (twitterData.Count <= 0) return;
            string crypt = StringCipherHelper.Decrypt(twitterData[4], "Cirtey1979!");
            TweetHelper.SendTweet(message, twitterData[1], twitterData[2], twitterData[3], crypt);
        }


        /// <summary>
        /// 	Sends the email insider alert.
        /// </summary>
        /// <param name="subject"> The subject. </param>
        /// <param name="body"> The body. </param>
        public static void SendEmailAlert(string subject, string body)
        {
            try
            {
                List<string> emailData = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
                if (emailData.Any())
                {
                    if (emailData[1] == "")
                    {
                        MessageBox.Show("Missing email data 'from'");
                        return;
                    }
                    string from = emailData[1];
                    if (emailData[2] == "")
                    {
                        MessageBox.Show("Missing email data 'to'");
                        return;
                    }
                    string to = emailData[2];
                    if (emailData[3] == "")
                    {
                        MessageBox.Show("Missing email data 'from password'");
                        return;
                    }
                    string frompass = emailData[3];
                    if (emailData[4] == "")
                    {
                        MessageBox.Show("Missing email data 'host'");
                        return;
                    }
                    string host = emailData[4];
                    if (emailData[5] == "")
                    {
                        MessageBox.Show("Missing email data 'port'");
                        return;
                    }
                    string port = emailData[5];
                    string crypt = StringCipherHelper.Decrypt(frompass, "Cirtey1979!");

                    Email.SendMail(from, Email.ExtractMails(to, ','), crypt, subject, body, host, Convert.ToInt32(port),
                                   "Trade alerts");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("Send Email Error");
                Log.WriteLog(ex.ToString());
            }
        }

        /// <summary>
        /// 	Sends the email.
        /// </summary>
        /// <param name="subject"> The subject. </param>
        /// <param name="body"> The body. </param>
        /// <param name="ratioAlert"> if set to <c>true</c> [ratio alert]. </param>
        /// <param name="ratioAlertNeg"> if set to <c>true</c> [ratio alert neg]. </param>
        /// <param name="flowAlert"> if set to <c>true</c> [flow alert]. </param>
        public void SendEmail(string subject, string body, bool ratioAlert, bool ratioAlertNeg, bool flowAlert)
        {
            try
            {
                List<string> emailData = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
                if (emailData.Any())
                {
                    string from = emailData[1];
                    string to = emailData[2];
                    string frompass = emailData[3];
                    string crypt = StringCipherHelper.Decrypt(frompass, "Cirtey1979!");
                    string host = emailData[4];
                    string port = emailData[5];


                    if (ratioAlert || flowAlert || ratioAlertNeg)
                    {
                        Email.SendMail(from, Email.ExtractMails(to, ','), crypt, subject, body, host,
                                       Convert.ToInt32(port), "Trade alerts");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("WebScrapMail SendEmail");
                Log.WriteLog(ex);
            }
        }


        /// <summary>
        /// 	Sends the email.
        /// </summary>
        /// <param name="subject"> The subject. </param>
        /// <param name="body"> The body. </param>
        public void SendEmail(string subject, string body)
        {
            try
            {
                List<string> emailData = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
                if (emailData.Any())
                {
                    string sendEmail = emailData[6];
                    string from = emailData[1];
                    string to = emailData[2];
                    string frompass = emailData[3];
                    string crypt = StringCipherHelper.Decrypt(frompass, "Cirtey1979!");
                    string host = emailData[4];
                    string port = emailData[5];
                    if (sendEmail == "true")
                    {
                        Email.SendMail(from, Email.ExtractMails(to, ','), crypt, subject, body, host,
                                       Convert.ToInt32(port), "Trade alerts");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("WebScrapMail SendEmail");
                Log.WriteLog(ex);
            }
        }



        /// <summary>
        /// Sends the mail money flow.
        /// </summary>
        /// <param name="ticker">The ticker.</param>
        /// <param name="uptickdowntick">The uptickdowntick.</param>
        /// <param name="percentchange">The percentchange.</param>
        /// <param name="moneyflow">The moneyflow.</param>
        /// <param name="ratioAlert">if set to <c>true</c> [ratio alert].</param>
        /// <param name="ratioAlertNeg">if set to <c>true</c> [ratio alert neg].</param>
        /// <param name="flowAlert">if set to <c>true</c> [flow alert].</param>
        public void SendMailMoneyFlow(string ticker, string uptickdowntick, string percentchange, string moneyflow, bool ratioAlert, bool ratioAlertNeg, bool flowAlert)
        {
            string now = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff");
            string subject = ticker.Trim().ToUpper() + " money flow alert";
            string body = "Daily percentage gain on ticker: " + percentchange + ". Uptick/Downtick ratio: " +
                          uptickdowntick + "; " +
                          "$ flow: " +
                          moneyflow + ". " + "Date : " + now;
            SendEmail(subject, body, ratioAlert, ratioAlertNeg, flowAlert);
        }
    }
}