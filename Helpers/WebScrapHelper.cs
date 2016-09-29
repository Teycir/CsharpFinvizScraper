#region

using System;
using System.Collections.Generic;
using System.Xml.XPath;
using HtmlAgilityPack;

#endregion

namespace Helpers
{
    public class WebScrapHelper
    {
        /// <summary>
        /// 	Loads the HTML doc.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <param name="node"> The node. </param>
        /// <returns> </returns>
        public static HtmlNodeCollection LoadHtmlDoc(string url, string node)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return null;
                string urltrim = url.Trim();
                var webGet = new HtmlWeb();
                HtmlDocument document = null;
                try
                {
                    document = webGet.Load(urltrim);
                    if (document == null) return null;
                }
                catch
                {
                    if (document == null) return null;
                }

                var nodes = document.DocumentNode.SelectNodes(node);
                if (nodes == null)
                    return null;
                if (nodes.Count < 1)
                    return null;
                return nodes;
            }
            catch (Exception ex)
            {
                Log.WriteLog("LoadHtmlDoc error");
                Log.WriteLog(ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 	Gets the webscrap data.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <param name="xpath"> The xpath. </param>
        /// <returns> </returns>
        public static List<string> GetWebScrapData(string url, string xpath)
        {
            List<string> data = new List<string>();
            var nodestickratio = LoadHtmlDoc(url, xpath);
            if (nodestickratio == null || nodestickratio.Count < 1) return null;
            foreach (var node in nodestickratio)
                data.Add(node.InnerText);
            return data;
        }


        /// <summary>
        /// 	Gets the xpath navigator.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <returns> </returns>
        private static XPathNavigator GetXpathNavigator(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;
            string urltrim = url.Trim();
            var webGet = new HtmlWeb();
            HtmlDocument document = null;
            try
            {
                document = webGet.Load(urltrim);
                if (document == null) return null;
            }
            catch
            {
                if (document == null) return null;
            }

            XPathNavigator nav = document.CreateNavigator();
            return nav;
        }


        /// <summary>
        /// 	Gets the web scrap data.
        /// </summary>
        /// <param name="url"> The URL. </param>
        /// <param name="xpath"> The xpath. </param>
        /// <returns> </returns>
        public static List<string> GetWebScrapData(string url, List<string> xpath)
        {
            List<string> data = new List<string>();
            var navWsj = GetXpathNavigator(url);

            if (navWsj == null) return null;
            foreach (var path in xpath)
            {
                var selectSingleNodeUptick = navWsj.SelectSingleNode(path);
                if (selectSingleNodeUptick != null)
                {
                    string datum = selectSingleNodeUptick.Value;
                    data.Add(datum);
                }
            }

            return data;
        }
    }
}