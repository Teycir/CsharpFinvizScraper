#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using WebScrap.Presenter;

#endregion

namespace WebScrap.View
{
    public partial class FrmScrapping : Form, IViewMain
    {
        private readonly PresMain _pres;
        private string _sendEmail;
        private string _storeDbdata;
        private string _root = @"http://finance.avafin.com/stock/";
        private string _total = @"?chartType=trade";
        private string _block = @"?chartType=block";


        private bool _t1 = true;
        private bool _t10 = true;
        private bool _t2 = true;
        private bool _t3 = true;
        private bool _t4 = true;
        private bool _t5 = true;


        private bool _t6 = true;
        private bool _t7 = true;
        private bool _t8 = true;
        private bool _t9 = true;
        private Thread _threadT;
        private bool _turn;

        public FrmScrapping()
        {
            InitializeComponent();
            _pres = new PresMain(this);
            DataStorageEnabled();
            ShowStatus();
            UpdateEmailActivationState();
            StarInvisible();
        }

        #region IViewMain Members

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="_labelRatio">The _label ratio.</param>
        /// <param name="_labelFlow">The _label flow.</param>
        /// <param name="_labelFRatio">The _label F ratio.</param>
        /// <param name="_labelFFlow">The _label F flow.</param>
        /// <param name="ticker">The ticker.</param>
        /// <param name="flowAlertValue">The flow alert value.</param>
        /// <param name="ratioalertValue">The ratioalert value.</param>
        /// <param name="storedata">if set to <c>true</c> [storedata].</param>
        /// <param name="sound">The sound.</param>
        /// <param name="activesoundalert">if set to <c>true</c> [activesoundalert].</param>
        /// <param name="activesmailalert">if set to <c>true</c> [activesmailalert].</param>
        /// <param name="starlabel">The starlabel.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">_labelRatio
        /// or
        /// _labelFlow</exception>
        public List<string> GetData(object _labelRatio, object _labelFlow, object _labelFRatio, object _labelFFlow, string ticker, string flowAlertValue, string ratioalertValue, string storedata, string sound, bool activesoundalert, bool activesmailalert, object starlabel)
        {
            DateTimePicker dtp = new DateTimePicker();
            ThreadHelper.SetText(this, labelDateDisplay, dtp.Value.Date.ToString("MM/dd/yyyy"));
            ThreadHelper.SetText(this, labelTimeDisplay, DateTime.Now.ToString("HH:mm:ss") );

            return _pres.GetData(_labelRatio, _labelFlow, _labelFRatio, _labelFFlow, ticker, flowAlertValue, ratioalertValue, storedata, sound,
                               activesoundalert, activesmailalert, starlabel);
           
        }

        /// <summary>
        /// 	Views the label.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="s"> The s. </param>
        public void ViewLabel(object obj, string s)
        {
            Label label = null;
            if (obj is Label)
            {
                label = obj as Label;
            }
            if (label != null)
            {
                //if (label.InvokeRequired)
                //{
                ThreadHelper.SetText(this, label, s);
                //label.Text = s;
                //} 
            }
        }


        /// <summary>
        /// Views the label.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public void VisibleLabel(object obj, bool visible)
        {
            Label label = null;
            if (obj is Label)
            {
                label = obj as Label;
            }
            if (label != null)
            {
                //if (label.InvokeRequired)
                //{
                ThreadHelper.SetVisibility(this, label, visible);
                //label.Text = s;
                //} 
            }
        }


        /// <summary>
        /// 	Views the text box.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="s"> The s. </param>
        public void ViewTextBox(object obj, string s)
        {
            TextBox txt = null;
            if (obj is TextBox)
            {
                txt = obj as TextBox;
            }
            if (txt != null)
            {
                //if (txt.InvokeRequired)
                //{
                ThreadHelper.SetText(this, txt, s);
                // txt.Text = s;
                //}
            }
        }

        public void ViewCheckBox(object obj, bool b)
        {
            CheckBox chk = null;
            if (obj is CheckBox)
            {
                chk = obj as CheckBox;
            }
            if (chk != null)
            {
                chk.Checked = b;
            }
        }

        /// <summary>
        /// Stars turn invisible.
        /// </summary>
        private void StarInvisible()
        {
            try
            {
                ThreadHelper.SetVisibility(this, labelT1Star, false);
                ThreadHelper.SetVisibility(this, labelT2Star, false);
                ThreadHelper.SetVisibility(this, labelT3Star, false);
                ThreadHelper.SetVisibility(this, labelT4Star, false);
                ThreadHelper.SetVisibility(this, labelT5Star, false);
                ThreadHelper.SetVisibility(this, labelT6Star, false);
                ThreadHelper.SetVisibility(this, labelT7Star, false);
                ThreadHelper.SetVisibility(this, labelT8Star, false);
                ThreadHelper.SetVisibility(this, labelT9Star, false);
                ThreadHelper.SetVisibility(this, labelT10Star, false);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
         
        }

        public string SetTickersState(string ticker1, string ticker2, string ticker3, string ticker4, string ticker5,
                                      string ticker6, string ticker7, string ticker8, string ticker9, string ticker10,
                                      string ticker1FAlert, string ticker2FAlert, string ticker3FAlert,
                                      string ticker4FAlert, string ticker5FAlert,
                                      string ticker6FAlert, string ticker7FAlert, string ticker8FAlert,
                                      string ticker9FAlert, string ticker10FAlert,
                                      string ticker1RAlert,
                                      string ticker2RAlert, string ticker3RAlert, string ticker4RAlert,
                                      string ticker5RAlert,
                                      string ticker6RAlert,
                                      string ticker7RAlert, string ticker8RAlert, string ticker9RAlert,
                                      string ticker10RAlert
            )
        {
            return _pres.SetTickersState(textBoxTicker1.Text, textBoxTicker2.Text, textBoxTicker3.Text,
                                         textBoxTicker4.Text, textBoxTicker5.Text,
                                         textBoxTicker6.Text, textBoxTicker7.Text, textBoxTicker8.Text,
                                         textBoxTicker9.Text, textBoxTicker10.Text,
                                         textBoxTicker1FlowAlert.Text,
                                         textBoxTicker2FlowAlert.Text, textBoxTicker3FlowAlert.Text,
                                         textBoxTicker4FlowAlert.Text, textBoxTicker5FlowAlert.Text,
                                         textBoxTicker6FlowAlert.Text,
                                         textBoxTicker7FlowAlert.Text, textBoxTicker8FlowAlert.Text,
                                         textBoxTicker9FlowAlert.Text, textBoxTicker10FlowAlert.Text,
                                         textBoxT1RAlert.Text, textBoxT2RAlert.Text, textBoxT3RAlert.Text,
                                         textBoxT4RAlert.Text, textBoxT5RAlert.Text,
                                         textBoxT6RAlert.Text, textBoxT7RAlert.Text, textBoxT8RAlert.Text,
                                         textBoxT9RAlert.Text, textBoxT10RAlert.Text
                );
        }

        public void GetTickersState(object ticker1, object ticker2, object ticker3, object ticker4, object ticker5,
                                    object ticker6, object ticker7, object ticker8, object ticker9, object ticker10,
                                    object ticker1FAlert, object ticker2FAlert, object ticker3FAlert,
                                    object ticker4FAlert, object ticker5FAlert,
                                    object ticker6FAlert, object ticker7FAlert, object ticker8FAlert,
                                    object ticker9FAlert, object ticker10FAlert,
                                    object ticker1RAlert,
                                    object ticker2RAlert, object ticker3RAlert, object ticker4RAlert,
                                    object ticker5RAlert,
                                    object ticker6RAlert,
                                    object ticker7RAlert, object ticker8RAlert, object ticker9RAlert,
                                    object ticker10RAlert
            )
        {
            _pres.GetTickersState(textBoxTicker1, textBoxTicker2, textBoxTicker3, textBoxTicker4, textBoxTicker5,
                                  textBoxTicker6, textBoxTicker7, textBoxTicker8, textBoxTicker9, textBoxTicker10,
                                  textBoxTicker1FlowAlert, textBoxTicker2FlowAlert, textBoxTicker3FlowAlert,
                                  textBoxTicker4FlowAlert, textBoxTicker5FlowAlert,
                                  textBoxTicker6FlowAlert, textBoxTicker7FlowAlert, textBoxTicker8FlowAlert,
                                  textBoxTicker9FlowAlert, textBoxTicker10FlowAlert,
                                  textBoxT1RAlert, textBoxT2RAlert,
                                  textBoxT3RAlert, textBoxT4RAlert, textBoxT5RAlert,
                                  textBoxT6RAlert, textBoxT7RAlert,
                                  textBoxT8RAlert, textBoxT9RAlert, textBoxT10RAlert
                );
        }

        public void GetWsjData(object labelT1B, object labelT2B, object labelT3B, object labelT4B, object labelT5B, object labelT1S, object labelT2S, object labelT3S, object labelT4S, object labelT5S, object labelT1BPrice, object labelT2BPrice, object labelT3BPrice, object labelT4BPrice, object labelT5BPrice, object labelT1SPrice, object labelT2SPrice, object labelT3SPrice, object labelT4SPrice, object labelT5SPrice, object labelT1BBlocks, object labelT2BBlocks, object labelT3BBlocks, object labelT4BBlocks, object labelT5BBlocks, object labelT1Slocks, object labelT2SBlocks, object labelT3SBlocks, object labelT4SBlocks, object labelT5SBlocks, object labelB1BRatio, object labelB2BRatio, object labelB3BRatio,object labelB4BRatio, object labelB5BRatio , object labelS1BRatio, object labelS2BRatio,object labelS3BRatio, object labelS4BRatio, object labelS5BRatio)
        {
            _pres.GetWsjData(labelT1BTicker, labelT2BTicker, labelT3BTicker, labelT4BTicker, labelT5BTicker, labelT1STicker, labelT2STicker, labelT3STicker, labelT4STicker, labelT5STicker,
               labelT1BPrice, labelT2BPrice, labelT3BPrice, labelT4BPrice, labelT5BPrice, labelT1SPrice, labelT2SPrice, labelT3SPrice, labelT4SPrice, labelT5SPrice,
               labelB1Blocks, labelB2Blocks, labelB3Blocks, labelB4Blocks, labelB5Blocks, labelS1Blocks, labelS2Blocks, labelS3Blocks, labelS4Blocks, labelS5Blocks,
               labelB1BRatio, labelB2BRatio, labelB3BRatio, labelB4BRatio, labelB5BRatio ,labelS1BRatio, labelS2BRatio, labelS3BRatio, labelS4BRatio, labelS5BRatio
               );
        }

        #endregion

        /// <summary>
        /// 	Datas the storage enabled.
        /// </summary>
        private void DataStorageEnabled()
        {
            List<string> list = XmlReadWrite.ReadData("DbData");
            if (list.Count > 6)
            {
                _storeDbdata = list[6];
            }
            else
            {
                _storeDbdata = "false";
            }
        }


        private void EmailEnabled()
        {
            List<string> list = XmlReadWrite.ReadData("EmailData");
            if (list.Count > 6)
            {
                _sendEmail = list[6];
            }
            else
            {
                _sendEmail = "false";
            }
        }


        private void UpdateEmailActivationState()
        {
            EmailEnabled();
            if (_sendEmail == "true")
            {
                checkBoxT1EmailAlert.Enabled = true;
                checkBoxT2EmailAlert.Enabled = true;
                checkBoxT3EmailAlert.Enabled = true;
                checkBoxT4EmailAlert.Enabled = true;
                checkBoxT5EmailAlert.Enabled = true;


                checkBoxT6EmailAlert.Enabled = true;
                checkBoxT7EmailAlert.Enabled = true;
                checkBoxT8EmailAlert.Enabled = true;
                checkBoxT9EmailAlert.Enabled = true;
                checkBoxT10EmailAlert.Enabled = true;
            }
            else
            {
                checkBoxT1EmailAlert.Enabled = false;
                checkBoxT2EmailAlert.Enabled = false;
                checkBoxT3EmailAlert.Enabled = false;
                checkBoxT4EmailAlert.Enabled = false;
                checkBoxT5EmailAlert.Enabled = false;


                checkBoxT6EmailAlert.Enabled = false;
                checkBoxT7EmailAlert.Enabled = false;
                checkBoxT8EmailAlert.Enabled = false;
                checkBoxT9EmailAlert.Enabled = false;
                checkBoxT10EmailAlert.Enabled = false;


                checkBoxT1EmailAlert.Checked = false;
                checkBoxT2EmailAlert.Checked = false;
                checkBoxT3EmailAlert.Checked = false;
                checkBoxT4EmailAlert.Checked = false;
                checkBoxT5EmailAlert.Checked = false;


                checkBoxT6EmailAlert.Checked = false;
                checkBoxT7EmailAlert.Checked = false;
                checkBoxT8EmailAlert.Checked = false;
                checkBoxT9EmailAlert.Checked = false;
                checkBoxT10EmailAlert.Checked = false;
            }
        }

        /// <summary>
        /// 	Gets the data ticker.
        /// </summary>
        private void GetDataTicker()
        {
            GetWsjData(labelT1BTicker, labelT2BTicker, labelT3BTicker, labelT4BTicker, labelT5BTicker, labelT1STicker, labelT2STicker, labelT3STicker, labelT4STicker, labelT5STicker,
               labelT1BPrice, labelT2BPrice, labelT3BPrice, labelT4BPrice, labelT5BPrice, labelT1SPrice, labelT2SPrice, labelT3SPrice, labelT4SPrice, labelT5SPrice,
               labelB1Blocks, labelB2Blocks, labelB3Blocks, labelB4Blocks, labelB5Blocks, labelS1Blocks, labelS2Blocks, labelS3Blocks, labelS4Blocks, labelS5Blocks,
               labelB1BRatio, labelB2BRatio, labelB3BRatio, labelB4BRatio, labelB5BRatio, labelS1BRatio, labelS2BRatio, labelS3BRatio, labelS4BRatio, labelS5BRatio
               );
           

            if (textBoxTicker1.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow1, "Type a ticker1");
                _t1 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio1, labelFlow1, labelTRatio1, labelTFlow1, textBoxTicker1.Text,
                                               textBoxTicker1FlowAlert.Text,
                                               textBoxT1RAlert.Text,
                                               _storeDbdata, "number1", checkBoxT1SoundAlert.Checked,
                                               checkBoxT1EmailAlert.Checked, labelT1Star);

                ThreadHelper.SetText(this, labelT1P2, data[1]);

                ThreadHelper.SetText(this, labelT1PriceVisual, data[0]);
                Thread.Sleep(1000);
                _t1 = false;
            }
            if (textBoxTicker2.Text.Trim() == "")
            {
                // labelFlow2.Text = "Type a ticker2";
                ThreadHelper.SetText(this, labelFlow2, "Type a ticker2");

                _t2 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio2, labelFlow2, labelTRatio2, labelTFlow2, textBoxTicker2.Text,
                                                textBoxTicker2FlowAlert.Text,
                                                textBoxT2RAlert.Text,
                                                _storeDbdata, "number2", checkBoxT2SoundAlert.Checked,
                                                checkBoxT2EmailAlert.Checked, labelT2Star);

                ThreadHelper.SetText(this, labelT2P2, data[1]);
                ThreadHelper.SetText(this, labelT2PriceVisual, data[0]);
               
                Thread.Sleep(1000);


                _t2 = false;
            }


            if (textBoxTicker3.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow3, "Type a ticker3");

                _t3 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio3, labelFlow3, labelTRatio3, labelTFlow3, textBoxTicker3.Text,
                                               textBoxTicker3FlowAlert.Text,
                                               textBoxT3RAlert.Text,
                                               _storeDbdata, "number3", checkBoxT3SoundAlert.Checked,
                                               checkBoxT3EmailAlert.Checked, labelT3Star);

                ThreadHelper.SetText(this, labelT3P2, data[1]);
                ThreadHelper.SetText(this, labelT3PriceVisual, data[0]);
     
                Thread.Sleep(1000);

                _t3 = false;
            }


            if (textBoxTicker4.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow4, "Type a ticker4");

                _t4 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio4, labelFlow4, labelTRatio4, labelTFlow4, textBoxTicker4.Text,
                                             textBoxTicker4FlowAlert.Text,
                                             textBoxT4RAlert.Text,
                                             _storeDbdata, "number4", checkBoxT4SoundAlert.Checked,
                                             checkBoxT4EmailAlert.Checked, labelT4Star);

                ThreadHelper.SetText(this, labelT4P2, data[1]);
                ThreadHelper.SetText(this, labelT4PriceVisual, data[0]);

             

                Thread.Sleep(1000);
                _t4 = false;
            }


            if (textBoxTicker5.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow5, "Type a ticker5");
                _t5 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio5, labelFlow5, labelTRatio5, labelTFlow5, textBoxTicker5.Text,
                                              textBoxTicker5FlowAlert.Text,
                                              textBoxT5RAlert.Text,
                                              _storeDbdata, "number5", checkBoxT5SoundAlert.Checked,
                                              checkBoxT5EmailAlert.Checked, labelT5Star);

                ThreadHelper.SetText(this, labelT5P2, data[1]);
                ThreadHelper.SetText(this, labelT5PriceVisual, data[0]);

                Thread.Sleep(1000);
                _t5 = false;
            }


            if (textBoxTicker6.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow6, "Type a ticker6");
                _t6 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio6, labelFlow6, labelTRatio6, labelTFlow6, textBoxTicker6.Text,
                                               textBoxTicker6FlowAlert.Text,
                                               textBoxT6RAlert.Text,
                                               _storeDbdata, "number6", checkBoxT6SoundAlert.Checked,
                                               checkBoxT6EmailAlert.Checked, labelT6Star);

                ThreadHelper.SetText(this, labelT6P2, data[1]);
                ThreadHelper.SetText(this, labelT6PriceVisual, data[0]);

                Thread.Sleep(1000);
                _t6 = false;
            }


            if (textBoxTicker7.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow7, "Type a ticker7");
                _t7 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio7, labelFlow7, labelTRatio7, labelTFlow7, textBoxTicker7.Text,
                                              textBoxTicker7FlowAlert.Text,
                                              textBoxT7RAlert.Text,
                                              _storeDbdata, "number7", checkBoxT7SoundAlert.Checked,
                                              checkBoxT7EmailAlert.Checked, labelT7Star);

                ThreadHelper.SetText(this, labelT7P2, data[1]);
                ThreadHelper.SetText(this, labelT7PriceVisual, data[0]);

                Thread.Sleep(1000);
                _t7 = false;
            }


            if (textBoxTicker8.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow8, "Type a ticker8");
                _t8 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio8, labelFlow8, labelTRatio8, labelTFlow8, textBoxTicker8.Text,
                                             textBoxTicker8FlowAlert.Text,
                                             textBoxT8RAlert.Text,
                                             _storeDbdata, "number8", checkBoxT8SoundAlert.Checked,
                                             checkBoxT8EmailAlert.Checked, labelT8Star);

                ThreadHelper.SetText(this, labelT8P2, data[1]);
                ThreadHelper.SetText(this, labelT8PriceVisual, data[0]);

                Thread.Sleep(1000);
                _t8 = false;
            }


            if (textBoxTicker9.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow9, "Type a ticker9");
                _t9 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio9, labelFlow9, labelTRatio9, labelTFlow9, textBoxTicker9.Text,
                                                 textBoxTicker9FlowAlert.Text,
                                                 textBoxT9RAlert.Text,
                                                 _storeDbdata, "number9", checkBoxT9SoundAlert.Checked,
                                                 checkBoxT9EmailAlert.Checked, labelT9Star);

                ThreadHelper.SetText(this, labelT9P2, data[1]);
                ThreadHelper.SetText(this, labelT9PriceVisual, data[0]);

              

                Thread.Sleep(1000);
                _t9 = false;
            }


            if (textBoxTicker10.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow10, "Type a ticker10");
                _t10 = true;
            }
            else
            {
                List<string> data = GetData(labelRatio10, labelFlow10, labelTRatio10, labelTFlow10, textBoxTicker10.Text,
                                                 textBoxTicker10FlowAlert.Text,
                                                 textBoxT10RAlert.Text,
                                                 _storeDbdata, "number10", checkBoxT10SoundAlert.Checked,
                                                 checkBoxT10EmailAlert.Checked, labelT10Star);

                ThreadHelper.SetText(this, labelT10P2, data[1]);
                ThreadHelper.SetText(this, labelT10PriceVisual, data[0]);



                Thread.Sleep(1000);
                _t10 = false;
            }
        }


        private void ShowStatus()
        {
            if (_t1 && _t2 && _t3 && _t4 && _t5 && _t6 && _t7 && _t8 && _t9 && _t10) //All tickers inactive
            {
                labelStatus1.ForeColor = Color.Red;
                ThreadHelper.SetText(this, labelStatus1, "Inactive");
            }
            else
            {
                ThreadHelper.SetText(this, labelStatus1, "Active");
                labelStatus1.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// 	Inits the timer.
        /// </summary>
        private void InitTimer()
        {
            while (_turn)
            {
                DataStorageEnabled();
                StarInvisible();
                GetDataTicker();
                ShowStatus();
                Thread.Sleep(200000);
            }
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            _turn = true;
            _threadT = new Thread(InitTimer);
            if (!_threadT.IsAlive)
            {
                _threadT.Start();
            }

            UpdateEmailActivationState();
        }


        /// <summary>
        /// 	Reinits this instance.
        /// </summary>
        private void Reinit()
        {
            labelDateDisplay.Text = null;
            labelTimeDisplay.Text = null;
            labelRatio1.Text = null;
            labelFlow1.Text = null;
            labelRatio2.Text = null;
            labelFlow2.Text = null;
            labelRatio3.Text = null;
            labelFlow3.Text = null;
            labelRatio4.Text = null;
            labelFlow4.Text = null;
            labelRatio5.Text = null;
            labelFlow5.Text = null;


            labelTRatio1.Text = null;
            labelTFlow1.Text = null;
            labelTRatio2.Text = null;
            labelTFlow2.Text = null;
            labelTRatio3.Text = null;
            labelTFlow3.Text = null;
            labelTRatio4.Text = null;
            labelTFlow4.Text = null;
            labelTRatio5.Text = null;
            labelTFlow5.Text = null;


            labelT1P2.Text = null;
            labelT2P2.Text = null;
            labelT3P2.Text = null;
            labelT4P2.Text = null;
            labelT5P2.Text = null;

            textBoxTicker1.Text = null;
            textBoxTicker2.Text = null;
            textBoxTicker3.Text = null;
            textBoxTicker4.Text = null;
            textBoxTicker5.Text = null;

            textBoxTicker1FlowAlert.Text = null;
            textBoxTicker2FlowAlert.Text = null;
            textBoxTicker3FlowAlert.Text = null;
            textBoxTicker4FlowAlert.Text = null;
            textBoxTicker5FlowAlert.Text = null;

            textBoxT1RAlert.Text = null;
            textBoxT2RAlert.Text = null;
            textBoxT3RAlert.Text = null;
            textBoxT4RAlert.Text = null;
            textBoxT5RAlert.Text = null;


            labelRatio6.Text = null;
            labelFlow6.Text = null;
            labelRatio7.Text = null;
            labelFlow7.Text = null;
            labelRatio8.Text = null;
            labelFlow8.Text = null;
            labelRatio9.Text = null;
            labelFlow9.Text = null;
            labelRatio10.Text = null;
            labelFlow10.Text = null;


            labelTRatio6.Text = null;
            labelTFlow6.Text = null;
            labelTRatio7.Text = null;
            labelTFlow7.Text = null;
            labelTRatio8.Text = null;
            labelTFlow8.Text = null;
            labelTRatio9.Text = null;
            labelTFlow9.Text = null;
            labelTRatio10.Text = null;
            labelTFlow10.Text = null;

            labelT6P2.Text = null;
            labelT7P2.Text = null;
            labelT8P2.Text = null;
            labelT9P2.Text = null;
            labelT10P2.Text = null;



            labelT1PriceVisual.Text = null;
            labelT2PriceVisual.Text = null;
            labelT3PriceVisual.Text = null;
            labelT4PriceVisual.Text = null;
            labelT5PriceVisual.Text = null;
            labelT6PriceVisual.Text = null;
            labelT7PriceVisual.Text = null;
            labelT8PriceVisual.Text = null;
            labelT9PriceVisual.Text = null;
            labelT10PriceVisual.Text = null;

            textBoxTicker6.Text = null;
            textBoxTicker7.Text = null;
            textBoxTicker8.Text = null;
            textBoxTicker9.Text = null;
            textBoxTicker10.Text = null;

            textBoxTicker6FlowAlert.Text = null;
            textBoxTicker7FlowAlert.Text = null;
            textBoxTicker8FlowAlert.Text = null;
            textBoxTicker9FlowAlert.Text = null;
            textBoxTicker10FlowAlert.Text = null;

            textBoxT6RAlert.Text = null;
            textBoxT7RAlert.Text = null;
            textBoxT8RAlert.Text = null;
            textBoxT9RAlert.Text = null;
            textBoxT10RAlert.Text = null;


            labelStatus1.ForeColor = Color.Red;
            labelStatus1.Text = "Inactive";

            StarInvisible();
           try
           {
               if (_threadT != null)
               {
                   if (_threadT.IsAlive)
                   {
                       _turn = false;
                       _threadT.Abort();
                       _threadT = null;
                   }
               }
           }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
          
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _turn = false;
            Reinit();
            UpdateEmailActivationState();
        }

        private void administrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministration form = new FrmAdministration();
            form.ShowDialog();
        }

        private void FrmScrapping_Load(object sender, EventArgs e)
        {
        }


        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            string result = SetTickersState(
                textBoxTicker1.Text, textBoxTicker2.Text, textBoxTicker3.Text,
                textBoxTicker4.Text, textBoxTicker5.Text,
                textBoxTicker6.Text, textBoxTicker7.Text, textBoxTicker8.Text,
                textBoxTicker9.Text, textBoxTicker10.Text,
                textBoxTicker1FlowAlert.Text,
                textBoxTicker2FlowAlert.Text, textBoxTicker3FlowAlert.Text,
                textBoxTicker4FlowAlert.Text, textBoxTicker5FlowAlert.Text,
                textBoxTicker6FlowAlert.Text,
                textBoxTicker7FlowAlert.Text, textBoxTicker8FlowAlert.Text,
                textBoxTicker9FlowAlert.Text, textBoxTicker10FlowAlert.Text,
                textBoxT1RAlert.Text, textBoxT2RAlert.Text, textBoxT3RAlert.Text,
                textBoxT4RAlert.Text, textBoxT5RAlert.Text,
                textBoxT6RAlert.Text, textBoxT7RAlert.Text, textBoxT8RAlert.Text,
                textBoxT9RAlert.Text, textBoxT10RAlert.Text
                );
            MessageBox.Show(result);
            UpdateEmailActivationState();
        }

        private void buttonLoadState_Click(object sender, EventArgs e)
        {
            GetTickersState(
                textBoxTicker1, textBoxTicker2, textBoxTicker3, textBoxTicker4, textBoxTicker5,
                textBoxTicker6, textBoxTicker7, textBoxTicker8, textBoxTicker9, textBoxTicker10,
                textBoxTicker1FlowAlert, textBoxTicker2FlowAlert, textBoxTicker3FlowAlert,
                textBoxTicker4FlowAlert, textBoxTicker5FlowAlert,
                textBoxTicker6FlowAlert, textBoxTicker7FlowAlert, textBoxTicker8FlowAlert,
                textBoxTicker9FlowAlert, textBoxTicker10FlowAlert,
                textBoxT1RAlert, textBoxT2RAlert,
                textBoxT3RAlert, textBoxT4RAlert, textBoxT5RAlert,
                textBoxT6RAlert, textBoxT7RAlert,
                textBoxT8RAlert, textBoxT9RAlert, textBoxT10RAlert
                );
        }

        private void FrmScrapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            _turn = false;
            Reinit();
            UpdateEmailActivationState();
            Application.Exit();
        }

     
        private void buttonBChart1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxTicker1.Text))
                Webpages.OpenWebpage(_root + textBoxTicker1.Text+_block);
        }

        private void buttonTchart1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker1.Text))
                Webpages.OpenWebpage(_root + textBoxTicker1.Text + _total);
        }

        private void buttonBChart2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker2.Text))
                Webpages.OpenWebpage(_root + textBoxTicker2.Text + _block);
        }

        private void buttonTchart2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker2.Text))
                Webpages.OpenWebpage(_root + textBoxTicker2.Text + _total);
        }

        private void buttonBChart3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker3.Text))
                Webpages.OpenWebpage(_root + textBoxTicker3.Text + _block);
        }

        private void buttonTchart3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker3.Text))
                Webpages.OpenWebpage(_root + textBoxTicker3.Text + _total);
        }

        private void buttonBChart4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker4.Text))
                Webpages.OpenWebpage(_root + textBoxTicker4.Text + _block);
        }

        private void buttonTchart4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker4.Text))
                Webpages.OpenWebpage(_root + textBoxTicker4.Text + _total);
        }


        private void buttonBChart5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker5.Text))
                Webpages.OpenWebpage(_root + textBoxTicker5.Text + _block);
        }

        private void buttonTchart5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker5.Text))
                Webpages.OpenWebpage(_root + textBoxTicker5.Text + _total);
        }


        private void buttonBChart6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker6.Text))
                Webpages.OpenWebpage(_root + textBoxTicker6.Text + _block);
        }

        private void buttonTchart6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker6.Text))
                Webpages.OpenWebpage(_root + textBoxTicker6.Text + _total);
        }

        private void buttonBChart7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker7.Text))
                Webpages.OpenWebpage(_root + textBoxTicker7.Text + _block);
        }

        private void buttonTchart7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker7.Text))
                Webpages.OpenWebpage(_root + textBoxTicker7.Text + _total);
        }

        private void buttonBChart8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker8.Text))
                Webpages.OpenWebpage(_root + textBoxTicker8.Text + _block);
        }

        private void buttonTchart8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker8.Text))
                Webpages.OpenWebpage(_root + textBoxTicker8.Text + _total);
        }

        private void buttonBChart9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker9.Text))
                Webpages.OpenWebpage(_root + textBoxTicker9.Text + _block);
        }

        private void buttonTchart9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker9.Text))
                Webpages.OpenWebpage(_root + textBoxTicker9.Text + _total);
        }

        private void buttonBChart10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker10.Text))
                Webpages.OpenWebpage(_root + textBoxTicker10.Text + _block);
        }

        private void buttonTchart10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTicker10.Text))
                Webpages.OpenWebpage(_root + textBoxTicker10.Text + _total);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHelp frm = new FrmHelp();
            frm.Show();
        }

     

        private void buttonBChartS1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT1STicker.Text))
                Webpages.OpenWebpage(_root + labelT1STicker.Text + _block);
        }

        private void buttonBChartS2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT2STicker.Text))
                Webpages.OpenWebpage(_root + labelT2STicker.Text + _block);
        }

        private void buttonBChartS3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT3STicker.Text))
                Webpages.OpenWebpage(_root + labelT3STicker.Text + _block);
        }

        private void buttonBChartS4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT4STicker.Text))
                Webpages.OpenWebpage(_root + labelT4STicker.Text + _block);
        }

        private void buttonBChartS5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT5STicker.Text))
                Webpages.OpenWebpage(_root + labelT5STicker.Text + _block);
        }




        private void buttonBChartB1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT1BTicker.Text))
                Webpages.OpenWebpage(_root + labelT1BTicker.Text + _block);
        }

        private void buttonBChartB2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT2BTicker.Text))
                Webpages.OpenWebpage(_root + labelT2BTicker.Text + _block);
        }

        private void buttonBChartB3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT3BTicker.Text))
                Webpages.OpenWebpage(_root + labelT3BTicker.Text + _block);
        }

        private void buttonBChartB4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT4BTicker.Text))
                Webpages.OpenWebpage(_root + labelT4BTicker.Text + _block);
        }

        private void buttonBChartB5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelT5BTicker.Text))
                Webpages.OpenWebpage(_root + labelT5BTicker.Text + _block);
        }

        private void labelSelling_Click(object sender, EventArgs e)
        {
         
        }

        private void buttonDesSound_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1SoundAlert, false,checkBoxT2SoundAlert, false,checkBoxT3SoundAlert, false,checkBoxT4SoundAlert, false,checkBoxT5SoundAlert, false,checkBoxT6SoundAlert, 
                false,checkBoxT7SoundAlert, false,checkBoxT8SoundAlert, false,checkBoxT9SoundAlert, false,checkBoxT10SoundAlert, false);
        }

        private void buttonActSound_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1SoundAlert, true, checkBoxT2SoundAlert, true, checkBoxT3SoundAlert, true, checkBoxT4SoundAlert, true, checkBoxT5SoundAlert, true, checkBoxT6SoundAlert,
            true, checkBoxT7SoundAlert, true, checkBoxT8SoundAlert, true, checkBoxT9SoundAlert, true, checkBoxT10SoundAlert, true);
        }

        private void buttonDesactEmail_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1EmailAlert, false, checkBoxT2EmailAlert, false, checkBoxT3EmailAlert, false, checkBoxT4EmailAlert, false, checkBoxT5EmailAlert, false, checkBoxT6EmailAlert,
                false, checkBoxT7EmailAlert, false, checkBoxT8EmailAlert, false, checkBoxT9EmailAlert, false, checkBoxT10EmailAlert, false);
        }

        private void buttonActEmail_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1EmailAlert, true, checkBoxT2EmailAlert, true, checkBoxT3EmailAlert, true, checkBoxT4EmailAlert, true, checkBoxT5EmailAlert, true, checkBoxT6EmailAlert,
           true, checkBoxT7EmailAlert, true, checkBoxT8EmailAlert, true, checkBoxT9EmailAlert, true, checkBoxT10EmailAlert, true);
        }

        private void screenerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}