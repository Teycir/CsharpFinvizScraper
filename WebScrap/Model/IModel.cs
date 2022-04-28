#region

using System.Collections.Generic;

#endregion

namespace WebScrap.Model
{
    internal interface IModel
    {
        bool CompareData(string value, string alertvalue, string sound, bool activesoundalert);
        bool CompareData(string value, string value1);

        Dictionary<string, string> GetFinvizData(string ticker);
        List<string> GetFinvizTickers(string url);
        void InsertFinvizData();
        void DeleteFinvizData();
        string GetUrl(string query, string displayMember, string connectionstring, string filter);
    }
}