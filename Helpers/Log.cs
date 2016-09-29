#region

using System;
using System.IO;
using System.Xml.Linq;

#endregion

namespace Helpers
{
    public class Log
    {
        //returns filename in format: YYYMMDD
        /// <summary>
        /// 	Gets the filename yyymmdd.
        /// </summary>
        /// <param name="suffix"> The suffix. </param>
        /// <param name="extension"> The extension. </param>
        /// <returns> </returns>
        public static string GetFilenameYyymmdd(string suffix, string extension)
        {
            return DateTime.Now.ToString("yyyy_MM_dd")
                   + suffix
                   + extension;
        }

        /// <summary>
        /// 	Makes the filename.
        /// </summary>
        /// <param name="signature"> The signature. </param>
        /// <param name="extension"> The extension. </param>
        /// <returns> </returns>
        private static string MakeFilename(string signature, string extension)
        {
            string path = Path.GetPathRoot(Environment.SystemDirectory);
            string filename = path + "WebScraperLOGS" + "\\"
                              + GetFilenameYyymmdd(signature, extension);
            FileInfo file = new FileInfo(filename);
            if (file.Directory != null) file.Directory.Create();
            return filename;
        }


        /// <summary>
        /// 	Writes the log.
        /// </summary>
        /// <param name="message"> The message. </param>
        public static void WriteLog(String message)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = MakeFilename("_LOG", ".txt");

                StreamWriter sw = new StreamWriter(filename, true);

                XElement xmlEntry = new XElement("logEntry",
                                                 new XElement("Date", DateTime.Now.ToString()),
                                                 new XElement("Message", message));
                //

                sw.WriteLine(xmlEntry);
                sw.Close();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 	Writes the data.
        /// </summary>
        /// <param name="server"> The server. </param>
        /// <param name="port"> The port. </param>
        /// <param name="database"> The database. </param>
        /// <param name="uid"> The uid. </param>
        /// <param name="password"> The password. </param>
        public static void WriteData(String server, string port, string database, string uid, string password)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = MakeFilename("_Data", ".xml");
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("DataEntry",
                                                 new XElement("Date", DateTime.Now.ToString()),
                                                 new XElement("server", server), new XElement("port", server),
                                                 new XElement("database", server), new XElement("uid", server),
                                                 new XElement("password", server));
                //
                sw.WriteLine(xmlEntry);
                sw.Close();
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// 	Writes the log.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        public static void WriteLog(Exception ex)
        {
            //just in case: we protect code with try.
            try
            {
                string filename = MakeFilename("_LOG", ".txt");
                StreamWriter sw = new StreamWriter(filename, true);
                XElement xmlEntry = new XElement("logEntry",
                                                 new XElement("Date", DateTime.Now.ToString()),
                                                 new XElement("Exception",
                                                              new XElement("Source", ex.Source),
                                                              new XElement("Message", ex.Message),
                                                              new XElement("Stack", ex.StackTrace)
                                                     ) //end exception
                    );
                //has inner exception?
                if (ex.InnerException != null)
                {
                    var xElement = xmlEntry.Element("Exception");
                    if (xElement != null)
                        xElement.Add(
                            new XElement("InnerException",
                                         new XElement("Source", ex.InnerException.Source),
                                         new XElement("Message", ex.InnerException.Message),
                                         new XElement("Stack", ex.InnerException.StackTrace))
                            );
                }
                sw.WriteLine(xmlEntry);
                sw.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}