#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.Model
{
    public class ScrapFuturesAlert
    {
        private Dictionary<string, string> GetTechnicalData(string url)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();

                List<string> dataPath = new List<string>();

                const string price = @"//*[@id='last_last']";
                const string percent = @"//*[@id='quotes_summary_current_data']/div/div[2]/div[1]/span[4]/text()";

                const string s3 = @"//*[@id='curr_table']/tbody/tr[1]/td[2]";
                const string r3 = @"//*[@id='curr_table']/tbody/tr[1]/td[8]";
                const string s2 = @"//*[@id='curr_table']/tbody/tr[1]/td[3]";
                const string r2 = @"//*[@id='curr_table']/tbody/tr[1]/td[7]";
                const string s1 = @"//*[@id='curr_table']/tbody/tr[1]/td[4]";
                const string r1 = @"//*[@id='curr_table']/tbody/tr[1]/td[6]";
               
                dataPath.Add(price);
                dataPath.Add(percent);
                dataPath.Add(s3);
                dataPath.Add(r3);
                dataPath.Add(s2);
                dataPath.Add(r2);
            
                dataPath.Add(s1);
                dataPath.Add(r1);



             
                var nodesPt = WebScrapHelper.LoadHtmlDoc(url, "//td");

                if (nodesPt != null)
                {
                  
                    foreach (var node in nodesPt)
                    {
                        if (node.InnerText.Trim().Equals("RSI(14)"))
                        {
                            data.Add("rsi", node.NextSibling.NextSibling.InnerText.Trim());
                        }


                        if (node.InnerText.Trim().Equals("MA20"))
                        {
                            if (node.NextSibling.NextSibling.InnerText.Trim().Contains("Buy"))
                                data.Add("sma20", "Buy");
                            else
                                data.Add("sma20", "Sell");
                        }

                        if (node.InnerText.Trim().Equals("MA50"))
                        {
                            if (node.NextSibling.NextSibling.InnerText.Trim().Contains("Buy"))
                                data.Add("sma50", "Buy");
                            else
                                data.Add("sma50", "Sell");
                        }
                    }
                }
            



                List<string> dataFinal = WebScrapHelper.GetWebScrapData(url, dataPath);



                if (dataFinal == null) return null;
                if (dataFinal.Count != 8) return null;
                if (dataFinal[3] == dataFinal[2] || (dataFinal[4] == dataFinal[5]) || (dataFinal[2] == dataFinal[4]) ||
                    (dataFinal[3] == dataFinal[5]))
                {
                    

                    data.Add("s3", null);
                    data.Add("r3", null);
                    data.Add("s2", null);
                    data.Add("r2", null);
                    data.Add("s1", null);
                    data.Add("r1", null);
                    data.Add("price", dataFinal[0]);
                    data.Add("percent", dataFinal[1]);
                   
                }
                else
                {
                    data.Add("price", dataFinal[0]);
                    data.Add("percent", dataFinal[1]);
                    data.Add("s3", dataFinal[2]);
                    data.Add("r3", dataFinal[3]);
                    data.Add("s2", dataFinal[4]);
                    data.Add("r2", dataFinal[5]);
                    data.Add("s1", dataFinal[6]);
                    data.Add("r1", dataFinal[7]);
                  
                }

                return data;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                return null;
            }
        }


        private bool RsiAlert(string rsi, double ob, double os)
        {
            if (String.IsNullOrEmpty(rsi)) return false;

            double rsival = Convert.ToDouble(rsi.Replace('.', ','));
            if (rsival > ob || rsival < os) return true;
            return false;
        }



        private string SmaAlert(string sma20,string sma50)
        {
            if ( String.IsNullOrEmpty(sma20) || String.IsNullOrEmpty(sma50)) return null;
            if (sma20.ToLower() == "buy" && sma50.ToLower() == "buy" ) return "TRENDING UP";
            if (sma20.ToLower() == "sell" && sma50.ToLower() == "sell") return "TRENDING DOWN";
            return null;
        }


        private bool PivotAlertFilter(string pp, string price, string type)
        {
            if (String.IsNullOrEmpty(pp)) return false;
            if (String.IsNullOrEmpty(price)) return false;
            if (price.Contains(','))
            {
                price = price.Replace(',', ' ');
                price = price.Replace('.', ',').Trim();
            }
            else
            {
                price = price.Replace('.', ',').Trim();
            }
            double ppval = Convert.ToDouble(pp.Replace('.', ','));

            double priceval = Convert.ToDouble(price);
            if (type.ToUpper().Trim() == "S")
            {
                if (priceval < ppval) return true;
            }

            if (type.ToUpper().Trim() == "R")
            {
                if (priceval > ppval) return true;
            }

            return false;
        }



        public void RsiDisplayAlerts(TextBox text, string rsi, int maxval, int minval)
        {
            if (string.IsNullOrEmpty(rsi)) return;

            double rsival = Convert.ToDouble(rsi.Replace('.', ','));
            if (rsival > maxval)
            {
                ThreadHelper.SetTextBoxBackColor(text, Color.LightPink);
            }
            else if (rsival < minval)
            {
                ThreadHelper.SetTextBoxBackColor(text, Color.GreenYellow);
            }
            else
            {
                ThreadHelper.SetTextBoxBackColor(text, Color.LightGray);
            }
        }


        public string SmaDisplayAlerts(string dsma20, string dsma50, string hsma20, string hsma50, 
                              string ticker, Form frm, Label label,
                             string url)
        {
            string dalertSma = SmaAlert(dsma20, dsma50);
            string halertSma = SmaAlert(hsma20, hsma50);
            string message = null;
            if (dalertSma==null)
            {
                message = "<=>";
                ThreadHelper.SetText(frm, label, " <=> ");
              
            }
            else if (dalertSma.ToUpper().Contains("DOWN"))
            {
                message = "↓↓";
                ThreadHelper.SetText(frm, label, " ↓↓ ");
             
            }
            else if (dalertSma.ToUpper().Contains("UP"))
            {
                message = "↑↑";
                ThreadHelper.SetText(frm, label, " ↑↑ ");
            
            }

            if (halertSma == null)
            {
                message += "<=>";
                ThreadHelper.SetText(frm, label, message);
             
            }
            else if (halertSma.ToUpper().Contains("DOWN"))
            {
                message += "↓↓";
                ThreadHelper.SetText(frm, label, message);
              
            }
            else if (halertSma.ToUpper().Contains("UP"))
            {
                message += "↑↑";
                ThreadHelper.SetText(frm, label, message);
               
            }
            if(message =="↑↑↑↑")
            {
                ThreadHelper.LabelSetFontColor(label, Color.Green);
            }
            else if (message == "↓↓↓↓")
            {
                ThreadHelper.LabelSetFontColor(label, Color.Red);
            }
            else
            {
                ThreadHelper.LabelSetFontColor(label, Color.Blue);
            }


            return message;
        }





        public void SmaAlerts(string sma20, string sma50,
                               string message, string ticker, Form frm, ListBox lst, bool sound,
                              bool mail, bool tweet, string url, string alarmtype, string filter,List<string> listalerts)
        {
            if (!filter.ToUpper().Contains(ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim())) return;
            string alertSma = SmaAlert(sma20, sma50);

            if (alertSma!=null)
            {
                string item =
                    (ticker + " " + message + " " + alertSma + " => " + DateTime.Now.ToShortTimeString()).Trim();
                    

                string itemextract = null;
                if (item.Contains(':'))
                    itemextract = item.Split(':')[0].Trim();
                if (!listalerts.Contains(itemextract))
                    listalerts.Add(itemextract);
                else
                    return;


                ThreadHelper.ListboxAddText(frm, lst, item);
                    ThreadHelper.ListboxSetFontColor(lst, Color.Green);
                    if (sound)
                    {
                        if (!string.IsNullOrEmpty(filter))
                        {
                            if (
                                filter.ToUpper().Contains(
                                    ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim()))
                            {
                                Sound.PlayAlert(alarmtype);
                            }
                        }
                    }
                    if (mail)
                    {
                        if (!string.IsNullOrEmpty(filter))
                        {
                            if (
                                filter.ToUpper().Contains(
                                    ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim()))
                            {
                                string now = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff");
                                string subject = item.Split('=')[0].Trim();
                                string body = now + " " + item.Split('=')[0].Trim();
                                WebScrapMail.SendEmailAlert(subject, body);
                            }
                        }
                        ;
                    }
                    if (tweet)
                    {
                        WebScrapMail.SendTweet("$spy " + item.Split('=')[0].Trim() + " " + url, "TwitterFutures");
                    }
                }
            
        }


        /// <summary>
        /// Pivots the alerts.
        /// </summary>
        /// <param name="pp">The pp.</param>
        /// <param name="price">The price.</param>
        /// <param name="ppType">Type of the pp.</param>
        /// <param name="message">The message.</param>
        /// <param name="ticker">The ticker.</param>
        /// <param name="listalerts">The listalerts.</param>
        /// <param name="sound">if set to <c>true</c> [sound].</param>
        /// <param name="mail">if set to <c>true</c> [mail].</param>
        /// <param name="tweet">if set to <c>true</c> [tweet].</param>
        /// <param name="frm">The FRM.</param>
        /// <param name="lst">The LST.</param>
        /// <param name="url">The URL.</param>
        /// <param name="alarmtype">The alarmtype.</param>
        /// <param name="filter">The filter.</param>
        public void PivotAlerts(string pp, string price, string ppType,
                                string message, string ticker, List<string> listalerts, bool sound,
                                bool mail, bool tweet, Form frm, ListBox lst, string url, string alarmtype,
                                string filter)
        {
            if (!filter.ToUpper().Contains(ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim())) return;
            bool alertR2D = PivotAlertFilter(pp, price, ppType);

            if (alertR2D)
            {
                string item = (ticker + " " + message + " " + pp + " => " + DateTime.Now.ToShortTimeString()).Trim()
                    ;

                string itemextract = null;
                if (item.Contains('='))
                {
                    itemextract = item.Split('=')[0].Trim();
                }

                if (!listalerts.Contains(itemextract))
                {
                    listalerts.Add(itemextract);
                    ThreadHelper.ListboxAddText(frm, lst, item);
                    ThreadHelper.ListboxSetFontColor(lst, Color.Blue);
                    if (sound)
                    {
                        if (!String.IsNullOrEmpty(filter))
                        {
                            if (
                                filter.ToUpper().Contains(
                                    ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim()))
                            {
                                Sound.PlayAlert(alarmtype);
                            }
                        }
                    }
                    if (mail)
                    {
                        if (!String.IsNullOrEmpty(filter))
                        {
                            if (
                                filter.ToUpper().Contains(
                                    ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim()))
                            {
                                string now = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff");
                                string subject = itemextract;
                                string body = now + " " + itemextract;
                                WebScrapMail.SendEmailAlert(subject, body);
                            }
                        }
                        ;
                    }
                    if (tweet)
                    {
                        WebScrapMail.SendTweet("$spy " + itemextract + " " + url, "TwitterFutures");
                    }
                }
            }
        }


        /// <summary>
        /// Rsis the alerts.
        /// </summary>
        /// <param name="dictio">The dic.</param>
        /// <param name="ticker">The ticker.</param>
        /// <param name="message">The message.</param>
        /// <param name="maxval">The maxval.</param>
        /// <param name="minval">The minval.</param>
        /// <param name="alerts">The alerts.</param>
        /// <param name="frm">The FRM.</param>
        /// <param name="lst">The LST.</param>
        /// <param name="sound">if set to <c>true</c> [sound].</param>
        /// <param name="mail">if set to <c>true</c> [mail].</param>
        /// <param name="tweet">if set to <c>true</c> [tweet].</param>
        /// <param name="url">The URL.</param>
        /// <param name="alarmtype">The alarmtype.</param>
        /// <param name="filter">The filter.</param>
        public void RsiAlerts(string dictio, string ticker, string message,
                              double maxval, double minval, List<string> alerts, Form frm, ListBox lst, bool sound,
                              bool mail, bool tweet, string url, string alarmtype, string filter)
        {
            if (!filter.ToUpper().Contains(ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim())) return;
            bool alertEsRsiD = RsiAlert(dictio, maxval, minval);
            if (alertEsRsiD)
            {
                string item = ("* RSI: "+ ticker + " " + message + " " + dictio + " => " + DateTime.Now.ToShortTimeString() + " *").Trim();
                string itemextract = null;
                string itemextractHour = null;
                if(item.Contains('.'))
                {
                     itemextract = item.Split('.')[0].Trim();
                }
                if (item.Contains('>'))
                {
                    itemextractHour = item.Split('>')[1].Trim().Substring(0,2);
                }
                string itemMarker = ticker + itemextract;
                string itemMarkerHour = "rsi"+ ticker + itemextractHour;
               

                if ((alerts.Contains(itemMarker))){return;}
                if ((alerts.Contains(itemMarkerHour))) { return; }
                if (!alerts.Contains(itemMarker)) alerts.Add((itemMarker));
                if (!alerts.Contains(itemMarkerHour)) alerts.Add((itemMarkerHour));
                
                  
                   ThreadHelper.ListboxAddText(frm, lst, item);
                   ThreadHelper.ListboxSetFontColor(lst, Color.Red);
                    if (sound)
                    {
                        if (!String.IsNullOrEmpty(filter))
                        {
                            if (
                                filter.ToUpper().Contains(
                                    ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim()))
                            {
                                Sound.PlayAlert(alarmtype);
                            }
                        }
                    }
                    if (mail)
                    {
                        if (!String.IsNullOrEmpty(filter))
                        {
                            if (
                                filter.ToUpper().Contains(
                                    ticker.ToUpper().Replace('#', ' ').Replace('F', ' ').Replace('_', ' ').Trim()))
                            {
                                string now = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff");
                                string subject = itemextract;
                                string body = now + " " + itemextract;
                                WebScrapMail.SendEmailAlert(subject, body);
                            }
                        }
                        ;
                    }
                    if (tweet)
                    {
                        WebScrapMail.SendTweet("$spy " + itemextract + " " + url, "TwitterFutures");
                    }
                
            }
        }


        public Dictionary<string, string> GetEsDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/indices/us-spx-500-futures-technical?period=86400");
        }

        public Dictionary<string, string> GetEsHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/indices/us-spx-500-futures-technical?period=900");
        }


        public Dictionary<string, string> GetNqDaily()
        {
            return GetTechnicalData(@" http://www.investing.com/indices/nq-100-futures-technical?period=86400");
        }

        public Dictionary<string, string> GetNqHourly()
        {
            return GetTechnicalData(@" http://www.investing.com/indices/nq-100-futures-technical?period=900");
        }


        public Dictionary<string, string> GetYmDaily()
        {
            return GetTechnicalData(@" http://www.investing.com/indices/us-30-technical?period=86400");
        }

        public Dictionary<string, string> GetYmHourly()
        {
            return GetTechnicalData(@" http://www.investing.com/indices/us-30-technical?period=900");
        }


        public Dictionary<string, string> GetVxDaily()
        {
            return GetTechnicalData(@" http://www.investing.com/indices/volatility-s-p-500-technical?period=86400");
        }

        public Dictionary<string, string> GetVxHourly()
        {
            return GetTechnicalData(@" http://www.investing.com/indices/volatility-s-p-500-technical?period=900");
        }


        public Dictionary<string, string> GetGcDaily()
        {
            return GetTechnicalData(@" http://www.investing.com/commodities/gold-technical?period=86400");
        }


        public Dictionary<string, string> GetGcHourly()
        {
            return GetTechnicalData(@" http://www.investing.com/commodities/gold-technical?period=900");
        }


        public Dictionary<string, string> GetHgDaily()
        {
            return GetTechnicalData(@" http://www.investing.com/commodities/copper-technical?period=86400");
        }


        public Dictionary<string, string> GetHgHourly()
        {
            return GetTechnicalData(@" http://www.investing.com/commodities/copper-technical?period=900");
        }

        public Dictionary<string, string> GetNgDaily()
        {
            return GetTechnicalData(@" http://www.investing.com/commodities/natural-gas-technical?period=86400");
        }


        public Dictionary<string, string> GetNgHourly()
        {
            return GetTechnicalData(@" http://www.investing.com/commodities/natural-gas-technical?period=900");
        }


        public Dictionary<string, string> GetZcDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-corn-technical?period=86400");
        }


        public Dictionary<string, string> GetZcHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-corn-technical?period=900");
        }


        public Dictionary<string, string> GetZlDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-soybean-oil-technical?period=86400");
        }


        public Dictionary<string, string> GetZlHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-soybean-oil-technical?period=900");
        }


        public Dictionary<string, string> GetCcDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-cocoa-technical?period=86400");
        }


        public Dictionary<string, string> GetCcHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-cocoa-technical?period=900");
        }


        public Dictionary<string, string> GetSbDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-sugar-no11-technical?period=86400");
        }


        public Dictionary<string, string> GetSbHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-sugar-no11-technical?period=900");
        }


        public Dictionary<string, string> GetLeDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/live-cattle-technical?period=86400");
        }


        public Dictionary<string, string> GetLeHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/live-cattle-technical?period=900");
        }


        public Dictionary<string, string> GetZnDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/rates-bonds/us-10-yr-t-note-technical?period=86400");
        }


        public Dictionary<string, string> GetZnHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/rates-bonds/us-10-yr-t-note-technical?period=900");
        }


        public Dictionary<string, string> GetE6Daily()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/eur-usd-technical?period=86400");
        }


        public Dictionary<string, string> GetE6Hourly()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/eur-usd-technical?period=900");
        }


        public Dictionary<string, string> GetB6Daily()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/gbp-usd-technical?period=86400");
        }


        public Dictionary<string, string> GetB6Hourly()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/gbp-usd-technical?period=900");
        }


        public Dictionary<string, string> GetTfDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/indices/smallcap-2000-technical?period=86400");
        }


        public Dictionary<string, string> GetTfHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/indices/smallcap-2000-technical?period=900");
        }


        public Dictionary<string, string> GetDaxDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/indices/germany-30-technical?period=86400");
        }


        public Dictionary<string, string> GetDaxHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/indices/germany-30-technical?period=900");
        }


        public Dictionary<string, string> GetSiDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/silver-technical?period=86400");
        }


        public Dictionary<string, string> GetSiHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/silver-technical?period=900");
        }


        public Dictionary<string, string> GetPlDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/platinum-technical?period=86400");
        }


        public Dictionary<string, string> GetPlHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/platinum-technical?period=900");
        }


        public Dictionary<string, string> GetClDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/crude-oil-technical?period=86400");
        }


        public Dictionary<string, string> GetClHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/crude-oil-technical?period=900");
        }


        public Dictionary<string, string> GetZwDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-wheat-technical?period=86400");
        }


        public Dictionary<string, string> GetZwHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-wheat-technical?period=900");
        }


        public Dictionary<string, string> GetZsDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-soybeans-technical?period=86400");
        }


        public Dictionary<string, string> GetZsHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-soybeans-technical?period=900");
        }


        public Dictionary<string, string> GetKcDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-coffee-c-technical?period=86400");
        }


        public Dictionary<string, string> GetKcHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-coffee-c-technical?period=900");
        }


        public Dictionary<string, string> GetCtDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-cotton-no.2-technical?period=86400");
        }


        public Dictionary<string, string> GetCtHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/us-cotton-no.2-technical?period=900");
        }


        public Dictionary<string, string> GetHeDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/lean-hogs-analysis?period=86400");
        }


        public Dictionary<string, string> GetHeHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/commodities/lean-hogs-analysis?period=900");
        }


        public Dictionary<string, string> GetBundDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/rates-bonds/euro-bund-technical?period=86400");
        }


        public Dictionary<string, string> GetBundHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/rates-bonds/euro-bund-technical?period=900");
        }


        public Dictionary<string, string> GetA6Daily()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/aud-usd-technical?period=86400");
        }


        public Dictionary<string, string> GetA6Hourly()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/aud-usd-technical?period=900");
        }


        public Dictionary<string, string> GetJ6Daily()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/usd-jpy-technical?period=86400");
        }


        public Dictionary<string, string> GetJ6Hourly()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/usd-jpy-technical?period=900");
        }

        public Dictionary<string, string> GetCadDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/cad-usd-technical?period=86400");
        }


        public Dictionary<string, string> GetCadHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/cad-usd-technical?period=900");
        }


        public Dictionary<string, string> GetChfDaily()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/chf-usd-technical?period=86400");
        }


        public Dictionary<string, string> GetChfHourly()
        {
            return GetTechnicalData(@"http://www.investing.com/currencies/chf-usd-technical?period=900");
        }
    }
}