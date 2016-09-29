#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using HtmlAgilityPack;

#endregion

namespace WebScrap.Model
{
    public class ScrapInsiderAlert
    {
        public List<string> GetItems(ListBox listBox1)
        {
            List<string> items = new List<string>();
            if (listBox1 == null) return null;
            if (listBox1.Items.Count < 1) return null;
            foreach (var ticker in listBox1.Items)
            {
                if (!items.Contains(ticker.ToString()))
                    items.Add((string) ticker);
            }
            return items;
        }


        /// <summary>
        /// 	Scraps the data.
        /// </summary>
        /// <param name="frm"> The FRM. </param>
        /// <param name="listbox"> The listbox. </param>
        /// <param name="items"> The items. </param>
        /// <param name="checkBoxSoundChecked"> if set to <c>true</c> [check box sound checked]. </param>
        /// <param name="checkBoxEmailChecked"> if set to <c>true</c> [check box email checked]. </param>
        /// <param name="checkBoxTwitterChecked"> if set to <c>true</c> [check box twitter checked]. </param>
        /// <param name="checkBoxUrlChecked"> if set to <c>true</c> [check box URL checked]. </param>
        /// <param name="purchases"> The purchases. </param>
        /// <param name="sales"> The sales. </param>
        /// <param name="selectedvalue"> The selectedvalue. </param>
        /// <param name="tradetype"> The tradetype. </param>
        /// <param name="message1"> The message1. </param>
        /// <param name="message2"> The message2. </param>
        /// <param name="trade"> The trade. </param>
        public void ScrapData(Form frm, ListBox listbox, IEnumerable<string> items, bool checkBoxSoundChecked,
                              bool checkBoxEmailChecked, bool checkBoxTwitterChecked,
                              bool checkBoxUrlChecked, List<string> purchases, List<string> sales, int selectedvalue,
                              string tradetype, string message1, string message2, string trade)
        {
            try
            {
                ScrapInsiderAlert scrap = new ScrapInsiderAlert();
                foreach (var ticker in items)
                {
                    Dictionary<string, string> purchase = scrap.GetInsidersData(ticker, tradetype);
                    if (purchase.Count >= 2)
                    {
                        if (purchase["lastprice"] != "0")
                        {
                            int pvalue = Convert.ToInt32(purchase["lastvalue"]);
                            if (pvalue >= selectedvalue)
                            {
                                string data = ticker.ToUpper() + message1 +
                                              purchase["lastprice"] + " for " + purchase["lastvalue"] + " $";

                                if (!purchases.Contains(data))
                                {
                                    purchases.Add(data);
                                    ThreadHelper.ListboxAddText(frm, listbox, data);
                                    ThreadHelper.ListboxAddText(frm, listbox, " ");
                                    if (checkBoxSoundChecked)
                                    {
                                        Sound.PlayAlert("clock");
                                    }
                                    if (checkBoxEmailChecked)
                                    {
                                        List<string> list = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
                                        if (list.Count < 6)
                                        {
                                            MessageBox.Show("Not enough Email Data");
                                        }
                                        else
                                        {
                                            string subject = message2 + ticker;
                                            string body = data + " " +
                                                          @"http://openinsider.com/screener?fd=3&fdr=&td=0&tdr=&s=" +
                                                          ticker +
                                                          @"&o=&" + trade +
                                                          @"&minprice=&maxprice=&v=0&sicMin=&sicMax=&sortcol=0&maxresults=100";
                                            WebScrapMail.SendEmailAlert(subject, body);
                                        }
                                    }

                                    if (checkBoxTwitterChecked)
                                    {
                                        WebScrapMail.SendTweet(
                                            "$spy $" + data + " " + @"http://openinsider.com/screener?fd=3&fdr=&td=0&tdr=&s=" +
                                            ticker +
                                            @"&o=&" + trade +
                                            @"&minprice=&maxprice=&v=0&sicMin=&sicMax=&sortcol=0&maxresults=100",
                                            "TwitterInsiders");
                                    }

                                    if (checkBoxUrlChecked)
                                    {
                                        try
                                        {
                                            Process.Start(@"http://openinsider.com/screener?fd=3&fdr=&td=0&tdr=&s=" +
                                                          ticker +
                                                          @"&o=&" + trade +
                                                          @"&minprice=&maxprice=&v=0&sicMin=&sicMax=&sortcol=0&maxresults=100");
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.WriteLog("FormInsidersAlert ScrapData");
                                            Log.WriteLog(ex.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }


                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("FormInsidersAlert ScrapData");
                Log.WriteLog(ex.ToString());
            }
        }


        /// <summary>
        /// 	Gets the value.
        /// </summary>
        /// <param name="node"> The node. </param>
        /// <param name="data"> The data. </param>
        /// <param name="key"> The key. </param>
        /// <param name="value"> The value. </param>
        private static void GetValue(HtmlNode node, Dictionary<string, string> data, string key, string value)
        {
            try
            {
                if (node.InnerText == "-" || node.InnerText == "Infinity%")
                {
                    data.Add(key, "0");
                }
                else
                {
                    string datum = null;
                    if (node.InnerText.Contains("%") && !node.InnerText.Contains(value + " at $"))
                    {
                        datum = node.InnerText.Replace("%", string.Empty);
                    }
                        // value last insider purchase
                    else if (node.InnerText.Contains("$") && node.InnerText.Contains(",") &&
                             !node.InnerText.Contains(value + " at $"))
                    {
                        string tmpdatum = node.InnerText.Replace(",", string.Empty);
                        datum = tmpdatum.Substring(1, tmpdatum.Length - 1);
                    }
                    else if (node.InnerText.Contains(",") && !node.InnerText.Contains(value + " at $"))
                    {
                        datum = node.InnerText.Replace(",", string.Empty);
                    }
                        // price of last purchase
                    else if (node.InnerText.Contains("$") && node.InnerText.Contains(value + " at $"))
                    {
                        string[] words = node.InnerText.Split('$');
                        int numElements = words.Count();
                        if (numElements > 1)
                        {
                            if (words[1].Contains(","))
                            {
                                string value1 = words[1].Replace(",", string.Empty);
                                words[1] = value1.Replace(",", ".");
                            }
                            datum = words[1];
                        }
                    }


                    else
                    {
                        datum = node.InnerText;
                    }
                    if (datum != null) data.Add(key, datum.Replace('$',' ').Replace('-',' ').Replace('+',' '));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("Getvalue Error");
                Log.WriteLog(ex.ToString());
            }
        }


        public List<string> GetInsidersTickers(string action)
        {
            try
            {
                List<string> data = new List<string>();

                string insidertrade = null;

                if (action == "Purchase")
                {
                    insidertrade =
                        @"http://openinsider.com/screener?fd=1&fdr=&td=0&tdr=&s=&o=&t=p&minprice=&maxprice=&v=0&sicMin=&sicMax=&sortcol=8&maxresults=100&excludeDerivRelated=1";
                    //*[@id="tablewrapper"]/a[1]
                }


                if (action == "Sale")
                {
                    insidertrade =
                        @"http://openinsider.com/screener?fd=1&fdr=&td=0&tdr=&s=&o=&t=s&minprice=&maxprice=&v=0&sicMin=&sicMax=&sortcol=8&maxresults=100&excludeDerivRelated=1";
                    //*[@id="tablewrapper"]/a[1]
                }
                if (action != "Sale" && action != "Purchase") return null;


                var nodesInsPur = WebScrapHelper.LoadHtmlDoc(insidertrade, "//*[@id='results']/a");

                foreach (var node in nodesInsPur)
                {
                    if (String.IsNullOrEmpty(node.InnerText)) break;
                    data.Add(node.InnerText);
                }

                var noDupes = data.Distinct().ToList();

                return noDupes;
            }
            catch (Exception ex)
            {
                Log.WriteLog("GetInsidersTickers error");
                Log.WriteLog(ex.ToString());
                return null;
            }
        }


        public Dictionary<string, string> GetInsidersData(string ticker, string action)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();

                string insidertrade = null;

                if (action == "Purchase")
                {
                    // @"http://openinsider.com/screener?fd=0&fdr=&td=0&tdr=&s=" + ticker +
                    // @"&o=&t=p&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1";
                    insidertrade =
                          @"http://openinsider.com/screener?fd=0&fdr=&td=0&tdr=&s=" + ticker +
                     @"&o=&t=p&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1";
                    //@"http://openinsider.com/screener?s="+ticker+@"&fd=1&fdr=&td=0&tdr=&o=&t=p&pl=0&ph=&v=&vh=&ocl=&och=&ll=&lh=&sicMin=&sicMax=&sortcol=0&cnt=100&excludeDerivRelated=1&daysago=0";
                }


                if (action == "Sale")
                {
                  //  @"http://openinsider.com/screener?fd=0&fdr=&td=0&tdr=&s=" + ticker +
                  //@"&o=&t=s&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1";

                    insidertrade =
                        //@"http://openinsider.com/screener?s="+ticker+@"&fd=1&fdr=&td=0&tdr=&o=&t=s&pl=0&ph=&v=&vh=&ocl=&och=&ll=&lh=&sicMin=&sicMax=&sortcol=0&cnt=100&excludeDerivRelated=1&daysago=0";

                      @"http://openinsider.com/screener?fd=0&fdr=&td=0&tdr=&s=" + ticker +
                    @"&o=&t=s&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1";



                }
                if (action != "Sale" && action != "Purchase") return null;


                var nodesInsPur = WebScrapHelper.LoadHtmlDoc(insidertrade, "//td");


                int j = 0;
                bool containsTrade = false;
                if (nodesInsPur != null)
                {
                    foreach (var node in nodesInsPur)
                    {
                        if (nodesInsPur.Count < 78)
                        {
                            data.Add("lastprice", "0");
                            data.Add("lastvalue", "0");
                            break;
                        }
                        j++;


                        if (j == 78)
                        {
                            if (node.InnerText.Contains('$'))
                            {
                                GetValue(node, data, "lastprice", action);
                                containsTrade = true;
                            }
                            else
                            {
                                data.Add("lastprice", "0");
                                data.Add("lastvalue", "0");
                                break;
                            }
                        }
                        if (containsTrade)
                        {
                            if (j == 82)
                            {
                                GetValue(node, data, "lastvalue", action);
                                containsTrade = false;
                                break;
                            }
                        }
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Log.WriteLog("GetInsidersData error");
                Log.WriteLog(ex.ToString());
                return null;
            }
        }
    }
}