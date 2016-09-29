namespace WebScrap.View
{
    partial class FrmAdministration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministration));
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelDb = new System.Windows.Forms.Label();
            this.textBoxDb = new System.Windows.Forms.TextBox();
            this.labelUid = new System.Windows.Forms.Label();
            this.textBoxUid = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonValidateDb = new System.Windows.Forms.Button();
            this.labelResultDb = new System.Windows.Forms.Label();
            this.panelDb = new System.Windows.Forms.Panel();
            this.labelDbCoordinates = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelFromPassword = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelEmailPort = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.LabelHost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelcKey = new System.Windows.Forms.Label();
            this.labelcSecret = new System.Windows.Forms.Label();
            this.labelTokenSecret = new System.Windows.Forms.Label();
            this.textBoxToEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEmailCoordinates = new System.Windows.Forms.Label();
            this.textBoxFromEmail = new System.Windows.Forms.TextBox();
            this.textBoxPortEmail = new System.Windows.Forms.TextBox();
            this.textBoxFromEmailPassword = new System.Windows.Forms.TextBox();
            this.textBoxHostEmail = new System.Windows.Forms.TextBox();
            this.labelResultEmail = new System.Windows.Forms.Label();
            this.buttonValidateEmail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTwitterMoneyFlow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxcKeyMoneyFlow = new System.Windows.Forms.TextBox();
            this.textBoxcSecretMoneyFlow = new System.Windows.Forms.TextBox();
            this.textBoxAccessTokenMoneyFlow = new System.Windows.Forms.TextBox();
            this.textBoxTokenSecretMoneyFlow = new System.Windows.Forms.TextBox();
            this.buttonValidateTwitterMoneyFlow = new System.Windows.Forms.Button();
            this.labelResultTwitterMoneyFlow = new System.Windows.Forms.Label();
            this.buttonValidateTwitterFutures = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxTwitterFutures = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxcKeyFutures = new System.Windows.Forms.TextBox();
            this.textBoxcSecretFutures = new System.Windows.Forms.TextBox();
            this.textBoxAccessTokenFutures = new System.Windows.Forms.TextBox();
            this.textBoxTokenSecretFutures = new System.Windows.Forms.TextBox();
            this.labelResultTwitterFutures = new System.Windows.Forms.Label();
            this.labelResultTwitterInsiders = new System.Windows.Forms.Label();
            this.buttonValidateTwitterInsiders = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxTwitterInsiders = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxcKeyInsiders = new System.Windows.Forms.TextBox();
            this.textBoxcSecretInsiders = new System.Windows.Forms.TextBox();
            this.textBoxAccessTokenInsiders = new System.Windows.Forms.TextBox();
            this.textBoxTokenSecretInsiders = new System.Windows.Forms.TextBox();
            this.panelDb.SuspendLayout();
            this.panelEmail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(80, 53);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(100, 20);
            this.textBoxServer.TabIndex = 0;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(16, 56);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "Server";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(16, 99);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(80, 96);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxPort.TabIndex = 2;
            // 
            // labelDb
            // 
            this.labelDb.AutoSize = true;
            this.labelDb.Location = new System.Drawing.Point(16, 142);
            this.labelDb.Name = "labelDb";
            this.labelDb.Size = new System.Drawing.Size(53, 13);
            this.labelDb.TabIndex = 5;
            this.labelDb.Text = "Database";
            // 
            // textBoxDb
            // 
            this.textBoxDb.Location = new System.Drawing.Point(80, 139);
            this.textBoxDb.Name = "textBoxDb";
            this.textBoxDb.Size = new System.Drawing.Size(100, 20);
            this.textBoxDb.TabIndex = 4;
            // 
            // labelUid
            // 
            this.labelUid.AutoSize = true;
            this.labelUid.Location = new System.Drawing.Point(16, 185);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(23, 13);
            this.labelUid.TabIndex = 7;
            this.labelUid.Text = "Uid";
            // 
            // textBoxUid
            // 
            this.textBoxUid.Location = new System.Drawing.Point(80, 182);
            this.textBoxUid.Name = "textBoxUid";
            this.textBoxUid.Size = new System.Drawing.Size(100, 20);
            this.textBoxUid.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(16, 228);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(80, 225);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 8;
            // 
            // buttonValidateDb
            // 
            this.buttonValidateDb.Location = new System.Drawing.Point(69, 332);
            this.buttonValidateDb.Name = "buttonValidateDb";
            this.buttonValidateDb.Size = new System.Drawing.Size(100, 23);
            this.buttonValidateDb.TabIndex = 10;
            this.buttonValidateDb.Text = "Validate Db";
            this.buttonValidateDb.UseVisualStyleBackColor = true;
            this.buttonValidateDb.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // labelResultDb
            // 
            this.labelResultDb.AutoSize = true;
            this.labelResultDb.Location = new System.Drawing.Point(101, 296);
            this.labelResultDb.Name = "labelResultDb";
            this.labelResultDb.Size = new System.Drawing.Size(0, 13);
            this.labelResultDb.TabIndex = 11;
            // 
            // panelDb
            // 
            this.panelDb.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelDb.Controls.Add(this.labelDbCoordinates);
            this.panelDb.Controls.Add(this.labelDb);
            this.panelDb.Controls.Add(this.textBoxServer);
            this.panelDb.Controls.Add(this.labelServer);
            this.panelDb.Controls.Add(this.labelPassword);
            this.panelDb.Controls.Add(this.textBoxPort);
            this.panelDb.Controls.Add(this.textBoxPassword);
            this.panelDb.Controls.Add(this.labelPort);
            this.panelDb.Controls.Add(this.labelUid);
            this.panelDb.Controls.Add(this.textBoxDb);
            this.panelDb.Controls.Add(this.textBoxUid);
            this.panelDb.Location = new System.Drawing.Point(12, 12);
            this.panelDb.Name = "panelDb";
            this.panelDb.Size = new System.Drawing.Size(229, 268);
            this.panelDb.TabIndex = 12;
            // 
            // labelDbCoordinates
            // 
            this.labelDbCoordinates.AutoSize = true;
            this.labelDbCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDbCoordinates.Location = new System.Drawing.Point(31, 14);
            this.labelDbCoordinates.Name = "labelDbCoordinates";
            this.labelDbCoordinates.Size = new System.Drawing.Size(166, 20);
            this.labelDbCoordinates.TabIndex = 10;
            this.labelDbCoordinates.Text = "Database coordinates";
            // 
            // labelFromPassword
            // 
            this.labelFromPassword.AutoSize = true;
            this.labelFromPassword.Location = new System.Drawing.Point(16, 142);
            this.labelFromPassword.Name = "labelFromPassword";
            this.labelFromPassword.Size = new System.Drawing.Size(79, 13);
            this.labelFromPassword.TabIndex = 5;
            this.labelFromPassword.Text = "From Password";
            this.toolTip1.SetToolTip(this.labelFromPassword, "Type here the password of the sending email adress");
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(16, 56);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(58, 13);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "From Email";
            this.toolTip1.SetToolTip(this.labelFrom, "Type Email adress of the sender of the email");
            // 
            // labelEmailPort
            // 
            this.labelEmailPort.AutoSize = true;
            this.labelEmailPort.Location = new System.Drawing.Point(16, 228);
            this.labelEmailPort.Name = "labelEmailPort";
            this.labelEmailPort.Size = new System.Drawing.Size(26, 13);
            this.labelEmailPort.TabIndex = 9;
            this.labelEmailPort.Text = "Port";
            this.toolTip1.SetToolTip(this.labelEmailPort, "Port number of sending Email adress");
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(16, 99);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(48, 13);
            this.labelTo.TabIndex = 3;
            this.labelTo.Text = "To Email";
            this.toolTip1.SetToolTip(this.labelTo, "Type the email adress of receiver\'s Email");
            // 
            // LabelHost
            // 
            this.LabelHost.AutoSize = true;
            this.LabelHost.Location = new System.Drawing.Point(16, 185);
            this.LabelHost.Name = "LabelHost";
            this.LabelHost.Size = new System.Drawing.Size(29, 13);
            this.LabelHost.TabIndex = 7;
            this.LabelHost.Text = "Host";
            this.toolTip1.SetToolTip(this.LabelHost, "Host of the sending Email");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Access Token";
            this.toolTip1.SetToolTip(this.label2, "Type here the password of the sending email adress");
            // 
            // labelcKey
            // 
            this.labelcKey.AutoSize = true;
            this.labelcKey.Location = new System.Drawing.Point(16, 56);
            this.labelcKey.Name = "labelcKey";
            this.labelcKey.Size = new System.Drawing.Size(31, 13);
            this.labelcKey.TabIndex = 1;
            this.labelcKey.Text = "cKey";
            this.toolTip1.SetToolTip(this.labelcKey, "Type Email adress of the sender of the email");
            // 
            // labelcSecret
            // 
            this.labelcSecret.AutoSize = true;
            this.labelcSecret.Location = new System.Drawing.Point(16, 99);
            this.labelcSecret.Name = "labelcSecret";
            this.labelcSecret.Size = new System.Drawing.Size(44, 13);
            this.labelcSecret.TabIndex = 3;
            this.labelcSecret.Text = "cSecret";
            this.toolTip1.SetToolTip(this.labelcSecret, "Type the email adress of receiver\'s Email");
            // 
            // labelTokenSecret
            // 
            this.labelTokenSecret.AutoSize = true;
            this.labelTokenSecret.Location = new System.Drawing.Point(2, 185);
            this.labelTokenSecret.Name = "labelTokenSecret";
            this.labelTokenSecret.Size = new System.Drawing.Size(72, 13);
            this.labelTokenSecret.TabIndex = 7;
            this.labelTokenSecret.Text = "Token Secret";
            this.toolTip1.SetToolTip(this.labelTokenSecret, "Host of the sending Email");
            // 
            // textBoxToEmail
            // 
            this.textBoxToEmail.Location = new System.Drawing.Point(80, 92);
            this.textBoxToEmail.Name = "textBoxToEmail";
            this.textBoxToEmail.Size = new System.Drawing.Size(131, 20);
            this.textBoxToEmail.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxToEmail, "For multiple e-mail separate with comma \',\' ");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "File name";
            this.toolTip1.SetToolTip(this.label4, "Host of the sending Email");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "File name";
            this.toolTip1.SetToolTip(this.label6, "Host of the sending Email");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Access Token";
            this.toolTip1.SetToolTip(this.label8, "Type here the password of the sending email adress");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "cKey";
            this.toolTip1.SetToolTip(this.label9, "Type Email adress of the sender of the email");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "cSecret";
            this.toolTip1.SetToolTip(this.label10, "Type the email adress of receiver\'s Email");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Token Secret";
            this.toolTip1.SetToolTip(this.label11, "Host of the sending Email");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "File name";
            this.toolTip1.SetToolTip(this.label13, "Host of the sending Email");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Access Token";
            this.toolTip1.SetToolTip(this.label15, "Type here the password of the sending email adress");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "cKey";
            this.toolTip1.SetToolTip(this.label16, "Type Email adress of the sender of the email");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "cSecret";
            this.toolTip1.SetToolTip(this.label17, "Type the email adress of receiver\'s Email");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 185);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Token Secret";
            this.toolTip1.SetToolTip(this.label18, "Host of the sending Email");
            // 
            // panelEmail
            // 
            this.panelEmail.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelEmail.Controls.Add(this.label3);
            this.panelEmail.Controls.Add(this.labelEmailCoordinates);
            this.panelEmail.Controls.Add(this.labelFromPassword);
            this.panelEmail.Controls.Add(this.textBoxFromEmail);
            this.panelEmail.Controls.Add(this.labelFrom);
            this.panelEmail.Controls.Add(this.labelEmailPort);
            this.panelEmail.Controls.Add(this.textBoxToEmail);
            this.panelEmail.Controls.Add(this.textBoxPortEmail);
            this.panelEmail.Controls.Add(this.labelTo);
            this.panelEmail.Controls.Add(this.LabelHost);
            this.panelEmail.Controls.Add(this.textBoxFromEmailPassword);
            this.panelEmail.Controls.Add(this.textBoxHostEmail);
            this.panelEmail.Location = new System.Drawing.Point(272, 12);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(229, 268);
            this.panelEmail.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 9);
            this.label3.TabIndex = 11;
            this.label3.Text = "Use comma \',\' as separator";
            // 
            // labelEmailCoordinates
            // 
            this.labelEmailCoordinates.AutoSize = true;
            this.labelEmailCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailCoordinates.Location = new System.Drawing.Point(31, 14);
            this.labelEmailCoordinates.Name = "labelEmailCoordinates";
            this.labelEmailCoordinates.Size = new System.Drawing.Size(135, 20);
            this.labelEmailCoordinates.TabIndex = 10;
            this.labelEmailCoordinates.Text = "Email coordinates";
            // 
            // textBoxFromEmail
            // 
            this.textBoxFromEmail.Location = new System.Drawing.Point(80, 56);
            this.textBoxFromEmail.Name = "textBoxFromEmail";
            this.textBoxFromEmail.Size = new System.Drawing.Size(131, 20);
            this.textBoxFromEmail.TabIndex = 0;
            // 
            // textBoxPortEmail
            // 
            this.textBoxPortEmail.Location = new System.Drawing.Point(111, 225);
            this.textBoxPortEmail.Name = "textBoxPortEmail";
            this.textBoxPortEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxPortEmail.TabIndex = 8;
            // 
            // textBoxFromEmailPassword
            // 
            this.textBoxFromEmailPassword.Location = new System.Drawing.Point(111, 139);
            this.textBoxFromEmailPassword.Name = "textBoxFromEmailPassword";
            this.textBoxFromEmailPassword.PasswordChar = '*';
            this.textBoxFromEmailPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxFromEmailPassword.TabIndex = 4;
            // 
            // textBoxHostEmail
            // 
            this.textBoxHostEmail.Location = new System.Drawing.Point(111, 182);
            this.textBoxHostEmail.Name = "textBoxHostEmail";
            this.textBoxHostEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostEmail.TabIndex = 6;
            // 
            // labelResultEmail
            // 
            this.labelResultEmail.AutoSize = true;
            this.labelResultEmail.Location = new System.Drawing.Point(339, 296);
            this.labelResultEmail.Name = "labelResultEmail";
            this.labelResultEmail.Size = new System.Drawing.Size(0, 13);
            this.labelResultEmail.TabIndex = 17;
            // 
            // buttonValidateEmail
            // 
            this.buttonValidateEmail.Location = new System.Drawing.Point(307, 332);
            this.buttonValidateEmail.Name = "buttonValidateEmail";
            this.buttonValidateEmail.Size = new System.Drawing.Size(100, 23);
            this.buttonValidateEmail.TabIndex = 16;
            this.buttonValidateEmail.Text = "Validate Email";
            this.buttonValidateEmail.UseVisualStyleBackColor = true;
            this.buttonValidateEmail.Click += new System.EventHandler(this.buttonValidateEmail_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxTwitterMoneyFlow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxcKeyMoneyFlow);
            this.panel1.Controls.Add(this.labelcKey);
            this.panel1.Controls.Add(this.textBoxcSecretMoneyFlow);
            this.panel1.Controls.Add(this.labelcSecret);
            this.panel1.Controls.Add(this.labelTokenSecret);
            this.panel1.Controls.Add(this.textBoxAccessTokenMoneyFlow);
            this.panel1.Controls.Add(this.textBoxTokenSecretMoneyFlow);
            this.panel1.Location = new System.Drawing.Point(536, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 268);
            this.panel1.TabIndex = 18;
            // 
            // textBoxTwitterMoneyFlow
            // 
            this.textBoxTwitterMoneyFlow.Location = new System.Drawing.Point(81, 222);
            this.textBoxTwitterMoneyFlow.Name = "textBoxTwitterMoneyFlow";
            this.textBoxTwitterMoneyFlow.ReadOnly = true;
            this.textBoxTwitterMoneyFlow.Size = new System.Drawing.Size(131, 20);
            this.textBoxTwitterMoneyFlow.TabIndex = 11;
            this.textBoxTwitterMoneyFlow.Text = "TwitterMoneyFlow";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Twitter coordinates";
            // 
            // textBoxcKeyMoneyFlow
            // 
            this.textBoxcKeyMoneyFlow.Location = new System.Drawing.Point(80, 56);
            this.textBoxcKeyMoneyFlow.Name = "textBoxcKeyMoneyFlow";
            this.textBoxcKeyMoneyFlow.Size = new System.Drawing.Size(131, 20);
            this.textBoxcKeyMoneyFlow.TabIndex = 0;
            // 
            // textBoxcSecretMoneyFlow
            // 
            this.textBoxcSecretMoneyFlow.Location = new System.Drawing.Point(80, 92);
            this.textBoxcSecretMoneyFlow.Name = "textBoxcSecretMoneyFlow";
            this.textBoxcSecretMoneyFlow.Size = new System.Drawing.Size(131, 20);
            this.textBoxcSecretMoneyFlow.TabIndex = 2;
            // 
            // textBoxAccessTokenMoneyFlow
            // 
            this.textBoxAccessTokenMoneyFlow.Location = new System.Drawing.Point(80, 139);
            this.textBoxAccessTokenMoneyFlow.Name = "textBoxAccessTokenMoneyFlow";
            this.textBoxAccessTokenMoneyFlow.Size = new System.Drawing.Size(131, 20);
            this.textBoxAccessTokenMoneyFlow.TabIndex = 4;
            // 
            // textBoxTokenSecretMoneyFlow
            // 
            this.textBoxTokenSecretMoneyFlow.Location = new System.Drawing.Point(80, 182);
            this.textBoxTokenSecretMoneyFlow.Name = "textBoxTokenSecretMoneyFlow";
            this.textBoxTokenSecretMoneyFlow.PasswordChar = '*';
            this.textBoxTokenSecretMoneyFlow.Size = new System.Drawing.Size(131, 20);
            this.textBoxTokenSecretMoneyFlow.TabIndex = 6;
            // 
            // buttonValidateTwitterMoneyFlow
            // 
            this.buttonValidateTwitterMoneyFlow.Location = new System.Drawing.Point(602, 332);
            this.buttonValidateTwitterMoneyFlow.Name = "buttonValidateTwitterMoneyFlow";
            this.buttonValidateTwitterMoneyFlow.Size = new System.Drawing.Size(100, 23);
            this.buttonValidateTwitterMoneyFlow.TabIndex = 19;
            this.buttonValidateTwitterMoneyFlow.Text = "Validate Twitter";
            this.buttonValidateTwitterMoneyFlow.UseVisualStyleBackColor = true;
            this.buttonValidateTwitterMoneyFlow.Click += new System.EventHandler(this.buttonValidateTwitter_Click);
            // 
            // labelResultTwitterMoneyFlow
            // 
            this.labelResultTwitterMoneyFlow.AutoSize = true;
            this.labelResultTwitterMoneyFlow.Location = new System.Drawing.Point(634, 296);
            this.labelResultTwitterMoneyFlow.Name = "labelResultTwitterMoneyFlow";
            this.labelResultTwitterMoneyFlow.Size = new System.Drawing.Size(0, 13);
            this.labelResultTwitterMoneyFlow.TabIndex = 20;
            // 
            // buttonValidateTwitterFutures
            // 
            this.buttonValidateTwitterFutures.Location = new System.Drawing.Point(860, 332);
            this.buttonValidateTwitterFutures.Name = "buttonValidateTwitterFutures";
            this.buttonValidateTwitterFutures.Size = new System.Drawing.Size(100, 23);
            this.buttonValidateTwitterFutures.TabIndex = 22;
            this.buttonValidateTwitterFutures.Text = "Validate Twitter";
            this.buttonValidateTwitterFutures.UseVisualStyleBackColor = true;
            this.buttonValidateTwitterFutures.Click += new System.EventHandler(this.buttonValidateTwitterFutures_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxTwitterFutures);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxcKeyFutures);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxcSecretFutures);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBoxAccessTokenFutures);
            this.panel2.Controls.Add(this.textBoxTokenSecretFutures);
            this.panel2.Location = new System.Drawing.Point(798, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 268);
            this.panel2.TabIndex = 21;
            // 
            // textBoxTwitterFutures
            // 
            this.textBoxTwitterFutures.Location = new System.Drawing.Point(81, 222);
            this.textBoxTwitterFutures.Name = "textBoxTwitterFutures";
            this.textBoxTwitterFutures.ReadOnly = true;
            this.textBoxTwitterFutures.Size = new System.Drawing.Size(131, 20);
            this.textBoxTwitterFutures.TabIndex = 11;
            this.textBoxTwitterFutures.Text = "TwitterFutures";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Twitter coordinates";
            // 
            // textBoxcKeyFutures
            // 
            this.textBoxcKeyFutures.Location = new System.Drawing.Point(80, 56);
            this.textBoxcKeyFutures.Name = "textBoxcKeyFutures";
            this.textBoxcKeyFutures.Size = new System.Drawing.Size(131, 20);
            this.textBoxcKeyFutures.TabIndex = 0;
            // 
            // textBoxcSecretFutures
            // 
            this.textBoxcSecretFutures.Location = new System.Drawing.Point(80, 92);
            this.textBoxcSecretFutures.Name = "textBoxcSecretFutures";
            this.textBoxcSecretFutures.Size = new System.Drawing.Size(131, 20);
            this.textBoxcSecretFutures.TabIndex = 2;
            // 
            // textBoxAccessTokenFutures
            // 
            this.textBoxAccessTokenFutures.Location = new System.Drawing.Point(80, 139);
            this.textBoxAccessTokenFutures.Name = "textBoxAccessTokenFutures";
            this.textBoxAccessTokenFutures.Size = new System.Drawing.Size(131, 20);
            this.textBoxAccessTokenFutures.TabIndex = 4;
            // 
            // textBoxTokenSecretFutures
            // 
            this.textBoxTokenSecretFutures.Location = new System.Drawing.Point(80, 182);
            this.textBoxTokenSecretFutures.Name = "textBoxTokenSecretFutures";
            this.textBoxTokenSecretFutures.PasswordChar = '*';
            this.textBoxTokenSecretFutures.Size = new System.Drawing.Size(131, 20);
            this.textBoxTokenSecretFutures.TabIndex = 6;
            // 
            // labelResultTwitterFutures
            // 
            this.labelResultTwitterFutures.AutoSize = true;
            this.labelResultTwitterFutures.Location = new System.Drawing.Point(873, 301);
            this.labelResultTwitterFutures.Name = "labelResultTwitterFutures";
            this.labelResultTwitterFutures.Size = new System.Drawing.Size(0, 13);
            this.labelResultTwitterFutures.TabIndex = 23;
            // 
            // labelResultTwitterInsiders
            // 
            this.labelResultTwitterInsiders.AutoSize = true;
            this.labelResultTwitterInsiders.Location = new System.Drawing.Point(1139, 301);
            this.labelResultTwitterInsiders.Name = "labelResultTwitterInsiders";
            this.labelResultTwitterInsiders.Size = new System.Drawing.Size(0, 13);
            this.labelResultTwitterInsiders.TabIndex = 26;
            // 
            // buttonValidateTwitterInsiders
            // 
            this.buttonValidateTwitterInsiders.Location = new System.Drawing.Point(1126, 332);
            this.buttonValidateTwitterInsiders.Name = "buttonValidateTwitterInsiders";
            this.buttonValidateTwitterInsiders.Size = new System.Drawing.Size(100, 23);
            this.buttonValidateTwitterInsiders.TabIndex = 25;
            this.buttonValidateTwitterInsiders.Text = "Validate Twitter";
            this.buttonValidateTwitterInsiders.UseVisualStyleBackColor = true;
            this.buttonValidateTwitterInsiders.Click += new System.EventHandler(this.buttonValidateTwitterInsiders_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.textBoxTwitterInsiders);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.textBoxcKeyInsiders);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.textBoxcSecretInsiders);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.textBoxAccessTokenInsiders);
            this.panel3.Controls.Add(this.textBoxTokenSecretInsiders);
            this.panel3.Location = new System.Drawing.Point(1064, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(229, 268);
            this.panel3.TabIndex = 24;
            // 
            // textBoxTwitterInsiders
            // 
            this.textBoxTwitterInsiders.Location = new System.Drawing.Point(81, 222);
            this.textBoxTwitterInsiders.Name = "textBoxTwitterInsiders";
            this.textBoxTwitterInsiders.ReadOnly = true;
            this.textBoxTwitterInsiders.Size = new System.Drawing.Size(131, 20);
            this.textBoxTwitterInsiders.TabIndex = 11;
            this.textBoxTwitterInsiders.Text = "TwitterInsiders";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 20);
            this.label14.TabIndex = 10;
            this.label14.Text = "Twitter coordinates";
            // 
            // textBoxcKeyInsiders
            // 
            this.textBoxcKeyInsiders.Location = new System.Drawing.Point(80, 56);
            this.textBoxcKeyInsiders.Name = "textBoxcKeyInsiders";
            this.textBoxcKeyInsiders.Size = new System.Drawing.Size(131, 20);
            this.textBoxcKeyInsiders.TabIndex = 0;
            // 
            // textBoxcSecretInsiders
            // 
            this.textBoxcSecretInsiders.Location = new System.Drawing.Point(80, 92);
            this.textBoxcSecretInsiders.Name = "textBoxcSecretInsiders";
            this.textBoxcSecretInsiders.Size = new System.Drawing.Size(131, 20);
            this.textBoxcSecretInsiders.TabIndex = 2;
            // 
            // textBoxAccessTokenInsiders
            // 
            this.textBoxAccessTokenInsiders.Location = new System.Drawing.Point(80, 139);
            this.textBoxAccessTokenInsiders.Name = "textBoxAccessTokenInsiders";
            this.textBoxAccessTokenInsiders.Size = new System.Drawing.Size(131, 20);
            this.textBoxAccessTokenInsiders.TabIndex = 4;
            // 
            // textBoxTokenSecretInsiders
            // 
            this.textBoxTokenSecretInsiders.Location = new System.Drawing.Point(80, 182);
            this.textBoxTokenSecretInsiders.Name = "textBoxTokenSecretInsiders";
            this.textBoxTokenSecretInsiders.PasswordChar = '*';
            this.textBoxTokenSecretInsiders.Size = new System.Drawing.Size(131, 20);
            this.textBoxTokenSecretInsiders.TabIndex = 6;
            // 
            // FrmAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1316, 366);
            this.Controls.Add(this.labelResultTwitterInsiders);
            this.Controls.Add(this.buttonValidateTwitterInsiders);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelResultTwitterFutures);
            this.Controls.Add(this.buttonValidateTwitterFutures);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelResultTwitterMoneyFlow);
            this.Controls.Add(this.buttonValidateTwitterMoneyFlow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelResultEmail);
            this.Controls.Add(this.buttonValidateEmail);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.panelDb);
            this.Controls.Add(this.labelResultDb);
            this.Controls.Add(this.buttonValidateDb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAdministration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administration";
            this.Load += new System.EventHandler(this.FrmAdministration_Load);
            this.panelDb.ResumeLayout(false);
            this.panelDb.PerformLayout();
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelDb;
        private System.Windows.Forms.TextBox textBoxDb;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.TextBox textBoxUid;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonValidateDb;
        private System.Windows.Forms.Label labelResultDb;
        private System.Windows.Forms.Panel panelDb;
        private System.Windows.Forms.Label labelDbCoordinates;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.Label labelEmailCoordinates;
        private System.Windows.Forms.Label labelFromPassword;
        private System.Windows.Forms.TextBox textBoxFromEmail;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelEmailPort;
        private System.Windows.Forms.TextBox textBoxToEmail;
        private System.Windows.Forms.TextBox textBoxPortEmail;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label LabelHost;
        private System.Windows.Forms.TextBox textBoxFromEmailPassword;
        private System.Windows.Forms.TextBox textBoxHostEmail;
        private System.Windows.Forms.Label labelResultEmail;
        private System.Windows.Forms.Button buttonValidateEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxcKeyMoneyFlow;
        private System.Windows.Forms.Label labelcKey;
        private System.Windows.Forms.TextBox textBoxcSecretMoneyFlow;
        private System.Windows.Forms.Label labelcSecret;
        private System.Windows.Forms.Label labelTokenSecret;
        private System.Windows.Forms.TextBox textBoxAccessTokenMoneyFlow;
        private System.Windows.Forms.TextBox textBoxTokenSecretMoneyFlow;
        private System.Windows.Forms.Button buttonValidateTwitterMoneyFlow;
        private System.Windows.Forms.Label labelResultTwitterMoneyFlow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTwitterMoneyFlow;
        private System.Windows.Forms.Button buttonValidateTwitterFutures;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTwitterFutures;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxcKeyFutures;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxcSecretFutures;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAccessTokenFutures;
        private System.Windows.Forms.TextBox textBoxTokenSecretFutures;
        private System.Windows.Forms.Label labelResultTwitterFutures;
        private System.Windows.Forms.Label labelResultTwitterInsiders;
        private System.Windows.Forms.Button buttonValidateTwitterInsiders;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxTwitterInsiders;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxcKeyInsiders;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxcSecretInsiders;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxAccessTokenInsiders;
        private System.Windows.Forms.TextBox textBoxTokenSecretInsiders;
    }
}