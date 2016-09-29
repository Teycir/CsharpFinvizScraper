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
        private readonly FrmMoneyFlow _frmMflow;

        public FrmLoadState()
        {
            InitializeComponent();
        }

        public FrmLoadState(FrmMoneyFlow frmMoneyFlow)
        {
            InitializeComponent();
            _frmMflow = frmMoneyFlow;
            PopulateComboBox();
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


        private void buttonLoadState_Click(object sender, EventArgs e)
        {
            if (comboBoxFiles.SelectedItem == null)
            {
                MessageBox.Show("Select a name for the state of tickers");
                return;
            }
            string selectedState = comboBoxFiles.SelectedItem.ToString();
            //ResetFrmMFlowTextBoxes();
            _frmMflow.GetTickersState(selectedState,
                                      _frmMflow.GetObjecttextBoxTicker1, _frmMflow.GetObjecttextBoxTicker2,
                                      _frmMflow.GetObjecttextBoxTicker3,
                                      _frmMflow.GetObjecttextBoxTicker4, _frmMflow.GetObjecttextBoxTicker5,
                                      _frmMflow.GetObjecttextBoxTicker6, _frmMflow.GetObjecttextBoxTicker7,
                                      _frmMflow.GetObjecttextBoxTicker8,
                                      _frmMflow.GetObjecttextBoxTicker9, _frmMflow.GetObjecttextBoxTicker10,
                                      _frmMflow.GetObjecttextBoxTicker1FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker2FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker3FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker4FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker5FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker6FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker7FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker8FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker9FlowAlert,
                                      _frmMflow.GetObjecttextBoxTicker10FlowAlert,
                                      _frmMflow.GetObjecttextBoxT1RAlert, _frmMflow.GetObjecttextBoxT2RAlert,
                                      _frmMflow.GetObjecttextBoxT3RAlert,
                                      _frmMflow.GetObjecttextBoxT4RAlert, _frmMflow.GetObjecttextBoxT5RAlert,
                                      _frmMflow.GetObjecttextBoxT6RAlert, _frmMflow.GetObjecttextBoxT7RAlert,
                                      _frmMflow.GetObjecttextBoxT8RAlert,
                                      _frmMflow.GetObjecttextBoxT9RAlert, _frmMflow.GetObjecttextBoxT10RAlert,
                                      _frmMflow.GetObjecttextBoxT1RAlertNeg, _frmMflow.GetObjecttextBoxT2RAlertNeg,
                                      _frmMflow.GetObjecttextBoxT3RAlertNeg,
                                      _frmMflow.GetObjecttextBoxT4RAlertNeg, _frmMflow.GetObjecttextBoxT5RAlertNeg,
                                      _frmMflow.GetObjecttextBoxT6RAlertNeg, _frmMflow.GetObjecttextBoxT7RAlertNeg,
                                      _frmMflow.GetObjecttextBoxT8RAlertNeg,
                                      _frmMflow.GetObjecttextBoxT9RAlertNeg, _frmMflow.GetObjecttextBoxT10RAlertNeg
                );


            Close();
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