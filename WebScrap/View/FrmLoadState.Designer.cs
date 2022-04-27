namespace WebScrap.View
{
    partial class FrmLoadState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoadState));
            this.comboBoxFiles = new System.Windows.Forms.ComboBox();
            this.buttonLoadState = new System.Windows.Forms.Button();
            this.labelAvailableStates = new System.Windows.Forms.Label();
            this.buttonDeleteState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxFiles
            // 
            this.comboBoxFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiles.FormattingEnabled = true;
            this.comboBoxFiles.Location = new System.Drawing.Point(12, 39);
            this.comboBoxFiles.Name = "comboBoxFiles";
            this.comboBoxFiles.Size = new System.Drawing.Size(319, 21);
            this.comboBoxFiles.TabIndex = 0;
            // 
           
            // 
            // labelAvailableStates
            // 
            this.labelAvailableStates.AutoSize = true;
            this.labelAvailableStates.Location = new System.Drawing.Point(107, 9);
            this.labelAvailableStates.Name = "labelAvailableStates";
            this.labelAvailableStates.Size = new System.Drawing.Size(140, 13);
            this.labelAvailableStates.TabIndex = 2;
            this.labelAvailableStates.Text = "Chose from available groups";
            // 
            // buttonDeleteState
            // 
            this.buttonDeleteState.Location = new System.Drawing.Point(231, 82);
            this.buttonDeleteState.Name = "buttonDeleteState";
            this.buttonDeleteState.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteState.TabIndex = 3;
            this.buttonDeleteState.Text = "Delete group";
            this.buttonDeleteState.UseVisualStyleBackColor = true;
            this.buttonDeleteState.Click += new System.EventHandler(this.buttonDeleteState_Click);
            // 
            // FrmLoadState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 127);
            this.Controls.Add(this.buttonDeleteState);
            this.Controls.Add(this.labelAvailableStates);
            this.Controls.Add(this.buttonLoadState);
            this.Controls.Add(this.comboBoxFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLoadState";
            this.Text = "Insiders tracker: tickers management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFiles;
        private System.Windows.Forms.Button buttonLoadState;
        private System.Windows.Forms.Label labelAvailableStates;
        private System.Windows.Forms.Button buttonDeleteState;
    }
}