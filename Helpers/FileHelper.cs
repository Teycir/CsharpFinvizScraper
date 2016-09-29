#region

using System;
using System.IO;
using System.Windows.Forms;

#endregion

namespace Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// 	Saves the list box items.
        /// </summary>
        /// <param name="listBox"> The list box. </param>
        /// <param name="filename"> The filename. </param>
        /// <param name="message"> The message. </param>
        /// <returns> </returns>
        public static string SaveListBoxItems(ListBox listBox, string filename, string message)
        {
            try
            {
                if (listBox.Items.Count == 0) return null;
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = filePath + "\\" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm") + "--" + filename + ".txt";
                StreamWriter saveFile = new StreamWriter(path);

                foreach (var item in listBox.Items)
                {
                    saveFile.WriteLine(item);
                }
                saveFile.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return message;
        }



        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <returns></returns>
        public static string GetRoot()
        {
            return Path.GetPathRoot(Environment.SystemDirectory);
        }



        //TextWriter tw = new StreamWriter(folderBrowserDialog3save.SelectedPath + "logfile1.txt");
        // // write a line of text to the file
        // tw.WriteLine(logfiletextbox.Text);
        // // close the stream
        // tw.Close();


        public static string SaveTextBox(TextBox txtBox, string filename, string message)
        {
            try
            {
                if (txtBox.Text == null) return null;
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = filePath + "\\" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm") + "--" + filename + ".txt";


                TextWriter tw = new StreamWriter(path);
                // write a line of text to the file
                tw.WriteLine(txtBox.Text);
                // close the stream
                tw.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return message;
        }


        /// <summary>
        /// 	Gets the directory files.
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <param name="extension"> The extension. </param>
        /// <returns> </returns>
        public static string[] GetDirectoryFiles(string path, string extension)

        {
            try
            {
                string[] files = Directory.GetFiles(path, "*." + extension, SearchOption.AllDirectories);
                return files;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 	Deletes the file.
        /// </summary>
        /// <param name="path"> The path. </param>
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message);
            }
        }
    }
}