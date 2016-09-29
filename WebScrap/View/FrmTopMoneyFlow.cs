#region

using System.Collections.Generic;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.View
{
    public partial class FrmTopMoneyFlow : Form
    {
        private const string QueryTopUptickOfTheDay =
            @"select DATE_FORMAT(date, '%Y-%m-%d'),  ticker, uptickdowntick, industry, sector from finviz.wsjdata  where DATE(date) = CURDATE() order by uptickdowntick desc limit 10;";

        private const string QueryBottomUptickOfTheDay =
            @"select DATE_FORMAT(date, '%Y-%m-%d'),  ticker, uptickdowntick, industry, sector from finviz.wsjdata  where DATE(date) = CURDATE() order by uptickdowntick asc limit 10;";


        private readonly string _connectionstring;

        public FrmTopMoneyFlow()
        {
            InitializeComponent();

            try
            {
                List<string> dbData =
                    XmlReadWrite.ReadData("DbData");
                //string server ="127.0.0.1";
                //string port = "3306";
                //string database = "avafinScraper";
                //string uid = "root";


                string server = dbData[1];
                string port = dbData[2];
                string db = dbData[3];
                string uid = dbData[4];
                string password = dbData[5];
                _connectionstring =
                    "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" + db + ";" + "UID=" + uid +
                    ";" + "PASSWORD=" + password + ";";
            }
            catch
            {
                MessageBox.Show("Top money flow connection problem");
            }


            try
            {
                GetQueryData(QueryTopUptickOfTheDay, "ticker", "uptickdowntick", "industry", "sector",
                                textBoxTopUptickDay);

                GetQueryData(QueryBottomUptickOfTheDay, "ticker", "uptickdowntick", "industry", "sector",
                                textBoxBottomUptickDay);
            }
            catch
            {
                MessageBox.Show("Top money flow query problem");
            }
        }


        private void GetQueryData(string query, string field1, string field2, string field3, string field4,
                                     TextBox textBox)
        {
            List<string> values;
            DbConnect.GetValue(query, field1, field2, field3, field4, _connectionstring, out values);
            textBox.Clear();


            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBox.AppendText((i.ToString() + " - " + value + "\r\n"));
                i++;
            }
        }
    }
}