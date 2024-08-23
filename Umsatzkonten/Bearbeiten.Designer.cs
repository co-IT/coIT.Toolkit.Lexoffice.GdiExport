namespace coIT.Lexoffice.GdiExport.Umsatzkonten
{
    partial class Bearbeiten
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
            this.ctrl_Kontoname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrl_Speichern = new System.Windows.Forms.Button();
            this.ctrl_Abbrechen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrl_Geschäftssparte = new System.Windows.Forms.TextBox();
            this.ctrl_SteuerlicherHinweis = new System.Windows.Forms.TextBox();
            this.nbx_Kontonummer = new System.Windows.Forms.NumericUpDown();
            this.cb_IstBeratung = new System.Windows.Forms.CheckBox();
            this.nbx_KalkulatorischesKonto = new System.Windows.Forms.NumericUpDown();
            this.nbx_Steuerrate = new System.Windows.Forms.NumericUpDown();
            this.nbx_Steuerschlüssel = new System.Windows.Forms.NumericUpDown();
            this.cb_IstAbrechenbar = new System.Windows.Forms.CheckBox();
            this.gb_Steuer = new System.Windows.Forms.GroupBox();
            this.gb_UmsatzkontoDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_Kontonummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_KalkulatorischesKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_Steuerrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_Steuerschlüssel)).BeginInit();
            this.gb_Steuer.SuspendLayout();
            this.gb_UmsatzkontoDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrl_Kontoname
            // 
            this.ctrl_Kontoname.Location = new System.Drawing.Point(158, 27);
            this.ctrl_Kontoname.Name = "ctrl_Kontoname";
            this.ctrl_Kontoname.Size = new System.Drawing.Size(305, 23);
            this.ctrl_Kontoname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kontoname";
            // 
            // ctrl_Speichern
            // 
            this.ctrl_Speichern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrl_Speichern.Location = new System.Drawing.Point(402, 463);
            this.ctrl_Speichern.Name = "ctrl_Speichern";
            this.ctrl_Speichern.Size = new System.Drawing.Size(104, 28);
            this.ctrl_Speichern.TabIndex = 2;
            this.ctrl_Speichern.Text = "Speichern";
            this.ctrl_Speichern.UseVisualStyleBackColor = true;
            this.ctrl_Speichern.Click += new System.EventHandler(this.ctrl_Speichern_Click);
            // 
            // ctrl_Abbrechen
            // 
            this.ctrl_Abbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrl_Abbrechen.Location = new System.Drawing.Point(279, 463);
            this.ctrl_Abbrechen.Name = "ctrl_Abbrechen";
            this.ctrl_Abbrechen.Size = new System.Drawing.Size(102, 28);
            this.ctrl_Abbrechen.TabIndex = 3;
            this.ctrl_Abbrechen.Text = "Abbrechen";
            this.ctrl_Abbrechen.UseVisualStyleBackColor = true;
            this.ctrl_Abbrechen.Click += new System.EventHandler(this.ctrl_Abbrechen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kontonummer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Geschäftssparte";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ist Beratung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Abrechenbar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Steuerlicher Hinweis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Steuerschlüssel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Steuerrate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Kalkulatorisches Konto";
            // 
            // ctrl_Geschäftssparte
            // 
            this.ctrl_Geschäftssparte.Location = new System.Drawing.Point(158, 105);
            this.ctrl_Geschäftssparte.Name = "ctrl_Geschäftssparte";
            this.ctrl_Geschäftssparte.Size = new System.Drawing.Size(305, 23);
            this.ctrl_Geschäftssparte.TabIndex = 13;
            // 
            // ctrl_SteuerlicherHinweis
            // 
            this.ctrl_SteuerlicherHinweis.Location = new System.Drawing.Point(155, 35);
            this.ctrl_SteuerlicherHinweis.Name = "ctrl_SteuerlicherHinweis";
            this.ctrl_SteuerlicherHinweis.Size = new System.Drawing.Size(305, 23);
            this.ctrl_SteuerlicherHinweis.TabIndex = 14;
            // 
            // nbx_Kontonummer
            // 
            this.nbx_Kontonummer.Location = new System.Drawing.Point(158, 66);
            this.nbx_Kontonummer.Maximum = new decimal(new int[] {
            200000000,
            0,
            0,
            0});
            this.nbx_Kontonummer.Name = "nbx_Kontonummer";
            this.nbx_Kontonummer.Size = new System.Drawing.Size(305, 23);
            this.nbx_Kontonummer.TabIndex = 20;
            // 
            // cb_IstBeratung
            // 
            this.cb_IstBeratung.AutoSize = true;
            this.cb_IstBeratung.Location = new System.Drawing.Point(158, 144);
            this.cb_IstBeratung.Name = "cb_IstBeratung";
            this.cb_IstBeratung.Size = new System.Drawing.Size(15, 14);
            this.cb_IstBeratung.TabIndex = 21;
            this.cb_IstBeratung.UseVisualStyleBackColor = true;
            // 
            // nbx_KalkulatorischesKonto
            // 
            this.nbx_KalkulatorischesKonto.Location = new System.Drawing.Point(158, 207);
            this.nbx_KalkulatorischesKonto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nbx_KalkulatorischesKonto.Name = "nbx_KalkulatorischesKonto";
            this.nbx_KalkulatorischesKonto.Size = new System.Drawing.Size(305, 23);
            this.nbx_KalkulatorischesKonto.TabIndex = 22;
            // 
            // nbx_Steuerrate
            // 
            this.nbx_Steuerrate.Location = new System.Drawing.Point(155, 112);
            this.nbx_Steuerrate.Name = "nbx_Steuerrate";
            this.nbx_Steuerrate.Size = new System.Drawing.Size(305, 23);
            this.nbx_Steuerrate.TabIndex = 23;
            // 
            // nbx_Steuerschlüssel
            // 
            this.nbx_Steuerschlüssel.Location = new System.Drawing.Point(155, 74);
            this.nbx_Steuerschlüssel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nbx_Steuerschlüssel.Name = "nbx_Steuerschlüssel";
            this.nbx_Steuerschlüssel.Size = new System.Drawing.Size(305, 23);
            this.nbx_Steuerschlüssel.TabIndex = 24;
            // 
            // cb_IstAbrechenbar
            // 
            this.cb_IstAbrechenbar.AutoSize = true;
            this.cb_IstAbrechenbar.Location = new System.Drawing.Point(158, 176);
            this.cb_IstAbrechenbar.Name = "cb_IstAbrechenbar";
            this.cb_IstAbrechenbar.Size = new System.Drawing.Size(15, 14);
            this.cb_IstAbrechenbar.TabIndex = 25;
            this.cb_IstAbrechenbar.UseVisualStyleBackColor = true;
            // 
            // gb_Steuer
            // 
            this.gb_Steuer.Controls.Add(this.nbx_Steuerrate);
            this.gb_Steuer.Controls.Add(this.label8);
            this.gb_Steuer.Controls.Add(this.nbx_Steuerschlüssel);
            this.gb_Steuer.Controls.Add(this.label7);
            this.gb_Steuer.Controls.Add(this.ctrl_SteuerlicherHinweis);
            this.gb_Steuer.Controls.Add(this.label6);
            this.gb_Steuer.Location = new System.Drawing.Point(12, 284);
            this.gb_Steuer.Name = "gb_Steuer";
            this.gb_Steuer.Size = new System.Drawing.Size(492, 158);
            this.gb_Steuer.TabIndex = 26;
            this.gb_Steuer.TabStop = false;
            this.gb_Steuer.Text = "Steuer Informationen";
            // 
            // gb_UmsatzkontoDetails
            // 
            this.gb_UmsatzkontoDetails.Controls.Add(this.nbx_KalkulatorischesKonto);
            this.gb_UmsatzkontoDetails.Controls.Add(this.label9);
            this.gb_UmsatzkontoDetails.Controls.Add(this.nbx_Kontonummer);
            this.gb_UmsatzkontoDetails.Controls.Add(this.cb_IstBeratung);
            this.gb_UmsatzkontoDetails.Controls.Add(this.ctrl_Kontoname);
            this.gb_UmsatzkontoDetails.Controls.Add(this.label1);
            this.gb_UmsatzkontoDetails.Controls.Add(this.label2);
            this.gb_UmsatzkontoDetails.Controls.Add(this.ctrl_Geschäftssparte);
            this.gb_UmsatzkontoDetails.Controls.Add(this.label5);
            this.gb_UmsatzkontoDetails.Controls.Add(this.label3);
            this.gb_UmsatzkontoDetails.Controls.Add(this.label4);
            this.gb_UmsatzkontoDetails.Controls.Add(this.cb_IstAbrechenbar);
            this.gb_UmsatzkontoDetails.Location = new System.Drawing.Point(12, 12);
            this.gb_UmsatzkontoDetails.Name = "gb_UmsatzkontoDetails";
            this.gb_UmsatzkontoDetails.Size = new System.Drawing.Size(492, 254);
            this.gb_UmsatzkontoDetails.TabIndex = 27;
            this.gb_UmsatzkontoDetails.TabStop = false;
            this.gb_UmsatzkontoDetails.Text = "Umsatzkonto Details";
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 510);
            this.Controls.Add(this.gb_UmsatzkontoDetails);
            this.Controls.Add(this.gb_Steuer);
            this.Controls.Add(this.ctrl_Abbrechen);
            this.Controls.Add(this.ctrl_Speichern);
            this.Name = "Bearbeiten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editiere Umsatzkonto";
            this.Load += new System.EventHandler(this.FormEditAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nbx_Kontonummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_KalkulatorischesKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_Steuerrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbx_Steuerschlüssel)).EndInit();
            this.gb_Steuer.ResumeLayout(false);
            this.gb_Steuer.PerformLayout();
            this.gb_UmsatzkontoDetails.ResumeLayout(false);
            this.gb_UmsatzkontoDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox ctrl_Kontoname;
        private Label label1;
        private Button ctrl_Speichern;
        private Button ctrl_Abbrechen;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox ctrl_Geschäftssparte;
        private TextBox ctrl_SteuerlicherHinweis;
        private NumericUpDown nbxAccountnumber;
        private CheckBox cb_IstBeratung;
        private NumericUpDown nbx_Kontonummer;
        private NumericUpDown nbx_KalkulatorischesKonto;
        private NumericUpDown numericUpDown2;
        private NumericUpDown nbx_Steuerschlüssel;
        private NumericUpDown nbx_Steuerrate;
        private CheckBox cb_IstAbrechenbar;
        private GroupBox gb_Steuer;
        private GroupBox gb_UmsatzkontoDetails;
    }
}