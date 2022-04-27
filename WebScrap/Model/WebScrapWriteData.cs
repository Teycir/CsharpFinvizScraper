#region

using System;
using System.IO;
using System.Xml.Linq;
using Helpers;

#endregion

namespace WebScrap.Model
{
    public class WebScrapWriteData
    {
        /// <summary>
        /// 	Gets the filename.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="extension"> The extension. </param>
        /// <returns> </returns>
        private static string GetFilename(string name, string extension)
        {
            return name
                   + extension;
        }


        /// <summary>
        /// 	Writes the twitter data.
        /// </summary>
        /// <param name="cKey"> The c key. </param>
        /// <param name="cSecret"> The c secret. </param>
        /// <param name="accessToken"> The access token. </param>
        /// <param name="tokenSecret"> The token secret. </param>
        /// <param name="xmlfilename"> The xmlfilename. </param>
        /// <returns> </returns>
        public static string WriteTwitterData(string cKey, string cSecret, string accessToken,
                                              string tokenSecret, string xmlfilename)
        {
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//" +
                                  GetFilename(xmlfilename, ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Date", DateTime.Now.ToString()),
                                                 new XElement("cKey", cKey),
                                                 new XElement("cSecret", cSecret),
                                                 new XElement("accessToken", accessToken),
                                                 new XElement("tokenSecret", tokenSecret))
                    ;
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Twitter params succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog("WebScrapWriteData WriteTwitterData");
                Log.WriteLog(ex);
                return "Twitter data entry Error";
            }
        }


        /// <summary>
        /// 	Writes the expiration data.
        /// </summary>
        /// <returns> </returns>
        public static string WriteExpirationData(string datestart)
        {
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//"
                                  + GetFilename("Licence", ".xml");
                File.Delete(filename);


                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Licence", datestart)
                    );


                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Activation params succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog("WebScrapWriteData WriteTwitterData");
                Log.WriteLog(ex);
                return "Activation data entry Error";
            }
        }


        /// <summary>
        /// 	Writes the email data.
        /// </summary>
        /// <param name="senderEmail"> The sender email. </param>
        /// <param name="receiverEmail"> The receiver email. </param>
        /// <param name="senderEmailPassword"> The sender email password. </param>
        /// <param name="senderEmailhost"> The sender emailhost. </param>
        /// <param name="senderEmaiPort"> The sender emai port. </param>
        /// <returns> </returns>
        public static string WriteEmailData(string senderEmail, string receiverEmail, string senderEmailPassword,
                                            string senderEmailhost, string senderEmaiPort)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//"
                                  + GetFilename("EmailData", ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Date", DateTime.Now.ToString()),
                                                 new XElement("senderEmail", senderEmail),
                                                 new XElement("receiverEmail", receiverEmail),
                                                 new XElement("senderEmailPassword", senderEmailPassword),
                                                 new XElement("senderEmailhost", senderEmailhost),
                                                 new XElement("senderEmaiPort", senderEmaiPort)
                    );
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Email params succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return "Email Error";
            }
        }


        /// <summary>
        /// 	Writes the data.
        /// </summary>
        /// <param name="server"> The server. </param>
        /// <param name="database"> The database. </param>
        /// <param name="password"> The password. </param>
        /// <param name="store"> The store. </param>
        /// <returns> </returns>
        public static string WriteDbData(string server,  string database)

        {
            //just in case: we protect code with try.
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//"
                                  + GetFilename("DbData", ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Date", DateTime.Now.ToString()),
                                                 new XElement("server", server),
                                                 new XElement("database", database)
       
                    );
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "DB storage succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return "DB Error";
            }
        }


        /// <summary>
        /// 	Writes the data.
        /// </summary>
        /// <param name="tickers"> The tickers. </param>
        /// <returns> </returns>
        public static string WriteDailyFuturesTickers(string tickers)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//"
                                  + GetFilename("DailyFuturesTickers", ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Tickers", tickers)
                    );
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Futures daily tickers storage succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return "Futures Daily Error";
            }
        }


        /// <summary>
        /// 	Writes the data.
        /// </summary>
        /// <param name="tickers"> The tickers. </param>
        /// <returns> </returns>
        public static string WriteHourlyFuturesTickers(string tickers)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//"
                                  + GetFilename("HourlyFuturesTickers", ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Tickers", tickers)
                    );
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Futures hourly tickers storage succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return "Futures hourly Error";
            }
        }





        /// <summary>
        /// 	Writes the data.
        /// </summary>
        /// <param name="tickers"> The tickers. </param>
        /// <returns> </returns>
        public static string WriteqHourlyFuturesTickers(string tickers)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = FileHelper.GetRoot() + "//InsidersTracker//"
                                  + GetFilename("qHourlyFuturesTickers", ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Tickers", tickers)
                    );
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Futures 15 min tickers storage succeeded";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return "Futures 15 min Error";
            }
        }


        /// <summary>
        /// 	Writes the data.
        /// </summary>
        /// <param name="tickerName"> Name of the ticker. </param>
        /// <param name="ticker1"> The ticker1. </param>
        /// <param name="ticker2"> The ticker2. </param>
        /// <param name="ticker3"> The ticker3. </param>
        /// <param name="ticker4"> The ticker4. </param>
        /// <param name="ticker5"> The ticker5. </param>
        /// <param name="ticker6"> The ticker6. </param>
        /// <param name="ticker7"> The ticker7. </param>
        /// <param name="ticker8"> The ticker8. </param>
        /// <param name="ticker9"> The ticker9. </param>
        /// <param name="ticker10"> The ticker10. </param>
        /// <param name="ticker1FAlert"> The ticker1 F alert. </param>
        /// <param name="ticker2FAlert"> The ticker2 F alert. </param>
        /// <param name="ticker3FAlert"> The ticker3 F alert. </param>
        /// <param name="ticker4FAlert"> The ticker4 F alert. </param>
        /// <param name="ticker5FAlert"> The ticker5 F alert. </param>
        /// <param name="ticker6FAlert"> The ticker6 F alert. </param>
        /// <param name="ticker7FAlert"> The ticker7 F alert. </param>
        /// <param name="ticker8FAlert"> The ticker8 F alert. </param>
        /// <param name="ticker9FAlert"> The ticker9 F alert. </param>
        /// <param name="ticker10FAlert"> The ticker10 F alert. </param>
        /// <param name="ticker1RAlert"> The ticker1 R alert. </param>
        /// <param name="ticker2RAlert"> The ticker2 R alert. </param>
        /// <param name="ticker3RAlert"> The ticker3 R alert. </param>
        /// <param name="ticker4RAlert"> The ticker4 R alert. </param>
        /// <param name="ticker5RAlert"> The ticker5 R alert. </param>
        /// <param name="ticker6RAlert"> The ticker6 R alert. </param>
        /// <param name="ticker7RAlert"> The ticker7 R alert. </param>
        /// <param name="ticker8RAlert"> The ticker8 R alert. </param>
        /// <param name="ticker9RAlert"> The ticker9 R alert. </param>
        /// <param name="ticker10RAlert"> The ticker10 R alert. </param>
        /// <param name="ticker1RAlertNeg"> The ticker1 R alert neg. </param>
        /// <param name="ticker2RAlertNeg"> The ticker2 R alert neg. </param>
        /// <param name="ticker3RAlertNeg"> The ticker3 R alert neg. </param>
        /// <param name="ticker4RAlertNeg"> The ticker4 R alert neg. </param>
        /// <param name="ticker5RAlertNeg"> The ticker5 R alert neg. </param>
        /// <param name="ticker6RAlertNeg"> The ticker6 R alert neg. </param>
        /// <param name="ticker7RAlertNeg"> The ticker7 R alert neg. </param>
        /// <param name="ticker8RAlertNeg"> The ticker8 R alert neg. </param>
        /// <param name="ticker9RAlertNeg"> The ticker9 R alert neg. </param>
        /// <param name="ticker10RAlertNeg"> The ticker10 R alert neg. </param>
        /// <returns> </returns>
        public static string WriteTickerData(string tickerName, string ticker1, string ticker2, string ticker3,
                                             string ticker4,
                                             string ticker5, string ticker6, string ticker7, string ticker8,
                                             string ticker9, string ticker10, string ticker1FAlert, string ticker2FAlert,
                                             string ticker3FAlert, string ticker4FAlert, string ticker5FAlert,
                                             string ticker6FAlert, string ticker7FAlert, string ticker8FAlert,
                                             string ticker9FAlert, string ticker10FAlert,
                                             string ticker1RAlert,
                                             string ticker2RAlert, string ticker3RAlert, string ticker4RAlert,
                                             string ticker5RAlert, string ticker6RAlert, string ticker7RAlert,
                                             string ticker8RAlert, string ticker9RAlert, string ticker10RAlert,
                                             string ticker1RAlertNeg,
                                             string ticker2RAlertNeg, string ticker3RAlertNeg, string ticker4RAlertNeg,
                                             string ticker5RAlertNeg, string ticker6RAlertNeg, string ticker7RAlertNeg,
                                             string ticker8RAlertNeg, string ticker9RAlertNeg, string ticker10RAlertNeg
            )
        {
            //just in case: we protect code with try.
            try
            {
                Directory.CreateDirectory(FileHelper.GetRoot() + "//InsidersTracker//tickers//");
                string filename = FileHelper.GetRoot() +"//InsidersTracker//tickers//"
                                  + GetFilename(tickerName, ".xml");
                File.Delete(filename);
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement(
                    "DataEntry",
                    new XElement("Date", DateTime.Now.ToString()),
                    new XElement("ticker1", ticker1.Trim().ToUpper()),
                    new XElement("ticker2", ticker2.Trim().ToUpper()),
                    new XElement("ticker3", ticker3.Trim().ToUpper()),
                    new XElement("ticker4", ticker4.Trim().ToUpper()),
                    new XElement("ticker5", ticker5.Trim().ToUpper()),
                    new XElement("ticker1FAlert", ticker1FAlert.Trim().ToUpper()),
                    new XElement("ticker2FAlert", ticker2FAlert.Trim().ToUpper()),
                    new XElement("ticker3FAlert", ticker3FAlert.Trim().ToUpper()),
                    new XElement("ticker4FAlert", ticker4FAlert.Trim().ToUpper()),
                    new XElement("ticker5FAlert", ticker5FAlert.Trim().ToUpper()),
                    new XElement("ticker1RAlert", ticker1RAlert.Trim().ToUpper()),
                    new XElement("ticker2RAlert", ticker2RAlert.Trim().ToUpper()),
                    new XElement("ticker3RAlert", ticker3RAlert.Trim().ToUpper()),
                    new XElement("ticker4RAlert", ticker4RAlert.Trim().ToUpper()),
                    new XElement("ticker5RAlert", ticker5RAlert.Trim().ToUpper()),
                    new XElement("ticker1RAlertNeg", ticker1RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker2RAlertNeg", ticker2RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker3RAlertNeg", ticker3RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker4RAlertNeg", ticker4RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker5RAlertNeg", ticker5RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker6", ticker6.Trim().ToUpper()),
                    new XElement("ticker7", ticker7.Trim().ToUpper()),
                    new XElement("ticker8", ticker8.Trim().ToUpper()),
                    new XElement("ticker9", ticker9.Trim().ToUpper()),
                    new XElement("ticker10", ticker10.Trim().ToUpper()),
                    new XElement("ticker6FAlert", ticker6FAlert.Trim().ToUpper()),
                    new XElement("ticker7FAlert", ticker7FAlert.Trim().ToUpper()),
                    new XElement("ticker8FAlert", ticker8FAlert.Trim().ToUpper()),
                    new XElement("ticker9FAlert", ticker9FAlert.Trim().ToUpper()),
                    new XElement("ticker10FAlert", ticker10FAlert.Trim().ToUpper()),
                    new XElement("ticker6RAlert", ticker6RAlert.Trim().ToUpper()),
                    new XElement("ticker7RAlert", ticker7RAlert.Trim().ToUpper()),
                    new XElement("ticker8RAlert", ticker8RAlert.Trim().ToUpper()),
                    new XElement("ticker9RAlert", ticker9RAlert.Trim().ToUpper()),
                    new XElement("ticker10RAlert", ticker10RAlert.Trim().ToUpper()),
                    new XElement("ticker6RAlertNeg", ticker6RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker7RAlertNeg", ticker7RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker8RAlertNeg", ticker8RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker9RAlertNeg", ticker9RAlertNeg.Trim().ToUpper()),
                    new XElement("ticker10RAlertNeg", ticker10RAlertNeg.Trim().ToUpper())
                    );


                //
                sw.WriteLine(xmlEntry);
                sw.Close();
                return "Ticker data recorded";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return "Ticker saving Error!";
            }
        }
    }
}