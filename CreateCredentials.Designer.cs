namespace coIT.Lexoffice.GdiExport
{
    partial class CreateCredentials
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            tbxLexofficeKey = new TextBox();
            label3 = new Label();
            tbxClockodoToken = new TextBox();
            label2 = new Label();
            tbxClockodoEmail = new TextBox();
            btnCreateConfig = new Button();
            gbxDateien = new GroupBox();
            btnMitarbeiter = new Button();
            tbxMitarbeiter = new TextBox();
            label6 = new Label();
            btnUmsatzkonten = new Button();
            tbxUmsatzkonten = new TextBox();
            label5 = new Label();
            btnKundenstamm = new Button();
            tbxKundenstamm = new TextBox();
            label4 = new Label();
            dlgKundenstamm = new OpenFileDialog();
            dlgUmsatzkonten = new OpenFileDialog();
            dlgMitarbeiter = new OpenFileDialog();
            groupBox1.SuspendLayout();
            gbxDateien.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbxLexofficeKey);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbxClockodoToken);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxClockodoEmail);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(374, 140);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Zugangsdaten Eingeben";
            // 
            // label1
            // 
            label1.Location = new Point(6, 101);
            label1.Name = "label1";
            label1.Size = new Size(115, 23);
            label1.TabIndex = 8;
            label1.Text = "Lexoffice Key:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbxLexofficeKey
            // 
            tbxLexofficeKey.Location = new Point(127, 102);
            tbxLexofficeKey.Name = "tbxLexofficeKey";
            tbxLexofficeKey.Size = new Size(224, 23);
            tbxLexofficeKey.TabIndex = 7;
            // 
            // label3
            // 
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(115, 23);
            label3.TabIndex = 5;
            label3.Text = "Clockodo Token:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbxClockodoToken
            // 
            tbxClockodoToken.Location = new Point(127, 64);
            tbxClockodoToken.Name = "tbxClockodoToken";
            tbxClockodoToken.Size = new Size(224, 23);
            tbxClockodoToken.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new Point(6, 22);
            label2.Name = "label2";
            label2.Size = new Size(115, 23);
            label2.TabIndex = 3;
            label2.Text = "Clockodo E-Mail:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbxClockodoEmail
            // 
            tbxClockodoEmail.Location = new Point(127, 23);
            tbxClockodoEmail.Name = "tbxClockodoEmail";
            tbxClockodoEmail.Size = new Size(224, 23);
            tbxClockodoEmail.TabIndex = 2;
            // 
            // btnCreateConfig
            // 
            btnCreateConfig.Location = new Point(268, 279);
            btnCreateConfig.Name = "btnCreateConfig";
            btnCreateConfig.Size = new Size(118, 29);
            btnCreateConfig.TabIndex = 6;
            btnCreateConfig.Text = "Anlegen";
            btnCreateConfig.UseVisualStyleBackColor = true;
            btnCreateConfig.Click += btnCreateConfig_Click;
            // 
            // gbxDateien
            // 
            gbxDateien.Controls.Add(btnMitarbeiter);
            gbxDateien.Controls.Add(tbxMitarbeiter);
            gbxDateien.Controls.Add(label6);
            gbxDateien.Controls.Add(btnUmsatzkonten);
            gbxDateien.Controls.Add(tbxUmsatzkonten);
            gbxDateien.Controls.Add(label5);
            gbxDateien.Controls.Add(btnKundenstamm);
            gbxDateien.Controls.Add(tbxKundenstamm);
            gbxDateien.Controls.Add(label4);
            gbxDateien.Location = new Point(12, 158);
            gbxDateien.Name = "gbxDateien";
            gbxDateien.Size = new Size(374, 115);
            gbxDateien.TabIndex = 10;
            gbxDateien.TabStop = false;
            gbxDateien.Text = "Datengrundlagen Konfigurieren";
            // 
            // btnMitarbeiter
            // 
            btnMitarbeiter.Location = new Point(288, 87);
            btnMitarbeiter.Name = "btnMitarbeiter";
            btnMitarbeiter.Size = new Size(75, 23);
            btnMitarbeiter.TabIndex = 8;
            btnMitarbeiter.Text = "Auswählen";
            btnMitarbeiter.UseVisualStyleBackColor = true;
            btnMitarbeiter.Click += btnMitarbeiter_Click;
            // 
            // tbxMitarbeiter
            // 
            tbxMitarbeiter.Location = new Point(93, 87);
            tbxMitarbeiter.Name = "tbxMitarbeiter";
            tbxMitarbeiter.ReadOnly = true;
            tbxMitarbeiter.Size = new Size(189, 23);
            tbxMitarbeiter.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 90);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 6;
            label6.Text = "Mitarbeiter";
            // 
            // btnUmsatzkonten
            // 
            btnUmsatzkonten.Location = new Point(288, 56);
            btnUmsatzkonten.Name = "btnUmsatzkonten";
            btnUmsatzkonten.Size = new Size(75, 23);
            btnUmsatzkonten.TabIndex = 5;
            btnUmsatzkonten.Text = "Auswählen";
            btnUmsatzkonten.UseVisualStyleBackColor = true;
            btnUmsatzkonten.Click += btnUmsatzkonten_Click;
            // 
            // tbxUmsatzkonten
            // 
            tbxUmsatzkonten.Location = new Point(93, 56);
            tbxUmsatzkonten.Name = "tbxUmsatzkonten";
            tbxUmsatzkonten.ReadOnly = true;
            tbxUmsatzkonten.Size = new Size(189, 23);
            tbxUmsatzkonten.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 59);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 3;
            label5.Text = "Umsatzkonten";
            // 
            // btnKundenstamm
            // 
            btnKundenstamm.Location = new Point(288, 25);
            btnKundenstamm.Name = "btnKundenstamm";
            btnKundenstamm.Size = new Size(75, 23);
            btnKundenstamm.TabIndex = 2;
            btnKundenstamm.Text = "Auswählen";
            btnKundenstamm.UseVisualStyleBackColor = true;
            btnKundenstamm.Click += btnKundenstamm_Click;
            // 
            // tbxKundenstamm
            // 
            tbxKundenstamm.Location = new Point(93, 25);
            tbxKundenstamm.Name = "tbxKundenstamm";
            tbxKundenstamm.ReadOnly = true;
            tbxKundenstamm.Size = new Size(189, 23);
            tbxKundenstamm.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 28);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 0;
            label4.Text = "Kundestamm";
            // 
            // dlgKundenstamm
            // 
            dlgKundenstamm.Filter = "Json files (*.json)|*.json";
            // 
            // dlgUmsatzkonten
            // 
            dlgUmsatzkonten.Filter = "Json files (*.json)|*.json";
            // 
            // dlgMitarbeiter
            // 
            dlgMitarbeiter.Filter = "Json files (*.json)|*.json";
            // 
            // CreateCredentials
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 320);
            Controls.Add(gbxDateien);
            Controls.Add(groupBox1);
            Controls.Add(btnCreateConfig);
            Name = "CreateCredentials";
            Text = "CreateCredentials";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbxDateien.ResumeLayout(false);
            gbxDateien.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCreateConfig;
        private Label label3;
        private TextBox tbxClockodoToken;
        private Label label2;
        private TextBox tbxClockodoEmail;
        private Label label1;
        private TextBox tbxLexofficeKey;
        private GroupBox gbxDateien;
        private OpenFileDialog dlgKundenstamm;
        private OpenFileDialog dlgUmsatzkonten;
        private Button btnUmsatzkonten;
        private TextBox tbxUmsatzkonten;
        private Label label5;
        private Button btnKundenstamm;
        private TextBox tbxKundenstamm;
        private Label label4;
        private Button btnMitarbeiter;
        private TextBox tbxMitarbeiter;
        private Label label6;
        private OpenFileDialog dlgMitarbeiter;
    }
}
