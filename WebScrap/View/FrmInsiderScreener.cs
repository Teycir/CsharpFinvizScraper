#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Helpers;
using WebScrap.Presenter;

#endregion

namespace WebScrap.View
{
    public partial class FrmInsiderScreener : Form, IViewScreener
    {
        private readonly PresMain _pres;

        public Thread ThreadMain;

        public FrmInsiderScreener(Thread threadMain)
        {
            ThreadMain = threadMain;
        }

        private string _connectionstring;
        private bool _obLiClick;
        private bool _obTpClick;
        private bool _osLiClick;
        private bool _osTpClick;

        public FrmInsiderScreener()
        {
            _pres = new PresMain(this);
            InitializeComponent();
            labelCurDateTxt.Text = DateTime.Now.ToShortDateString();
        }

        public bool ExceptionDb { get; set; }

        #region IViewScreener Members

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
        /// 	Views the label
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

        #endregion

        private void FrmScreener_FormClosed(object sender, FormClosedEventArgs e)
        {
            labelUpdateStatusContent.Text = null;
            if (ThreadMain != null)
            {
                ThreadMain.Abort();
                ThreadMain = null;
            }
        }

        private void buttonStopUpdate_Click(object sender, EventArgs e)
        {
            labelUpdateStatusContent.Text = null;
            buttonUpdate.Enabled = true;
            if (ThreadMain != null)
            {
                ThreadMain.Abort();
                ThreadMain = null;
            }
        }

        private void buttonDeleteData_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = true;
            _pres.DeleteFinvizData(labelUpdateStatusContent, "Data deleted");
        }

 
   


        private void FrmScreener_Load(object sender, EventArgs e)
        {
            List<string> dbData =
                XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");

  
            if (dbData != null)
            {
                string server = dbData[1];
                string database = dbData[2];


                _connectionstring = "Data Source = " + server + "; Initial Catalog = " + database + ";Integrated Security = True";

                DbConnect dbc = new DbConnect(server,database);
                bool isconnected=dbc.OpenConnection();
                if(isconnected)
                {
                    dbc.CloseConnection();
                }
                else
                {
                    MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                              "Database error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                                "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
         
        }



        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ThreadMain = new Thread(state => _pres.UpdateFinvizDb(labelUpdateStatusContent, "Data updated"));
            ThreadMain.IsBackground = true;
            ThreadMain.Start();
            buttonStopUpdate.Enabled = true;
            buttonUpdate.Enabled = false;
        }



    }
}