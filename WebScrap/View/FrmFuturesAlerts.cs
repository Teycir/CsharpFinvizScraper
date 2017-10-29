#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using WebScrap.Model;

#endregion

namespace WebScrap.View
{
    public partial class FrmFuturesAlerts : Form
    {
        private readonly List<string> _alertsDailyPp = new List<string>();
        private readonly List<string> _alertsHourlyPp = new List<string>();
        private readonly List<string> _alertsqHourlyPp = new List<string>();
        private readonly List<string> _alertsDailySma = new List<string>();
        private readonly List<string> _alertsHourlySma = new List<string>();
        private readonly List<string> _alertsqHourlySma = new List<string>();
        private readonly List<string> _alertsDailyRsi = new List<string>();
        private readonly List<string> _alertsHourlyRsi = new List<string>();
        private readonly List<string> _alertsqHourlyRsi = new List<string>();

        private readonly ScrapFuturesAlert _scrap;
        public Thread ThreadMain;
        public bool ThreadMainActive;
        private bool _mailalertDaily;
        private bool _mailalertHourly;
        private bool _mailalertqHourly;
        private bool _soundalertDaily;
        private bool _soundalertHourly;
        private bool _soundalertqHourly;
        private bool _tweetalertDaily;
        private bool _tweetalertHourly;
        private bool _tweetalertqHourly;

        private bool _rsiDaily;
        private bool _rsiHourly;
        private bool _rsiqHourly;
        private bool _smaDaily;
        private bool _smaHourly;
        private bool _smaqHourly;
        private bool _ppDaily;
        private bool _ppHourly;
        private bool _ppqHourly;
        private bool _pp1Daily;
        private bool _pp1Hourly;
        private bool _pp1qHourly;
        private bool _pp2Daily;
        private bool _pp2Hourly;
        private bool _pp2qHourly;
        private bool _pp3Daily;
        private bool _pp3Hourly;
        private bool _pp3qHourly;

        public FrmFuturesAlerts()
        {
            InitializeComponent();
            _scrap = new ScrapFuturesAlert();
            labelActive.Visible = false;
            labelInactive.Visible = true;
            List<string> dailyTickers = XmlReadWrite.ReadXMLData("DailyFuturesTickers", "//Insiderstracker//");
            if (dailyTickers != null)
                textBoxDailyTickers.Text = dailyTickers[0];
            List<string> hourlyTickers = XmlReadWrite.ReadXMLData("HourlyFuturesTickers", "//Insiderstracker//");
            if (hourlyTickers != null)
                textBoxHourlyTickers.Text = hourlyTickers[0];
            List<string> qhourlyTickers = XmlReadWrite.ReadXMLData("qHourlyFuturesTickers", "//Insiderstracker//");
            if (qhourlyTickers != null)
                textBoxqHourlyTickers.Text = qhourlyTickers[0];

            _rsiDaily = true;
            _rsiHourly = true;
            _rsiqHourly = true;
            _smaDaily = true;
            _smaHourly = false;
            _smaqHourly = false;

        }


        private void InitThreadMain()
        {
            while (ThreadMainActive)
            {
                GetMainData();
            }
        }

        private void StartMainThread()
        {
            ThreadMainActive = true;
            ThreadMain = new Thread(InitThreadMain);
            if (!ThreadMain.IsAlive)
            {
                ThreadMain.IsBackground = true;
                ThreadMain.Start();
            }
            ThreadHelper.SetVisibility(this, labelInactive, false);
            ThreadHelper.SetVisibility(this, labelActive, true);
        }

        private void StopMainThread()
        {
            ThreadMainActive = false;
            ThreadHelper.SetVisibility(this, labelInactive, true);
            ThreadHelper.SetVisibility(this, labelActive, false);
            if (ThreadMain == null) return;
            if (ThreadMain.IsAlive)
            {
                ThreadMain.Abort();
            }
        }

        private void StartWebScraping()
        {
            if (_scrap.GetEsDaily() == null)
            {
                MessageBox.Show("Data unavailable on investing.com.", "Webscraping error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            StartMainThread();
            Thread.Sleep(10000);
        }


        /// <summary>
        /// Gets the future data.
        /// </summary>
        /// <param name="dailydatafut">The datafut.</param>
        /// <param name="hourlydatafut">The hourlydatafut.</param>
        /// <param name="ticker">The ticker.</param>
        /// <param name="text1">The text1.</param>
        /// <param name="label1">The label1.</param>
        /// <param name="text2">The text2.</param>
        /// <param name="text3">The text3.</param>
        /// <param name="text4">The text4.</param>
        /// <param name="text5">The text5.</param>
        /// <param name="text6">The text6.</param>
        /// <param name="text7">The text7.</param>
        /// <param name="url">The URL.</param>
        /// <param name="labeltrend">The labeltrend.</param>
        private void GetFutureData(Dictionary<string, string> dailydatafut, Dictionary<string, string> hourlydatafut, Dictionary<string, string> qhourlydatafut,
                                   string ticker, TextBox text1, Label label1, TextBox text2, TextBox text3,
                                   TextBox text4, TextBox text5, TextBox text6, TextBox text7, string url, Label labeltrend)
        {
            Dictionary<string, string> f1Daily = dailydatafut;
            Dictionary<string, string> f1Hourly = hourlydatafut;
            Dictionary<string, string> f1qHourly = qhourlydatafut;
            if (dailydatafut == null || hourlydatafut == null || qhourlydatafut == null) return;

            if (f1Daily.ContainsKey("rsi"))
               if (f1Daily["rsi"] != null)
                  _scrap.RsiDisplayAlerts(text4, f1Daily["rsi"], 70, 30);
            
            if (f1Hourly.ContainsKey("rsi"))
               if (f1Hourly["rsi"] != null)
                _scrap.RsiDisplayAlerts(text7, f1Hourly["rsi"], 70, 30);






            if (f1Daily.ContainsKey("price"))
                if (f1Daily["price"]!=null)
            ThreadHelper.SetText(this, text1, f1Daily["price"]);
            if (f1Daily.ContainsKey("percent"))
                if (f1Daily["percent"]!= null)
            ThreadHelper.SetText(this, label1, f1Daily["percent"]);
            if (f1Daily.ContainsKey("s3"))
                if (f1Daily["s3"]!=null)
            ThreadHelper.SetText(this, text2, f1Daily["s3"]);
            if (f1Daily.ContainsKey("r3"))
                if (f1Daily["r3"]!=null)
            ThreadHelper.SetText(this, text3, f1Daily["r3"]);
            if (f1Daily.ContainsKey("rsi"))
                if (f1Daily["rsi"]!=null)
            ThreadHelper.SetText(this, text4, f1Daily["rsi"]);
            if (f1Hourly.ContainsKey("s3"))
                if (f1Hourly["s3"]!=null)
            ThreadHelper.SetText(this, text5, f1Hourly["s3"]);
            if (f1Hourly.ContainsKey("r3"))
                if (f1Hourly["r3"]!=null)
            ThreadHelper.SetText(this, text6, f1Hourly["r3"]);
            if (f1Hourly.ContainsKey("rsi"))
                if (f1Hourly["rsi"]!=null)
            ThreadHelper.SetText(this, text7, f1Hourly["rsi"]);



            if (f1Daily.ContainsKey("sma20") && f1Daily.ContainsKey("sma50")
                && f1Hourly.ContainsKey("sma20") && f1Hourly.ContainsKey("sma50")
                && f1qHourly.ContainsKey("sma20") && f1qHourly.ContainsKey("sma50"))
                _scrap.SmaDisplayAlerts(f1Daily["sma20"], f1Daily["sma50"], 
                    f1Hourly["sma20"], f1Hourly["sma50"], 
                    f1qHourly["sma20"], f1qHourly["sma50"], ticker, this, labeltrend, url);



            if(_rsiDaily && f1Daily.ContainsKey("rsi"))
            {
                
                    _scrap.RsiAlerts(f1Daily["rsi"], ticker, " daily RSI14 alert: ", 70, 30,
                       _alertsDailyRsi, this, listBoxFDaily, _soundalertDaily, _mailalertDaily, _tweetalertDaily, url,
                       "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);
            }
      

            if(_rsiHourly && f1Hourly.ContainsKey("rsi"))
            {
                _scrap.RsiAlerts(f1Hourly["rsi"], ticker, " 60 min RSI14 alert: ", 70, 30,
                          _alertsHourlyRsi, this, listBoxFHourly, _soundalertHourly, _mailalertHourly, _tweetalertHourly,
                          url, "SIREN", textBoxHourlyTickers.Text);
                Thread.Sleep(200);
            }



            if (_rsiqHourly && f1qHourly.ContainsKey("rsi"))
            {
                _scrap.RsiAlerts(f1qHourly["rsi"], ticker, " 15 min RSI14 alert: ", 70, 30,
                          _alertsqHourlyRsi, this, listBoxFqHourly, _soundalertqHourly, _mailalertqHourly, _tweetalertqHourly,
                          url, "SIREN", textBoxqHourlyTickers.Text);
                Thread.Sleep(200);
            }



            if (_smaDaily && f1Daily.ContainsKey("sma20") && f1Daily.ContainsKey("sma50"))
            {
                _scrap.SmaAlerts(f1Daily["sma20"], f1Daily["sma50"],
                              "daily SMA alert: ", ticker, this, listBoxFDaily, _soundalertDaily, _mailalertDaily, _tweetalertDaily,
                           url, "ALARM", textBoxDailyTickers.Text, _alertsDailySma);
                Thread.Sleep(600);

            }
          


            if(_smaHourly && f1Hourly.ContainsKey("sma20") && f1Hourly.ContainsKey("sma50"))
            {
                _scrap.SmaAlerts(f1Hourly["sma20"], f1Hourly["sma50"],
                       " 60 min SMA alert: ", ticker, this, listBoxFHourly, _soundalertHourly, _mailalertHourly, _tweetalertHourly,
                    url, "SIREN", textBoxHourlyTickers.Text,_alertsHourlySma);
                Thread.Sleep(600);
            }



            if (_smaqHourly && f1qHourly.ContainsKey("sma20") && f1qHourly.ContainsKey("sma50"))
            {
                _scrap.SmaAlerts(f1qHourly["sma20"], f1qHourly["sma50"],
                       " 15 min SMA alert: ", ticker, this, listBoxFqHourly, _soundalertqHourly, _mailalertqHourly, _tweetalertqHourly,
                    url, "SIREN", textBoxHourlyTickers.Text, _alertsqHourlySma);
                Thread.Sleep(600);
            }




            if (_ppDaily && f1Daily.ContainsKey("price") && f1Daily.ContainsKey("s1") && f1Daily.ContainsKey("s2") &&  f1Daily.ContainsKey("s3") && f1Daily.ContainsKey("r1") && f1Daily.ContainsKey("r2") && f1Daily.ContainsKey("r3"))
            {
                _scrap.PivotAlerts(f1Daily["s1"], f1Daily["price"],
                        "S", " daily S1 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily, _mailalertDaily,
                        _tweetalertDaily, this, listBoxFDaily, url, "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);

                _scrap.PivotAlerts(f1Daily["r1"], f1Daily["price"],
                                   "R", " daily R1 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily, _mailalertDaily,
                                   _tweetalertDaily, this, listBoxFDaily, url, "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1Daily["s3"], f1Daily["price"],
                                   "S", " daily S3 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily, _mailalertDaily,
                                   _tweetalertDaily, this, listBoxFDaily, url, "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);

                _scrap.PivotAlerts(f1Daily["r3"], f1Daily["price"],
                                   "R", " daily R3 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily, _mailalertDaily,
                                   _tweetalertDaily, this, listBoxFDaily, url, "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1Daily["s3"], f1Daily["price"],
                                   "S", " daily S3 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily, _mailalertDaily,
                                   _tweetalertDaily, this, listBoxFDaily, url, "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1Daily["r3"], f1Daily["price"],
                                   "R", " daily R3 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily, _mailalertDaily,
                                   _tweetalertDaily, this, listBoxFDaily, url, "ALARM", textBoxDailyTickers.Text);
                Thread.Sleep(600);
            }

            if (_ppHourly && f1Hourly.ContainsKey("price") && f1Hourly.ContainsKey("s1") && f1Hourly.ContainsKey("s2") && f1Hourly.ContainsKey("s3") && f1Hourly.ContainsKey("r1") && f1Hourly.ContainsKey("r2") && f1Hourly.ContainsKey("r3"))
            {
                _scrap.PivotAlerts(f1Hourly["s1"], f1Hourly["price"],
                         "S", " 60 min S1 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                         _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                         textBoxHourlyTickers.Text);
                Thread.Sleep(600);

                _scrap.PivotAlerts(f1Hourly["r1"], f1Hourly["price"],
                                   "R", " 60 min R1 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                   _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                   textBoxHourlyTickers.Text);
                Thread.Sleep(600);



                _scrap.PivotAlerts(f1Hourly["s2"], f1Hourly["price"],
                                   "S", " 60 min S2 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                   _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                   textBoxHourlyTickers.Text);
                Thread.Sleep(600);

                _scrap.PivotAlerts(f1Hourly["r2"], f1Hourly["price"],
                                   "R", " 60 min R2 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                   _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                   textBoxHourlyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1Hourly["s3"], f1Hourly["price"],
                                   "S", " 60 min S3 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                   _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                   textBoxHourlyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1Hourly["r3"], f1Hourly["price"],
                                   "R", " 60 min R3 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                   _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                   textBoxHourlyTickers.Text);
                Thread.Sleep(600);
            }




            if (_ppqHourly && f1qHourly.ContainsKey("price") && f1qHourly.ContainsKey("s1") && f1qHourly.ContainsKey("s2") && f1qHourly.ContainsKey("s3") && f1qHourly.ContainsKey("r1") && f1qHourly.ContainsKey("r2") && f1qHourly.ContainsKey("r3"))
            {
                _scrap.PivotAlerts(f1qHourly["s1"], f1qHourly["price"],
                         "S", " 15 min S1 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                         _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                         textBoxqHourlyTickers.Text);
                Thread.Sleep(600);

                _scrap.PivotAlerts(f1qHourly["r1"], f1qHourly["price"],
                                   "R", " 15 min R1 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                   _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                   textBoxqHourlyTickers.Text);
                Thread.Sleep(600);



                _scrap.PivotAlerts(f1qHourly["s2"], f1qHourly["price"],
                                   "S", " 15 min S2 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                   _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                   textBoxqHourlyTickers.Text);
                Thread.Sleep(600);

                _scrap.PivotAlerts(f1qHourly["r2"], f1qHourly["price"],
                                   "R", " 15 min R2 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                   _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                   textBoxqHourlyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1qHourly["s3"], f1qHourly["price"],
                                   "S", " 15 min S3 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                   _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                   textBoxqHourlyTickers.Text);
                Thread.Sleep(600);


                _scrap.PivotAlerts(f1qHourly["r3"], f1qHourly["price"],
                                   "R", " 15 min R3 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                   _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                   textBoxqHourlyTickers.Text);
                Thread.Sleep(600);
            }





            if (!_ppDaily)
            {
                if (_pp1Daily && f1Daily.ContainsKey("price") && f1Daily.ContainsKey("s1")  && f1Daily.ContainsKey("r1"))
                {
                    _scrap.PivotAlerts(f1Daily["s1"], f1Daily["price"],
                                       "S", " Daily S1 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily,
                                       _mailalertDaily, _tweetalertDaily, this, listBoxFDaily, url, "SIREN",
                                       textBoxDailyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1Daily["r1"], f1Daily["price"],
                                       "R", " Daily R1 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily,
                                       _mailalertDaily, _tweetalertDaily, this, listBoxFDaily, url, "SIREN",
                                       textBoxDailyTickers.Text);
                    Thread.Sleep(600);

                }

                if (_pp2Daily && f1Daily.ContainsKey("price") && f1Daily.ContainsKey("s2") && f1Daily.ContainsKey("r2"))
                {
                    _scrap.PivotAlerts(f1Daily["s2"], f1Daily["price"],
                                       "S", " Daily S2 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily,
                                       _mailalertDaily, _tweetalertDaily, this, listBoxFDaily, url, "SIREN",
                                       textBoxDailyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1Daily["r2"], f1Daily["price"],
                                       "R", " Daily R2 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily,
                                       _mailalertDaily, _tweetalertDaily, this, listBoxFDaily, url, "SIREN",
                                       textBoxDailyTickers.Text);
                    Thread.Sleep(600);

                }

                if (_pp3Daily && f1Daily.ContainsKey("price") && f1Daily.ContainsKey("s3") && f1Daily.ContainsKey("r3"))
                {
                    _scrap.PivotAlerts(f1Daily["s3"], f1Daily["price"],
                                       "S", " Daily S3 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily,
                                       _mailalertDaily, _tweetalertDaily, this, listBoxFDaily, url, "SIREN",
                                       textBoxDailyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1Daily["r3"], f1Daily["price"],
                                       "R", " Daily R3 breach alert: ", ticker, _alertsDailyPp, _soundalertDaily,
                                       _mailalertDaily, _tweetalertDaily, this, listBoxFDaily, url, "SIREN",
                                       textBoxDailyTickers.Text);
                    Thread.Sleep(600);

                }
            }
          
            if(!_ppHourly)
            {
                if (_pp1Hourly && f1Hourly.ContainsKey("price") && f1Hourly.ContainsKey("s1") && f1Hourly.ContainsKey("r1"))
                {
                    _scrap.PivotAlerts(f1Hourly["s1"], f1Hourly["price"],
                                       "S", " 60 min S1 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                       _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                       textBoxHourlyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1Hourly["r1"], f1Hourly["price"],
                                       "R", " 60 min R1 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                       _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                       textBoxHourlyTickers.Text);
                    Thread.Sleep(600);

                }

                if (_pp2Hourly && f1Hourly.ContainsKey("price") && f1Hourly.ContainsKey("s2") && f1Hourly.ContainsKey("r2"))
                {
                    _scrap.PivotAlerts(f1Hourly["s2"], f1Hourly["price"],
                                       "S", " 60 min S2 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                       _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                       textBoxHourlyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1Hourly["r2"], f1Hourly["price"],
                                       "R", " 60 min R2 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                       _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                       textBoxHourlyTickers.Text);
                    Thread.Sleep(600);

                }

                if (_pp3Hourly && f1Hourly.ContainsKey("price") && f1Hourly.ContainsKey("s3") && f1Hourly.ContainsKey("r3"))
                {
                    _scrap.PivotAlerts(f1Hourly["s3"], f1Hourly["price"],
                                       "S", " 15 min S3 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                       _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                       textBoxHourlyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1Hourly["r3"], f1Hourly["price"],
                                       "R", " 15 min R3 breach alert: ", ticker, _alertsHourlyPp, _soundalertHourly,
                                       _mailalertHourly, _tweetalertHourly, this, listBoxFHourly, url, "SIREN",
                                       textBoxHourlyTickers.Text);
                    Thread.Sleep(600);

                }
            }





            if (!_ppqHourly)
            {
                if (_pp1qHourly && f1qHourly.ContainsKey("price") && f1qHourly.ContainsKey("s1") && f1qHourly.ContainsKey("r1"))
                {
                    _scrap.PivotAlerts(f1qHourly["s1"], f1qHourly["price"],
                                       "S", " 15 min S1 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                       _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                       textBoxqHourlyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1qHourly["r1"], f1qHourly["price"],
                                       "R", " 15 min R1 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                       _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                       textBoxqHourlyTickers.Text);
                    Thread.Sleep(600);

                }

                if (_pp2qHourly && f1qHourly.ContainsKey("price") && f1qHourly.ContainsKey("s2") && f1qHourly.ContainsKey("r2"))
                {
                    _scrap.PivotAlerts(f1qHourly["s2"], f1qHourly["price"],
                                       "S", " 15 min S2 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                       _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                       textBoxqHourlyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1qHourly["r2"], f1qHourly["price"],
                                       "R", " 15 min R2 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                       _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                       textBoxqHourlyTickers.Text);
                    Thread.Sleep(600);

                }

                if (_pp3qHourly && f1qHourly.ContainsKey("price") && f1qHourly.ContainsKey("s3") && f1qHourly.ContainsKey("r3"))
                {
                    _scrap.PivotAlerts(f1qHourly["s3"], f1qHourly["price"],
                                       "S", " 15 min S3 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                       _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                       textBoxqHourlyTickers.Text);
                    Thread.Sleep(600);

                    _scrap.PivotAlerts(f1qHourly["r3"], f1qHourly["price"],
                                       "R", " 15 min R3 breach alert: ", ticker, _alertsqHourlyPp, _soundalertqHourly,
                                       _mailalertqHourly, _tweetalertqHourly, this, listBoxFqHourly, url, "SIREN",
                                       textBoxqHourlyTickers.Text);
                    Thread.Sleep(600);

                }
            }







        }


        private void GetMainData()
        {

            GetFutureData(_scrap.GetEsDaily(), _scrap.GetEsHourly(), _scrap.GetEsQHourly(), "#ES_F", textBoxF1Price, labelF1PC, textBoxF1S3D,
                          textBoxF1R3D,
                          textBoxF1RSID, textBoxF1S3H, textBoxF1R3H, textBoxF1RSIH,
                          @"http://www.investing.com/indices/us-spx-500-futures-technical?period=86400", labelT1);


            GetFutureData(_scrap.GetYmDaily(), _scrap.GetYmHourly(), _scrap.GetYmQHourly(), "#YM_F", textBoxF2Price, labelF2PC, textBoxF2S3D,
                          textBoxF2R3D,
                          textBoxF2RSID, textBoxF2S3H, textBoxF2R3H, textBoxF2RSIH,
                          @" http://www.investing.com/indices/us-30-technical?period=86400", labelT2);

            GetFutureData(_scrap.GetVxDaily(), _scrap.GetVxHourly(), _scrap.GetVxQHourly(), "#VIX", textBoxF3Price, labelF3PC, textBoxF3S3D,
                          textBoxF3R3D,
                          textBoxF3RSID, textBoxF3S3H, textBoxF3R3H, textBoxF3RSIH,
                          @" http://www.investing.com/indices/volatility-s-p-500-technical?period=86400", labelT3);

            GetFutureData(_scrap.GetGcDaily(), _scrap.GetGcHourly(), _scrap.GetGcQHourly(), "#GC_F", textBoxF4Price, labelF4PC, textBoxF4S3D,
                          textBoxF4R3D,
                          textBoxF4RSID, textBoxF4S3H, textBoxF4R3H, textBoxF4RSIH,
                          @" http://www.investing.com/commodities/gold-technical?period=86400", labelT4);

            GetFutureData(_scrap.GetHgDaily(), _scrap.GetHgHourly(), _scrap.GetHgQHourly(), "#HG_F", textBoxF5Price, labelF5PC, textBoxF5S3D,
                          textBoxF5R3D,
                          textBoxF5RSID, textBoxF5S3H, textBoxF5R3H, textBoxF5RSIH,
                          @" http://www.investing.com/commodities/copper-technical?period=86400", labelT5);

            GetFutureData(_scrap.GetNgDaily(), _scrap.GetNgHourly(), _scrap.GetNgQHourly(), "#NG_F", textBoxF6Price, labelF6PC, textBoxF6S3D,
                          textBoxF6R3D,
                          textBoxF6RSID, textBoxF6S3H, textBoxF6R3H, textBoxF6RSIH,
                          @" http://www.investing.com/commodities/natural-gas-technical?period=86400", labelT6);

            GetFutureData(_scrap.GetZcDaily(), _scrap.GetZcHourly(), _scrap.GetZcQHourly(), "#ZC_F", textBoxF7Price, labelF7PC, textBoxF7S3D,
                          textBoxF7R3D,
                          textBoxF7RSID, textBoxF7S3H, textBoxF7R3H, textBoxF7RSIH,
                          @"http://www.investing.com/commodities/us-corn-technical?period=86400", labelT7);

            GetFutureData(_scrap.GetZlDaily(), _scrap.GetZlHourly(), _scrap.GetZlQHourly(), "#ZL_F", textBoxF8Price, labelF8PC, textBoxF8S3D,
                          textBoxF8R3D,
                          textBoxF8RSID, textBoxF8S3H, textBoxF8R3H, textBoxF8RSIH,
                          @"http://www.investing.com/commodities/us-soybean-oil-technical?period=86400", labelT8);

            GetFutureData(_scrap.GetCcDaily(), _scrap.GetCcHourly(), _scrap.GetCcQHourly(), "#CC_F", textBoxF9Price, labelF9PC, textBoxF9S3D,
                          textBoxF9R3D,
                          textBoxF9RSID, textBoxF9S3H, textBoxF9R3H, textBoxF9RSIH,
                          @"http://www.investing.com/commodities/us-cocoa-technical?period=86400", labelT9);

            GetFutureData(_scrap.GetSbDaily(), _scrap.GetSbHourly(), _scrap.GetSbQHourly(), "#SB_F", textBoxF10Price, labelF10PC, textBoxF10S3D,
                          textBoxF10R3D,
                          textBoxF10RSID, textBoxF10S3H, textBoxF10R3H, textBoxF10RSIH,
                          @"http://www.investing.com/commodities/us-sugar-no11-technical?period=86400", labelT10);

            GetFutureData(_scrap.GetLeDaily(), _scrap.GetLeHourly(), _scrap.GetLeQHourly(), "#LE_F", textBoxF11Price, labelF11PC, textBoxF11S3D,
                          textBoxF11R3D,
                          textBoxF11RSID, textBoxF11S3H, textBoxF11R3H, textBoxF11RSIH,
                          @"http://www.investing.com/commodities/live-cattle-technical?period=86400", labelT11);

            GetFutureData(_scrap.GetZnDaily(), _scrap.GetZnHourly(), _scrap.GetZnQHourly(), "#ZN_F", textBoxF12Price, labelF12PC, textBoxF12S3D,
                          textBoxF12R3D,
                          textBoxF12RSID, textBoxF12S3H, textBoxF12R3H, textBoxF12RSIH,
                          @"http://www.investing.com/rates-bonds/us-10-yr-t-note-technical?period=86400", labelT12);

            GetFutureData(_scrap.GetE6Daily(), _scrap.GetE6Hourly(), _scrap.GetE6QHourly(), "#EUR", textBoxF13Price, labelF13PC, textBoxF13S3D,
                          textBoxF13R3D,
                          textBoxF13RSID, textBoxF13S3H, textBoxF13R3H, textBoxF13RSIH,
                          @"http://www.investing.com/currencies/eur-usd-technical?period=86400", labelT13);

            GetFutureData(_scrap.GetB6Daily(), _scrap.GetB6Hourly(), _scrap.GetB6QHourly(), "#GBP", textBoxF14Price, labelF14PC, textBoxF14S3D,
                          textBoxF14R3D,
                          textBoxF14RSID, textBoxF14S3H, textBoxF14R3H, textBoxF14RSIH,
                          @"http://www.investing.com/currencies/gbp-usd-technical?period=86400", labelT14);

            GetFutureData(_scrap.GetNqDaily(), _scrap.GetNqHourly(), _scrap.GetNqQHourly(), "#NQ_F", textBoxF15Price, labelF15PC, textBoxF15S3D,
                          textBoxF15R3D,
                          textBoxF15RSID, textBoxF15S3H, textBoxF15R3H, textBoxF15RSIH,
                          @" http://www.investing.com/indices/nq-100-futures-technical?period=86400", labelT15);

            GetFutureData(_scrap.GetTfDaily(), _scrap.GetTfHourly(), _scrap.GetTfQHourly(), "#TF_F", textBoxF16Price, labelF16PC, textBoxF16S3D,
                          textBoxF16R3D,
                          textBoxF16RSID, textBoxF16S3H, textBoxF16R3H, textBoxF16RSIH,
                          @"http://www.investing.com/indices/smallcap-2000-technical?period=86400", labelT16);

            GetFutureData(_scrap.GetDaxDaily(), _scrap.GetDaxHourly(), _scrap.GetDaxQHourly(), "#DAX", textBoxF17Price, labelF17PC,
                          textBoxF17S3D, textBoxF17R3D,
                          textBoxF17RSID, textBoxF17S3H, textBoxF17R3H, textBoxF17RSIH,
                          @"http://www.investing.com/indices/germany-30-technical?period=86400", labelT17);

            GetFutureData(_scrap.GetSiDaily(), _scrap.GetSiHourly(), _scrap.GetSiQHourly(), "#SI_F", textBoxF18Price, labelF18PC, textBoxF18S3D,
                          textBoxF18R3D,
                          textBoxF18RSID, textBoxF18S3H, textBoxF18R3H, textBoxF18RSIH,
                          @"http://www.investing.com/commodities/silver-technical?period=86400", labelT18);

            GetFutureData(_scrap.GetPlDaily(), _scrap.GetPlHourly(), _scrap.GetPlQHourly(), "#PL_F", textBoxF19Price, labelF19PC, textBoxF19S3D,
                          textBoxF19R3D,
                          textBoxF19RSID, textBoxF19S3H, textBoxF19R3H, textBoxF19RSIH,
                          @"http://www.investing.com/commodities/platinum-technical?period=86400", labelT19);

            GetFutureData(_scrap.GetClDaily(), _scrap.GetClHourly(), _scrap.GetClQHourly(), "#CL_F", textBoxF20Price, labelF20PC, textBoxF20S3D,
                          textBoxF20R3D,
                          textBoxF20RSID, textBoxF20S3H, textBoxF20R3H, textBoxF20RSIH,
                          @"http://www.investing.com/commodities/crude-oil-technical?period=86400", labelT20);

            GetFutureData(_scrap.GetZwDaily(), _scrap.GetZwHourly(), _scrap.GetZwQHourly(), "#ZW_F", textBoxF21Price, labelF21PC, textBoxF21S3D,
                          textBoxF21R3D,
                          textBoxF21RSID, textBoxF21S3H, textBoxF21R3H, textBoxF21RSIH,
                          @"http://www.investing.com/commodities/us-wheat-technical?period=86400", labelT21);

            GetFutureData(_scrap.GetZsDaily(), _scrap.GetZsHourly(), _scrap.GetZsQHourly(), "#ZS_F", textBoxF22Price, labelF22PC, textBoxF22S3D,
                          textBoxF22R3D,
                          textBoxF22RSID, textBoxF22S3H, textBoxF22R3H, textBoxF22RSIH,
                          @"http://www.investing.com/commodities/us-soybeans-technical?period=86400", labelT22);

            GetFutureData(_scrap.GetKcDaily(), _scrap.GetKcHourly(), _scrap.GetKcQHourly(), "#KC_F", textBoxF23Price, labelF23PC, textBoxF23S3D,
                          textBoxF23R3D,
                          textBoxF23RSID, textBoxF23S3H, textBoxF23R3H, textBoxF23RSIH,
                          @"http://www.investing.com/commodities/us-coffee-c-technical?period=86400", labelT23);

            GetFutureData(_scrap.GetCtDaily(), _scrap.GetCtHourly(), _scrap.GetCtQHourly(), "#CT_F", textBoxF24Price, labelF24PC, textBoxF24S3D,
                          textBoxF24R3D,
                          textBoxF24RSID, textBoxF24S3H, textBoxF24R3H, textBoxF24RSIH,
                          @"http://www.investing.com/commodities/us-cotton-no.2-technical?period=86400", labelT24);

            GetFutureData(_scrap.GetHeDaily(), _scrap.GetHeHourly(), _scrap.GetHeQHourly(), "#HE_F", textBoxF25Price, labelF25PC, textBoxF25S3D,
                          textBoxF25R3D,
                          textBoxF25RSID, textBoxF25S3H, textBoxF25R3H, textBoxF25RSIH,
                          @"http://www.investing.com/commodities/lean-hogs-analysis?period=86400", labelT25);

            GetFutureData(_scrap.GetBundDaily(), _scrap.GetBundHourly(), _scrap.GetBundQHourly(), "#BUND", textBoxF26Price, labelF26PC,
                          textBoxF26S3D, textBoxF26R3D,
                          textBoxF26RSID, textBoxF26S3H, textBoxF26R3H, textBoxF26RSIH,
                          @"http://www.investing.com/rates-bonds/euro-bund-technical?period=86400", labelT26);

            GetFutureData(_scrap.GetA6Daily(), _scrap.GetA6Hourly(), _scrap.GetA6QHourly(), "#AUD", textBoxF27Price, labelF27PC, textBoxF27S3D,
                          textBoxF27R3D,
                          textBoxF27RSID, textBoxF27S3H, textBoxF27R3H, textBoxF27RSIH,
                          @"http://www.investing.com/currencies/aud-usd-technical?period=86400", labelT27);

            GetFutureData(_scrap.GetJ6Daily(), _scrap.GetJ6Hourly(), _scrap.GetJ6QHourly(), "#USDJPY", textBoxF28Price, labelF28PC, textBoxF28S3D,
                          textBoxF28R3D,
                          textBoxF28RSID, textBoxF28S3H, textBoxF28R3H, textBoxF28RSIH,
                          @"http://www.investing.com/currencies/jpy-usd-technical?period=86400", labelT28);

            GetFutureData(_scrap.GetCadDaily(), _scrap.GetCadHourly(), _scrap.GetCadQHourly(), "#CAD", textBoxF29Price, labelF29PC,
                          textBoxF29S3D, textBoxF29R3D,
                          textBoxF29RSID, textBoxF29S3H, textBoxF29R3H, textBoxF29RSIH,
                          @"http://www.investing.com/currencies/cad-usd-technical?period=86400", labelT29);

            GetFutureData(_scrap.GetChfDaily(), _scrap.GetChfHourly(), _scrap.GetChfQHourly(), "#CHF", textBoxF30Price, labelF30PC,
                          textBoxF30S3D, textBoxF30R3D,
                          textBoxF30RSID, textBoxF30S3H, textBoxF30R3H, textBoxF30RSIH,
                          @"http://www.investing.com/currencies/chf-usd-technical?period=86400", labelT30);
        }

      

        private void buttonF1Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/indices/us-spx-500-futures-streaming-chart");
        }

        private void buttonF2Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/indices/us-30-chart");
        }

        private void buttonF3Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/indices/volatility-s-p-500-chart");
        }

        private void buttonF4Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/gold-streaming-chart");
        }

        private void buttonF5Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/copper-streaming-chart");
        }

        private void buttonF6Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/natural-gas-streaming-chart");
        }

        private void buttonF7Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-corn-streaming-chart");
        }

        private void buttonF8Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-soybean-oil-streaming-chart");
        }

        private void buttonF9Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-cocoa-streaming-chart");
        }

        private void buttonF10Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-sugar-no11-streaming-chart");
        }

        private void buttonF11Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/live-cattle-streaming-chart");
        }

        private void buttonF12Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/rates-bonds/us-10-yr-t-note-streaming-chart");
        }

        private void buttonF13Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/currencies/eur-usd-chart");
        }

        private void buttonF14Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/currencies/gbp-usd-chart");
        }

        private void buttonF15Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/indices/nq-100-futures-streaming-chart");
        }

        private void buttonF16Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/indices/smallcap-2000-chart");
        }

        private void buttonF17Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/indices/germany-30-chart");
        }

        private void buttonF18Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/silver-streaming-chart");
        }

        private void buttonF19Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/platinum-streaming-chart");
        }

        private void buttonF20Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/crude-oil-streaming-chart");
        }

        private void buttonF21Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-wheat-streaming-chart");
        }

        private void buttonF22Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-soybeans-streaming-chart");
        }

        private void buttonF23Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-coffee-c");
        }

        private void buttonF24Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/us-cotton-no.2-streaming-chart");
        }

        private void buttonF25Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/commodities/lean-hogs-streaming-chart");
        }

        private void buttonF26Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/rates-bonds/euro-bund-streaming-chart");
        }

        private void buttonF27Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/currencies/aud-usd-chart");
        }

        private void buttonF28Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/currencies/usd-jpy-chart");
        }


        private void buttonF29Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/currencies/cad-usd-chart");
        }


        private void buttonF30Chart_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.investing.com/currencies/chf-usd-chart");
        }


        private void label31_Click(object sender, EventArgs e)
        {
        }

        private void FrmFuturesAlerts_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        private void FrmFuturesAlerts_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDataScraping();
        }

        private void StopDataScraping()
        {
            ThreadMainActive = false;
            if (ThreadMain != null)
            {
                if (ThreadMain.IsAlive)
                    ThreadMain.Abort();
            }

            labelActive.Visible = false;
            labelInactive.Visible = false;
            Dispose();
        }

        private void buttonStart_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StartWebScraping();
        }

        private void checkBoxSoundFT_CheckedChanged(object sender, EventArgs e)
        {
            _soundalertDaily = checkBoxSoundFT.Checked;
        }

        private void checkBoxEmailF_CheckedChanged(object sender, EventArgs e)
        {
            List<string> emailData = XmlReadWrite.ReadXMLData("EmailData", "//Insiderstracker//");
            if (emailData == null)
            {
                MessageBox.Show("Missing email data, go to Email administration and provide the data.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxEmailHourly.Checked = false;
                return;
            }
            _mailalertDaily = checkBoxEmailF.Checked;
        }

        private void checkBoxFTwitter_CheckedChanged(object sender, EventArgs e)
        {
            List<string> tweetData = XmlReadWrite.ReadXMLData("TwitterFutures", "//Insiderstracker//");
            if (tweetData == null)
            {
                MessageBox.Show("Missing twitterfutures data, go to Twitter administration and provide the data.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxFTwitter.Checked = false;
                return;
            }
            _tweetalertDaily = checkBoxFTwitter.Checked;
        }

        private void checkBoxTwitterHourly_CheckedChanged(object sender, EventArgs e)
        {
            List<string> tweetData = XmlReadWrite.ReadXMLData("TwitterFutures", "//Insiderstracker//");
            if (tweetData == null)
            {
                MessageBox.Show("Missing twitterfutures data, go to Twitter administration and provide the data.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxTwitterHourly.Checked = false;
                return;
            }
            _tweetalertHourly = checkBoxTwitterHourly.Checked;
        }

        private void checkBoxSoundHourly_CheckedChanged(object sender, EventArgs e)
        {
            _soundalertHourly = checkBoxSoundHourly.Checked;
        }

        private void checkBoxEmailHourly_CheckedChanged(object sender, EventArgs e)
        {
            _mailalertHourly = checkBoxEmailHourly.Checked;
        }







        private void checkBoxTwitterqHourly_CheckedChanged(object sender, EventArgs e)
        {
            List<string> tweetData = XmlReadWrite.ReadXMLData("TwitterFutures", "//Insiderstracker//");
            if (tweetData == null)
            {
                MessageBox.Show("Missing twitterfutures data, go to Twitter administration and provide the data.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxTwitterqHourly.Checked = false;
                return;
            }
            _tweetalertqHourly = checkBoxTwitterqHourly.Checked;
        }

        private void checkBoxSoundqHourly_CheckedChanged(object sender, EventArgs e)
        {
            _soundalertqHourly = checkBoxSoundqHourly.Checked;
        }

        private void checkBoxEmailqHourly_CheckedChanged(object sender, EventArgs e)
        {
            _mailalertqHourly = checkBoxEmailqHourly.Checked;
        }





        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopMainThread();
            _alertsqHourlyPp.Clear();
            _alertsHourlyPp.Clear();
            _alertsDailyPp.Clear();
            _alertsqHourlyRsi.Clear();
            _alertsHourlyRsi.Clear();
            _alertsDailyRsi.Clear();
            _alertsqHourlySma.Clear();
            _alertsHourlySma.Clear();
            _alertsDailySma.Clear();
            listBoxFqHourly.Items.Clear();
            listBoxFHourly.Items.Clear();
            listBoxFDaily.Items.Clear();
        }



        private void buttonClearqHourlyAlerts_Click(object sender, EventArgs e)
        {
            _alertsqHourlyPp.Clear();
            _alertsqHourlyRsi.Clear();
            _alertsqHourlySma.Clear();
            listBoxFqHourly.Items.Clear();
        }


        private void buttonClearHourlyAlerts_Click(object sender, EventArgs e)
        {
            _alertsHourlyPp.Clear();
            _alertsHourlyRsi.Clear();
            _alertsHourlySma.Clear();
            listBoxFHourly.Items.Clear();
        }

        private void buttonClearDaily_Click(object sender, EventArgs e)
        {
            _alertsDailyPp.Clear();
            _alertsDailyRsi.Clear();
            _alertsDailySma.Clear();
            listBoxFDaily.Items.Clear();
        }

        private void buttonDailyTickers_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxDailyTickers.Text))
            {
                MessageBox.Show("Type tickers and separate them by space.", "Storage error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string result = WebScrapWriteData.WriteDailyFuturesTickers(textBoxDailyTickers.Text.Trim().ToUpper());
                MessageBox.Show(result, "Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonHourlyTickers_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxHourlyTickers.Text))
            {
                MessageBox.Show("Type tickers and separate them by space.", "Storage error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string result = WebScrapWriteData.WriteHourlyFuturesTickers(textBoxHourlyTickers.Text.Trim().ToUpper());
                MessageBox.Show(result, "Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void buttonqHourlyTickers_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxqHourlyTickers.Text))
            {
                MessageBox.Show("Type tickers and separate them by space.", "Storage error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string result = WebScrapWriteData.WriteqHourlyFuturesTickers(textBoxqHourlyTickers.Text.Trim().ToUpper());
                MessageBox.Show(result, "Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBoxDRsi_CheckedChanged(object sender, EventArgs e)
        {
            _rsiDaily = checkBoxDRsi.Checked;
        }

        private void checkBoxDPp_CheckedChanged(object sender, EventArgs e)
        {
            _ppDaily = checkBoxDPp.Checked;
            if (_ppDaily)
            {
                checkBoxPP1D.Enabled = false;
                checkBoxPP2D.Enabled = false;
                checkBoxPP3D.Enabled = false;
                checkBoxPP1D.Checked = false;
                checkBoxPP2D.Checked = false;
                checkBoxPP3D.Checked = false;
                _pp1Daily = false;
                _pp2Daily = false;
                _pp3Daily = false;
            }
            if (!_ppDaily)
            {
                checkBoxPP1D.Enabled = true;
                checkBoxPP2D.Enabled = true;
                checkBoxPP3D.Enabled = true;
            }
         
        }

        private void checkBoxDsma_CheckedChanged(object sender, EventArgs e)
        {
            _smaDaily = checkBoxDSma .Checked;
        }

        private void checkBoxHRsi_CheckedChanged(object sender, EventArgs e)
        {
            _rsiHourly = checkBoxHRsi.Checked;
        }



        private void checkBoxHPp_CheckedChanged(object sender, EventArgs e)
        {
            _ppHourly = checkBoxHPp.Checked;
            if(_ppHourly)
            {
                checkBoxPP1H.Enabled = false;
                checkBoxPP2H.Enabled = false;
                checkBoxPP3H.Enabled = false;
                checkBoxPP1H.Checked = false;
                checkBoxPP2H.Checked = false;
                checkBoxPP3H.Checked = false;
                _pp1Hourly = false;
                _pp2Hourly = false;
                _pp3Hourly = false; 
            }
            if(!_ppHourly)
            {
                checkBoxPP1H.Enabled = true;
                checkBoxPP2H.Enabled = true;
                checkBoxPP3H.Enabled = true;
            }
           
        }

        private void checkBoxHSma_CheckedChanged(object sender, EventArgs e)
        {
            _smaHourly = checkBoxHSma.Checked;
        }





        private void checkBoxqHRsi_CheckedChanged(object sender, EventArgs e)
        {
            _rsiqHourly = checkBoxqHRsi.Checked;
        }




        private void checkBoxqHPp_CheckedChanged(object sender, EventArgs e)
        {
            _ppqHourly = checkBoxqHPp.Checked;
            if (_ppqHourly)
            {
                checkBoxqPP1H.Enabled = false;
                checkBoxqPP2H.Enabled = false;
                checkBoxqPP3H.Enabled = false;
                checkBoxqPP1H.Checked = false;
                checkBoxqPP2H.Checked = false;
                checkBoxqPP3H.Checked = false;
                _pp1qHourly = false;
                _pp2qHourly = false;
                _pp3qHourly = false;
            }
            if (!_ppqHourly)
            {
                checkBoxqPP1H.Enabled = true;
                checkBoxqPP2H.Enabled = true;
                checkBoxqPP3H.Enabled = true;
            }
        }



        private void checkBoxPP1H_CheckedChanged(object sender, EventArgs e)
        {
            _pp1Hourly = checkBoxPP1H.Checked;
        }

        private void checkBoxPP2H_CheckedChanged(object sender, EventArgs e)
        {
            _pp2Hourly = checkBoxPP2H.Checked;
        }

        private void checkBoxPP3H_CheckedChanged(object sender, EventArgs e)
        {
            _pp3Hourly = checkBoxPP3H.Checked;
        }

        private void checkBoxPP1D_CheckedChanged(object sender, EventArgs e)
        {

            _pp1Daily = checkBoxPP1D.Checked;
        }

        private void checkBoxPP2D_CheckedChanged(object sender, EventArgs e)
        {
            _pp2Daily = checkBoxPP2D.Checked;
        }

        private void checkBoxPP3D_CheckedChanged(object sender, EventArgs e)
        {
            _pp3Daily = checkBoxPP3D.Checked;
        }


        private void checkBoxqHSma_CheckedChanged(object sender, EventArgs e)
        {
            _smaqHourly = checkBoxqHSma.Checked;
        }

        private void checkBoxqPP1H_CheckedChanged(object sender, EventArgs e)
        {
            _pp1qHourly = checkBoxqPP1H.Checked;
        }

        private void checkBoxqPP2H_CheckedChanged(object sender, EventArgs e)
        {
            _pp2qHourly = checkBoxqPP2H.Checked;
        }

        private void checkBoxqPP3H_CheckedChanged(object sender, EventArgs e)
        {
            _pp3qHourly = checkBoxqPP3H.Checked;
        }
    }

}