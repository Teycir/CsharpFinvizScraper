#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using WebScrap.Presenter;

#endregion

namespace WebScrap.View
{
    public partial class FrmMoneyFlow : Form, IViewMoneyFlow
    {
        private readonly PresMain _pres;
        public Thread ThreadListboxBearDivergence;
        public Thread ThreadListboxBullDivergence;
        public Thread ThreadMain;
      
        private bool _listboxthreadBearDivergenceactive;
        private bool _listboxthreadBullDivergenceactive;
        private bool _mainthreadactive;
      
      

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

     

        public FrmMoneyFlow()
        {
            //bool isdbvalid = GetDbConnection();
            //if(! isdbvalid)return;

            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            _pres = new PresMain(this);

        
            ShowStatus();

            StarInvisible();

            StartWebScraping();


            List<string> files = new List<string>();
            Directory.CreateDirectory(FileHelper.GetRoot() + "//InsidersTracker//tickers//");
            string path = FileHelper.GetRoot() + "//InsidersTracker//tickers//";

         
            
            string[] files1 = FileHelper.GetDirectoryFiles(path, "xml");
            if (files1!=null)
            {
                foreach (var file in files1)
                {
                    if (!files1.Any()) continue;

                    string[] pathArr = file.Split('\\');
                    string[] fileArr = pathArr.Last().Split('.');
                    string fileName = fileArr[0].Split('/').Last();
                    files.Add(fileName);
                }
                if (files.Count > 0)
                {
                    GetTickersState(files[0],
                                    textBoxTicker1,
                                    textBoxTicker2, textBoxTicker3, textBoxTicker4, textBoxTicker5,
                                    textBoxTicker6, textBoxTicker7, textBoxTicker8, textBoxTicker9, textBoxTicker10,
                                    textBoxTicker1FlowAlert, textBoxTicker2FlowAlert, textBoxTicker3FlowAlert,
                                    textBoxTicker4FlowAlert, textBoxTicker5FlowAlert,
                                    textBoxTicker6FlowAlert, textBoxTicker7FlowAlert, textBoxTicker8FlowAlert,
                                    textBoxTicker9FlowAlert, textBoxTicker10FlowAlert,
                                    textBoxT1RAlert, textBoxT2RAlert,
                                    textBoxT3RAlert, textBoxT4RAlert, textBoxT5RAlert,
                                    textBoxT6RAlert, textBoxT7RAlert,
                                    textBoxT8RAlert, textBoxT9RAlert, textBoxT10RAlert,
                                    textBoxT1RAlertNeg, textBoxT2RAlertNeg,
                                    textBoxT3RAlertNeg, textBoxT4RAlertNeg, textBoxT5RAlertNeg,
                                    textBoxT6RAlertNeg, textBoxT7RAlertNeg,
                                    textBoxT8RAlertNeg, textBoxT9RAlertNeg, textBoxT10RAlertNeg
                        );
                }
            }
           

           
        }

        #region Properties

        public object GetObjecttextBoxTicker1
        {
            get { return textBoxTicker1; }
        }

        public object GetObjecttextBoxTicker2
        {
            get { return textBoxTicker2; }
        }

        public object GetObjecttextBoxTicker3
        {
            get { return textBoxTicker3; }
        }

        public object GetObjecttextBoxTicker4
        {
            get { return textBoxTicker4; }
        }

        public object GetObjecttextBoxTicker5
        {
            get { return textBoxTicker5; }
        }

        public object GetObjecttextBoxTicker6
        {
            get { return textBoxTicker6; }
        }

        public object GetObjecttextBoxTicker7
        {
            get { return textBoxTicker7; }
        }

        public object GetObjecttextBoxTicker8
        {
            get { return textBoxTicker8; }
        }

        public object GetObjecttextBoxTicker9
        {
            get { return textBoxTicker9; }
        }

        public object GetObjecttextBoxTicker10
        {
            get { return textBoxTicker10; }
        }


        public object GetObjecttextBoxTicker1FlowAlert
        {
            get { return textBoxTicker1FlowAlert; }
        }

        public object GetObjecttextBoxTicker2FlowAlert
        {
            get { return textBoxTicker2FlowAlert; }
        }

        public object GetObjecttextBoxTicker3FlowAlert
        {
            get { return textBoxTicker3FlowAlert; }
        }

        public object GetObjecttextBoxTicker4FlowAlert
        {
            get { return textBoxTicker4FlowAlert; }
        }

        public object GetObjecttextBoxTicker5FlowAlert
        {
            get { return textBoxTicker5FlowAlert; }
        }

        public object GetObjecttextBoxTicker6FlowAlert
        {
            get { return textBoxTicker6FlowAlert; }
        }

        public object GetObjecttextBoxTicker7FlowAlert
        {
            get { return textBoxTicker7FlowAlert; }
        }

        public object GetObjecttextBoxTicker8FlowAlert
        {
            get { return textBoxTicker8FlowAlert; }
        }

        public object GetObjecttextBoxTicker9FlowAlert
        {
            get { return textBoxTicker9FlowAlert; }
        }

        public object GetObjecttextBoxTicker10FlowAlert
        {
            get { return textBoxTicker10FlowAlert; }
        }


        public object GetObjecttextBoxT1RAlert
        {
            get { return textBoxT1RAlert; }
        }

        public object GetObjecttextBoxT2RAlert
        {
            get { return textBoxT2RAlert; }
        }

        public object GetObjecttextBoxT3RAlert
        {
            get { return textBoxT3RAlert; }
        }

        public object GetObjecttextBoxT4RAlert
        {
            get { return textBoxT4RAlert; }
        }

        public object GetObjecttextBoxT5RAlert
        {
            get { return textBoxT5RAlert; }
        }

        public object GetObjecttextBoxT6RAlert
        {
            get { return textBoxT6RAlert; }
        }

        public object GetObjecttextBoxT7RAlert
        {
            get { return textBoxT7RAlert; }
        }

        public object GetObjecttextBoxT8RAlert
        {
            get { return textBoxT8RAlert; }
        }

        public object GetObjecttextBoxT9RAlert
        {
            get { return textBoxT9RAlert; }
        }

        public object GetObjecttextBoxT10RAlert
        {
            get { return textBoxT10RAlert; }
        }


        public object GetObjecttextBoxT1RAlertNeg
        {
            get { return textBoxT1RAlertNeg; }
        }

        public object GetObjecttextBoxT2RAlertNeg
        {
            get { return textBoxT2RAlertNeg; }
        }

        public object GetObjecttextBoxT3RAlertNeg
        {
            get { return textBoxT3RAlertNeg; }
        }

        public object GetObjecttextBoxT4RAlertNeg
        {
            get { return textBoxT4RAlertNeg; }
        }

        public object GetObjecttextBoxT5RAlertNeg
        {
            get { return textBoxT5RAlert; }
        }

        public object GetObjecttextBoxT6RAlertNeg
        {
            get { return textBoxT6RAlertNeg; }
        }

        public object GetObjecttextBoxT7RAlertNeg
        {
            get { return textBoxT7RAlertNeg; }
        }

        public object GetObjecttextBoxT8RAlertNeg
        {
            get { return textBoxT8RAlertNeg; }
        }

        public object GetObjecttextBoxT9RAlertNeg
        {
            get { return textBoxT9RAlertNeg; }
        }

        public object GetObjecttextBoxT10RAlertNeg
        {
            get { return textBoxT10RAlertNeg; }
        }


        public string GettextBoxTicker1
        {
            get { return textBoxTicker1.Text; }
        }

        public string GettextBoxTicker2
        {
            get { return textBoxTicker2.Text; }
        }

        public string GettextBoxTicker3
        {
            get { return textBoxTicker3.Text; }
        }

        public string GettextBoxTicker4
        {
            get { return textBoxTicker4.Text; }
        }

        public string GettextBoxTicker5
        {
            get { return textBoxTicker5.Text; }
        }

        public string GettextBoxTicker6
        {
            get { return textBoxTicker6.Text; }
        }

        public string GettextBoxTicker7
        {
            get { return textBoxTicker7.Text; }
        }

        public string GettextBoxTicker8
        {
            get { return textBoxTicker8.Text; }
        }

        public string GettextBoxTicker9
        {
            get { return textBoxTicker9.Text; }
        }

        public string GettextBoxTicker10
        {
            get { return textBoxTicker10.Text; }
        }


        public string GettextBoxTicker1FlowAlert
        {
            get { return textBoxTicker1FlowAlert.Text; }
        }

        public string GettextBoxTicker2FlowAlert
        {
            get { return textBoxTicker2FlowAlert.Text; }
        }

        public string GettextBoxTicker3FlowAlert
        {
            get { return textBoxTicker3FlowAlert.Text; }
        }

        public string GettextBoxTicker4FlowAlert
        {
            get { return textBoxTicker4FlowAlert.Text; }
        }

        public string GettextBoxTicker5FlowAlert
        {
            get { return textBoxTicker5FlowAlert.Text; }
        }

        public string GettextBoxTicker6FlowAlert
        {
            get { return textBoxTicker6FlowAlert.Text; }
        }

        public string GettextBoxTicker7FlowAlert
        {
            get { return textBoxTicker7FlowAlert.Text; }
        }

        public string GettextBoxTicker8FlowAlert
        {
            get { return textBoxTicker8FlowAlert.Text; }
        }

        public string GettextBoxTicker9FlowAlert
        {
            get { return textBoxTicker9FlowAlert.Text; }
        }

        public string GettextBoxTicker10FlowAlert
        {
            get { return textBoxTicker10FlowAlert.Text; }
        }


        public string GettextBoxT1RAlert
        {
            get { return textBoxT1RAlert.Text; }
        }

        public string GettextBoxT2RAlert
        {
            get { return textBoxT2RAlert.Text; }
        }

        public string GettextBoxT3RAlert
        {
            get { return textBoxT3RAlert.Text; }
        }

        public string GettextBoxT4RAlert
        {
            get { return textBoxT4RAlert.Text; }
        }

        public string GettextBoxT5RAlert
        {
            get { return textBoxT5RAlert.Text; }
        }

        public string GettextBoxT6RAlert
        {
            get { return textBoxT6RAlert.Text; }
        }

        public string GettextBoxT7RAlert
        {
            get { return textBoxT7RAlert.Text; }
        }

        public string GettextBoxT8RAlert
        {
            get { return textBoxT8RAlert.Text; }
        }

        public string GettextBoxT9RAlert
        {
            get { return textBoxT9RAlert.Text; }
        }

        public string GettextBoxT10RAlert
        {
            get { return textBoxT10RAlert.Text; }
        }


        public string GettextBoxT1RAlertNeg
        {
            get { return textBoxT1RAlertNeg.Text; }
        }

        public string GettextBoxT2RAlertNeg
        {
            get { return textBoxT2RAlertNeg.Text; }
        }

        public string GettextBoxT3RAlertNeg
        {
            get { return textBoxT3RAlertNeg.Text; }
        }

        public string GettextBoxT4RAlertNeg
        {
            get { return textBoxT4RAlertNeg.Text; }
        }

        public string GettextBoxT5RAlertNeg
        {
            get { return textBoxT5RAlert.Text; }
        }

        public string GettextBoxT6RAlertNeg
        {
            get { return textBoxT6RAlertNeg.Text; }
        }

        public string GettextBoxT7RAlertNeg
        {
            get { return textBoxT7RAlertNeg.Text; }
        }

        public string GettextBoxT8RAlertNeg
        {
            get { return textBoxT8RAlertNeg.Text; }
        }

        public string GettextBoxT9RAlertNeg
        {
            get { return textBoxT9RAlertNeg.Text; }
        }

        public string GettextBoxT10RAlertNeg
        {
            get { return textBoxT10RAlertNeg.Text; }
        }

        public string TickerName { get; set; }

        #endregion

        #region IViewMoneyFlow Members

        public bool Tweet { get; set; }
        public bool Email { get; set; }

    
     

        /// <summary>
        /// 	Views the label.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="values"> The values. </param>
        public void FillCombobox(object obj, List<string> values)
        {
            ComboBox combo = null;
            if (obj is ComboBox)
            {
                combo = obj as ComboBox;
            }
            if (combo != null)
            {
                combo.DataSource = values;
            }
        }

        /// <summary>
        /// 	Gets the data.
        /// </summary>
        /// <param name="_labelRatio"> The _label ratio. </param>
        /// <param name="_labelFlow"> The _label flow. </param>
        /// <param name="_labelFRatio"> The _label F ratio. </param>
        /// <param name="_labelFFlow"> The _label F flow. </param>
        /// <param name="ticker"> The ticker. </param>
        /// <param name="flowAlertValue"> The flow alert value. </param>
        /// <param name="ratioalertValue"> The ratioalert value. </param>
        /// <param name="ratioalertValueNeg"> The ratioalert value neg. </param>
        /// <param name="storedata"> if set to <c>true</c> [storedata]. </param>
        /// <param name="sound"> The sound. </param>
        /// <param name="activesoundalert"> if set to <c>true</c> [activesoundalert]. </param>
        /// <param name="activesmailalert"> if set to <c>true</c> [activesmailalert]. </param>
        /// <param name="starlabel"> The starlabel. </param>
        /// <exception cref="System.ArgumentNullException">_labelRatio
        /// 	or
        /// 	_labelFlow</exception>
        public void GetWsjData(object _labelRatio, object _labelFlow, object _labelFRatio, object _labelFFlow,
                               string ticker, string flowAlertValue, string ratioalertValue, string ratioalertValueNeg,
                                string sound, bool activesoundalert, bool activesmailalert,
                               object starlabel)
        {
            DateTimePicker dtp = new DateTimePicker();
            ThreadHelper.SetText(this, labelDateDisplay, dtp.Value.Date.ToString("MM/dd/yyyy"));
            ThreadHelper.SetText(this, labelTimeDisplay, DateTime.Now.ToString("HH:mm:ss"));

            _pres.GetWsjData(_labelRatio, _labelFlow, _labelFRatio, _labelFFlow, ticker, flowAlertValue, ratioalertValue,
                             ratioalertValueNeg, sound,
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
                ThreadHelper.SetText(this, label, s);
            }
        }


        /// <summary>
        /// 	Views the label.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        /// <param name="visible"> if set to <c>true</c> [visible]. </param>
        public void VisibleLabel(object obj, bool visible)
        {
            Label label = null;
            if (obj is Label)
            {
                label = obj as Label;
            }
            if (label != null)
            {
                ThreadHelper.SetVisibility(this, label, visible);
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
                ThreadHelper.SetText(this, txt, s);
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


        public void ListboxAddItem(object obj, string data)
        {
            ListBox lbx = null;
            if (obj is ListBox)
            {
                lbx = obj as ListBox;
            }
            if (lbx != null)
            {
                ThreadHelper.ListboxAddText(this, lbx, data);
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
        /// <param name="labelT1BPrice"> The label t1 B price. </param>
        /// <param name="labelT2BPrice"> The label t2 B price. </param>
        /// <param name="labelT3BPrice"> The label t3 B price. </param>
        /// <param name="labelT4BPrice"> The label t4 B price. </param>
        /// <param name="labelT5BPrice"> The label t5 B price. </param>
        /// <param name="labelT1SPrice"> The label t1 S price. </param>
        /// <param name="labelT2SPrice"> The label t2 S price. </param>
        /// <param name="labelT3SPrice"> The label t3 S price. </param>
        /// <param name="labelT4SPrice"> The label t4 S price. </param>
        /// <param name="labelT5SPrice"> The label t5 S price. </param>
        /// <param name="labelT1BBlocks"> The label t1 B blocks. </param>
        /// <param name="labelT2BBlocks"> The label t2 B blocks. </param>
        /// <param name="labelT3BBlocks"> The label t3 B blocks. </param>
        /// <param name="labelT4BBlocks"> The label t4 B blocks. </param>
        /// <param name="labelT5BBlocks"> The label t5 B blocks. </param>
        /// <param name="labelT1Slocks"> The label t1 slocks. </param>
        /// <param name="labelT2SBlocks"> The label t2 S blocks. </param>
        /// <param name="labelT3SBlocks"> The label t3 S blocks. </param>
        /// <param name="labelT4SBlocks"> The label t4 S blocks. </param>
        /// <param name="labelT5SBlocks"> The label t5 S blocks. </param>
        /// <param name="labelB1BRatio"> The label b1 B ratio. </param>
        /// <param name="labelB2BRatio"> The label b2 B ratio. </param>
        /// <param name="labelB3BRatio"> The label b3 B ratio. </param>
        /// <param name="labelB4BRatio"> The label b4 B ratio. </param>
        /// <param name="labelB5BRatio"> The label b5 B ratio. </param>
        /// <param name="labelS1BRatio"> The label s1 B ratio. </param>
        /// <param name="labelS2BRatio"> The label s2 B ratio. </param>
        /// <param name="labelS3BRatio"> The label s3 B ratio. </param>
        /// <param name="labelS4BRatio"> The label s4 B ratio. </param>
        /// <param name="labelS5BRatio"> The label s5 B ratio. </param>
        public void GetWsjData(object labelT1B, object labelT2B, object labelT3B, object labelT4B, object labelT5B,
                               object labelT1S, object labelT2S, object labelT3S, object labelT4S, object labelT5S,
                               object labelT1BPrice, object labelT2BPrice, object labelT3BPrice, object labelT4BPrice,
                               object labelT5BPrice, object labelT1SPrice, object labelT2SPrice, object labelT3SPrice,
                               object labelT4SPrice, object labelT5SPrice, object labelT1BBlocks, object labelT2BBlocks,
                               object labelT3BBlocks, object labelT4BBlocks, object labelT5BBlocks, object labelT1Slocks,
                               object labelT2SBlocks, object labelT3SBlocks, object labelT4SBlocks,
                               object labelT5SBlocks, object labelB1BRatio, object labelB2BRatio, object labelB3BRatio,
                               object labelB4BRatio, object labelB5BRatio, object labelS1BRatio, object labelS2BRatio,
                               object labelS3BRatio, object labelS4BRatio, object labelS5BRatio)
        {
            _pres.GetWsjData(
                labelT1BTicker, labelT2BTicker, labelT3BTicker, labelT4BTicker, labelT5BTicker,
                labelT1STicker, labelT2STicker, labelT3STicker, labelT4STicker, labelT5STicker,
                labelT6BTicker, labelT7BTicker, labelT8BTicker, labelT9BTicker, labelT10BTicker,
                labelT6STicker, labelT7STicker, labelT8STicker, labelT9STicker, labelT10STicker,
                labelT11BTicker, labelT12BTicker, labelT13BTicker, labelT14BTicker, labelT15BTicker,
                labelT11STicker, labelT12STicker, labelT13STicker, labelT14STicker, labelT15STicker,
                labelT16BTicker, labelT17BTicker, labelT18BTicker, labelT19BTicker, labelT20BTicker,
                labelT16STicker, labelT17STicker, labelT18STicker, labelT19STicker, labelT20STicker
                );
        }

        #endregion

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
            return _pres.SetTickersState(tickername, ticker1, ticker2, ticker3, ticker4, ticker5,
                                         ticker6, ticker7, ticker8, ticker9, ticker10,
                                         ticker1FAlert, ticker2FAlert, ticker3FAlert,
                                         ticker4FAlert, ticker5FAlert, ticker6FAlert,
                                         ticker7FAlert, ticker8FAlert, ticker9FAlert,
                                         ticker10FAlert,
                                         ticker1RAlert, ticker2RAlert,
                                         ticker3RAlert, ticker4RAlert, ticker5RAlert,
                                         ticker6RAlert, ticker7RAlert, ticker8RAlert,
                                         ticker9RAlert, ticker10RAlert,
                                         ticker1RAlertNeg, ticker2RAlertNeg,
                                         ticker3RAlertNeg, ticker4RAlertNeg, ticker5RAlertNeg,
                                         ticker6RAlertNeg, ticker7RAlertNeg, ticker8RAlertNeg,
                                         ticker9RAlertNeg, ticker10RAlertNeg);
        }


        public void GetTickersState(string ticker, object ticker1, object ticker2, object ticker3, object ticker4,
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
                                    object ticker9RAlertNeg, object ticker10RAlertNeg)
        {
            _pres.GetTickersState(ticker,
                                  ticker1, ticker2, ticker3, ticker4, ticker5,
                                  ticker6, ticker7, ticker8, ticker9, ticker10,
                                  ticker1FAlert, ticker2FAlert, ticker3FAlert,
                                  ticker4FAlert, ticker5FAlert, ticker6FAlert,
                                  ticker7FAlert, ticker8FAlert, ticker9FAlert,
                                  ticker10FAlert,
                                  ticker1RAlert, ticker2RAlert,
                                  ticker3RAlert, ticker4RAlert, ticker5RAlert,
                                  ticker6RAlert, ticker7RAlert, ticker8RAlert,
                                  ticker9RAlert, ticker10RAlert,
                                  ticker1RAlertNeg, ticker2RAlertNeg,
                                  ticker3RAlertNeg, ticker4RAlertNeg, ticker5RAlertNeg,
                                  ticker6RAlertNeg, ticker7RAlertNeg, ticker8RAlertNeg,
                                  ticker9RAlertNeg, ticker10RAlertNeg)
                ;
        }

        /// <summary>
        /// 	Stars turn invisible.
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


        /// <summary>
        /// 	Gets the data ticker.
        /// </summary>
        private void GetDataTicker()
        {
            GetWsjData(labelT1BTicker, labelT2BTicker, labelT3BTicker, labelT4BTicker, labelT5BTicker,
                       labelT1STicker, labelT2STicker, labelT3STicker, labelT4STicker, labelT5STicker,
                       labelT6BTicker, labelT7BTicker, labelT8BTicker, labelT9BTicker, labelT10BTicker,
                       labelT6STicker, labelT7STicker, labelT8STicker, labelT9STicker, labelT10STicker,
                       labelT11BTicker, labelT12BTicker, labelT13BTicker, labelT14BTicker, labelT15BTicker,
                       labelT11STicker, labelT12STicker, labelT13STicker, labelT14STicker, labelT15STicker,
                       labelT16BTicker, labelT17BTicker, labelT18BTicker, labelT19BTicker, labelT20BTicker,
                       labelT16STicker, labelT17STicker, labelT18STicker, labelT19STicker, labelT20STicker
                );


            if (textBoxTicker1.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow1, "Type a ticker1");
                _t1 = true;
            }
            else
            {
                GetWsjData(labelRatio1, labelFlow1, labelTRatio1, labelTFlow1, textBoxTicker1.Text,
                           textBoxTicker1FlowAlert.Text,
                           textBoxT1RAlert.Text, textBoxT1RAlertNeg.Text,
                            "number1", checkBoxT1SoundAlert.Checked,
                           checkBoxT1EmailAlert.Checked, labelT1Star);


                Thread.Sleep(500);
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
                GetWsjData(labelRatio2, labelFlow2, labelTRatio2, labelTFlow2, textBoxTicker2.Text,
                           textBoxTicker2FlowAlert.Text,
                           textBoxT2RAlert.Text, textBoxT2RAlertNeg.Text,
                          "number2", checkBoxT2SoundAlert.Checked,
                           checkBoxT2EmailAlert.Checked, labelT2Star);


                Thread.Sleep(500);


                _t2 = false;
            }


            if (textBoxTicker3.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow3, "Type a ticker3");

                _t3 = true;
            }
            else
            {
                GetWsjData(labelRatio3, labelFlow3, labelTRatio3, labelTFlow3, textBoxTicker3.Text,
                           textBoxTicker3FlowAlert.Text,
                           textBoxT3RAlert.Text, textBoxT3RAlertNeg.Text,
                            "number3", checkBoxT3SoundAlert.Checked,
                           checkBoxT3EmailAlert.Checked, labelT3Star);


                Thread.Sleep(500);

                _t3 = false;
            }


            if (textBoxTicker4.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow4, "Type a ticker4");

                _t4 = true;
            }
            else
            {
                GetWsjData(labelRatio4, labelFlow4, labelTRatio4, labelTFlow4, textBoxTicker4.Text,
                           textBoxTicker4FlowAlert.Text,
                           textBoxT4RAlert.Text, textBoxT4RAlertNeg.Text,
                           "number4", checkBoxT4SoundAlert.Checked,
                           checkBoxT4EmailAlert.Checked, labelT4Star);


                Thread.Sleep(500);
                _t4 = false;
            }


            if (textBoxTicker5.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow5, "Type a ticker5");
                _t5 = true;
            }
            else
            {
                GetWsjData(labelRatio5, labelFlow5, labelTRatio5, labelTFlow5, textBoxTicker5.Text,
                           textBoxTicker5FlowAlert.Text,
                           textBoxT5RAlert.Text, textBoxT5RAlertNeg.Text,
                            "number5", checkBoxT5SoundAlert.Checked,
                           checkBoxT5EmailAlert.Checked, labelT5Star);


                Thread.Sleep(500);
                _t5 = false;
            }


            if (textBoxTicker6.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow6, "Type a ticker6");
                _t6 = true;
            }
            else
            {
                GetWsjData(labelRatio6, labelFlow6, labelTRatio6, labelTFlow6, textBoxTicker6.Text,
                           textBoxTicker6FlowAlert.Text,
                           textBoxT6RAlert.Text, textBoxT6RAlertNeg.Text,
                            "number6", checkBoxT6SoundAlert.Checked,
                           checkBoxT6EmailAlert.Checked, labelT6Star);


                Thread.Sleep(500);
                _t6 = false;
            }


            if (textBoxTicker7.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow7, "Type a ticker7");
                _t7 = true;
            }
            else
            {
                GetWsjData(labelRatio7, labelFlow7, labelTRatio7, labelTFlow7, textBoxTicker7.Text,
                           textBoxTicker7FlowAlert.Text,
                           textBoxT7RAlert.Text, textBoxT7RAlertNeg.Text,
                          "number7", checkBoxT7SoundAlert.Checked,
                           checkBoxT7EmailAlert.Checked, labelT7Star);


                Thread.Sleep(500);
                _t7 = false;
            }


            if (textBoxTicker8.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow8, "Type a ticker8");
                _t8 = true;
            }
            else
            {
                GetWsjData(labelRatio8, labelFlow8, labelTRatio8, labelTFlow8, textBoxTicker8.Text,
                           textBoxTicker8FlowAlert.Text,
                           textBoxT8RAlert.Text, textBoxT8RAlertNeg.Text,
                          "number8", checkBoxT8SoundAlert.Checked,
                           checkBoxT8EmailAlert.Checked, labelT8Star);


                Thread.Sleep(500);
                _t8 = false;
            }


            if (textBoxTicker9.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow9, "Type a ticker9");
                _t9 = true;
            }
            else
            {
                GetWsjData(labelRatio9, labelFlow9, labelTRatio9, labelTFlow9, textBoxTicker9.Text,
                           textBoxTicker9FlowAlert.Text,
                           textBoxT9RAlert.Text, textBoxT9RAlertNeg.Text,
                            "number9", checkBoxT9SoundAlert.Checked,
                           checkBoxT9EmailAlert.Checked, labelT9Star);


                Thread.Sleep(500);
                _t9 = false;
            }


            if (textBoxTicker10.Text.Trim() == "")
            {
                ThreadHelper.SetText(this, labelFlow10, "Type a ticker10");
                _t10 = true;
            }
            else
            {
                GetWsjData(labelRatio10, labelFlow10, labelTRatio10, labelTFlow10, textBoxTicker10.Text,
                           textBoxTicker10FlowAlert.Text,
                           textBoxT10RAlert.Text, textBoxT10RAlertNeg.Text,
                      "number10", checkBoxT10SoundAlert.Checked,
                           checkBoxT10EmailAlert.Checked, labelT10Star);


                Thread.Sleep(500);
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

        private void BearDivergenceAlerts()
        {
            _pres.DivergenceAlerts(listBoxBearDivergence, false);
        }


        private void BullDivergenceAlerts()
        {
            _pres.DivergenceAlerts(listBoxDivergence, true);
        }

        /// <summary>
        /// 	Inits the timer.
        /// </summary>
        private void InitThread()
        {
            while (_mainthreadactive)
            {
                StarInvisible();
                GetDataTicker();
                ShowStatus();
                Thread.Sleep(200000);
            }
        }


        private void InitTimerListboxBearDivergence()
        {
            while (_listboxthreadBearDivergenceactive)
            {
                BearDivergenceAlerts();
            }
        }

        private void InitTimerListboxDivergence()
        {
            while (_listboxthreadBullDivergenceactive)
            {
                BullDivergenceAlerts();
            }
        }


        private void StartDivergencesThread()
        {
            _listboxthreadBullDivergenceactive = true;
            ThreadListboxBullDivergence = new Thread(InitTimerListboxDivergence);
            if (!ThreadListboxBullDivergence.IsAlive)
            {
                ThreadListboxBullDivergence.IsBackground = true;
                ThreadListboxBullDivergence.Start();
            }


            _listboxthreadBearDivergenceactive = true;
            ThreadListboxBearDivergence = new Thread(InitTimerListboxBearDivergence);
            if (!ThreadListboxBearDivergence.IsAlive)
            {
                ThreadListboxBearDivergence.IsBackground = true;
                ThreadListboxBearDivergence.Start();
            }
        }


        private void StartWebScraping()
        {
            _mainthreadactive = true;
            ThreadMain = new Thread(InitThread);
            if (!ThreadMain.IsAlive)
            {
                // To not let the thread open after application exit
                ThreadMain.IsBackground = true;
                ThreadMain.Start();
            }


            StartDivergencesThread();
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
                if (ThreadMain != null)
                {
                    if (ThreadMain.IsAlive)
                    {
                        _mainthreadactive = false;
                        ThreadMain.Abort();
                        ThreadMain = null;
                    }
                }


                if (ThreadListboxBullDivergence != null)
                {
                    if (ThreadListboxBullDivergence.IsAlive)
                    {
                        _listboxthreadBullDivergenceactive = false;
                        ThreadListboxBullDivergence.Abort();
                        ThreadListboxBullDivergence = null;
                    }
                }
            }

            catch (Exception ex)
            {
                Log.WriteLog(ex);
            }
        }


        private void FrmScrapping_Load(object sender, EventArgs e)
        {
            
        }


        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            FrmSaveState savestate = new FrmSaveState(this);
            savestate.Show();
        }

        private void buttonLoadState_Click(object sender, EventArgs e)
        {
            FrmLoadState loadstate = new FrmLoadState(this);
            loadstate.Show();
        }

        private void FrmScrapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainthreadactive = false;
            _listboxthreadBearDivergenceactive = false;
            _listboxthreadBullDivergenceactive = false;
            Reinit();

            Dispose();
        }


        private void labelSelling_Click(object sender, EventArgs e)
        {
        }

        private void buttonDesSound_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1SoundAlert, false, checkBoxT2SoundAlert, false, checkBoxT3SoundAlert, false,
                                   checkBoxT4SoundAlert, false, checkBoxT5SoundAlert, false, checkBoxT6SoundAlert,
                                   false, checkBoxT7SoundAlert, false, checkBoxT8SoundAlert, false, checkBoxT9SoundAlert,
                                   false, checkBoxT10SoundAlert, false);
        }

        private void buttonActSound_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1SoundAlert, true, checkBoxT2SoundAlert, true, checkBoxT3SoundAlert, true,
                                   checkBoxT4SoundAlert, true, checkBoxT5SoundAlert, true, checkBoxT6SoundAlert,
                                   true, checkBoxT7SoundAlert, true, checkBoxT8SoundAlert, true, checkBoxT9SoundAlert,
                                   true, checkBoxT10SoundAlert, true);
        }

        private void buttonDesactEmail_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1EmailAlert, false, checkBoxT2EmailAlert, false, checkBoxT3EmailAlert, false,
                                   checkBoxT4EmailAlert, false, checkBoxT5EmailAlert, false, checkBoxT6EmailAlert,
                                   false, checkBoxT7EmailAlert, false, checkBoxT8EmailAlert, false, checkBoxT9EmailAlert,
                                   false, checkBoxT10EmailAlert, false);
        }

        private void buttonActEmail_Click(object sender, EventArgs e)
        {
            _pres.ManageCheckBoxes(checkBoxT1EmailAlert, true, checkBoxT2EmailAlert, true, checkBoxT3EmailAlert, true,
                                   checkBoxT4EmailAlert, true, checkBoxT5EmailAlert, true, checkBoxT6EmailAlert,
                                   true, checkBoxT7EmailAlert, true, checkBoxT8EmailAlert, true, checkBoxT9EmailAlert,
                                   true, checkBoxT10EmailAlert, true);
        }

        private void buttonOpenWsj_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://online.wsj.com/mdc/public/page/2_3022-mfgppl-moneyflow.html");
        }


        private void buttonCmChart1_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker1.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart2_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker2.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart3_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker3.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart4_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker4.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart5_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker5.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart6_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker6.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart7_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker7.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart8_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker8.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart9_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker9.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }

        private void buttonCmChart10_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.chartmill.com/stockcharts.php?ticker=" + textBoxTicker10.Text +
                                 @"&i1=49&ip1=&width=1200EL&months=12&timeframe=DAILY&i2=44&ip2=&i3=45&ip3=&type=CANDLES&nt=&filters=&tab=0&v=9&s=5&p=0");
        }


        private void buttonVChart1_Click(object sender, EventArgs e)
        {
            //http://www.shortanalytics.com/getshortchart.php?tsymbol=kpti
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker1.Text);
        }

        private void buttonVChart2_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker2.Text);
        }

        private void buttonVChart3_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker3.Text);
        }

        private void buttonVChart4_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker4.Text);
        }

        private void buttonVChart5_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker5.Text);
        }

        private void buttonVChart6_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker6.Text);
        }

        private void buttonVChart7_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker7.Text);
        }

        private void buttonVChart8_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker8.Text);
        }

        private void buttonVChart9_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker9.Text);
        }

        private void buttonVChart10_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://www.shortanalytics.com/getshortchart.php?tsymbol=" + textBoxTicker10.Text);
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            string result = FileHelper.SaveListBoxItems(listBoxBearDivergence, "Bear divergence Alert",
                                                        " Bear divergence stocks data saved");
            if (result != null)
            {
                MessageBox.Show(result);
            }

            string result2 = FileHelper.SaveListBoxItems(listBoxDivergence, "Bull divergence Alert",
                                                         " Bull divergence stocks data saved");
            if (result2 != null)
            {
                MessageBox.Show(result2);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
        }

        private void labelT1STicker_Click(object sender, EventArgs e)
        {
            //http://quotes.wsj.com/XON?mod=DNH_S_cq
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT1STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }


        private void labelT2STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT2STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT3STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT3STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT4STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT4STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT5STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT5STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT6STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT6STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT7STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT7STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT8STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT8STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT9STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT9STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT10STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT10STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT11STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT11STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT12STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT12STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT13STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT13STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT14STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT14STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT15STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT15STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT16STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT16STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT17STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT17STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT18STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT18STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT19STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT19STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT20STicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT20STicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT1BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT1BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT2BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT2BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT3BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT3BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT4BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT4BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT5BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT5BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT6BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT6BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT7BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT7BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT8BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT8BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT9BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT9BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT10BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT10BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT11BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT11BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT12BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT12BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT13BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT13BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT14BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT14BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT15BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT15BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT16BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT16BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT17BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT17BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT18BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT18BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT19BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT19BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void labelT20BTicker_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + labelT20BTicker.Text.Split(' ')[1] + @"?mod=DNH_S_cq");
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            toolTipAvafinBlocks.SetToolTip(panel1, "Click on label to open wsj ticker page");
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            toolTipAvafinBlocks.SetToolTip(panel2, "Click on label to open wsj ticker page");
        }


        private void buttonFlowChart1_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker1.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart2_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker2.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart3_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker3.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart4_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker4.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart5_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker5.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart6_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker6.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart7_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker7.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart8_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker8.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart9_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker9.Text + @"?mod=DNH_S_cq");
        }

        private void buttonFlowChart10_Click(object sender, EventArgs e)
        {
            Webpages.OpenWebpage(@"http://quotes.wsj.com/" + textBoxTicker10.Text + @"?mod=DNH_S_cq");
        }



        private void buttonBullDivergences_Click(object sender, EventArgs e)
        {
            listBoxDivergence.Items.Clear();
        }

        private void buttonBearDivergences_Click(object sender, EventArgs e)
        {
            listBoxBearDivergence.Items.Clear();
        }

        private void checkBoxTwitter_CheckedChanged(object sender, EventArgs e)
        {
            Tweet = checkBoxTwitter.Checked;
        }

        private void checkBoxEmail_CheckedChanged(object sender, EventArgs e)
        {
            Email = checkBoxEmail.Checked;
        }
    }
}