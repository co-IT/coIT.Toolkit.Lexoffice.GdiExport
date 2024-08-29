namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung
{
    partial class UmsatzkontenprüfungControl
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
            tvErgebnis = new TreeView();
            tbxCsvPfad = new TextBox();
            btnCsvAuswählen = new Button();
            dlgCsvÖffnen = new OpenFileDialog();
            gbxZeitraum = new GroupBox();
            btnAbfragen = new Button();
            label2 = new Label();
            label1 = new Label();
            cbxCacheNeuladen = new CheckBox();
            dtpZeitraumEnde = new DateTimePicker();
            dtpZeitraumStart = new DateTimePicker();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tbpPrüfung = new TabPage();
            kundeMitarbeiterView = new Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen.KundeMitarbeiterView();
            tabPage2 = new TabPage();
            umsatzkontoKundeView = new Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen.UmsatzkontoKundeView();
            tabPage1 = new TabPage();
            kundeUmsatzkontoView = new Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen.KundeUmsatzkontoView();
            tabPage3 = new TabPage();
            gbxZeitraum.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpPrüfung.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tvErgebnis
            // 
            tvErgebnis.Dock = DockStyle.Fill;
            tvErgebnis.Location = new Point(3, 3);
            tvErgebnis.Name = "tvErgebnis";
            tvErgebnis.Size = new Size(751, 295);
            tvErgebnis.TabIndex = 0;
            // 
            // tbxCsvPfad
            // 
            tbxCsvPfad.Enabled = false;
            tbxCsvPfad.Location = new Point(6, 42);
            tbxCsvPfad.Name = "tbxCsvPfad";
            tbxCsvPfad.Size = new Size(261, 23);
            tbxCsvPfad.TabIndex = 2;
            // 
            // btnCsvAuswählen
            // 
            btnCsvAuswählen.Location = new Point(273, 42);
            btnCsvAuswählen.Name = "btnCsvAuswählen";
            btnCsvAuswählen.Size = new Size(104, 23);
            btnCsvAuswählen.TabIndex = 3;
            btnCsvAuswählen.Text = "Csv Auswählen";
            btnCsvAuswählen.UseVisualStyleBackColor = true;
            btnCsvAuswählen.Click += btnCsvAuswählen_Click;
            // 
            // dlgCsvÖffnen
            // 
            dlgCsvÖffnen.Filter = "CSV files (*.csv)|*.csv";
            // 
            // gbxZeitraum
            // 
            gbxZeitraum.Controls.Add(btnAbfragen);
            gbxZeitraum.Controls.Add(label2);
            gbxZeitraum.Controls.Add(label1);
            gbxZeitraum.Controls.Add(cbxCacheNeuladen);
            gbxZeitraum.Controls.Add(dtpZeitraumEnde);
            gbxZeitraum.Controls.Add(dtpZeitraumStart);
            gbxZeitraum.Location = new Point(3, 3);
            gbxZeitraum.Name = "gbxZeitraum";
            gbxZeitraum.Size = new Size(317, 144);
            gbxZeitraum.TabIndex = 4;
            gbxZeitraum.TabStop = false;
            gbxZeitraum.Text = "Zeitraum auswählen";
            // 
            // btnAbfragen
            // 
            btnAbfragen.Location = new Point(191, 114);
            btnAbfragen.Name = "btnAbfragen";
            btnAbfragen.Size = new Size(111, 23);
            btnAbfragen.TabIndex = 5;
            btnAbfragen.Text = "Abfrage starten";
            btnAbfragen.UseVisualStyleBackColor = true;
            btnAbfragen.Click += btnAbfragen_Click;
            // 
            // label2
            // 
            label2.Location = new Point(45, 51);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 4;
            label2.Text = "Ende:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(45, 22);
            label1.Name = "label1";
            label1.Size = new Size(51, 23);
            label1.TabIndex = 3;
            label1.Text = "Anfang:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxCacheNeuladen
            // 
            cbxCacheNeuladen.AutoSize = true;
            cbxCacheNeuladen.CheckAlign = ContentAlignment.MiddleRight;
            cbxCacheNeuladen.Location = new Point(68, 89);
            cbxCacheNeuladen.Name = "cbxCacheNeuladen";
            cbxCacheNeuladen.Size = new Size(234, 19);
            cbxCacheNeuladen.TabIndex = 2;
            cbxCacheNeuladen.Text = "Cache für diesen Zeitraum aktualisieren";
            cbxCacheNeuladen.UseVisualStyleBackColor = true;
            // 
            // dtpZeitraumEnde
            // 
            dtpZeitraumEnde.Location = new Point(102, 51);
            dtpZeitraumEnde.Name = "dtpZeitraumEnde";
            dtpZeitraumEnde.Size = new Size(200, 23);
            dtpZeitraumEnde.TabIndex = 1;
            // 
            // dtpZeitraumStart
            // 
            dtpZeitraumStart.Location = new Point(102, 22);
            dtpZeitraumStart.Name = "dtpZeitraumStart";
            dtpZeitraumStart.Size = new Size(200, 23);
            dtpZeitraumStart.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbxCsvPfad);
            groupBox1.Controls.Add(btnCsvAuswählen);
            groupBox1.Location = new Point(326, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 144);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Abgefragten Zeitraum mit GDI abgleichen";
            // 
            // panel1
            // 
            panel1.Controls.Add(gbxZeitraum);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(765, 155);
            panel1.TabIndex = 8;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpPrüfung);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 155);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(765, 329);
            tabControl1.TabIndex = 9;
            // 
            // tbpPrüfung
            // 
            tbpPrüfung.Controls.Add(tvErgebnis);
            tbpPrüfung.Location = new Point(4, 24);
            tbpPrüfung.Name = "tbpPrüfung";
            tbpPrüfung.Padding = new Padding(3);
            tbpPrüfung.Size = new Size(757, 301);
            tbpPrüfung.TabIndex = 0;
            tbpPrüfung.Text = "Umsatzkonten Prüfung";
            tbpPrüfung.UseVisualStyleBackColor = true;
            // 
            // kundeMitarbeiterView
            // 
            kundeMitarbeiterView.Dock = DockStyle.Fill;
            kundeMitarbeiterView.Location = new Point(3, 3);
            kundeMitarbeiterView.Name = "kundeMitarbeiterView";
            kundeMitarbeiterView.Size = new Size(751, 295);
            kundeMitarbeiterView.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(umsatzkontoKundeView);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(757, 301);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Konto Kunde";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // umsatzkontoKundeView
            // 
            umsatzkontoKundeView.Dock = DockStyle.Fill;
            umsatzkontoKundeView.Location = new Point(3, 3);
            umsatzkontoKundeView.Name = "umsatzkontoKundeView";
            umsatzkontoKundeView.Size = new Size(751, 295);
            umsatzkontoKundeView.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(kundeUmsatzkontoView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(757, 301);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Kunde Konto";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // kundeUmsatzkontoView
            // 
            kundeUmsatzkontoView.Dock = DockStyle.Fill;
            kundeUmsatzkontoView.Location = new Point(3, 3);
            kundeUmsatzkontoView.Name = "kundeUmsatzkontoView";
            kundeUmsatzkontoView.Size = new Size(751, 295);
            kundeUmsatzkontoView.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(kundeMitarbeiterView);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(757, 301);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Kunde Mitarbeiter";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // UmsatzkontenprüfungControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "UmsatzkontenprüfungControl";
            Size = new Size(765, 484);
            Load += UmsatzkontenprüfungControl_Load;
            gbxZeitraum.ResumeLayout(false);
            gbxZeitraum.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tbpPrüfung.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView tvErgebnis;
        private TextBox tbxCsvPfad;
        private Button btnCsvAuswählen;
        private OpenFileDialog dlgCsvÖffnen;
        private GroupBox gbxZeitraum;
        private Button btnAbfragen;
        private Label label2;
        private Label label1;
        private CheckBox cbxCacheNeuladen;
        private DateTimePicker dtpZeitraumEnde;
        private DateTimePicker dtpZeitraumStart;
        private GroupBox groupBox1;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tbpPrüfung;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen.UmsatzkontoKundeView umsatzkontoKundeView;
        private Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen.KundeUmsatzkontoView kundeUmsatzkontoView;
        private Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen.KundeMitarbeiterView kundeMitarbeiterView;
    }
}
