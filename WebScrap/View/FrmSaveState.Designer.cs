namespace WebScrap.View
{
    partial class FrmSaveState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaveState));
            this.textBoxSaveState = new System.Windows.Forms.TextBox();
            this.labelNameSaveState = new System.Windows.Forms.Label();
            this.buttonSaveState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSaveState
            // 
            this.textBoxSaveState.Location = new System.Drawing.Point(41, 41);
            this.textBoxSaveState.Name = "textBoxSaveState";
            this.textBoxSaveState.Size = new System.Drawing.Size(216, 20);
            this.textBoxSaveState.TabIndex = 0;
            // 
            // labelNameSaveState
            // 
            this.labelNameSaveState.AutoSize = true;
            this.labelNameSaveState.Location = new System.Drawing.Point(41, 13);
            this.labelNameSaveState.Name = "labelNameSaveState";
            this.labelNameSaveState.Size = new System.Drawing.Size(129, 13);
            this.labelNameSaveState.TabIndex = 1;
            this.labelNameSaveState.Text = "Name of the state to save";
            // 
            // buttonSaveState
            // 
            this.buttonSaveState.Location = new System.Drawing.Point(115, 70);
            this.buttonSaveState.Name = "buttonSaveState";
            this.buttonSaveState.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveState.TabIndex = 2;
            this.buttonSaveState.Text = "Save group";
            this.buttonSaveState.UseVisualStyleBackColor = true;
            this.buttonSaveState.Click += new System.EventHandler(this.buttonSaveState_Click);
            // 
            // FrmSaveState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 105);
            this.Controls.Add(this.buttonSaveState);
            this.Controls.Add(this.labelNameSaveState);
            this.Controls.Add(this.textBoxSaveState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSaveState";
            this.Text = "Insiders tracker: save tickers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSaveState;
        private System.Windows.Forms.Label labelNameSaveState;
        private System.Windows.Forms.Button buttonSaveState;
    }
}