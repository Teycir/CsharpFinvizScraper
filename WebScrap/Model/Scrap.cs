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
        /// 	Brings the WSJ data to my shiny beautiful database.
        /// </summary>
        /// <param name="ticker"> The sexy ticker. </param>
        /// <returns> </returns>
        public Dictionary<string, string> GetWsjData(string ticker)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();


            string page = @" http://quotes.wsj.com/" + ticker;

            string pathratio;
            if(ticker.ToUpper().Contains("ETF"))
            {
                pathratio = "//*[@id='cr_keystock_drawer']/div[4]/ul/li/div[1]/div/div/div";
               
            }
            else
            {
                pathratio = "//*[@id='cr_keystock_drawer']/div[3]/ul/li/div[1]/div/div/div";
            }
            var nodestickratio = WebScrapHelper.LoadHtmlDoc(page,pathratio
                                                           );
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

            string pathprice;
             if(ticker.ToUpper().Contains("ETF"))
             {
                 pathprice = "//*[@id='quote_val']";
             }
             else
             {
                 pathprice = "//*[@id='quote_val']";
             }

            var nodesprice = WebScrapHelper.LoadHtmlDoc(page, pathprice);

            if (nodesprice != null)

                // nodestickratio old
                foreach (var node in nodesprice)
                {
                    if (nodesprice.Count != 1)
                    {
                        data.Add("price", "null");
                        break;
                    }
                    else
                    {
                        data.Add("price", node.InnerText);
                    }
                }



            string pathpercentchange;
               if(ticker.ToUpper().Contains("ETF"))
               {
                   pathpercentchange = "//*[@id='quote_changePer']";
               }
               else
               {
                   pathpercentchange = "//*[@id='quote_changePer']";
               }

            var nodespercentchange = WebScrapHelper.LoadHtmlDoc(page, pathpercentchange);
            if (nodespercentchange != null)
                foreach (var node in nodespercentchange)
                {
                    if (nodestickratio != null)
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



            string pathmoneyFlow;

            if (ticker.ToUpper().Contains("ETF"))
            {
                pathmoneyFlow = "//*[@id='cr_keystock_drawer']/div[4]/ul/li/div[2]/span/span";
            }
            else
            {
                pathmoneyFlow = "//*[@id='cr_keystock_drawer']/div[3]/ul/li/div[2]/span/span";
            }
            var nodesmoneyflow = WebScrapHelper.LoadHtmlDoc(page, pathmoneyFlow
                                                            );
            if (nodesmoneyflow != null)
                foreach (var node in nodesmoneyflow)
                {
                    if (nodestickratio != null)
                        if (nodestickratio.Count != 1)
                        {
                            data.Add("moneyflow", "null");
                            data.Add("moneyflowbrute", "null");
                            break;
                        }
                        else
                        {
                            string mflow = node.InnerText;
                            data.Add("moneyflowbrute", mflow);
                            mflow = mflow.Replace(",", "").Trim();
                            mflow = mflow.Replace("$", "").Trim();
                            if (mflow.Contains('M'))
                                mflow = mflow.Replace(" M", "0000").Trim();
                            if (mflow.Contains('.'))
                                mflow = mflow.Replace(".", "").Trim();
                            data.Add("moneyflow", mflow);
                        }
                }
            return data;
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


                // All purchases


                string urlInsPur =
                    @"http://openinsider.com/screener?fd=0&fdr=&td=0&tdr=&s=" + ticker +
                    @"&o=&t=p&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1";

                // Recent purchases


                int i;
                int purchase = 0;
                List<string> differeninsiderpurchases = new List<string>();
                XPathNavigator navPurchases = Navigator(ticker,
                                                        @"http://openinsider.com/screener?fd=0&fdr=&td=90&tdr=&s=",
                                                        @"&o=&t=p&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1");
                if (navPurchases != null)
                {
                    for (i = 1; i < 400; i++)
                    {
                        string xpathPurchase = @"//*[@id='tablewrapper']/table/tbody/tr[" + i + "]/td[5]/a";
                        XPathNavigator selectSingleNodePurchase = navPurchases.SelectSingleNode(xpathPurchase);
                        if (selectSingleNodePurchase != null)
                        {
                            purchase++;
                            if (!differeninsiderpurchases.Contains(selectSingleNodePurchase.Value))
                                differeninsiderpurchases.Add(selectSingleNodePurchase.Value);
                        }
                        else
                        {
                            break;
                        }
                    }
                    data.Add("numrecentinsiderpurchases", purchase.ToString());

                    data.Add("numrecentdifferentinsiderpurchases", differeninsiderpurchases.Count.ToString());
                }
                else
                {
                    data.Add("numrecentinsiderpurchases", "0");
                    data.Add("numrecentdifferentinsiderpurchases", "0");
                }
                HtmlNodeCollection nodesInsPur = WebScrapHelper.LoadHtmlDoc(urlInsPur, "//td");


                int j = 0;
                bool containsPurchase = false;
                if (nodesInsPur != null)
                {
                    foreach (var node in nodesInsPur)
                    {
                        // 78
                        if (nodesInsPur.Count < 80)
                        {
                            data.Add("lastinsiderpurchaseprice", "0");
                            data.Add("lastinsiderpurchasevalue", "0");
                            break;
                        }
                        j++;

                        if (j == 80)
                        {
                            if (node.InnerText.Contains('$'))
                            {
                                GetValue(node, data, "lastinsiderpurchaseprice");
                                containsPurchase = true;
                            }
                            else
                            {
                                data.Add("lastinsiderpurchaseprice", "0");
                                data.Add("lastinsiderpurchasevalue", "0");
                                break;
                            }
                        }
                        if (containsPurchase)
                        {
                            if (j == 84)
                            {
                                GetValue(node, data, "lastinsiderpurchasevalue");
                                containsPurchase = false;
                                break;
                            }
                        }
                    }
                }


                // All sales


                string urlInsSal =
                    @"http://openinsider.com/screener?fd=0&fdr=&td=0&tdr=&s=" + ticker +
                    @"&o=&t=s&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1";


                // Recent Sales


                int k;
                int sale = 0;
                List<string> differeninsidersales = new List<string>();

                XPathNavigator navSales = Navigator(ticker, @"http://openinsider.com/screener?fd=0&fdr=&td=90&tdr=&s=",
                                                    @"&o=&t=s&minprice=&maxprice=&v=1000&sicMin=&sicMax=&sortcol=0&maxresults=500&excludeDerivRelated=1");
                if (navSales != null)
                {
                    for (k = 1; k < 400; k++)
                    {
                        string xpathSale = @"//*[@id='tablewrapper']/table/tbody/tr[" + k + "]/td[5]/a";
                        XPathNavigator selectSingleNodeSale = navSales.SelectSingleNode(xpathSale);
                        if (selectSingleNodeSale != null)
                        {
                            sale++;
                        if (!differeninsidersales.Contains(selectSingleNodeSale.Value))
                                differeninsidersales.Add(selectSingleNodeSale.Value);
                        }
                        else
                        {
                            break;
                        }
                    }
                    data.Add("numrecentinsidersales", sale.ToString());
                    data.Add("numrecentdifferentinsidersales", differeninsidersales.Count.ToString());
                }
                else
                {
                    data.Add("numrecentinsidersales", "0");
                    data.Add("numrecentdifferentinsidersales", "0");
                }
                var nodesInsSal = WebScrapHelper.LoadHtmlDoc(urlInsSal, "//td");


                k = 0;
                bool containsSale = false;
                if (nodesInsSal != null)
                {
                    foreach (var node in nodesInsSal)
                    {
                        if (nodesInsSal.Count < 80)
                        {
                            data.Add("lastinsidersaleprice", "0");
                            data.Add("lastinsidersalevalue", "0");
                            break;
                        }
                        k++;


                        if (k == 80)
                        {
                            if (node.InnerText.Contains("$"))
                            {
                                GetValue(node, data, "lastinsidersaleprice");
                                containsSale = true;
                            }
                            else
                            {
                                data.Add("lastinsidersaleprice", "0");
                                data.Add("lastinsidersalevalue", "0");
                                break;
                            }
                        }
                        if (containsSale)
                        {
                            if (k == 84)
                            {
                                GetValue(node, data, "lastinsidersalevalue");
                                containsSale = false;
                                break;
                            }
                        }
                    }
                }


                const string xpathOwner = @"//*[@id='tablewrapper']/table/tbody/tr[1]/td[6]";
                //*[@id="tablewrapper"]/table/tbody/tr[1]/td[6]
               
                if (navSales != null)
                {
                    XPathNavigator selectSingleNodeSaleByOwner = navSales.SelectSingleNode(xpathOwner);

                    if (selectSingleNodeSaleByOwner != null)
                    {
                        if (selectSingleNodeSaleByOwner.Value.Contains("10%"))
                        {
                            data.Add("lastinsidersaleisbyowner", "yes");
                        }
                        else
                        {
                            data.Add("lastinsidersaleisbyowner", "no");
                        }
                    }
                    else
                    {
                        data.Add("lastinsidersaleisbyowner", "no");
                    }
                }
                else
                {
                    data.Add("lastinsidersaleisbyowner", "no");
                }


                if (navPurchases != null)
                {
                    XPathNavigator selectSingleNodePurchaseByOwner = navPurchases.SelectSingleNode(xpathOwner);

                    if (selectSingleNodePurchaseByOwner != null)
                    {
                        if (selectSingleNodePurchaseByOwner.Value.Contains("10%"))
                        {
                            data.Add("lastinsiderpurchaseisbyowner", "yes");
                        }
                        else
                        {
                            data.Add("lastinsiderpurchaseisbyowner", "no");
                        }
                    }
                    else
                    {
                        data.Add("lastinsiderpurchaseisbyowner", "no");
                    }
                }
                else
                {
                    data.Add("lastinsiderpurchaseisbyowner", "no");
                }


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
            const string deletequery = "delete FROM finviz.findata where ticker<>'0';";
            connection.Delete(deletequery);
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
            //tickers.Add("cqh");
            //tickers.Add("swks");
            //tickers.Add("ayr");
            //tickers.Add("xon");
            //tickers.Add("opk");
            //tickers.Add("psec");
            string idDownload = BuildIdDownload();
            foreach (var ticker in tickers)
            {
                if (ticker == "NO DATA") continue;

                Dictionary<string, string> data = GetFinvizData(ticker);
                if (data == null) continue;
                // check if no data is missing 
                if (data.Count() < 41) continue;

                string insertquery =
                    "INSERT INTO findata (iddownload, ticker,date,price,targetprice,volume,relvolume," +
                    "rsi14,52whigh,52wlow,shortratio,shortfloat,instown,insttrans,insidown," +
                    "insidtrans,profitmargin,debteq,peg,pe,forwardpe,pricetobook,booksh,cashsh," +
                    "reco,dividendpercent,perfyear,perfhalfyear,employees,optionable,shortable," +
                    "sector,industry,country,lastinsiderpurchaseprice,lastinsiderpurchasevalue," +
                    "lastinsidersaleprice,lastinsidersalevalue,lastinsiderpurchaseisbyowner,lastinsidersaleisbyowner," +
                    "numrecentinsiderpurchases,numrecentinsidersales,numrecentdifferentinsiderpurchases,numrecentdifferentinsidersales" +
                    ") VALUES " + "(" + '"' +
                    idDownload + '"' + ',' + '"' +
                    ticker.Trim().ToUpper() + '"' +
                    ',' + "CURTIME()" + ',' + '"' +
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
                    data["country"] + '"' + ',' + '"' +
                    data["lastinsiderpurchaseprice"] + '"' + ',' + '"' +
                    data["lastinsiderpurchasevalue"] + '"' + ',' + '"' +
                    data["lastinsidersaleprice"] + '"' + ',' + '"' +
                    data["lastinsidersalevalue"] + '"' + ',' + '"' +
                    data["lastinsiderpurchaseisbyowner"] + '"' + ',' + '"' +
                    data["lastinsidersaleisbyowner"] + '"' + ',' + '"' +
                    data["numrecentinsiderpurchases"] + '"' + ',' + '"' +
                    data["numrecentinsidersales"] + '"' + ',' + '"' +
                    data["numrecentdifferentinsiderpurchases"] + '"' + ',' + '"' +
                    data["numrecentdifferentinsidersales"] + '"'
                    + ")";

                 connection.Insert(insertquery);
            }
        }


        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        public List<string> GetAvafinData(string url)
        {
            try
            {
                var nodes = WebScrapHelper.LoadHtmlDoc(url, "//td[@class='price-table-cell']");
                List<string> tickers = new List<string>();
                if (nodes == null)
                {
                    return new List<string> {"Data not available"};
                }
                int i = 0;
                foreach (var v in nodes)
                {
                    i++;

                    // Get the price
                    if (i == 1)
                    {
                        tickers.Add(v.InnerText.Substring(1, v.InnerText.Length - 1));
                    }

                    // Get the percentage return of the day on the ticker
                    if (i == 2)
                    {
                        tickers.Add(CleanPercentageData(v.InnerText));
                    }
                    // The placement of the data containing bought/sold ratio
                    if (i == 23)
                    {
                        tickers.Add(v.InnerText);
                    }
                    // The placement of the data containing $ Flow
                    if (i == 24)
                    {
                        tickers.Add(CleanFlowData(v.InnerText));
                    }
                }

                return tickers;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        public List<string> GetWsjTickers(string url)
        {
            try
            {
                var nodes = WebScrapHelper.LoadHtmlDoc(url, "//td[@class='text']");
                List<string> tickers = new List<string>();
                if (nodes == null)
                {
                    return new List<string> {"Data not available"};
                }
                int i = 0;
                foreach (var v in nodes)
                {
                    i++;

                    if (i >= 2 && i <= 22)
                    {
                        tickers.Add(CleanWsjTicker(v.InnerText));
                    }
                    if (i >= 22) break;
                }
                return tickers;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <returns> </returns>
        public List<string> GetWsjPricesBuy()
        {
            try
            {
                var nodes =
                    WebScrapHelper.LoadHtmlDoc(@"http://online.wsj.com/mdc/public/page/2_3022-mfgppl-moneyflow.html",
                                               "//td[@class='nnum']");
                List<string> prices = new List<string>();
                if (nodes == null)
                {
                    return new List<string> {"Data not available"};
                }
                int i = 0;
                foreach (var v in nodes)
                {
                    i++;
                    if (i < 18)
                    {
                        // buy
                        if (i == 1)
                        {
                            prices.Add(v.InnerText);
                        }


                        if (i == 4)
                        {
                            prices.Add(v.InnerText);
                        }


                        if (i == 7)
                        {
                            prices.Add(v.InnerText);
                        }

                        if (i == 10)
                        {
                            prices.Add(v.InnerText);
                        }

                        if (i == 13)
                        {
                            prices.Add(v.InnerText);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return prices;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <returns> </returns>
        public List<string> GetWsjPricesSell()
        {
            try
            {
                var nodes =
                    WebScrapHelper.LoadHtmlDoc(@"http://online.wsj.com/mdc/public/page/2_3022-mflppg-moneyflow.html",
                                               "//td[@class='pnum']");
                List<string> prices = new List<string>();
                if (nodes == null)
                {
                    return new List<string> {"Data not available"};
                }
                int i = 0;
                foreach (var v in nodes)
                {
                    i++;
                    if (i < 18)
                    {
                        // buy
                        if (i == 1)
                        {
                            prices.Add(v.InnerText);
                        }


                        if (i == 5)
                        {
                            prices.Add(v.InnerText);
                        }


                        if (i == 9)
                        {
                            prices.Add(v.InnerText);
                        }

                        if (i == 13)
                        {
                            prices.Add(v.InnerText);
                        }

                        if (i == 17)
                        {
                            prices.Add(v.InnerText);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return prices;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        public List<string> GetWsjFlows(string url)
        {
            try
            {
                var nodes = WebScrapHelper.LoadHtmlDoc(url, "//td[@class='num']");
                List<string> blocks = new List<string>();
                if (nodes == null)
                {
                    return new List<string> {"Data not available"};
                }
                int i = 0;
                foreach (var v in nodes)
                {
                    i++;


                    if (i == 1)
                    {
                        blocks.Add(v.InnerText);
                    }


                    if (i == 9)
                    {
                        blocks.Add(v.InnerText);
                    }


                    if (i == 17)
                    {
                        blocks.Add(v.InnerText);
                    }

                    if (i == 25)
                    {
                        blocks.Add(v.InnerText);
                    }


                    if (i == 33)
                    {
                        blocks.Add(v.InnerText);
                    }
                }
                return blocks;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        public List<string> GetWsjFlowsRatio(string url)
        {
            try
            {
                var nodes = WebScrapHelper.LoadHtmlDoc(url, "//td[@class='num']");
                List<string> blocks = new List<string>();
                if (nodes == null)
                {
                    return new List<string> {"Data not available"};
                }
                int i = 0;
                foreach (var v in nodes)
                {
                    i++;


                    if (i == 4)
                    {
                        blocks.Add(v.InnerText);
                    }


                    if (i == 12)
                    {
                        blocks.Add(v.InnerText);
                    }


                    if (i == 20)
                    {
                        blocks.Add(v.InnerText);
                    }

                    if (i == 28)
                    {
                        blocks.Add(v.InnerText);
                    }


                    if (i == 36)
                    {
                        blocks.Add(v.InnerText);
                    }
                }
                return blocks;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="stock"> The stock. </param>
        /// <returns> </returns>
        public List<string> GetFlowData(string stock)
        {
            try
            {
                int day = Convert.ToInt32(DateTime.Now.Day.ToString());
                int month = Convert.ToInt32(DateTime.Now.Month.ToString());
                int year = Convert.ToInt32(DateTime.Now.Year.ToString());
                string date = month.ToString() + @"%2F" + day.ToString() + @"%2F" + year.ToString();


                HttpClient client = new HttpClient {BaseAddress = new Uri("http://finance.avafin.com")};

                string url =
                    @"data?sEcho=2&iColumns=9&sColumns=&iDisplayStart=0&iDisplayLength=20&mDataProp_0=0&mDataProp_1=1&mDataProp_2=2&mDataProp_3=3&mDataProp_4=4&mDataProp_5=5&mDataProp_6=6&mDataProp_7=7&mDataProp_8=8&sSearch=&bRegex=false&sSearch_0=&bRegex_0=false&bSearchable_0=true&sSearch_1=&bRegex_1=false&bSearchable_1=true&sSearch_2=&bRegex_2=false&bSearchable_2=true&sSearch_3=&bRegex_3=false&bSearchable_3=true&sSearch_4=&bRegex_4=false&bSearchable_4=true&sSearch_5=&bRegex_5=false&bSearchable_5=true&sSearch_6=&bRegex_6=false&bSearchable_6=true&sSearch_7=&bRegex_7=false&bSearchable_7=true&sSearch_8=&bRegex_8=false&bSearchable_8=true&iSortCol_0=4&sSortDir_0=asc&iSortingCols=1&bSortable_0=true&bSortable_1=true&bSortable_2=true&bSortable_3=true&bSortable_4=true&bSortable_5=true&bSortable_6=true&bSortable_7=true&bSortable_8=true&type=BS_RATIO&date=" +
                    date + "&categoryName=&alertId=0&alertId2=&industryId=0&sectorId=0&symbol=" + stock +
                    @"&recom=&period=&perfPercent=";
                string response = null;
                try
                {
                    response = client.GetStringAsync(url).Result;
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex);
                }


                List<string> tickers = new List<string>();
                if (response != null)
                {
                    List<string> htmlValues = new List<string>(response.Split(','));

                    if (!(htmlValues.Count > 4))
                    {
                        return new List<string> {"Data not available"};
                    }

                    int i = 0;
                    foreach (var v in htmlValues)
                    {
                        i++;

                        if (i == 11)
                        {
                            // BS
                            tickers.Add(v.Substring(1, v.Length - 2));
                        }
                        if (i == 12)
                        {
                            string[] s = v.Split('$');
                            string[] s1 = s[1].Split('<');

                            // Flow
                            tickers.Add(s1[0]);
                        }
                    }
                }

                return tickers;
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 	Liquids the stocks alert.
        /// </summary>
        /// <param name="ticker"> The ticker. </param>
        /// <param name="upratio"> The upratio. </param>
        /// <param name="downratio"> The downratio. </param>
        /// <returns> </returns>
        public List<string> GetStocksData(string ticker, string upratio, string downratio)
        {
            Dictionary<string, string> tickerdataFlow = GetWsjData(ticker);
            string uptickdowntick = null;

            string moneyflow = null;

            string moneyflowbrute = null;

            string percentchange = null;
            {
                if (tickerdataFlow == null) return null;
                if (tickerdataFlow.Count == 5)
                {
                    uptickdowntick = tickerdataFlow["uptickdowntick"];
                    moneyflowbrute = tickerdataFlow["moneyflowbrute"];
                    moneyflow = tickerdataFlow["moneyflow"];
                    percentchange = tickerdataFlow["percentchange"];
                }
            }

            bool ratioAlert = CompareData(uptickdowntick, upratio);
            bool ratioAlertNeg = CompareData(downratio, uptickdowntick);


            if (ratioAlert || ratioAlertNeg && uptickdowntick != "0.00")
            {
                List<string> data = new List<string>();
                data.Add(ticker);
                data.Add(uptickdowntick);
                data.Add(moneyflowbrute);
                data.Add(moneyflow);
                data.Add(percentchange);

                return data;
            }
            return null;
        }


        /// <summary>
        /// 	Liquids the stocks alert.
        /// </summary>
        /// <param name="ticker"> The ticker. </param>
        /// <param name="upratio"> The upratio. </param>
        /// <param name="downratio"> The downratio. </param>
        /// <param name="upratioExtreme"> The upratio extreme. </param>
        /// <param name="downratioExtreme"> The downratio extreme. </param>
        /// <returns> ticker, sector,industry,country,uptickdowntick,percentchange </returns>
        public List<string> GetStocksDataAllLiquid(string ticker, string upratio, string downratio,
                                                   string upratioExtreme, string downratioExtreme)
        {
            Dictionary<string, string> tickerdataFlow = GetWsjDataAllLiquid(ticker);


            string sector = null;


            string industry = null;

            string country = null;

            string uptickdowntick = null;


            string percentchange = null;


            string moneyflow = null;


            if (tickerdataFlow == null)
            {
                return null;
            }

            if (tickerdataFlow.Count == 7)
            {
                sector = tickerdataFlow["sector"];
                industry = tickerdataFlow["industry"];
                country = tickerdataFlow["country"];
                uptickdowntick = tickerdataFlow["uptickdowntick"];
                percentchange = tickerdataFlow["percentchange"];
                moneyflow = tickerdataFlow["moneyflow"];
            }


            bool ratioAlert = CompareData(uptickdowntick, upratio);
            bool ratioAlertNeg = CompareData(downratio, uptickdowntick);

            bool ratioExtremeAlert = CompareData(uptickdowntick, upratioExtreme);
            bool ratioExtremeAlertNeg = CompareData(downratioExtreme, uptickdowntick);


            if (ratioAlert || ratioAlertNeg && uptickdowntick != "0.00")
            {
                List<string> data = new List<string>();
                data.Add(ticker);
                data.Add(sector);
                data.Add(industry);
                data.Add(country);
                data.Add(uptickdowntick);
                data.Add(percentchange);
                data.Add(moneyflow);

                string highlight = null;
                if (ratioExtremeAlert)
                {
                    highlight = "++++";
                    data.Add(highlight);
                }

                else if (ratioExtremeAlertNeg)
                {
                    highlight = "- - - -";
                    data.Add(highlight);
                }
                else
                {
                    highlight = "";
                    data.Add(highlight);
                }
                return data;
            }
            return null;
        }



        /// <summary>
        /// 	Sends the divergence alert.
        /// </summary>
        /// <param name="sendmail"> if set to <c>true</c> [sendmail]. </param>
        /// <param name="sendtweet"> if set to <c>true</c> [sendtweet]. </param>
        /// <param name="datumdiverg"> The datumdiverg. </param>
        /// <param name="flowvalue"> The flowvalue. </param>
        public void SendDivergenceAlert(bool sendmail, bool sendtweet, List<string> datumdiverg, double flowvalue)
        {
            bool isvalidforposting = false;
            if (datumdiverg[6].Contains("M"))
            {
                string value = datumdiverg[6].Replace("M", String.Empty);
                string value1 = value.Replace('.', ',');
                double mflow = Convert.ToDouble(value1);
                isvalidforposting = Math.Abs(mflow) > flowvalue;
            }
            if (datumdiverg[6].Contains("B"))
            {
                isvalidforposting = true;
            }

            if (sendmail && isvalidforposting)
            {
                WebScrapMail.SendEmailAlert("$ flow Divergence",
                                            datumdiverg[0] + ";" + datumdiverg[1] + ";uptick/downtick " + datumdiverg[4].Trim() +
                                            ";price % change " + datumdiverg[5].Trim() + "  ;$ flow  " +
                                            datumdiverg[6] + " " + @"http://quotes.wsj.com/" + datumdiverg[0]);
            }

            if (sendtweet && isvalidforposting)
            {
                WebScrapMail.SendTweet("$spy $ flow Divergence : " +
                                       "$" + datumdiverg[0] +";"+datumdiverg[1] + ";uptick/downtick " + datumdiverg[4].Trim() +
                                       "; price % change " + datumdiverg[5].Trim() + "  ;$ flow  " + datumdiverg[6] +
                                       " " + @"http://quotes.wsj.com/" + datumdiverg[0], "TwitterMoneyFlow");
            }
        }


        /// <summary>
        /// 	Prices the money flow divergence.
        /// </summary>
        /// <param name="uptickdowntick"> The uptickdowntick. </param>
        /// <param name="percentchange"> The percentchange. </param>
        /// <returns> </returns>
        public bool PriceMoneyFlowDivergence(string uptickdowntick, string percentchange)
        {
            bool isDivergent = false;
            bool negativechange = false;
            bool buy = CompareData(uptickdowntick, "1.1");
            bool sell = CompareData(uptickdowntick, "0.9");
            if (percentchange.Contains("-"))
            {
                negativechange = true;
            }
            if (negativechange && buy)
            {
                isDivergent = true;
            }
            if (!negativechange && !sell)
            {
                isDivergent = true;
            }

            return isDivergent;
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
            //string port = "3306";
            //string database = "avafinScraper";
            //string uid = "root";
            //string password = "";
            if (dbData == null) return null;
            if (dbData.Count < 6)
            {
                Log.WriteLog("Insufficent data to connect to db.");
                return null;
            }
            string server = dbData[1];
            string port = dbData[2];
            string database = dbData[3];
            string uid = dbData[4];
            string password = dbData[5];
            string crypt = StringCipherHelper.Decrypt(password, "Cirtey1979!");

            List<string> values;
            string connectionstring =
                "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid +
                ";" + "PASSWORD=" + crypt + ";";
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

        /// <summary>
        /// 	Gets the WSJ data.
        /// </summary>
        /// <param name="ticker"> The ticker. </param>
        /// <returns> </returns>
        public Dictionary<string, string> GetWsjDataAllLiquid(string ticker)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string urlPt = @"http://finviz.com/quote.ashx?t=" + ticker + @"&ty=c&ta=0&p=d";
            var nodesPt = WebScrapHelper.LoadHtmlDoc(urlPt, "//td");

            if (nodesPt != null)
            {
                foreach (var node in nodesPt)
                {
                    if (node.InnerText.Trim().Count(x => x == '|') == 2)
                    {
                        GetSectorIndustryCountry(node, data);
                        break;
                    }
                }
            }

            var navWsj = Navigator(ticker, @" http://quotes.wsj.com/", @"?mod=DNH_S_cq");

            if (navWsj == null) return null;
            const string xpathUptick = "//*[@id='cr_keystock_drawer']/div[3]/ul/li/div[1]/div/div/div";
            var selectSingleNodeUptick = navWsj.SelectSingleNode(xpathUptick);
            if (selectSingleNodeUptick != null)
            {
                string uptick = selectSingleNodeUptick.Value;
                data.Add("uptickdowntick", uptick);
            }
            else
            {
                data.Add("uptickdowntick", null);
            }
            const string xpathPrice = "//*[@id='quote_val']";
            var selectSingleNodePrice = navWsj.SelectSingleNode(xpathPrice);
            if (selectSingleNodePrice != null)
            {
                string price = selectSingleNodePrice.Value;
                data.Add("price", price);
            }
            else
            {
                data.Add("price", null);
            }
            const string xpathPercent = "//*[@id='quote_changePer']";
            var selectSingleNodePercent = navWsj.SelectSingleNode(xpathPercent);
            if (selectSingleNodePercent != null)
            {
                string percent = selectSingleNodePercent.Value;
                data.Add("percentchange", percent);
            }
            else
            {
                data.Add("percentchange", null);
            }

            const string xpathMoneyFlow = "//*[@id='cr_keystock_drawer']/div[3]/ul/li/div[2]/span/span";
            var selectSingleNodMoneyFlow = navWsj.SelectSingleNode(xpathMoneyFlow);
            if (selectSingleNodMoneyFlow != null)
            {
                string percent = selectSingleNodMoneyFlow.Value;
                data.Add("moneyflow", percent);
            }
            else
            {
                data.Add("moneyflow", null);
            }


            return data;
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
                //string port = "3306";
                //string database = "avafinScraper";
                //string uid = "root";
                if (dbData == null)
                {
                    return null;
                }
                if (dbData.Count < 6)
                {
                    Log.WriteLog("Insufficent data to connect to db.");
                    return null;
                }
                string server = dbData[1];
                string port = dbData[2];
                string uid = dbData[4];
                string password = dbData[5];
              
                string crypt = StringCipherHelper.Decrypt(password, "Cirtey1979!");

                DbConnect db = new DbConnect(server, port, dbname, uid, crypt);
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
                data.Add("country", content[2]);
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