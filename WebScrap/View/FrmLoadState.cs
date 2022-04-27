#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Helpers;

#endregion

namespace WebScrap.View
{
    public partial class FrmLoadState : Form
    {
      
        public FrmLoadState()
        {
            InitializeComponent();
        }


        private void PopulateComboBox()
        {
            
            List<string> files = new List<string>();
            Directory.CreateDirectory(FileHelper.GetRoot()+ "//InsidersTracker//tickers//");
            string path = FileHelper.GetRoot() + "//InsidersTracker//tickers//";

          
            
            string[] files1 = FileHelper.GetDirectoryFiles(path, "xml");
            if (files1!=null)
            {
                foreach (var file in files1)
                {
                    if (!files1.Any()) continue;

                    string[] pathArr = file.Split('\\');
                    string[] fileArr = pathArr.Last().Split('.');
                    string fileName = fileArr[0].Split('/').Last();
                    files.Add(fileName);
                    comboBoxFiles.Items.Add(fileName);
                }
            }

          
        }


        private void buttonDeleteState_Click(object sender, EventArgs e)
        {
            if (comboBoxFiles.SelectedItem == null)
            {
                MessageBox.Show("Select a name for the state of tickers");
                return;
            }
            string selectedState = comboBoxFiles.SelectedItem.ToString();
            string path = FileHelper.GetRoot() + "//InsidersTracker//tickers//" +
                          selectedState + ".xml";
          
            FileHelper.DeleteFile(path);
            if (!File.Exists(path))
            {
                MessageBox.Show("State deleted",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                    );
                Close();
            }
            else
            {
                MessageBox.Show("State not deleted", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}