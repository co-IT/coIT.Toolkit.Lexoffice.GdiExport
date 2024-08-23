namespace coIT.Lexoffice.GdiExport.Mitarbeiterliste
{
    partial class View
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMitarbeiter = new System.Windows.Forms.DataGridView();
            this.spcGeteilteAnsicht = new System.Windows.Forms.SplitContainer();
            this.gbxStundelohnAuswertung = new System.Windows.Forms.GroupBox();
            this.lblStundenlohn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUmsatz = new System.Windows.Forms.Label();
            this.nbxStundenlohn = new System.Windows.Forms.NumericUpDown();
            this.nbxStundenanzahl = new System.Windows.Forms.NumericUpDown();
            this.nbxUmsatz = new System.Windows.Forms.NumericUpDown();
            this.btnBerechnen = new System.Windows.Forms.Button();
            this.lblEnde = new System.Windows.Forms.Label();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbxKonto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.cbxTeam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcGeteilteAnsicht)).BeginInit();
            this.spcGeteilteAnsicht.Panel1.SuspendLayout();
            this.spcGeteilteAnsicht.Panel2.SuspendLayout();
            this.spcGeteilteAnsicht.SuspendLayout();
            this.gbxStundelohnAuswertung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxStundenlohn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxStundenanzahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxUmsatz)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMitarbeiter
            // 
            this.dgvMitarbeiter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMitarbeiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMitarbeiter.Location = new System.Drawing.Point(0, 0);
            this.dgvMitarbeiter.Name = "dgvMitarbeiter";
            this.dgvMitarbeiter.RowHeadersWidth = 51;
            this.dgvMitarbeiter.RowTemplate.Height = 29;
            this.dgvMitarbeiter.Size = new System.Drawing.Size(1463, 499);
            this.dgvMitarbeiter.TabIndex = 0;
            // 
            // spcGeteilteAnsicht
            // 
            this.spcGeteilteAnsicht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcGeteilteAnsicht.Location = new System.Drawing.Point(0, 0);
            this.spcGeteilteAnsicht.Name = "spcGeteilteAnsicht";
            this.spcGeteilteAnsicht.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcGeteilteAnsicht.Panel1
            // 
            this.spcGeteilteAnsicht.Panel1.Controls.Add(this.dgvMitarbeiter);
            // 
            // spcGeteilteAnsicht.Panel2
            // 
            this.spcGeteilteAnsicht.Panel2.Controls.Add(this.gbxStundelohnAuswertung);
            this.spcGeteilteAnsicht.Size = new System.Drawing.Size(1463, 960);
            this.spcGeteilteAnsicht.SplitterDistance = 499;
            this.spcGeteilteAnsicht.TabIndex = 1;
            // 
            // gbxStundelohnAuswertung
            // 
            this.gbxStundelohnAuswertung.Controls.Add(this.lblStundenlohn);
            this.gbxStundelohnAuswertung.Controls.Add(this.label2);
            this.gbxStundelohnAuswertung.Controls.Add(this.lblUmsatz);
            this.gbxStundelohnAuswertung.Controls.Add(this.nbxStundenlohn);
            this.gbxStundelohnAuswertung.Controls.Add(this.nbxStundenanzahl);
            this.gbxStundelohnAuswertung.Controls.Add(this.nbxUmsatz);
            this.gbxStundelohnAuswertung.Controls.Add(this.btnBerechnen);
            this.gbxStundelohnAuswertung.Controls.Add(this.lblEnde);
            this.gbxStundelohnAuswertung.Controls.Add(this.dtpEnde);
            this.gbxStundelohnAuswertung.Controls.Add(this.lblStart);
            this.gbxStundelohnAuswertung.Controls.Add(this.dtpStart);
            this.gbxStundelohnAuswertung.Controls.Add(this.cbxKonto);
            this.gbxStundelohnAuswertung.Controls.Add(this.label1);
            this.gbxStundelohnAuswertung.Controls.Add(this.lblTeam);
            this.gbxStundelohnAuswertung.Controls.Add(this.cbxTeam);
            this.gbxStundelohnAuswertung.Location = new System.Drawing.Point(17, 17);
            this.gbxStundelohnAuswertung.Name = "gbxStundelohnAuswertung";
            this.gbxStundelohnAuswertung.Size = new System.Drawing.Size(462, 383);
            this.gbxStundelohnAuswertung.TabIndex = 1;
            this.gbxStundelohnAuswertung.TabStop = false;
            this.gbxStundelohnAuswertung.Text = "Stundenlohnauswertung";
            // 
            // lblStundenlohn
            // 
            this.lblStundenlohn.Location = new System.Drawing.Point(96, 345);
            this.lblStundenlohn.Name = "lblStundenlohn";
            this.lblStundenlohn.Size = new System.Drawing.Size(114, 25);
            this.lblStundenlohn.TabIndex = 14;
            this.lblStundenlohn.Text = "Stundenlohn:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Stundenanzahl:";
            // 
            // lblUmsatz
            // 
            this.lblUmsatz.Location = new System.Drawing.Point(96, 259);
            this.lblUmsatz.Name = "lblUmsatz";
            this.lblUmsatz.Size = new System.Drawing.Size(62, 25);
            this.lblUmsatz.TabIndex = 12;
            this.lblUmsatz.Text = "Umsatz:";
            // 
            // nbxStundenlohn
            // 
            this.nbxStundenlohn.DecimalPlaces = 2;
            this.nbxStundenlohn.Enabled = false;
            this.nbxStundenlohn.Location = new System.Drawing.Point(216, 343);
            this.nbxStundenlohn.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nbxStundenlohn.Name = "nbxStundenlohn";
            this.nbxStundenlohn.Size = new System.Drawing.Size(207, 27);
            this.nbxStundenlohn.TabIndex = 11;
            // 
            // nbxStundenanzahl
            // 
            this.nbxStundenanzahl.DecimalPlaces = 2;
            this.nbxStundenanzahl.Enabled = false;
            this.nbxStundenanzahl.Location = new System.Drawing.Point(216, 300);
            this.nbxStundenanzahl.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nbxStundenanzahl.Name = "nbxStundenanzahl";
            this.nbxStundenanzahl.Size = new System.Drawing.Size(207, 27);
            this.nbxStundenanzahl.TabIndex = 10;
            // 
            // nbxUmsatz
            // 
            this.nbxUmsatz.DecimalPlaces = 2;
            this.nbxUmsatz.Enabled = false;
            this.nbxUmsatz.Location = new System.Drawing.Point(216, 257);
            this.nbxUmsatz.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nbxUmsatz.Name = "nbxUmsatz";
            this.nbxUmsatz.Size = new System.Drawing.Size(207, 27);
            this.nbxUmsatz.TabIndex = 9;
            // 
            // btnBerechnen
            // 
            this.btnBerechnen.Location = new System.Drawing.Point(329, 212);
            this.btnBerechnen.Name = "btnBerechnen";
            this.btnBerechnen.Size = new System.Drawing.Size(94, 29);
            this.btnBerechnen.TabIndex = 8;
            this.btnBerechnen.Text = "Berechnen";
            this.btnBerechnen.UseVisualStyleBackColor = true;
            this.btnBerechnen.Click += new System.EventHandler(this.btnBerechnen_Click);
            // 
            // lblEnde
            // 
            this.lblEnde.Location = new System.Drawing.Point(28, 169);
            this.lblEnde.Name = "lblEnde";
            this.lblEnde.Size = new System.Drawing.Size(62, 25);
            this.lblEnde.TabIndex = 7;
            this.lblEnde.Text = "Ende:";
            // 
            // dtpEnde
            // 
            this.dtpEnde.Location = new System.Drawing.Point(96, 169);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(327, 27);
            this.dtpEnde.TabIndex = 6;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(28, 128);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(62, 25);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Start:";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(96, 126);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(327, 27);
            this.dtpStart.TabIndex = 4;
            // 
            // cbxKonto
            // 
            this.cbxKonto.FormattingEnabled = true;
            this.cbxKonto.Location = new System.Drawing.Point(96, 82);
            this.cbxKonto.Name = "cbxKonto";
            this.cbxKonto.Size = new System.Drawing.Size(327, 28);
            this.cbxKonto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Konto:";
            // 
            // lblTeam
            // 
            this.lblTeam.Location = new System.Drawing.Point(28, 38);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(62, 25);
            this.lblTeam.TabIndex = 1;
            this.lblTeam.Text = "Team:";
            // 
            // cbxTeam
            // 
            this.cbxTeam.FormattingEnabled = true;
            this.cbxTeam.Location = new System.Drawing.Point(96, 38);
            this.cbxTeam.Name = "cbxTeam";
            this.cbxTeam.Size = new System.Drawing.Size(327, 28);
            this.cbxTeam.TabIndex = 0;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcGeteilteAnsicht);
            this.Name = "View";
            this.Size = new System.Drawing.Size(1463, 960);
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMitarbeiter)).EndInit();
            this.spcGeteilteAnsicht.Panel1.ResumeLayout(false);
            this.spcGeteilteAnsicht.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcGeteilteAnsicht)).EndInit();
            this.spcGeteilteAnsicht.ResumeLayout(false);
            this.gbxStundelohnAuswertung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbxStundenlohn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxStundenanzahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxUmsatz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvMitarbeiter;
        private SplitContainer spcGeteilteAnsicht;
        private GroupBox gbxStundelohnAuswertung;
        private Label lblEnde;
        private DateTimePicker dtpEnde;
        private Label lblStart;
        private DateTimePicker dtpStart;
        private ComboBox cbxKonto;
        private Label label1;
        private Label lblTeam;
        private ComboBox cbxTeam;
        private Button btnBerechnen;
        private Label lblStundenlohn;
        private Label label2;
        private Label lblUmsatz;
        private NumericUpDown nbxStundenlohn;
        private NumericUpDown nbxStundenanzahl;
        private NumericUpDown nbxUmsatz;
    }
}
