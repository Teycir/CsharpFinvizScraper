#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.XPath;
using Helpers;
using HtmlAgilityPack;

#endregion

namespace WebScrap.Model
{
    internal class Scrap : IModel
    {
        #region IModel Members

        /// <summary>
        /// 	Gets the URL.
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <param name="displayMember"> The display member. </param>
        /// <param name="connectionstring"> The connectionstring. </param>
        /// <param name="filter"> The filter. </param>
        /// <returns> </returns>
        public string GetUrl(string query, string displayMember, string connectionstring, string filter)
        {
            List<string> values;
            Helpers.DbConnect.GetValue(query, displayMember, connectionstring, out values);
            string value = @"http://finviz.com/screener.ashx?v=111&o=" + filter + "&t=";
            foreach (var ticker in values)
            {
                value += ticker + ",";
            }

            return value;
        }


        /// <summary>
        /// 	Gets the finviz tickers.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        public List<string> GetFinvizTickers(string url)
        {
            try
            {
                const decimal rounds = 400;
                ////Todo
                //const decimal rounds = 2;

                int roundFlat = (int) (rounds);
                List<int> pages = new List<int>();
                pages.Add(0);
                int increments = 1;
                for (int i = 0; i < roundFlat - 1; i++)
                {
                    increments = increments + 20;
                    pages.Add(increments);
                }

                List<string> tickers = new List<string>();

                foreach (var page in pages)
                {
                    HtmlNodeCollection nodes;
                    if (page == 0)
                    {
                        nodes = WebScrapHelper.LoadHtmlDoc(url, "//a[@class='screener-link-primary']");
                    }
                    else
                    {
                        nodes =
                            WebScrapHelper.LoadHtmlDoc(url + "&" + "r=" + page.ToString(CultureInfo.InvariantCulture),
                                                       "//a[@class='screener-link-primary']");
                    }

                    if (nodes == null)
                    {
                        tickers.Add("NO DATA");
                        continue;
                        //return tickers;
                    }
                    foreach (var v in nodes)
                    {
                        if (Regex.IsMatch(v.InnerText, "[A-Z]") && v.InnerText.Length < 5 && v.InnerText != "Help")
                        {
                            if (tickers.Contains(v.InnerText)) return tickers;
                            tickers.Add(v.InnerText);
                        }
                    }
                }


                return tickers;
            }
            catch (Exception ex)
            {
                Log.WriteLog("GetFinvizTickers");
                Log.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 	Gets the data. 
        /// </summary>
        /// <param name="ticker"> The ticker. </param>
        /// <returns> </returns>
        public List<InsidersData> GetOpenInsiderData(string ticker)
        {
            try
            {
                List<InsidersData> insidersdata = new   List<InsidersData>();
  
                // sales
                string urlPt = @"http://openinsider.com/screener?s=" + ticker 
                    + @"&o=&pl=&ph=&ll=&lh=&fd=0&fdr=&td=0&tdr=&fdlyl=&fdlyh=&daysago=&xp=1&xs=1&excludeDerivRelated=1&vl=&vh=&ocl=&och=&sic1=-1&sicl=100&sich=9999&grp=0&nfl=&nfh=&nil=&nih=&nol=&noh=&v2l=&v2h=&oc2l=&oc2h=&sortcol=0&cnt=100&page=1";
                var nodesPt = WebScrapHelper.LoadHtmlDoc(urlPt, "//td");

                if (nodesPt != null)
                {
                    foreach (var node in nodesPt)
                    {
                        if (node.InnerText.Trim().ToUpper()==ticker.ToUpper())
                        {
                            InsidersData insiderData = new InsidersData();
                            if (node.PreviousSibling == null) continue;
                            if (node.NextSibling.NextSibling == null) continue;
                            if (node.NextSibling.NextSibling.NextSibling == null) continue;
                            if (node.NextSibling.NextSibling.NextSibling == null) continue;
                            if (node.NextSibling.NextSibling.NextSibling.NextSibling == null) continue;
                            if (node.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling
                            .NextSibling.NextSibling.NextSibling == null) continue;
                                
                          
                            var tradeDate = node.PreviousSibling.InnerText.Trim();
                            var insiderName =  node.NextSibling.InnerText.Trim();
                            var insiderTitle = node.NextSibling.NextSibling.InnerText.Trim();
                            var tradeType = node.NextSibling.NextSibling.NextSibling.InnerText.Trim();
                            var price = node.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Trim();
                            if (price.Contains(','))
                            {
                                price = price.Replace(@",", String.Empty).Trim();
                            }
                            if (price.Contains('$'))
                            {
                                price = price.Replace(@"$", String.Empty).Trim();
                            }
                            if (price.Contains('.'))
                            {
                                price = price.Replace(@".", @",").Trim();
                            }

                            if (price.StartsWith("0"))
                            {
                                continue;
                            }


                            var value = node.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling
                                .NextSibling.NextSibling.NextSibling.InnerText.Trim();

                            if (value.Contains(',')) 
                            { 
                                value = value.Replace(@",", String.Empty).Trim();
                            }
                            if (value.Contains('-')) 
                            {
                                value = value.Replace(@"-", String.Empty).Trim();
                            }
                            if (value.Contains('+'))
                            {
                                value = value.Replace(@"+", String.Empty).Trim();
                            }
                            if (value.Contains('$')) 
                            {
                                value = value.Replace(@"$", String.Empty).Trim();
                            }
                            if (value.Contains('.'))
                            {
                                value = value.Replace(@".", @",").Trim();
                            }
                            if (value.StartsWith("0"))
                            {
                                continue;
                            }

                            insiderData.Tradedate = Convert.ToDateTime(tradeDate);
                            insiderData.InsiderName = insiderName;
                            insiderData.Title = insiderTitle;
                            insiderData.Tradetype = tradeType;
                            insiderData.Price =  Convert.ToDouble(price);
                            insiderData.Value = Convert.ToDouble(value);
                            insidersdata.Add(insiderData);
                        }
                        

                    }
                }
                return insidersdata;
            }
            catch (Exception e)
            {
                Log.WriteLog(e);
                return null;
            }
        }




        /// <summary>
        /// 	Gets the data. Price and PT
        /// </summary>
        /// <param name="ticker"> The ticker. </param>
        /// <returns> </returns>
        public Dictionary<string, string> GetFinvizData(string ticker)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();


                string urlPt = @"http://finviz.com/quote.ashx?t=" + ticker + @"&ty=c&ta=0&p=d";
                var nodesPt = WebScrapHelper.LoadHtmlDoc(urlPt, "//td");

                if (nodesPt != null)
                {
                    foreach (var node in nodesPt)
                    {
                        // Industry, sector, country
                        // if (i == 37)
                        if (node.InnerText.Trim().Count(x => x == '|') == 2)
                        {
                            GetSectorIndustryCountry(node, data);
                        }


                        //Price
                        // if (i == 173)
                        if (node.InnerText.Trim().Equals("Price"))
                        {
                            GetValue(node.NextSibling, data, "price");
                        }
                        //PT
                        //if (i == 99)
                        if (node.InnerText.Trim().Equals("Target Price"))
                        {
                            GetValue(node.NextSibling, data, "targetprice");
                        }

                        //volume
                        //  if (i == 183)
                        if (node.InnerText.Trim().Equals("Volume"))
                        {
                            GetValue(node.NextSibling, data, "volume");
                        }

                        //relvolume
                        //if (i == 159)
                        if (node.InnerText.Trim().Equals("Rel Volume"))
                        {
                            GetValue(node.NextSibling, data, "relvolume");
                        }

                        //rsi14
                        //   if (i == 147)
                        if (node.InnerText.Trim().Equals("RSI (14)"))
                        {
                            GetValue(node.NextSibling, data, "rsi14");
                        }


                        //52whi
                        // if (i == 123)
                        if (node.InnerText.Trim().Equals("52W High"))
                        {
                            GetValue(node.NextSibling, data, "52whigh");
                        }

                        //52wlo
                        // if (i == 135)
                        if (node.InnerText.Trim().Equals("52W Low"))
                        {
                            GetValue(node.NextSibling, data, "52wlow");
                        }

                        //shortratio--8
                        //if (i == 87)
                        if (node.InnerText.Trim().Equals("Short Ratio"))
                        {
                            GetValue(node.NextSibling, data, "shortratio");
                        }

                        //shortfloat--6
                        //if (i == 75)
                        if (node.InnerText.Trim().Equals("Short Float"))
                        {
                            GetValue(node.NextSibling, data, "shortfloat");
                        }
                        //instown--5
                        //if (i == 73)
                        if (node.InnerText.Trim().Equals("Inst Own"))
                        {
                            GetValue(node.NextSibling, data, "instown");
                        }

                        //instrans--7
                        //  if (i == 85)
                        if (node.InnerText.Trim().Equals("Inst Trans"))
                        {
                            GetValue(node.NextSibling, data, "insttrans");
                        }


                        //insidown--2
                        // if (i == 49)
                        if (node.InnerText.Trim().Equals("Insider Own"))
                        {
                            GetValue(node.NextSibling, data, "insidown");
                        }

                        //insitrans --4
                        //if (i == 61)
                        if (node.InnerText.Trim().Equals("Insider Trans"))
                        {
                            GetValue(node.NextSibling, data, "insidtrans");
                        }

                        //profit
                        //  if (i == 157)
                        if (node.InnerText.Trim().Equals("Profit Margin"))
                        {
                            GetValue(node.NextSibling, data, "profitmargin");
                        }

                        //debteq
                        // if (i == 153)
                        if (node.InnerText.Trim().Equals(@"Debt/Eq"))
                        {
                            GetValue(node.NextSibling, data, "debteq");
                        }

                        //peg 
                        //if (i == 69)
                        if (node.InnerText.Trim().Equals("PEG"))
                        {
                            GetValue(node.NextSibling, data, "peg");
                        }

                        //pe 
                        //if (i == 45)
                        if (node.InnerText.Trim().Equals(@"P/E"))
                        {
                            GetValue(node.NextSibling, data, "pe");
                        }

                        //forwardpe -- 3
                        //if (i == 57)
                        if (node.InnerText.Trim().Equals(@"Forward P/E"))
                        {
                            GetValue(node.NextSibling, data, "forwardpe");
                        }

                        //Pricetobook--9
                        //if (i == 93)
                        if (node.InnerText.Trim().Equals(@"P/B"))
                        {
                            GetValue(node.NextSibling, data, "pricetobook");
                        }

                        //bookpershare--8
                        //if (i == 91)
                        if (node.InnerText.Trim().Equals(@"Book/sh"))
                        {
                            GetValue(node.NextSibling, data, "booksh");
                        }

                        //cashpershare
                        //if (i == 103)
                        if (node.InnerText.Trim().Equals(@"Cash/sh"))
                        {
                            GetValue(node.NextSibling, data, "cashsh");
                        }

                        //reco
                        // if (i == 175)
                        if (node.InnerText.Trim().Equals("Recom"))
                        {
                            GetValue(node.NextSibling, data, "reco");
                        }

                        //div
                        //if (i == 127)
                        if (node.InnerText.Trim().Equals(@"Dividend %"))
                        {
                            GetValue(node.NextSibling, data, "dividendpercent");
                        }

                        //perfyear
                        //if (i == 101)
                        if (node.InnerText.Trim().Equals("Perf Year"))
                        {
                            GetValue(node.NextSibling, data, "perfyear");
                        }
                        //perfhalfy-7
                        //if (i == 89)
                        if (node.InnerText.Trim().Equals("Perf Half Y"))
                        {
                            GetValue(node.NextSibling, data, "perfhalfyear");
                        }

                        //emplo
                        //if (i == 139)
                        if (node.InnerText.Trim().Equals("Employees"))
                        {
                            GetValue(node.NextSibling, data, "employees");
                        }

                        //option
                        //if (i == 151)
                        if (node.InnerText.Trim().Equals("Optionable"))
                        {
                            GetValue(node.NextSibling, data, "optionable", false);
                        }
                        //short
                        //if (i == 163)
                        if (node.InnerText.Trim().Equals("Shortable"))
                        {
                            GetValue(node.NextSibling, data, "shortable", false);
                        }
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                Log.WriteLog(e);
                return null;
            }
        }


        /// <summary>
        /// 	Deletes the finviz data.
        /// </summary>
        public void DeleteFinvizData()
        {
            DbConnect connection = DbConnect("finviz");
            const string deletequery = "delete FROM findata where ticker<>'0';";
            connection.Delete(deletequery);
            const string deletequeryInsiders = "delete FROM insiders where ticker<>'0';";
            connection.Delete(deletequeryInsiders);
        }


     


        /// <summary>
        /// 	Inserts the finviz data.
        /// </summary>
        public void InsertFinvizData()
        {
           
            DbConnect connection = DbConnect("finviz");
            List<string> tickers = GetFinvizTickers(@"http://finviz.com/screener.ashx?v=1");
            //// TODO
            //testing do not remove
            //List<string> tickers = new List<string>();

            // tickers.Add("swks");
            //tickers.Add("aap");
            //tickers.Add("aatc");

            string idDownload = BuildIdDownload();
            foreach (var ticker in tickers)
            {
                if (ticker == "NO DATA") continue;

                Dictionary<string, string> data = GetFinvizData(ticker);
               
                if (data == null) continue;
                // check if no data is missing 
                if (data.Count() < 31) continue;

                string insertquery =
                    "INSERT INTO findata (iddownload, ticker,date,price,targetprice,volume,relvolume," +
                    "rsi14,whigh,wlow,shortratio,shortfloat,instown,insttrans,insidown," +
                    "insidtrans,profitmargin,debteq,peg,pe,forwardpe,pricetobook,booksh,cashsh," +
                    "reco,dividendpercent,perfyear,perfhalfyear,employees,optionable,shortable," +
                    "sector,industry,country"+") VALUES " + "(" + '"' +
                    idDownload + '"' + ',' + '"' +
                    ticker.Trim().ToUpper() + '"' +
                    ',' + "GETDATE()" + ',' + '"' +
                    data["price"] + '"' + ',' + '"' +
                    data["targetprice"] + '"' + ',' + '"' +
                    data["volume"] + '"' + ',' + '"' +
                    data["relvolume"] + '"' + ',' + '"' +
                    data["rsi14"] + '"' + ',' + '"' +
                    data["52whigh"] + '"' + ',' + '"' +
                    data["52wlow"] + '"' + ',' + '"' +
                    data["shortratio"] + '"' + ',' + '"' +
                    data["shortfloat"] + '"' + ',' + '"' +
                    data["instown"] + '"' + ',' + '"' +
                    data["insttrans"] + '"' + ',' + '"' +
                    data["insidown"] + '"' + ',' + '"' +
                    data["insidtrans"] + '"' + ',' + '"' +
                    data["profitmargin"] + '"' + ',' + '"' +
                    data["debteq"] + '"' + ',' + '"' +
                    data["peg"] + '"' + ',' + '"' +
                    data["pe"] + '"' + ',' + '"' +
                    data["forwardpe"] + '"' + ',' + '"' +
                    data["pricetobook"] + '"' + ',' + '"' +
                    data["booksh"] + '"' + ',' + '"' +
                    data["cashsh"] + '"' + ',' + '"' +
                    data["reco"] + '"' + ',' + '"' +
                    data["dividendpercent"] + '"' + ',' + '"' +
                    data["perfyear"] + '"' + ',' + '"' +
                    data["perfhalfyear"] + '"' + ',' + '"' +
                    data["employees"] + '"' + ',' + '"' +
                    data["optionable"] + '"' + ',' + '"' +
                    data["shortable"] + '"' + ',' + '"' +
                    data["sector"] + '"' + ',' + '"' +
                    data["industry"] + '"' + ',' + '"' +
                    data["country"] + '"' +  
                     ")";

                 connection.Insert(insertquery);

                List<InsidersData> dataInsiders = GetOpenInsiderData(ticker);

                if (dataInsiders == null) continue;
                // check if no data is missing 


                foreach (var insider in dataInsiders)
                {
                    DateTime insidertrade = insider.Tradedate;
                    string price = insider.Price.ToString().Replace(',', '.');
                    string tradevalue = insider.Value.ToString().Replace(',', '.');
                    string format = "yyyy-MM-dd HH:mm:ss";
                    string insertqueryInsiders =
                   "INSERT INTO insiders (iddownload, ticker,date,tradedate,insidername,title,tradetype,price,value" + ") VALUES " + "(" + '"' +
                   idDownload + '"' + ',' + '"' +
                   ticker.Trim().ToUpper() + '"' +
                   ',' + "GETDATE()" + ',' + '"' +
                   insidertrade.ToString(format) + '"' + ',' + '"' +
                   insider.InsiderName + '"' + ',' + '"' +
                   insider.Title + '"' + ',' + '"' +
                   insider.Tradetype + '"' + ',' + '"' +
                   price + '"' + ',' + '"' +
                   tradevalue + '"' +
                    ")";

                    connection.Insert(insertqueryInsiders);
                }


               
            }
        }


      
  


        /// <summary>
        /// 	Compares the data.
        /// </summary>
        /// <param name="value"> The value. </param>
        /// <param name="value1"> The value1. </param>
        /// <param name="sound"> The sound. </param>
        /// <param name="activesoundalert"> if set to <c>true</c> [activesoundalert]. </param>
        /// <returns> </returns>
        public bool CompareData(string value, string value1, string sound, bool activesoundalert)
        {
            double val;
            double alertval;
            if (value == null || value1 == null) return false;
            if (value.Contains('.'))
            {
                value = value.Replace('.', ',');
            }

            if (value1.Contains('.'))
            {
                value1 = value1.Replace('.', ',');
            }

            if (Double.TryParse(value, out val) && Double.TryParse(value1, out alertval))
                // if done, then is a number
            {
                if (Math.Abs(alertval) < Math.Abs(val))
                {
                    if (activesoundalert)
                    {
                        Sound.PlayAlert("clock");
                        Thread.Sleep(2000);
                        Sound.PlayAlert(sound);
                    }

                    return true;
                }
            }
            else
            {
                Log.WriteLog("Cannot compare incorrect input data");
                return false;
            }
            return false;
        }


        /// <summary>
        /// 	Compares the data.
        /// </summary>
        /// <param name="value"> The value. </param>
        /// <param name="value1"> The value1. </param>
        /// <returns> </returns>
        public bool CompareData(string value, string value1)
        {
            double val;
            double alertval;
            if (value == null || value1 == null) return false;
            if (value.Contains('.'))
            {
                value = value.Replace('.', ',');
            }

            if (value.Contains('%'))
            {
                value = value.Remove('%');
            }


            if (value1.Contains('.'))
            {
                value1 = value1.Replace('.', ',');
            }

            if (value1.Contains('%'))
            {
                value1 = value1.Remove('%');
            }

            if (Double.TryParse(value, out val) && Double.TryParse(value1, out alertval))

            {
                if (Math.Abs(alertval) < Math.Abs(val))
                {
                    return true;
                }
            }
            else
            {
                Log.WriteLog("Cannot compare incorrect input data");
                return false;
            }
            return false;
        }

        #endregion

        private string BuildIdDownload()
        {
            List<string> dbData =
                XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");
            //string server ="127.0.0.1";

            //string database = "avafinScraper";
            //string uid = "root";
            //string password = "";
            if (dbData == null) return null;
            if (dbData.Count < 3)
            {
                Log.WriteLog("Insufficent data to connect to db.");
                return null;
            }
            string server = dbData[1];
            string database = dbData[2];


            List<string> values;
            string connectionstring =
                "Data Source = " + server + "; Initial Catalog = " + database + ";Integrated Security = True";
            const string selectlastiddownload =
                @"select  iddownload from finviz.findata  order by iddownload desc limit 1;";


            Helpers.DbConnect.GetValue(selectlastiddownload, "iddownload", connectionstring, out values);
            string val = null;
            if (values == null) return null;
            if (values.Count > 1)
            {
                val = values[1];
            }

            if (string.IsNullOrEmpty(val))
            {
                val = "1";
            }
            else
            {
                int valint = Convert.ToInt32(val);
                int valintfinal = valint + 1;
                val = valintfinal.ToString(CultureInfo.InvariantCulture);
            }
            return val;
        }

       
        private static XPathNavigator Navigator(string ticker, string urlp1, string urlp2)
        {
            string ticksratio = urlp1 + ticker + urlp2;


            if (string.IsNullOrEmpty(ticksratio)) return null;
            string urltrim = ticksratio.Trim();
            var webGet = new HtmlWeb();
            HtmlDocument document = null;
            try
            {
                document = webGet.Load(urltrim);
                if (document == null) return null;
            }
            catch
            {
                if (document == null) return null;
            }

            XPathNavigator nav = document.CreateNavigator();
            return nav;
        }


        /// <summary>
        /// 	Gets the WSJ data ratio.
        /// </summary>
        /// <param name="ticker"> The ticker. </param>
        /// <returns> </returns>
        public Dictionary<string, string> GetWsjDataRatio(string ticker)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string ticksratio = @" http://quotes.wsj.com/" + ticker + @"?mod=DNH_S_cq";


            var nodestickratio = WebScrapHelper.LoadHtmlDoc(ticksratio,
                                                            "//*[@id='cr_keystock_drawer']/div[3]/ul/li/div[1]/div/div/div");
            if (nodestickratio != null)
                foreach (var node in nodestickratio)
                {
                    if (nodestickratio.Count != 1)
                    {
                        data.Add("uptickdowntick", "null");
                        break;
                    }
                    else
                    {
                        data.Add("uptickdowntick", node.InnerText);
                    }
                }

            var nodespercentchange = WebScrapHelper.LoadHtmlDoc(ticksratio, "//*[@id='quote_changePer']");
            if (nodespercentchange != null)
                foreach (var node in nodespercentchange)
                {
                    if (nodestickratio == null) continue;
                    if (nodestickratio.Count != 1)
                    {
                        data.Add("percentchange", "null");
                        break;
                    }
                    else
                    {
                        data.Add("percentchange", node.InnerText);
                    }
                }

            return data;
        }

        /// <summary>
        /// 	Dbs the connect.
        /// </summary>
        /// <param name="dbname"> The dbname. </param>
        /// <returns> </returns>
        public DbConnect DbConnect(string dbname)
        {
            try
            {
                List<string> dbData =
                    XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");
                //string server ="127.0.0.1";
                //string database = "avafinScraper";
                //string uid = "root";
                if (dbData == null)
                {
                    return null;
                }
                if (dbData.Count < 3)
                {
                    Log.WriteLog("Insufficent data to connect to db.");
                    return null;
                }
                string server = dbData[1];
                DbConnect db = new DbConnect(server, dbname);
                return db;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 	Gets the value.
        /// </summary>
        /// <param name="node"> The node. </param>
        /// <param name="data"> The data. </param>
        /// <param name="isNumeric"> if set to <c>true</c> [is numeric]. </param>
        /// <param name="key"> The key. </param>
        private static void GetValue(HtmlNode node, Dictionary<string, string> data, string key, bool isNumeric = true)
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
                    if (node.InnerText.Contains("%") &&
                        (!node.InnerText.Contains("Purchase at $") || !node.InnerText.Contains("Sale at $")))
                    {
                        datum = node.InnerText.Replace("%", string.Empty);
                    }
                        // value last insider purchase / sale
                    else if (node.InnerText.Contains("$") && node.InnerText.Contains(",") &&
                             (!node.InnerText.Contains("Purchase at $") || !node.InnerText.Contains("Sale at $")))
                    {
                        string tmpdatum = node.InnerText.Replace(",", string.Empty);
                        datum = tmpdatum.Substring(1, tmpdatum.Length - 1);
                    }
                    else if (node.InnerText.Contains(",") &&
                             (!node.InnerText.Contains("Purchase at $") || !node.InnerText.Contains("Sale at $")))
                    {
                        datum = node.InnerText.Replace(",", string.Empty);
                    }
                        // price of last purchase / sale
                    else if (node.InnerText.Contains("$") &&
                             (node.InnerText.Contains("Purchase at $") || node.InnerText.Contains("Sale at $")))
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

                    if (isNumeric)
                    {
                        datum = Numerics.ExtractNumbers(datum);
                    }


                    if (datum != null) data.Add(key, datum.Replace('$', ' '));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
        }


        /// <summary>
        /// 	Gets the value.
        /// </summary>
        /// <param name="node"> The node. </param>
        /// <param name="data"> The data. </param>
        private static void GetSectorIndustryCountry(HtmlNode node, Dictionary<string, string> data)
        {
            try
            {
                string[] content = node.InnerText.Split('|');
                string sector = content[0].Split('\n')[4];
                data.Add("sector", sector);
                data.Add("industry", content[1].Replace("&amp;", "&"));
                data.Add("country", content[2].Substring(0,5).Trim());
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
        }


        /// <summary>
        /// 	Cleans the WSJ ticker.
        /// </summary>
        /// <param name="value"> The value. </param>
        /// <returns> </returns>
        private string CleanWsjTicker(string value)
        {
            string v1 = value.Split('(')[1];
            string v2 = v1.Split(')')[0];

            return v2;
        }


        /// Cleans the data.
        /// </summary>
        /// <param name="bruteData"> The brute data. </param>
        /// <returns> </returns>
        private string CleanFlowData(string bruteData)
        {
            string multiple;
            if (bruteData.Contains("M"))
            {
                multiple = "000000";
            }
            else if (bruteData.Contains("K"))
            {
                multiple = "000";
            }
            else if (bruteData.Contains("B"))
            {
                multiple = "000000000";
            }
            else
            {
                multiple = "";
            }
            string[] bruteData1 = bruteData.Split('.');
            string cleanedData = bruteData1[0].Substring(1, bruteData1[0].Length - 1).Trim() + multiple;
            return cleanedData;
        }

        private string CleanPercentageData(string bruteData)
        {
            string[] bruteData1 = bruteData.Split('(');
            string[] bruteData2 = bruteData1[1].Split(' ');
            return bruteData2[0];
        }
    }
}