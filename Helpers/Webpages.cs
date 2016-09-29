#region

using System;
using System.Diagnostics;

#endregion

namespace Helpers
{
    public class Webpages
    {
        public static void OpenWebpage(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}