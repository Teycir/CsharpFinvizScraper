#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

#endregion

namespace Helpers
{
    public class XmlReadWrite
    {
        /// <summary>
        /// 	Gets the filename.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="extension"> The extension. </param>
        /// <returns> </returns>
        public static string GetFilename(string name, string extension)
        {
            return name
                   + extension;
        }


        /// <summary>
        /// 	Reads the XML data.
        /// </summary>
        /// <param name="filename"> The filename. </param>
        /// <param name="path"> The path. </param>
        /// <returns> </returns>
        public static List<string> ReadXMLData(string filename, string path)
        {
            //just in case: we protect code with try.
            try
            {
                var data = new List<string>();

                Directory.CreateDirectory(FileHelper.GetRoot() +path);
                string filePath = FileHelper.GetRoot()  +path +
                                  GetFilename(filename, ".xml");

                if (!File.Exists(filePath))
                {
                    // Create a file to write to.

                    File.WriteAllText(filePath, "");
                }
                //System.IO.StreamReader sr = new System.IO.StreamReader(filename, true);
                var doc = new XmlDocument();
                doc.Load(filePath);
                if (doc.DocumentElement != null)
                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    {
                        //string text = node.InnerText; //or loop through its children as well
                        if (node.Attributes != null)
                        {
                            //data[0] = node.Attributes["server"].InnerText;
                            data.Add(node.InnerText);
                        }
                    }
                return data;
                //sr.Close();
                //return "Validation OK";
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex);
                return null;
                // return "Validation Error";
            }
        }
    }
}