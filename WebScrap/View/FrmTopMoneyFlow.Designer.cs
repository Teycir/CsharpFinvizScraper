namespace WebScrap.View
{
    partial class FrmTopMoneyFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTopMoneyFlow));
            this.labelTopUptickOfTheDay = new System.Windows.Forms.Label();
            this.labelBottoUptickOfTheDay = new System.Windows.Forms.Label();
            this.textBoxTopUptickDay = new System.Windows.Forms.TextBox();
            this.textBoxBottomUptickDay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTopUptickOfTheDay
            // 
            this.labelTopUptickOfTheDay.AutoSize = true;
            this.labelTopUptickOfTheDay.ForeColor = System.Drawing.Color.Green;
            this.labelTopUptickOfTheDay.Location = new System.Drawing.Point(22, 13);
            this.labelTopUptickOfTheDay.Name = "labelTopUptickOfTheDay";
            this.labelTopUptickOfTheDay.Size = new System.Drawing.Size(173, 13);
            this.labelTopUptickOfTheDay.TabIndex = 1;
            this.labelTopUptickOfTheDay.Text = "Top uptick/dowtick ratio of the day";
            // 
            // labelBottoUptickOfTheDay
            // 
            this.labelBottoUptickOfTheDay.AutoSize = true;
            this.labelBottoUptickOfTheDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBottoUptickOfTheDay.Location = new System.Drawing.Point(414, 13);
            this.labelBottoUptickOfTheDay.Name = "labelBottoUptickOfTheDay";
            this.labelBottoUptickOfTheDay.Size = new System.Drawing.Size(187, 13);
            this.labelBottoUptickOfTheDay.TabIndex = 3;
            this.labelBottoUptickOfTheDay.Text = "Bottom uptick/dowtick ratio of the day";
            // 
            // textBoxTopUptickDay
            // 
            this.textBoxTopUptickDay.Location = new System.Drawing.Point(25, 43);
            this.textBoxTopUptickDay.Multiline = true;
            this.textBoxTopUptickDay.Name = "textBoxTopUptickDay";
            this.textBoxTopUptickDay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTopUptickDay.Size = new System.Drawing.Size(325, 257);
            this.textBoxTopUptickDay.TabIndex = 4;
            // 
            // textBoxBottomUptickDay
            // 
            this.textBoxBottomUptickDay.Location = new System.Drawing.Point(417, 43);
            this.textBoxBottomUptickDay.Multiline = true;
            this.textBoxBottomUptickDay.Name = "textBoxBottomUptickDay";
            this.textBoxBottomUptickDay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBottomUptickDay.Size = new System.Drawing.Size(325, 257);
            this.textBoxBottomUptickDay.TabIndex = 5;
            // 
            // FrmTopMoneyFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 322);
            this.Controls.Add(this.textBoxBottomUptickDay);
            this.Controls.Add(this.textBoxTopUptickDay);
            this.Controls.Add(this.labelBottoUptickOfTheDay);
            this.Controls.Add(this.labelTopUptickOfTheDay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTopMoneyFlow";
            this.Text = "Top money flow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTopUptickOfTheDay;
        private System.Windows.Forms.Label labelBottoUptickOfTheDay;
        private System.Windows.Forms.TextBox textBoxTopUptickDay;
        private System.Windows.Forms.TextBox textBoxBottomUptickDay;

    }
}