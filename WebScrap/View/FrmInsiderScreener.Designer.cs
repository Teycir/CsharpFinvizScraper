namespace WebScrap.View
{
    partial class FrmInsiderScreener
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsiderScreener));
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonStopUpdate = new System.Windows.Forms.Button();
            this.buttonDeleteData = new System.Windows.Forms.Button();
            this.labelUpdateStatus = new System.Windows.Forms.Label();
            this.labelUpdateStatusContent = new System.Windows.Forms.Label();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.labelCurDate = new System.Windows.Forms.Label();
            this.labelCurDateTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(113, 14);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update data";
            this.toolTipInfo.SetToolTip(this.buttonUpdate, "Update Database from finviz");
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonStopUpdate
            // 
            this.buttonStopUpdate.Enabled = false;
            this.buttonStopUpdate.Location = new System.Drawing.Point(205, 14);
            this.buttonStopUpdate.Name = "buttonStopUpdate";
            this.buttonStopUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonStopUpdate.TabIndex = 1;
            this.buttonStopUpdate.Text = "Stop Update";
            this.toolTipInfo.SetToolTip(this.buttonStopUpdate, "ancel update process");
            this.buttonStopUpdate.UseVisualStyleBackColor = true;
            this.buttonStopUpdate.Click += new System.EventHandler(this.buttonStopUpdate_Click);
            // 
            // buttonDeleteData
            // 
            this.buttonDeleteData.Location = new System.Drawing.Point(12, 15);
            this.buttonDeleteData.Name = "buttonDeleteData";
            this.buttonDeleteData.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteData.TabIndex = 3;
            this.buttonDeleteData.Text = "Delete data";
            this.toolTipInfo.SetToolTip(this.buttonDeleteData, "Clear database");
            this.buttonDeleteData.UseVisualStyleBackColor = true;
            this.buttonDeleteData.Click += new System.EventHandler(this.buttonDeleteData_Click);
            // 
            // labelUpdateStatus
            // 
            this.labelUpdateStatus.AutoSize = true;
            this.labelUpdateStatus.Location = new System.Drawing.Point(296, 19);
            this.labelUpdateStatus.Name = "labelUpdateStatus";
            this.labelUpdateStatus.Size = new System.Drawing.Size(67, 13);
            this.labelUpdateStatus.TabIndex = 4;
            this.labelUpdateStatus.Text = "Data status :";
            // 
            // labelUpdateStatusContent
            // 
            this.labelUpdateStatusContent.AutoSize = true;
            this.labelUpdateStatusContent.ForeColor = System.Drawing.Color.Red;
            this.labelUpdateStatusContent.Location = new System.Drawing.Point(369, 19);
            this.labelUpdateStatusContent.Name = "labelUpdateStatusContent";
            this.labelUpdateStatusContent.Size = new System.Drawing.Size(0, 13);
            this.labelUpdateStatusContent.TabIndex = 5;
            // 
            // labelCurDate
            // 
            this.labelCurDate.AutoSize = true;
            this.labelCurDate.Location = new System.Drawing.Point(521, 19);
            this.labelCurDate.Name = "labelCurDate";
            this.labelCurDate.Size = new System.Drawing.Size(68, 13);
            this.labelCurDate.TabIndex = 15;
            this.labelCurDate.Text = "Current date:";
            // 
            // labelCurDateTxt
            // 
            this.labelCurDateTxt.AutoSize = true;
            this.labelCurDateTxt.ForeColor = System.Drawing.Color.Red;
            this.labelCurDateTxt.Location = new System.Drawing.Point(595, 19);
            this.labelCurDateTxt.Name = "labelCurDateTxt";
            this.labelCurDateTxt.Size = new System.Drawing.Size(0, 13);
            this.labelCurDateTxt.TabIndex = 16;
            // 
            // FrmInsiderScreener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(759, 70);
            this.Controls.Add(this.labelCurDateTxt);
            this.Controls.Add(this.labelCurDate);
            this.Controls.Add(this.labelUpdateStatusContent);
            this.Controls.Add(this.labelUpdateStatus);
            this.Controls.Add(this.buttonDeleteData);
            this.Controls.Add(this.buttonStopUpdate);
            this.Controls.Add(this.buttonUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInsiderScreener";
            this.Text = "Insiders tracker: insider screener";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScreener_FormClosed);
            this.Load += new System.EventHandler(this.FrmScreener_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonStopUpdate;
        private System.Windows.Forms.Button buttonDeleteData;
        private System.Windows.Forms.Label labelUpdateStatus;
        private System.Windows.Forms.Label labelUpdateStatusContent;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.Label labelCurDate;
        private System.Windows.Forms.Label labelCurDateTxt;

    }
}