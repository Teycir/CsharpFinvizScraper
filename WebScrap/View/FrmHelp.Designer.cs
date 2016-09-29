namespace WebScrap.View
{
    partial class FrmHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHelp));
            this.labelHelp = new System.Windows.Forms.Label();
            this.labelHelp1 = new System.Windows.Forms.Label();
            this.linkLabelWsj = new System.Windows.Forms.LinkLabel();
            this.linkLabelFinviz = new System.Windows.Forms.LinkLabel();
            this.linkLabelOpenInsider = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelInstall = new System.Windows.Forms.LinkLabel();
            this.linkLabelInvesting = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(61, 74);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(249, 13);
            this.labelHelp.TabIndex = 0;
            this.labelHelp.Text = "Monitors stocks $ flows and screens insider trades. ";
            // 
            // labelHelp1
            // 
            this.labelHelp1.AutoSize = true;
            this.labelHelp1.Location = new System.Drawing.Point(61, 97);
            this.labelHelp1.Name = "labelHelp1";
            this.labelHelp1.Size = new System.Drawing.Size(235, 13);
            this.labelHelp1.TabIndex = 1;
            this.labelHelp1.Text = "Data sources from publicly available free info on:";
            // 
            // linkLabelWsj
            // 
            this.linkLabelWsj.AutoSize = true;
            this.linkLabelWsj.Location = new System.Drawing.Point(119, 134);
            this.linkLabelWsj.Name = "linkLabelWsj";
            this.linkLabelWsj.Size = new System.Drawing.Size(112, 13);
            this.linkLabelWsj.TabIndex = 6;
            this.linkLabelWsj.TabStop = true;
            this.linkLabelWsj.Text = "http://online.wsj.com/";
            this.linkLabelWsj.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWsj_LinkClicked);
            // 
            // linkLabelFinviz
            // 
            this.linkLabelFinviz.AutoSize = true;
            this.linkLabelFinviz.Location = new System.Drawing.Point(119, 161);
            this.linkLabelFinviz.Name = "linkLabelFinviz";
            this.linkLabelFinviz.Size = new System.Drawing.Size(90, 13);
            this.linkLabelFinviz.TabIndex = 7;
            this.linkLabelFinviz.TabStop = true;
            this.linkLabelFinviz.Text = "http://finviz.com/";
            this.linkLabelFinviz.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFinviz_LinkClicked);
            // 
            // linkLabelOpenInsider
            // 
            this.linkLabelOpenInsider.AutoSize = true;
            this.linkLabelOpenInsider.Location = new System.Drawing.Point(119, 189);
            this.linkLabelOpenInsider.Name = "linkLabelOpenInsider";
            this.linkLabelOpenInsider.Size = new System.Drawing.Size(115, 13);
            this.linkLabelOpenInsider.TabIndex = 8;
            this.linkLabelOpenInsider.TabStop = true;
            this.linkLabelOpenInsider.Text = "http://openinsider.com";
            this.linkLabelOpenInsider.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenInsider_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Installation and utilisation:";
            // 
            // linkLabelInstall
            // 
            this.linkLabelInstall.AutoSize = true;
            this.linkLabelInstall.Location = new System.Drawing.Point(100, 38);
            this.linkLabelInstall.Name = "linkLabelInstall";
            this.linkLabelInstall.Size = new System.Drawing.Size(177, 13);
            this.linkLabelInstall.TabIndex = 10;
            this.linkLabelInstall.TabStop = true;
            this.linkLabelInstall.Text = "http://insiderstracker.blogspot.com/";
            this.linkLabelInstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInstall_LinkClicked);
            // 
            // linkLabelInvesting
            // 
            this.linkLabelInvesting.AutoSize = true;
            this.linkLabelInvesting.Location = new System.Drawing.Point(119, 218);
            this.linkLabelInvesting.Name = "linkLabelInvesting";
            this.linkLabelInvesting.Size = new System.Drawing.Size(135, 13);
            this.linkLabelInvesting.TabIndex = 11;
            this.linkLabelInvesting.TabStop = true;
            this.linkLabelInvesting.Text = "http://www.investing.com/";
            this.linkLabelInvesting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInvesting_LinkClicked);
            // 
            // FrmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 258);
            this.Controls.Add(this.linkLabelInvesting);
            this.Controls.Add(this.linkLabelInstall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabelOpenInsider);
            this.Controls.Add(this.linkLabelFinviz);
            this.Controls.Add(this.linkLabelWsj);
            this.Controls.Add(this.labelHelp1);
            this.Controls.Add(this.labelHelp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insiders tracker: help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label labelHelp1;
        private System.Windows.Forms.LinkLabel linkLabelWsj;
        private System.Windows.Forms.LinkLabel linkLabelFinviz;
        private System.Windows.Forms.LinkLabel linkLabelOpenInsider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelInstall;
        private System.Windows.Forms.LinkLabel linkLabelInvesting;

    }
}