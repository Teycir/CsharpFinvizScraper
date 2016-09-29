#region

using System.Collections.Generic;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.View
{
    public partial class FrmTopInsiderTrades : Form
    {
        private const string QueryBiggestBuys =
            @"select ticker, lastinsiderpurchasevalue, industry, sector from finviz.findata where numrecentinsiderpurchases > 0    and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) order by lastinsiderpurchasevalue desc limit 20;";


        private const string QueryBiggestSales =
            @"select ticker, lastinsidersalevalue, industry, sector from finviz.findata where numrecentinsidersales > 0    and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) order by lastinsidersalevalue desc limit 20;";


        private const string QueryTopNumSales =
            @"select ticker, numrecentinsidersales, industry, sector from finviz.findata where numrecentinsidersales > 0   and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) order by numrecentinsidersales desc limit 20;";


        private const string QueryTopNumPurchases =
            @"select ticker, numrecentinsiderpurchases, industry, sector from finviz.findata where numrecentinsiderpurchases > 0   and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) order by numrecentinsiderpurchases desc limit 20;";

        private const string QueryTopNumDSales =
            @"select ticker, numrecentdifferentinsidersales, industry, sector from finviz.findata where numrecentinsidersales > 0   and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) order by numrecentdifferentinsidersales desc limit 20;";


        private const string QueryTopNumDPurchases =
            @"select ticker, numrecentdifferentinsiderpurchases, industry, sector from finviz.findata where numrecentinsiderpurchases > 0  and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) order by numrecentdifferentinsiderpurchases desc limit 20;";


        private string _connectionstring;

        private void ConnectDb()
        {
            List<string> dbData =
              XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");
            //string server ="127.0.0.1";
            //string port = "3306";
            //string database = "avafinScraper";
            //string uid = "root";
            if (dbData != null)
            {
                string server = dbData[1];
                string port = dbData[2];
                string db = dbData[3];
                string uid = dbData[4];
                string password = dbData[5];
                string crypt = StringCipherHelper.Decrypt(password, "Cirtey1979!");
                _connectionstring =
                    "SERVER=" + server + ";" + "Port=" + port + ";" + "DATABASE=" + db + ";" + "UID=" + uid +
                    ";" + "PASSWORD=" + crypt + ";";
                DbConnect dbc = new DbConnect(server, port, db, uid, crypt);
                bool isconnected = dbc.OpenConnection();
                if (!isconnected)
                {

                    MessageBox.Show("DB error, go to administration and record correct database coordinates.",
                              "Database error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("DB error, go to administration and record database coordinates.", "Database error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }


         
        }

        public FrmTopInsiderTrades()
        {
            InitializeComponent();
            ConnectDb();
            GetInsidersData(QueryBiggestBuys, "ticker", "last" +
                                                        "" +
                                                        "insiderpurchasevalue", "industry", "sector",
                         txtTopInsiderBuys);
            GetInsidersData(QueryBiggestSales, "ticker", "lastinsidersalevalue", "industry", "sector",
                            txtTopInsiderSales);

            GetInsidersData(QueryTopNumSales, "ticker", "numrecentinsidersales", "industry", "sector",
                            txtTopNumSales);
            GetInsidersData(QueryTopNumPurchases, "ticker", "numrecentinsiderpurchases", "industry", "sector",
                            txtTopNumPurchases);

            GetInsidersData(QueryTopNumDSales, "ticker", "numrecentdifferentinsidersales", "industry", "sector",
                            txtTopNumDSales);
            GetInsidersData(QueryTopNumDPurchases, "ticker", "numrecentdifferentinsiderpurchases", "industry", "sector",
                            txtTopNumDPurchases);
        }


        private void GetInsidersData(string query, string field1, string field2, string field3, string field4,
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