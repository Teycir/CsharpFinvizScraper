#region

using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

#endregion

namespace Helpers
{
    public class Email
    {
        /// <summary>
        /// 	Sends the mail.
        /// </summary>
        /// <param name="from"> From. </param>
        /// <param name="to"> To. </param>
        /// <param name="frompass"> The frompass. </param>
        /// <param name="subj"> The subj. </param>
        /// <param name="bod"> The bod. </param>
        /// <param name="host"> The host. </param>
        /// <param name="port"> The port. </param>
        public static void SendMail(string from, List<string> to, string frompass, string subj, string bod, string host,
                                    int port, string fromdisplay)
        {
            foreach (var toaddress in to)
            {
                var fromAddress = new MailAddress(from, fromdisplay);
                var toAddress = new MailAddress(toaddress);
                string fromPassword = frompass;
                string subject = subj;
                string body = bod;

                var smtp = new SmtpClient
                               {
                                   Host = host,
                                   Port = port,
                                   EnableSsl = true,
                                   DeliveryMethod = SmtpDeliveryMethod.Network,
                                   UseDefaultCredentials = false,
                                   Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                               };
                using (var message = new MailMessage(fromAddress, toAddress)
                                         {
                                             Subject = subject,
                                             Body = body
                                         })
                {
                    smtp.Send(message);
                }
            }
        }

        public static List<string> ExtractMails(string mail, char separator)
        {
            List<string> toadressList = new List<string>();
            string[] toadress = mail.Trim().Split(separator);
            foreach (var s in toadress)
            {
                toadressList.Add(s);
            }
            return toadressList;
        }
    }
}