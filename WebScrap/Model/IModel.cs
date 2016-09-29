#region

using System.Collections.Generic;

#endregion

namespace WebScrap.Model
{
    internal interface IModel
    {
        Dictionary<string, string> GetWsjData(string ticker);
        List<string> GetAvafinData(string url);
        List<string> GetFlowData(string url);

        bool CompareData(string value, string alertvalue, string sound, bool activesoundalert);
        bool CompareData(string value, string value1);

        List<string> GetWsjTickers(string url);
        List<string> GetWsjPricesBuy();
        List<string> GetWsjPricesSell();
        List<string> GetWsjFlows(string url);
        List<string> GetWsjFlowsRatio(string url);
        Dictionary<string, string> GetFinvizData(string ticker);
        List<string> GetFinvizTickers(string url);
        void InsertFinvizData();
        void DeleteFinvizData();
        string GetUrl(string query, string displayMember, string connectionstring, string filter);
        List<string> GetStocksData(string ticker, string upratio, string downratio);

        List<string> GetStocksDataAllLiquid(string ticker, string upratio, string downratio, string upratioExtreme,
                                            string downratioExtreme);

        bool PriceMoneyFlowDivergence(string uptickdowntick, string percentchange);
    
        void SendDivergenceAlert(bool sendmail, bool sendtweet, List<string> datumdiverg, double flowvalue);
    }
}