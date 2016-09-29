#region

using System;
using System.Collections.Generic;
using Helpers;
using WebScrap.Model;

#endregion

namespace WebScrap.Presenter
{
    /// <summary>
    /// </summary>
    internal class PresMain
    {
        private readonly WebScrapMail _mail = new WebScrapMail();
        private readonly IModel _scrap;
        private readonly IViewMoneyFlow _viewMoneyFlow;
        private readonly IViewScreener _viewScreener;

      
        private List<string> _tickerexists = new List<string>();

        public PresMain(IViewMoneyFlow view)
        {
            _viewMoneyFlow = view;
            _scrap = new Scrap();

            _tickerexists = null;
        }

        public PresMain(IViewScreener view)
        {
            _viewScreener = view;
            _scrap = new Scrap();
        }


        public bool FilterIndustry { get; set; }
        public string SelectedIndustry { get; set; }
        public bool FilterSector { get; set; }
        public string SelectedSector { get; set; }

        public void DeleteFinvizData(object labelDelete, string messageDelete)
        {
            _viewScreener.ViewLabel(labelDelete, "");
            _scrap.DeleteFinvizData();
            _viewScreener.ViewLabel(labelDelete, messageDelete);
        }

        public void UpdateFinvizDb(object labelUpdate, string messageUpdate)
        {
            _viewScreener.ViewLabel(labelUpdate, "Updating data.");
            _scrap.InsertFinvizData();
            _viewScreener.ViewLabel(labelUpdate, messageUpdate);
            Sound.PlayAlert("clock");
        }


        /// <summary>
        /// 	Fills the drop down list.
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <param name="dropDownName"> Name of the drop down. </param>
        /// <param name="displayMember"> The display member. </param>
        /// <param name="connectionstring"> The connectionstring. </param>
        public void FillDropDownList(string query, object dropDownName, string displayMember, string connectionstring)
        {
            List<string> values;
            if (!DbConnect.GetValue(query, displayMember, connectionstring, out values)) return;
            _viewScreener.FillCombobox(dropDownName, values);
        }


        /// <summary>
        /// 	Fills the drop down list.
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <param name="dropDownName"> Name of the drop down. </param>
        /// <param name="displayMember"> The display member. </param>
        /// <param name="connectionstring"> The connectionstring. </param>
        public void FillDropDownListMoneyFlow(string query, object dropDownName, string displayMember,
                                              string connectionstring)
        {
            List<string> values;
            if (!DbConnect.GetValue(query, displayMember, connectionstring, out values)) return;
            _viewMoneyFlow.FillCombobox(dropDownName, values);
        }

        /// <summary>
        /// 	Launches the page.
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <param name="displayMember"> The display member. </param>
        /// <param name="connectionstring"> The connectionstring. </param>
        /// <param name="filter"> The filter. </param>
        public void LaunchPage(string query, string displayMember, string connectionstring, string filter)
        {
            Webpages.OpenWebpage(_scrap.GetUrl(query, displayMember, connectionstring, filter));
        }

        /// <summary>
        /// 	Fills the drop downlist.
        /// </summary>
        /// <param name="comboboxes"> The comboboxes. </param>
        public void FillDropDownlist(List<object> comboboxes)
        {
            List<string> optionable = new List<string>();
            optionable.Add(string.Empty);
            optionable.Add("yes");
            optionable.Add("no");
            _viewScreener.FillCombobox(comboboxes[0], optionable);

            List<string> rsi14 = new List<string>();
            rsi14.Add(string.Empty);
            rsi14.Add(">70");
            rsi14.Add("<70");
            rsi14.Add(">30");
            rsi14.Add("<30");
            _viewScreener.FillCombobox(comboboxes[1], rsi14);
            List<string> anareco = new List<string>();
            anareco.Add(string.Empty);
            anareco.Add("=1");
            anareco.Add(">=2");
            anareco.Add("<=2");
            anareco.Add("<=4");
            anareco.Add("=5");
            _viewScreener.FillCombobox(comboboxes[2], anareco);
            List<string> price = new List<string>();
            price.Add(string.Empty);
            price.Add("<2");
            price.Add("<5");
            price.Add("<10");
            price.Add(">10");
            _viewScreener.FillCombobox(comboboxes[3], price);

            List<string> wlow52 = new List<string>();
            wlow52.Add(string.Empty);
            wlow52.Add("<0");
            wlow52.Add(">10");
            wlow52.Add(">30");
            wlow52.Add(">50");
            _viewScreener.FillCombobox(comboboxes[4], wlow52);

            List<string> whigh52 = new List<string>();
            whigh52.Add(string.Empty);
            whigh52.Add(">0");
            whigh52.Add("<10");
            whigh52.Add("<30");
            whigh52.Add("<50");
            _viewScreener.FillCombobox(comboboxes[5], whigh52);

            List<string> lastinsiderpurchaseisbywner = new List<string>();
            lastinsiderpurchaseisbywner.Add(string.Empty);
            lastinsiderpurchaseisbywner.Add("yes");
            lastinsiderpurchaseisbywner.Add("no");

            _viewScreener.FillCombobox(comboboxes[6], lastinsiderpurchaseisbywner);

            List<string> lastinsidersaleisbyowner = new List<string>();
            lastinsidersaleisbyowner.Add(string.Empty);
            lastinsidersaleisbyowner.Add("yes");
            lastinsidersaleisbyowner.Add("no");

            _viewScreener.FillCombobox(comboboxes[7], lastinsidersaleisbyowner);

            List<string> numrecentinspurchase = new List<string>();
            numrecentinspurchase.Add(string.Empty);
            numrecentinspurchase.Add(">0");
            numrecentinspurchase.Add(">3");


            _viewScreener.FillCombobox(comboboxes[8], numrecentinspurchase);

            List<string> numrecentinssale = new List<string>();
            numrecentinssale.Add(string.Empty);
            numrecentinssale.Add(">0");
            numrecentinssale.Add(">3");


            _viewScreener.FillCombobox(comboboxes[9], numrecentinssale);

            List<string> numrecentdiffinspurchase = new List<string>();
            numrecentdiffinspurchase.Add(string.Empty);
            numrecentdiffinspurchase.Add(">0");
            numrecentdiffinspurchase.Add(">3");


            _viewScreener.FillCombobox(comboboxes[10], numrecentdiffinspurchase);

            List<string> numrecentdiffinssale = new List<string>();
            numrecentdiffinssale.Add(string.Empty);
            numrecentdiffinssale.Add(">0");
            numrecentdiffinssale.Add(">3");


            _viewScreener.FillCombobox(comboboxes[11], numrecentdiffinssale);
        }


        /// <summary>
        /// 	Divergences the alerts.
        /// </summary>
        /// <param name="listboxDivergence"> The listbox divergence. </param>
        /// <param name="bull"> if set to <c>true</c> [bull]. </param>
        public void DivergenceAlerts(object listboxDivergence, bool bull)
        {
            try
            {
                _tickerexists = new List<string>();
                List<string> dataDiverg = new List<string>();
                List<string> dataFinviz =
                    _scrap.GetFinvizTickers(
                        (@"http://finviz.com/screener.ashx?v=1&&f=sh_avgvol_o50,sh_price_o1,sh_relvol_o1"));

                foreach (var ticker in dataFinviz)
                {
                    List<string> datum = _scrap.GetStocksDataAllLiquid(ticker, "1.1", "0.9", "5", "0.1");
                    bool isdivergent = false;
                    if (datum == null) continue;
                    if (datum.Count > 0 && !datum.Contains(null))
                        isdivergent = _scrap.PriceMoneyFlowDivergence(datum[4],
                                                                      datum[5]);
                    if (isdivergent)
                    {
                        List<string> datumdiverg = _scrap.GetStocksDataAllLiquid(ticker, "1.2", "0.8", "5", "0.1");

                        if (datumdiverg == null) continue;

                        if (!(datumdiverg.Count > 0 && !datumdiverg.Contains(null))) continue;
                        // low $ flows excluded
                        if (!(datumdiverg[6].Contains("M") || datumdiverg[6].Contains("B"))) continue;
                        if (bull)
                        {
                            if (datumdiverg[6].Contains("-"))
                                continue;
                        }
                        if (!bull)
                        {
                            if (!(datumdiverg[6].Contains("-")))
                                continue;
                        }


                        if (FilterIndustry && !string.IsNullOrEmpty(SelectedIndustry))
                        {
                            if (datumdiverg[2].Trim() == SelectedIndustry.Trim())
                            {
                                if (_tickerexists.Contains(datumdiverg[0].Trim())) continue;
                                PopulateListbox(listboxDivergence, dataDiverg,
                                                datumdiverg[0] + " / " + datumdiverg[4].Trim() + " / " +
                                                datumdiverg[5].Trim() + "  /  " + datumdiverg[6]);
                                _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[7]);
                                _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[1]);
                                _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[2]);
                                _tickerexists.Add(datumdiverg[0].Trim());

                                _scrap.SendDivergenceAlert(_viewMoneyFlow.Email, _viewMoneyFlow.Tweet, datumdiverg, 5);
                            }
                        }


                        else if (FilterSector && !string.IsNullOrEmpty(SelectedSector))
                        {
                            if (datumdiverg[1].Trim() == SelectedSector.Trim())
                            {
                                if (_tickerexists.Contains(datumdiverg[0].Trim())) continue;
                                PopulateListbox(listboxDivergence, dataDiverg,
                                                datumdiverg[0] + " / " + datumdiverg[4].Trim() + " / " +
                                                datumdiverg[5].Trim() + "  /  " + datumdiverg[6]);
                                _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[7]);
                                _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[1]);
                                _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[2]);
                                _tickerexists.Add(datumdiverg[0].Trim());


                                _scrap.SendDivergenceAlert(_viewMoneyFlow.Email, _viewMoneyFlow.Tweet, datumdiverg, 5);
                            }
                        }
                        else
                        {
                            if (_tickerexists.Contains(datumdiverg[0].Trim())) continue;
                            PopulateListbox(listboxDivergence, dataDiverg,
                                            datumdiverg[0] + " / " + datumdiverg[4].Trim() + " / " +
                                            datumdiverg[5].Trim() + "  /  " + datumdiverg[6]);
                            _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[7]);
                            _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[1]);
                            _viewMoneyFlow.ListboxAddItem(listboxDivergence, datumdiverg[2]);
                            _tickerexists.Add(datumdiverg[0].Trim());

                            _scrap.SendDivergenceAlert(_viewMoneyFlow.Email, _viewMoneyFlow.Tweet, datumdiverg, 5);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("Presmain DivergenceAlerts");
                Log.WriteLog(ex.ToString());
            }
        }


        /// <summary>
        /// 	Populates the listbox.
        /// </summary>
        /// <param name="listbox"> The listbox. </param>
        /// <param name="data"> The data. </param>
        /// <param name="datum"> The datum. </param>
        private void PopulateListbox(object listbox, List<string> data, string datum)
        {
            if (data.Contains(datum) || datum == null) return;
            data.Add(datum);

            if (data.Count < 2)
                _viewMoneyFlow.ListboxAddItem(listbox, "++++++++++++++++++");


            _viewMoneyFlow.ListboxAddItem(listbox, "------------------");

            _viewMoneyFlow.ListboxAddItem(listbox, datum.Trim().ToUpper());
        }


        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="labelprice">The labelprice.</param>
        /// <param name="labelmoneyflow">The labelmoneyflow.</param>
        /// <param name="labeluptickdowntick">The labeluptickdowntick.</param>
        /// <param name="labelpercentchange">The labelpercentchange.</param>
        /// <param name="ticker">The ticker.</param>
        /// <param name="alertFlowValue">The alert flow value.</param>
        /// <param name="alertRatioValue">The alert ratio value.</param>
        /// <param name="alertRatioValueNeg">The alert ratio value neg.</param>
        /// <param name="sound">The sound.</param>
        /// <param name="activesoundalert">if set to <c>true</c> [activesoundalert].</param>
        /// <param name="activemailalert">if set to <c>true</c> [activemailalert].</param>
        /// <param name="starlabel">The starlabel.</param>
        public void GetWsjData(object labelprice, object labelmoneyflow, object labeluptickdowntick,
                               object labelpercentchange,
                               string ticker, string alertFlowValue,
                               string alertRatioValue, string alertRatioValueNeg, string sound,
                               bool activesoundalert,
                               bool activemailalert, object starlabel)
        {
            try
            {
                Dictionary<string, string> tickerdataFlow = _scrap.GetWsjData(ticker);


                string uptickdowntick = null;
                string price = null;
                string percentchange = null;
                string moneyflow = null;
                string moneyflowbrute = null;

                if (tickerdataFlow != null)
                {
                    if (tickerdataFlow.Count > 0)
                    {
                        uptickdowntick = tickerdataFlow["uptickdowntick"];
                        price = tickerdataFlow["price"];
                        percentchange = tickerdataFlow["percentchange"];
                        moneyflow = tickerdataFlow["moneyflow"];
                        moneyflowbrute = tickerdataFlow["moneyflowbrute"];
                    }
                }


                bool flowAlert = _scrap.CompareData(moneyflow, alertFlowValue, sound, activesoundalert);
                bool ratioAlert = _scrap.CompareData(uptickdowntick, alertRatioValue, sound, activesoundalert);
                bool ratioAlertNeg = _scrap.CompareData(alertRatioValueNeg, uptickdowntick, sound, activesoundalert);


                bool starVisible = false;

                if (flowAlert || ratioAlert || ratioAlertNeg)
                {
                    starVisible = true;
                }


                _viewMoneyFlow.VisibleLabel(starlabel, starVisible);
                _viewMoneyFlow.ViewLabel(labelmoneyflow, moneyflowbrute);
                _viewMoneyFlow.ViewLabel(labelpercentchange, percentchange);
                _viewMoneyFlow.ViewLabel(labeluptickdowntick, uptickdowntick);
                _viewMoneyFlow.ViewLabel(labelprice, price);


                if (activemailalert)
                {
                    _mail.SendMailMoneyFlow(ticker, percentchange, uptickdowntick,moneyflow, ratioAlert, ratioAlertNeg, flowAlert);
                }
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
        }


        /// <summary>
        /// 	Gets the WSJ data.
        /// </summary>
        /// <param name="labelT1B"> The label t1 B. </param>
        /// <param name="labelT2B"> The label t2 B. </param>
        /// <param name="labelT3B"> The label t3 B. </param>
        /// <param name="labelT4B"> The label t4 B. </param>
        /// <param name="labelT5B"> The label t5 B. </param>
        /// <param name="labelT1S"> The label t1 S. </param>
        /// <param name="labelT2S"> The label t2 S. </param>
        /// <param name="labelT3S"> The label t3 S. </param>
        /// <param name="labelT4S"> The label t4 S. </param>
        /// <param name="labelT5S"> The label t5 S. </param>
        /// <param name="labelT6B"> The label t6 B. </param>
        /// <param name="labelT7B"> The label t7 B. </param>
        /// <param name="labelT8B"> The label t8 B. </param>
        /// <param name="labelT9B"> The label t9 B. </param>
        /// <param name="labelT10B"> The label T10 B. </param>
        /// <param name="labelT6S"> The label t6 S. </param>
        /// <param name="labelT7S"> The label t7 S. </param>
        /// <param name="labelT8S"> The label t8 S. </param>
        /// <param name="labelT9S"> The label t9 S. </param>
        /// <param name="labelT10S"> The label T10 S. </param>
        /// <param name="labelT11B"> The label T11 B. </param>
        /// <param name="labelT12B"> The label T12 B. </param>
        /// <param name="labelT13B"> The label T13 B. </param>
        /// <param name="labelT14B"> The label T14 B. </param>
        /// <param name="labelT15B"> The label T15 B. </param>
        /// <param name="labelT11S"> The label T11 S. </param>
        /// <param name="labelT12S"> The label T12 S. </param>
        /// <param name="labelT13S"> The label T13 S. </param>
        /// <param name="labelT14S"> The label T14 S. </param>
        /// <param name="labelT15S"> The label T15 S. </param>
        /// <param name="labelT16B"> The label T16 B. </param>
        /// <param name="labelT17B"> The label T17 B. </param>
        /// <param name="labelT18B"> The label T18 B. </param>
        /// <param name="labelT19B"> The label T19 B. </param>
        /// <param name="labelT20B"> The label T20 B. </param>
        /// <param name="labelT16S"> The label T16 S. </param>
        /// <param name="labelT17S"> The label T17 S. </param>
        /// <param name="labelT18S"> The label T18 S. </param>
        /// <param name="labelT19S"> The label T19 S. </param>
        /// <param name="labelT20S"> The label T20 S. </param>
        /// <param name="?"> The ?. </param>
        public void GetWsjData(Object labelT1B, Object labelT2B, Object labelT3B, Object labelT4B, Object labelT5B,
                               Object labelT1S, Object labelT2S, Object labelT3S, Object labelT4S, Object labelT5S,
                               Object labelT6B, Object labelT7B, Object labelT8B, Object labelT9B, Object labelT10B,
                               Object labelT6S, Object labelT7S, Object labelT8S, Object labelT9S, Object labelT10S,
                               Object labelT11B, Object labelT12B, Object labelT13B, Object labelT14B, Object labelT15B,
                               Object labelT11S, Object labelT12S, Object labelT13S, Object labelT14S, Object labelT15S,
                               Object labelT16B, Object labelT17B, Object labelT18B, Object labelT19B, Object labelT20B,
                               Object labelT16S, Object labelT17S, Object labelT18S, Object labelT19S, Object labelT20S
            )
        {
            // Buy on weakness
            List<string> tickersB =
                _scrap.GetWsjTickers(@"http://online.wsj.com/mdc/public/page/2_3022-mfgppl-moneyflow.html");


            // Sell on strength;
            // Buy on weakness
            List<string> tickersS =
                _scrap.GetWsjTickers(@"http://online.wsj.com/mdc/public/page/2_3022-mflppg-moneyflow.html");

            if (tickersB == null) return;

            if (tickersB.Count == 21)
            {
                _viewMoneyFlow.ViewLabel(labelT1B, "1- " + tickersB[0]);
                _viewMoneyFlow.ViewLabel(labelT2B, "2- " + tickersB[1]);
                _viewMoneyFlow.ViewLabel(labelT3B, "3- " + tickersB[2]);
                _viewMoneyFlow.ViewLabel(labelT4B, "4- " + tickersB[3]);
                _viewMoneyFlow.ViewLabel(labelT5B, "5- " + tickersB[4]);

                _viewMoneyFlow.ViewLabel(labelT6B, "6- " + tickersB[5]);
                _viewMoneyFlow.ViewLabel(labelT7B, "7- " + tickersB[6]);
                _viewMoneyFlow.ViewLabel(labelT8B, "8- " + tickersB[7]);
                _viewMoneyFlow.ViewLabel(labelT9B, "9- " + tickersB[8]);
                _viewMoneyFlow.ViewLabel(labelT10B, "10- " + tickersB[9]);

                _viewMoneyFlow.ViewLabel(labelT11B, "11- " + tickersB[10]);
                _viewMoneyFlow.ViewLabel(labelT12B, "12- " + tickersB[11]);
                _viewMoneyFlow.ViewLabel(labelT13B, "13- " + tickersB[12]);
                _viewMoneyFlow.ViewLabel(labelT14B, "14- " + tickersB[13]);
                _viewMoneyFlow.ViewLabel(labelT15B, "15- " + tickersB[14]);

                _viewMoneyFlow.ViewLabel(labelT16B, "16- " + tickersB[15]);
                _viewMoneyFlow.ViewLabel(labelT17B, "17- " + tickersB[16]);
                _viewMoneyFlow.ViewLabel(labelT18B, "18- " + tickersB[17]);
                _viewMoneyFlow.ViewLabel(labelT19B, "19- " + tickersB[18]);
                _viewMoneyFlow.ViewLabel(labelT20B, "20-" + tickersB[19]);
            }

            if (tickersS == null) return;
            if (tickersS.Count == 21)
            {
                _viewMoneyFlow.ViewLabel(labelT1S, "1- " + tickersS[0]);
                _viewMoneyFlow.ViewLabel(labelT2S, "2- " + tickersS[1]);
                _viewMoneyFlow.ViewLabel(labelT3S, "3- " + tickersS[2]);
                _viewMoneyFlow.ViewLabel(labelT4S, "4- " + tickersS[3]);
                _viewMoneyFlow.ViewLabel(labelT5S, "5- " + tickersS[4]);

                _viewMoneyFlow.ViewLabel(labelT6S, "6- " + tickersS[5]);
                _viewMoneyFlow.ViewLabel(labelT7S, "7- " + tickersS[6]);
                _viewMoneyFlow.ViewLabel(labelT8S, "8- " + tickersS[7]);
                _viewMoneyFlow.ViewLabel(labelT9S, "9- " + tickersS[8]);
                _viewMoneyFlow.ViewLabel(labelT10S, "10- " + tickersS[9]);

                _viewMoneyFlow.ViewLabel(labelT11S, "11- " + tickersS[10]);
                _viewMoneyFlow.ViewLabel(labelT12S, "12- " + tickersS[11]);
                _viewMoneyFlow.ViewLabel(labelT13S, "13- " + tickersS[12]);
                _viewMoneyFlow.ViewLabel(labelT14S, "14- " + tickersS[13]);
                _viewMoneyFlow.ViewLabel(labelT15S, "15- " + tickersS[14]);

                _viewMoneyFlow.ViewLabel(labelT16S, "16- " + tickersS[15]);
                _viewMoneyFlow.ViewLabel(labelT17S, "17- " + tickersS[16]);
                _viewMoneyFlow.ViewLabel(labelT18S, "18- " + tickersS[17]);
                _viewMoneyFlow.ViewLabel(labelT19S, "19- " + tickersS[18]);
                _viewMoneyFlow.ViewLabel(labelT20S, "20-" + tickersS[19]);
            }
        }

        /// <summary>
        /// 	Sets the state.
        /// </summary>
        /// <param name="tickername"> The tickername. </param>
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
        public string SetTickersState(string tickername, string ticker1, string ticker2, string ticker3, string ticker4,
                                      string ticker5,
                                      string ticker6, string ticker7, string ticker8, string ticker9, string ticker10,
                                      string ticker1FAlert, string ticker2FAlert, string ticker3FAlert,
                                      string ticker4FAlert, string ticker5FAlert, string ticker6FAlert,
                                      string ticker7FAlert, string ticker8FAlert, string ticker9FAlert,
                                      string ticker10FAlert,
                                      string ticker1RAlert, string ticker2RAlert,
                                      string ticker3RAlert, string ticker4RAlert, string ticker5RAlert,
                                      string ticker6RAlert, string ticker7RAlert, string ticker8RAlert,
                                      string ticker9RAlert, string ticker10RAlert,
                                      string ticker1RAlertNeg, string ticker2RAlertNeg,
                                      string ticker3RAlertNeg, string ticker4RAlertNeg, string ticker5RAlertNeg,
                                      string ticker6RAlertNeg, string ticker7RAlertNeg, string ticker8RAlertNeg,
                                      string ticker9RAlertNeg, string ticker10RAlertNeg)
        {
            return WebScrapWriteData.WriteTickerData(tickername, ticker1, ticker2, ticker3, ticker4, ticker5, ticker6,
                                                     ticker7, ticker8, ticker9,
                                                     ticker10,
                                                     ticker1FAlert, ticker2FAlert, ticker3FAlert, ticker4FAlert,
                                                     ticker5FAlert, ticker6FAlert, ticker7FAlert, ticker8FAlert,
                                                     ticker9FAlert,
                                                     ticker10FAlert,
                                                     ticker1RAlert, ticker2RAlert, ticker3RAlert, ticker4RAlert,
                                                     ticker5RAlert, ticker6RAlert, ticker7RAlert, ticker8RAlert,
                                                     ticker9RAlert,
                                                     ticker10RAlert,
                                                     ticker1RAlertNeg, ticker2RAlertNeg, ticker3RAlertNeg,
                                                     ticker4RAlertNeg,
                                                     ticker5RAlertNeg, ticker6RAlertNeg, ticker7RAlertNeg,
                                                     ticker8RAlertNeg,
                                                     ticker9RAlertNeg,
                                                     ticker10RAlertNeg
                );
        }

        /// <summary>
        /// 	Gets the state of the tickers.
        /// </summary>
        /// <param name="file"> The file. </param>
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
        public void GetTickersState(string file, object ticker1, object ticker2, object ticker3, object ticker4,
                                    object ticker5,
                                    object ticker6, object ticker7, object ticker8, object ticker9, object ticker10,
                                    object ticker1FAlert, object ticker2FAlert, object ticker3FAlert,
                                    object ticker4FAlert, object ticker5FAlert, object ticker6FAlert,
                                    object ticker7FAlert, object ticker8FAlert, object ticker9FAlert,
                                    object ticker10FAlert,
                                    object ticker1RAlert, object ticker2RAlert,
                                    object ticker3RAlert, object ticker4RAlert, object ticker5RAlert,
                                    object ticker6RAlert, object ticker7RAlert, object ticker8RAlert,
                                    object ticker9RAlert, object ticker10RAlert,
                                    object ticker1RAlertNeg, object ticker2RAlertNeg,
                                    object ticker3RAlertNeg, object ticker4RAlertNeg, object ticker5RAlertNeg,
                                    object ticker6RAlertNeg, object ticker7RAlertNeg, object ticker8RAlertNeg,
                                    object ticker9RAlertNeg, object ticker10RAlertNeg
            )
        {
            try
            {
                List<string> data = XmlReadWrite.ReadXMLData(file, "//Insiderstracker//tickers//");


                string ticker1D = null;
                if (data[1] != null)
                {
                    ticker1D = data[1];
                }


                string ticker2D = null;
                if (data[2] != null)
                {
                    ticker2D = data[2];
                }


                string ticker3D = null;
                if (data[3] != null)
                {
                    ticker3D = data[3];
                }


                string ticker4D = null;
                if (data[4] != null)
                {
                    ticker4D = data[4];
                }


                string ticker5D = null;
                if (data[5] != null)
                {
                    ticker5D = data[5];
                }


                string ticker1DFa = null;
                if (data[6] != null)
                {
                    ticker1DFa = data[6];
                }


                string ticker2DFa = null;
                if (data[7] != null)
                {
                    ticker2DFa = data[7];
                }


                string ticker3DFa = null;
                if (data[8] != null)
                {
                    ticker3DFa = data[8];
                }


                string ticker4DFa = null;
                if (data[9] != null)
                {
                    ticker4DFa = data[9];
                }


                string ticker5DFa = null;
                if (data[10] != null)
                {
                    ticker5DFa = data[10];
                }


                string ticker1DRa = null;
                if (data[11] != null)
                {
                    ticker1DRa = data[11];
                }


                string ticker2DRa = null;
                if (data[12] != null)
                {
                    ticker2DRa = data[12];
                }


                string ticker3DRa = null;
                if (data[13] != null)
                {
                    ticker3DRa = data[13];
                }


                string ticker4DRa = null;
                if (data[14] != null)
                {
                    ticker4DRa = data[14];
                }


                string ticker5DRa = null;
                if (data[15] != null)
                {
                    ticker5DRa = data[15];
                }


                string ticker1DRaNeg = null;
                if (data[16] != null)
                {
                    ticker1DRaNeg = data[16];
                }


                string ticker2DRaNeg = null;
                if (data[17] != null)
                {
                    ticker2DRaNeg = data[17];
                }


                string ticker3DRaNeg = null;
                if (data[18] != null)
                {
                    ticker3DRaNeg = data[18];
                }


                string ticker4DRaNeg = null;
                if (data[19] != null)
                {
                    ticker4DRaNeg = data[19];
                }


                string ticker5DRaNeg = null;
                if (data[20] != null)
                {
                    ticker5DRaNeg = data[20];
                }


                _viewMoneyFlow.ViewTextBox(ticker1, ticker1D);
                _viewMoneyFlow.ViewTextBox(ticker2, ticker2D);
                _viewMoneyFlow.ViewTextBox(ticker3, ticker3D);
                _viewMoneyFlow.ViewTextBox(ticker4, ticker4D);
                _viewMoneyFlow.ViewTextBox(ticker5, ticker5D);

                _viewMoneyFlow.ViewTextBox(ticker1FAlert, ticker1DFa);
                _viewMoneyFlow.ViewTextBox(ticker2FAlert, ticker2DFa);
                _viewMoneyFlow.ViewTextBox(ticker3FAlert, ticker3DFa);
                _viewMoneyFlow.ViewTextBox(ticker4FAlert, ticker4DFa);
                _viewMoneyFlow.ViewTextBox(ticker5FAlert, ticker5DFa);

                _viewMoneyFlow.ViewTextBox(ticker1RAlert, ticker1DRa);
                _viewMoneyFlow.ViewTextBox(ticker2RAlert, ticker2DRa);
                _viewMoneyFlow.ViewTextBox(ticker3RAlert, ticker3DRa);
                _viewMoneyFlow.ViewTextBox(ticker4RAlert, ticker4DRa);
                _viewMoneyFlow.ViewTextBox(ticker5RAlert, ticker5DRa);


                _viewMoneyFlow.ViewTextBox(ticker1RAlertNeg, ticker1DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker2RAlertNeg, ticker2DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker3RAlertNeg, ticker3DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker4RAlertNeg, ticker4DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker5RAlertNeg, ticker5DRaNeg);


                string ticker6D = null;
                if (data[21] != null)
                {
                    ticker6D = data[21];
                }


                string ticker7D = null;
                if (data[22] != null)
                {
                    ticker7D = data[22];
                }


                string ticker8D = null;
                if (data[23] != null)
                {
                    ticker8D = data[23];
                }


                string ticker9D = null;
                if (data[24] != null)
                {
                    ticker9D = data[24];
                }


                string ticker10D = null;
                if (data[25] != null)
                {
                    ticker10D = data[25];
                }


                string ticker6DFa = null;
                if (data[26] != null)
                {
                    ticker6DFa = data[26];
                }


                string ticker7DFa = null;
                if (data[27] != null)
                {
                    ticker7DFa = data[27];
                }


                string ticker8DFa = null;
                if (data[28] != null)
                {
                    ticker8DFa = data[28];
                }


                string ticker9DFa = null;
                if (data[29] != null)
                {
                    ticker9DFa = data[29];
                }


                string ticker10DFa = null;
                if (data[30] != null)
                {
                    ticker10DFa = data[30];
                }


                string ticker6DRa = null;
                if (data[31] != null)
                {
                    ticker6DRa = data[31];
                }


                string ticker7DRa = null;
                if (data[32] != null)
                {
                    ticker7DRa = data[32];
                }


                string ticker8DRa = null;
                if (data[33] != null)
                {
                    ticker8DRa = data[33];
                }


                string ticker9DRa = null;
                if (data[34] != null)
                {
                    ticker9DRa = data[34];
                }


                string ticker10DRa = null;
                if (data[35] != null)
                {
                    ticker10DRa = data[35];
                }


                string ticker6DRaNeg = null;
                if (data[36] != null)
                {
                    ticker6DRaNeg = data[36];
                }


                string ticker7DRaNeg = null;
                if (data[37] != null)
                {
                    ticker7DRaNeg = data[37];
                }


                string ticker8DRaNeg = null;
                if (data[38] != null)
                {
                    ticker8DRaNeg = data[38];
                }


                string ticker9DRaNeg = null;
                if (data[39] != null)
                {
                    ticker9DRaNeg = data[39];
                }


                string ticker10DRaNeg = null;
                if (data[40] != null)
                {
                    ticker10DRaNeg = data[40];
                }


                _viewMoneyFlow.ViewTextBox(ticker6, ticker6D);
                _viewMoneyFlow.ViewTextBox(ticker7, ticker7D);
                _viewMoneyFlow.ViewTextBox(ticker8, ticker8D);
                _viewMoneyFlow.ViewTextBox(ticker9, ticker9D);
                _viewMoneyFlow.ViewTextBox(ticker10, ticker10D);

                _viewMoneyFlow.ViewTextBox(ticker6FAlert, ticker6DFa);
                _viewMoneyFlow.ViewTextBox(ticker7FAlert, ticker7DFa);
                _viewMoneyFlow.ViewTextBox(ticker8FAlert, ticker8DFa);
                _viewMoneyFlow.ViewTextBox(ticker9FAlert, ticker9DFa);
                _viewMoneyFlow.ViewTextBox(ticker10FAlert, ticker10DFa);

                _viewMoneyFlow.ViewTextBox(ticker6RAlert, ticker6DRa);
                _viewMoneyFlow.ViewTextBox(ticker7RAlert, ticker7DRa);
                _viewMoneyFlow.ViewTextBox(ticker8RAlert, ticker8DRa);
                _viewMoneyFlow.ViewTextBox(ticker9RAlert, ticker9DRa);
                _viewMoneyFlow.ViewTextBox(ticker10RAlert, ticker10DRa);


                _viewMoneyFlow.ViewTextBox(ticker6RAlertNeg, ticker6DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker7RAlertNeg, ticker7DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker8RAlertNeg, ticker8DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker9RAlertNeg, ticker9DRaNeg);
                _viewMoneyFlow.ViewTextBox(ticker10RAlertNeg, ticker10DRaNeg);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
        }

        public void ManageCheckBoxes(Object ticker1, bool value1, Object ticker2, bool value2, Object ticker3,
                                     bool value3, Object ticker4, bool value4, Object ticker5, bool value5,
                                     Object ticker6, bool value6, Object ticker7, bool value7, Object ticker8,
                                     bool value8, Object ticker9, bool value9, Object ticker10, bool value10)
        {
            _viewMoneyFlow.ViewCheckBox(ticker1, value1);
            _viewMoneyFlow.ViewCheckBox(ticker2, value2);
            _viewMoneyFlow.ViewCheckBox(ticker3, value3);
            _viewMoneyFlow.ViewCheckBox(ticker4, value4);
            _viewMoneyFlow.ViewCheckBox(ticker5, value5);
            _viewMoneyFlow.ViewCheckBox(ticker6, value6);
            _viewMoneyFlow.ViewCheckBox(ticker7, value7);
            _viewMoneyFlow.ViewCheckBox(ticker8, value8);
            _viewMoneyFlow.ViewCheckBox(ticker9, value9);
            _viewMoneyFlow.ViewCheckBox(ticker10, value10);
        }
    }
}