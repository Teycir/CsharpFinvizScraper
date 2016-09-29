namespace WebScrap.View
{
    partial class FrmContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContact));
            this.labelContact = new System.Windows.Forms.Label();
            this.linkLabelEmail = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRegistred = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelContact
            // 
            this.labelContact.AutoSize = true;
            this.labelContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContact.Location = new System.Drawing.Point(36, 17);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(298, 15);
            this.labelContact.TabIndex = 0;
            this.labelContact.Text = "Insiders tracker made by Tayssir Ben Soltane in 2015.";
            // 
            // linkLabelEmail
            // 
            this.linkLabelEmail.AutoSize = true;
            this.linkLabelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelEmail.Location = new System.Drawing.Point(26, 95);
            this.linkLabelEmail.Name = "linkLabelEmail";
            this.linkLabelEmail.Size = new System.Drawing.Size(133, 20);
            this.linkLabelEmail.TabIndex = 1;
            this.linkLabelEmail.TabStop = true;
            this.linkLabelEmail.Text = "teycir@gmail.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TeyciTek product © ; reselling or distributing is strictly forbidden.";
            // 
            // labelRegistred
            // 
            this.labelRegistred.AutoSize = true;
            this.labelRegistred.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegistred.Location = new System.Drawing.Point(117, 63);
            this.labelRegistred.Name = "labelRegistred";
            this.labelRegistred.Size = new System.Drawing.Size(129, 18);
            this.labelRegistred.TabIndex = 3;
            this.labelRegistred.Text = "Registred product.";
            // 
            // FrmContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 127);
            this.Controls.Add(this.labelRegistred);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabelEmail);
            this.Controls.Add(this.labelContact);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insiders tracker: contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.LinkLabel linkLabelEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRegistred;
    }
}