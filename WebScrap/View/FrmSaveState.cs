#region

using System;
using System.Windows.Forms;

#endregion

namespace WebScrap.View
{
    public partial class FrmSaveState : Form
    {
        private readonly FrmMoneyFlow _frmMflow;

        public FrmSaveState()
        {
            InitializeComponent();
        }

        public FrmSaveState(FrmMoneyFlow mflow)
        {
            InitializeComponent();
            _frmMflow = mflow;
        }


        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSaveState.Text))
            {
                MessageBox.Show("Type a name for the state of tickers");
                return;
            }


            string result = _frmMflow.SetTickersState(
                textBoxSaveState.Text.Trim(), _frmMflow.GettextBoxTicker1, _frmMflow.GettextBoxTicker2,
                _frmMflow.GettextBoxTicker3,
                _frmMflow.GettextBoxTicker4, _frmMflow.GettextBoxTicker5,
                _frmMflow.GettextBoxTicker6, _frmMflow.GettextBoxTicker7, _frmMflow.GettextBoxTicker8,
                _frmMflow.GettextBoxTicker9, _frmMflow.GettextBoxTicker10,
                _frmMflow.GettextBoxTicker1FlowAlert,
                _frmMflow.GettextBoxTicker2FlowAlert, _frmMflow.GettextBoxTicker3FlowAlert,
                _frmMflow.GettextBoxTicker4FlowAlert, _frmMflow.GettextBoxTicker5FlowAlert,
                _frmMflow.GettextBoxTicker6FlowAlert,
                _frmMflow.GettextBoxTicker7FlowAlert, _frmMflow.GettextBoxTicker8FlowAlert,
                _frmMflow.GettextBoxTicker9FlowAlert, _frmMflow.GettextBoxTicker10FlowAlert,
                _frmMflow.GettextBoxT1RAlert, _frmMflow.GettextBoxT2RAlert, _frmMflow.GettextBoxT3RAlert,
                _frmMflow.GettextBoxT4RAlert, _frmMflow.GettextBoxT5RAlert,
                _frmMflow.GettextBoxT6RAlert, _frmMflow.GettextBoxT7RAlert, _frmMflow.GettextBoxT8RAlert,
                _frmMflow.GettextBoxT9RAlert, _frmMflow.GettextBoxT10RAlert,
                _frmMflow.GettextBoxT1RAlertNeg, _frmMflow.GettextBoxT2RAlertNeg, _frmMflow.GettextBoxT3RAlertNeg,
                _frmMflow.GettextBoxT4RAlertNeg, _frmMflow.GettextBoxT5RAlertNeg,
                _frmMflow.GettextBoxT6RAlertNeg, _frmMflow.GettextBoxT7RAlertNeg, _frmMflow.GettextBoxT8RAlertNeg,
                _frmMflow.GettextBoxT9RAlertNeg, _frmMflow.GettextBoxT10RAlertNeg
                );
            MessageBox.Show(result);

            Close();
        }
    }
}