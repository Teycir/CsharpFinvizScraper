#region

using System.Collections.Generic;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.View
{
    public partial class FrmInsiderTransactions : Form
    {
        private const string QueryIndustBuys =
            @" select industry, sum(lastinsiderpurchasevalue)  as insiderpurchasevalue from finviz.findata where lastinsiderpurchasepriceisrecent='yes' group by industry order by insiderpurchasevalue desc ;  ";

        private const string QueryIndustSales =
            @" select industry, sum(lastinsidersalevalue)  as insidersalevalue from finviz.findata where lastinsidersalepriceisrecent='yes' group by industry order by insidersalevalue desc ;  ";

        private const string QuerySectorBuys =
            @" select sector, sum(lastinsiderpurchasevalue)  as insiderpurchasevalue from finviz.findata where lastinsiderpurchasepriceisrecent='yes' group by sector order by insiderpurchasevalue desc ;  ";

        private const string QuerySectorSales =
            @" select sector, sum(lastinsidersalevalue)  as insidersalevalue from finviz.findata where lastinsidersalepriceisrecent='yes' group by sector order by insidersalevalue desc ;  ";



        private const string QueryIndustryPurSaleRatio =
           @"select industry, round(sum(lastinsiderpurchasevalue) /  sum(lastinsidersalevalue),2) as insiderevalue from finviz.findata 
        where lastinsiderpurchasepriceisrecent='yes' and lastinsidersalepriceisrecent='yes' group by industry order by insiderevalue desc ;";


        private const string QuerySectorPurSaleRatio =
            @"select sector, round(sum(lastinsiderpurchasevalue) /  sum(lastinsidersalevalue),2) as insiderevalue from finviz.findata 
        where lastinsiderpurchasepriceisrecent='yes' and lastinsidersalepriceisrecent='yes' group by sector order by insiderevalue desc ;";


        private const string QueryBiggestBuys =
            @"select ticker, lastinsiderpurchasevalue, industry, sector from finviz.findata where lastinsiderpurchasepriceisrecent='yes'   order by lastinsiderpurchasevalue desc limit 20;";


        private const string QueryBiggestSales =
         @"select ticker, lastinsidersalevalue, industry, sector from finviz.findata where lastinsidersalepriceisrecent='yes'   order by lastinsidersalevalue desc limit 20;";
        
        private readonly string _connectionstring;

        public FrmInsiderTransactions()
        {
            InitializeComponent();
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


            GetInsidersData(QueryIndustBuys, "industry", "insiderpurchasevalue", textBoxBuysIndust);
            GetInsidersData(QueryIndustSales, "industry", "insidersalevalue", textBoxSalesIndust);
            GetInsidersData(QuerySectorBuys, "sector", "insiderpurchasevalue", textBoxBuysSector);
            GetInsidersData(QuerySectorSales, "sector", "insidersalevalue", textBoxSalesSector);
            GetInsidersData(QueryIndustryPurSaleRatio, "industry", "insiderevalue", textBoxBuysSalesIndust);
            GetInsidersData(QuerySectorPurSaleRatio, "sector", "insiderevalue", textBoxBuySalesSector);
            GetInsidersData(QueryBiggestBuys, "ticker", "lastinsiderpurchasevalue", "industry", "sector",textBoxBiggestStockBuys);
            GetInsidersData(QueryBiggestSales, "ticker", "lastinsidersalevalue", "industry", "sector", textBoxBiggestStockSales);
            
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


        private void GetInsidersData(string query, string field1, string field2, string field3, string field4, TextBox textBox)
        {
            List<string> values;
            DbConnect.GetValue(query, field1, field2,field3,field4, _connectionstring, out values);
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