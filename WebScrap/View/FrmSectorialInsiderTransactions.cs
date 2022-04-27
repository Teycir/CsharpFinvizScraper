#region

using System.Collections.Generic;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.View
{
    public partial class FrmSectorialInsiderTransactions : Form
    {
        private const string QueryIndustBuys =
            @" select industry, sum(lastinsiderpurchasevalue)  as insiderpurchasevalue from finviz.findata where numrecentinsiderpurchases > 0 and trim(industry) <> 'Exchange Traded Fund'  and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)  group by industry order by insiderpurchasevalue desc ;  ";

        private const string QueryIndustSales =
            @" select industry, sum(lastinsidersalevalue)  as insidersalevalue from finviz.findata where numrecentinsidersales > 0 and trim(industry) <> 'Exchange Traded Fund'   and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1) group by industry order by insidersalevalue desc ;  ";

        private const string QuerySectorBuys =
            @" select sector, sum(lastinsiderpurchasevalue)  as insiderpurchasevalue from finviz.findata where numrecentinsiderpurchases > 0  and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)  group by sector order by insiderpurchasevalue desc ;  ";

        private const string QuerySectorSales =
            @" select sector, sum(lastinsidersalevalue)  as insidersalevalue from finviz.findata where numrecentinsidersales > 0   and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)  group by sector order by insidersalevalue desc ;  ";


        private const string QueryIndustryPurSaleRatio =
            @"select industry, round(sum(lastinsiderpurchasevalue) /  sum(lastinsidersalevalue),2) as insiderevalue from finviz.findata 
        where numrecentinsiderpurchases > 0 and numrecentinsidersales > 0 and trim(industry) <> 'Exchange Traded Fund'  and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)  group by industry order by insiderevalue desc ;";

        private const string QueryIndustryPurSaleRatioTotal =
            @"select 
        round(sum(lastinsiderpurchasevalue)/sum(lastinsidersalevalue),2)  as ratioBuySell from finviz.findata
        where  iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1);";


        private const string QuerySectorPurSaleRatio =
            @"select sector, round(sum(lastinsiderpurchasevalue) /  sum(lastinsidersalevalue),2) as insiderevalue from finviz.findata 
        where numrecentinsiderpurchases > 0 and numrecentinsidersales > 0   and iddownload = (select iddownload from  finviz.findata order by iddownload desc limit 1)  group by sector order by insiderevalue desc ;";


        private string _connectionstring;



        private void ConnectDb()
        {
            List<string> dbData =
              XmlReadWrite.ReadXMLData("DbData", "//Insiderstracker//");
            //string server ="127.0.0.1";
            //string database = "avafinScraper";
            //string uid = "root";
            if (dbData != null)
            {
                string server = dbData[1];
                string database = dbData[2];
                _connectionstring = "Data Source = " + server + "; Initial Catalog = " + database + ";Integrated Security = True";

                DbConnect dbc = new DbConnect(server, database);
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


        public FrmSectorialInsiderTransactions()
        {
            InitializeComponent();
            ConnectDb();


            GetInsidersData(QueryIndustBuys, "industry", "insiderpurchasevalue", textBoxBuysIndust);
            GetInsidersData(QueryIndustSales, "industry", "insidersalevalue", textBoxSalesIndust);
            GetInsidersData(QuerySectorBuys, "sector", "insiderpurchasevalue", textBoxBuysSector);
            GetInsidersData(QuerySectorSales, "sector", "insidersalevalue", textBoxSalesSector);


            GetInsidersData(QueryIndustryPurSaleRatio, "industry", "insiderevalue", textBoxBuysSalesIndust);

            GetSingleInsidersData(QueryIndustryPurSaleRatioTotal, "ratioBuySell", "ratioBuySell", textBoxTotalBuySell);

            GetInsidersData(QuerySectorPurSaleRatio, "sector", "insiderevalue", textBoxBuySalesSector);
        }


        private void GetInsidersData(string query, string category, string field, TextBox textBox)
        {
            List<string> values;
            DbConnect.GetValue(query, category, field, _connectionstring, out values);
            textBox.Clear();


            int i = 0;
            foreach (var value in values)
            {
                if (i > 0)
                    textBox.AppendText((i.ToString() + " - " + value + "\r\n"));
                i++;
            }
        }

        private void GetSingleInsidersData(string query, string category, string field, TextBox textBox)
        {
            List<string> values;
            DbConnect.GetSingleValue(query, category, field, _connectionstring, out values);
            if (values.Count > 1)
                textBox.Text = values[1];
        }
    }
}