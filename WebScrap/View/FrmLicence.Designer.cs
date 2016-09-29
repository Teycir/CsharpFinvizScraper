namespace WebScrap.View
{
    partial class FrmLicence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLicence));
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.labelLicence = new System.Windows.Forms.Label();
            this.buttonValidateLicence = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(41, 35);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(205, 20);
            this.textBoxKeyword.TabIndex = 0;
            // 
            // labelLicence
            // 
            this.labelLicence.AutoSize = true;
            this.labelLicence.Location = new System.Drawing.Point(79, 15);
            this.labelLicence.Name = "labelLicence";
            this.labelLicence.Size = new System.Drawing.Size(135, 13);
            this.labelLicence.TabIndex = 1;
            this.labelLicence.Text = "Enter activation key below:";
            // 
            // buttonValidateLicence
            // 
            this.buttonValidateLicence.Location = new System.Drawing.Point(111, 61);
            this.buttonValidateLicence.Name = "buttonValidateLicence";
            this.buttonValidateLicence.Size = new System.Drawing.Size(75, 23);
            this.buttonValidateLicence.TabIndex = 2;
            this.buttonValidateLicence.Text = "Validate";
            this.buttonValidateLicence.UseVisualStyleBackColor = true;
            this.buttonValidateLicence.Click += new System.EventHandler(this.buttonValidateLicence_Click);
            // 
            // FrmLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 93);
            this.Controls.Add(this.buttonValidateLicence);
            this.Controls.Add(this.labelLicence);
            this.Controls.Add(this.textBoxKeyword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLicence";
            this.Text = "Insiders tracker: licence";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label labelLicence;
        private System.Windows.Forms.Button buttonValidateLicence;
    }
}