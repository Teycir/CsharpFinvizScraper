#region

using System.Collections.Generic;
using Helpers;

#endregion

namespace WebScrap.Model
{
    public static class WebScrapLicence
    {
        public static bool LicenceFileValid()
        {
            List<string> dbData = XmlReadWrite.ReadXMLData("Licence", "//Insiderstracker//");

            if (dbData == null || dbData.Count != 1)
            {
                return false;
            }
            return true;
        }


        public static string[] GetLicence()
        {
            List<string> licencedata = XmlReadWrite.ReadXMLData("Licence", "//Insiderstracker//");

            if (licencedata == null || licencedata.Count != 1) return null;
            string datestart1 = licencedata[0];
            int encryptlength = datestart1.Length;
            int numberletters = RegexHelper.NumberOfletters(datestart1);

            if (encryptlength == 44 || numberletters > 0)
            {
                string plaintext = StringCipherHelper.Decrypt(datestart1, "Cirtey1979!");
                string[] getdata = plaintext.Split('*');
                return getdata;
            }
            return null;
        }
    }
}