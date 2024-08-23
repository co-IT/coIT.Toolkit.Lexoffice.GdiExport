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
            dtpZeitraumStart = new DateTimePicker();
            dtpZeitraumEnde = new DateTimePicker();
            cbxCacheNeuladen = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            btnAbfragen = new Button();
            groupBox1 = new GroupBox();
            gbxZeitraum.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tvErgebnis
            // 
            tvErgebnis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvErgebnis.Location = new Point(0, 153);
            tvErgebnis.Name = "tvErgebnis";
            tvErgebnis.Size = new Size(765, 331);
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
            gbxZeitraum.Location = new Point(12, 3);
            gbxZeitraum.Name = "gbxZeitraum";
            gbxZeitraum.Size = new Size(317, 144);
            gbxZeitraum.TabIndex = 4;
            gbxZeitraum.TabStop = false;
            gbxZeitraum.Text = "Zeitraum auswählen";
            // 
            // dtpZeitraumStart
            // 
            dtpZeitraumStart.Location = new Point(102, 22);
            dtpZeitraumStart.Name = "dtpZeitraumStart";
            dtpZeitraumStart.Size = new Size(200, 23);
            dtpZeitraumStart.TabIndex = 0;
            // 
            // dtpZeitraumEnde
            // 
            dtpZeitraumEnde.Location = new Point(102, 51);
            dtpZeitraumEnde.Name = "dtpZeitraumEnde";
            dtpZeitraumEnde.Size = new Size(200, 23);
            dtpZeitraumEnde.TabIndex = 1;
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
            // label1
            // 
            label1.Location = new Point(45, 22);
            label1.Name = "label1";
            label1.Size = new Size(51, 23);
            label1.TabIndex = 3;
            label1.Text = "Anfang:";
            label1.TextAlign = ContentAlignment.MiddleRight;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(tbxCsvPfad);
            groupBox1.Controls.Add(btnCsvAuswählen);
            groupBox1.Location = new Point(335, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 144);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Abgefragten Zeitraum mit GDI abgleichen";
            // 
            // UmsatzkontenprüfungControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(gbxZeitraum);
            Controls.Add(tvErgebnis);
            Name = "UmsatzkontenprüfungControl";
            Size = new Size(765, 484);
            Load += UmsatzkontenprüfungControl_Load;
            gbxZeitraum.ResumeLayout(false);
            gbxZeitraum.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}
