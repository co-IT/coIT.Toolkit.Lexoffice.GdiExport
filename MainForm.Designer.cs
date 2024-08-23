namespace coIT.Lexoffice.GdiExport
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbc = new TabControl();
            tbpRequest = new TabPage();
            lblStatistiken = new Label();
            lview_InvoiceLines = new ListView();
            groupBox1 = new GroupBox();
            label2 = new Label();
            lview_ErkannteFehler = new ListView();
            gbxGdiExport = new GroupBox();
            btnTwoMonthsAgo = new Button();
            btnBeforeLastMonth = new Button();
            btnLastMonth = new Button();
            cbxIncludeCustomers = new CheckBox();
            btnAnzeigen = new Button();
            label1 = new Label();
            btnGenerateGdiExportFile = new Button();
            dtpStart = new DateTimePicker();
            lblStart = new Label();
            dtpEnd = new DateTimePicker();
            tbpDebitorNumber = new TabPage();
            tbpAccounts = new TabPage();
            spcUmsatzkontenSplit = new SplitContainer();
            tbpMiterabeiterliste = new TabPage();
            tbc.SuspendLayout();
            tbpRequest.SuspendLayout();
            groupBox1.SuspendLayout();
            gbxGdiExport.SuspendLayout();
            tbpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcUmsatzkontenSplit).BeginInit();
            spcUmsatzkontenSplit.SuspendLayout();
            SuspendLayout();
            // 
            // tbc
            // 
            tbc.Controls.Add(tbpRequest);
            tbc.Controls.Add(tbpDebitorNumber);
            tbc.Controls.Add(tbpAccounts);
            tbc.Controls.Add(tbpMiterabeiterliste);
            tbc.Dock = DockStyle.Fill;
            tbc.Location = new Point(0, 0);
            tbc.Name = "tbc";
            tbc.SelectedIndex = 0;
            tbc.Size = new Size(1264, 709);
            tbc.TabIndex = 0;
            // 
            // tbpRequest
            // 
            tbpRequest.Controls.Add(lblStatistiken);
            tbpRequest.Controls.Add(lview_InvoiceLines);
            tbpRequest.Controls.Add(groupBox1);
            tbpRequest.Location = new Point(4, 24);
            tbpRequest.Name = "tbpRequest";
            tbpRequest.Padding = new Padding(3);
            tbpRequest.Size = new Size(1256, 681);
            tbpRequest.TabIndex = 0;
            tbpRequest.Text = "Export";
            tbpRequest.UseVisualStyleBackColor = true;
            // 
            // lblStatistiken
            // 
            lblStatistiken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatistiken.Location = new Point(18, 195);
            lblStatistiken.Name = "lblStatistiken";
            lblStatistiken.Size = new Size(1220, 110);
            lblStatistiken.TabIndex = 8;
            // 
            // lview_InvoiceLines
            // 
            lview_InvoiceLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lview_InvoiceLines.Location = new Point(18, 307);
            lview_InvoiceLines.Margin = new Padding(3, 2, 3, 2);
            lview_InvoiceLines.Name = "lview_InvoiceLines";
            lview_InvoiceLines.Size = new Size(1220, 363);
            lview_InvoiceLines.TabIndex = 3;
            lview_InvoiceLines.UseCompatibleStateImageBehavior = false;
            lview_InvoiceLines.View = View.Details;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lview_ErkannteFehler);
            groupBox1.Controls.Add(gbxGdiExport);
            groupBox1.Location = new Point(18, 6);
            groupBox1.MinimumSize = new Size(1220, 186);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1220, 186);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 15);
            label2.Name = "label2";
            label2.Size = new Size(153, 15);
            label2.TabIndex = 6;
            label2.Text = "Beim Laden erkannte Fehler";
            // 
            // lview_ErkannteFehler
            // 
            lview_ErkannteFehler.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lview_ErkannteFehler.Location = new Point(427, 33);
            lview_ErkannteFehler.Name = "lview_ErkannteFehler";
            lview_ErkannteFehler.Size = new Size(787, 147);
            lview_ErkannteFehler.TabIndex = 3;
            lview_ErkannteFehler.UseCompatibleStateImageBehavior = false;
            lview_ErkannteFehler.View = View.Details;
            // 
            // gbxGdiExport
            // 
            gbxGdiExport.Controls.Add(btnTwoMonthsAgo);
            gbxGdiExport.Controls.Add(btnBeforeLastMonth);
            gbxGdiExport.Controls.Add(btnLastMonth);
            gbxGdiExport.Controls.Add(cbxIncludeCustomers);
            gbxGdiExport.Controls.Add(btnAnzeigen);
            gbxGdiExport.Controls.Add(label1);
            gbxGdiExport.Controls.Add(btnGenerateGdiExportFile);
            gbxGdiExport.Controls.Add(dtpStart);
            gbxGdiExport.Controls.Add(lblStart);
            gbxGdiExport.Controls.Add(dtpEnd);
            gbxGdiExport.Location = new Point(6, 15);
            gbxGdiExport.Margin = new Padding(3, 2, 3, 2);
            gbxGdiExport.Name = "gbxGdiExport";
            gbxGdiExport.Padding = new Padding(3, 2, 3, 2);
            gbxGdiExport.Size = new Size(405, 166);
            gbxGdiExport.TabIndex = 4;
            gbxGdiExport.TabStop = false;
            gbxGdiExport.Text = "GDI Export";
            // 
            // btnTwoMonthsAgo
            // 
            btnTwoMonthsAgo.Location = new Point(274, 84);
            btnTwoMonthsAgo.Name = "btnTwoMonthsAgo";
            btnTwoMonthsAgo.Size = new Size(111, 27);
            btnTwoMonthsAgo.TabIndex = 9;
            btnTwoMonthsAgo.Text = "Vor-vorletzter Monat";
            btnTwoMonthsAgo.UseVisualStyleBackColor = true;
            btnTwoMonthsAgo.Click += btnTwoMonthsAgo_Click;
            // 
            // btnBeforeLastMonth
            // 
            btnBeforeLastMonth.Location = new Point(274, 51);
            btnBeforeLastMonth.Name = "btnBeforeLastMonth";
            btnBeforeLastMonth.Size = new Size(111, 27);
            btnBeforeLastMonth.TabIndex = 8;
            btnBeforeLastMonth.Text = "Vorletzter Monat";
            btnBeforeLastMonth.UseVisualStyleBackColor = true;
            btnBeforeLastMonth.Click += btnBeforeLastMonth_Click;
            // 
            // btnLastMonth
            // 
            btnLastMonth.Location = new Point(274, 18);
            btnLastMonth.Name = "btnLastMonth";
            btnLastMonth.Size = new Size(111, 27);
            btnLastMonth.TabIndex = 7;
            btnLastMonth.Text = "Letzter Monat";
            btnLastMonth.UseVisualStyleBackColor = true;
            btnLastMonth.Click += btnLastMonth_Click;
            // 
            // cbxIncludeCustomers
            // 
            cbxIncludeCustomers.AutoSize = true;
            cbxIncludeCustomers.Checked = true;
            cbxIncludeCustomers.CheckState = CheckState.Checked;
            cbxIncludeCustomers.Location = new Point(61, 89);
            cbxIncludeCustomers.Name = "cbxIncludeCustomers";
            cbxIncludeCustomers.Size = new Size(189, 19);
            cbxIncludeCustomers.TabIndex = 6;
            cbxIncludeCustomers.Text = "Inkludiere Leistungsempfänger";
            cbxIncludeCustomers.UseVisualStyleBackColor = true;
            // 
            // btnAnzeigen
            // 
            btnAnzeigen.Location = new Point(25, 125);
            btnAnzeigen.Name = "btnAnzeigen";
            btnAnzeigen.Size = new Size(106, 27);
            btnAnzeigen.TabIndex = 5;
            btnAnzeigen.Text = "🖥 Anzeigen";
            btnAnzeigen.UseVisualStyleBackColor = true;
            btnAnzeigen.Click += btnAnzeigen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 54);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 4;
            label1.Text = "Ende:";
            // 
            // btnGenerateGdiExportFile
            // 
            btnGenerateGdiExportFile.Location = new Point(149, 125);
            btnGenerateGdiExportFile.Margin = new Padding(3, 2, 3, 2);
            btnGenerateGdiExportFile.Name = "btnGenerateGdiExportFile";
            btnGenerateGdiExportFile.Size = new Size(106, 27);
            btnGenerateGdiExportFile.TabIndex = 2;
            btnGenerateGdiExportFile.Text = "📃 Exportieren";
            btnGenerateGdiExportFile.UseVisualStyleBackColor = true;
            btnGenerateGdiExportFile.Click += btnGenerateGdiExportFile_Click;
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "  ddd dd MMM yyyy";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(61, 21);
            dtpStart.Margin = new Padding(3, 2, 3, 2);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(194, 23);
            dtpStart.TabIndex = 0;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(19, 23);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(34, 15);
            lblStart.TabIndex = 3;
            lblStart.Text = "Start:";
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "  ddd dd MMM yyyy";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(61, 54);
            dtpEnd.Margin = new Padding(3, 2, 3, 2);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(194, 23);
            dtpEnd.TabIndex = 1;
            // 
            // tbpDebitorNumber
            // 
            tbpDebitorNumber.Location = new Point(4, 24);
            tbpDebitorNumber.Name = "tbpDebitorNumber";
            tbpDebitorNumber.Padding = new Padding(3);
            tbpDebitorNumber.Size = new Size(1256, 681);
            tbpDebitorNumber.TabIndex = 1;
            tbpDebitorNumber.Text = "Leistungsempfänger";
            tbpDebitorNumber.UseVisualStyleBackColor = true;
            // 
            // tbpAccounts
            // 
            tbpAccounts.Controls.Add(spcUmsatzkontenSplit);
            tbpAccounts.Location = new Point(4, 24);
            tbpAccounts.Name = "tbpAccounts";
            tbpAccounts.Padding = new Padding(3);
            tbpAccounts.Size = new Size(1256, 681);
            tbpAccounts.TabIndex = 2;
            tbpAccounts.Text = "Umsatzkonten";
            tbpAccounts.UseVisualStyleBackColor = true;
            // 
            // spcUmsatzkontenSplit
            // 
            spcUmsatzkontenSplit.Dock = DockStyle.Fill;
            spcUmsatzkontenSplit.Location = new Point(3, 3);
            spcUmsatzkontenSplit.Name = "spcUmsatzkontenSplit";
            spcUmsatzkontenSplit.Orientation = Orientation.Horizontal;
            spcUmsatzkontenSplit.Size = new Size(1250, 675);
            spcUmsatzkontenSplit.SplitterDistance = 257;
            spcUmsatzkontenSplit.TabIndex = 0;
            // 
            // tbpMiterabeiterliste
            // 
            tbpMiterabeiterliste.Location = new Point(4, 24);
            tbpMiterabeiterliste.Margin = new Padding(3, 2, 3, 2);
            tbpMiterabeiterliste.Name = "tbpMiterabeiterliste";
            tbpMiterabeiterliste.Padding = new Padding(3, 2, 3, 2);
            tbpMiterabeiterliste.Size = new Size(1256, 681);
            tbpMiterabeiterliste.TabIndex = 3;
            tbpMiterabeiterliste.Text = "Mitarbeiter";
            tbpMiterabeiterliste.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 709);
            Controls.Add(tbc);
            Name = "MainForm";
            Text = "co-IT.eu GmbH | Lexoffice to GDI Export";
            Load += Form1_Load;
            tbc.ResumeLayout(false);
            tbpRequest.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbxGdiExport.ResumeLayout(false);
            gbxGdiExport.PerformLayout();
            tbpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcUmsatzkontenSplit).EndInit();
            spcUmsatzkontenSplit.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbc;
        private TabPage tbpRequest;
        private TabPage tbpDebitorNumber;
        private TabPage tbpAccounts;
        private Button btnGenerateGdiExportFile;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private GroupBox gbxGdiExport;
        private Label label1;
        private Label lblStart;
        private TabPage tbpMiterabeiterliste;
        private ListView lview_InvoiceLines;
        private Label label2;
        private ListView lview_ErkannteFehler;
        private Button btnAnzeigen;
        private CheckBox cbxIncludeCustomers;
        private Button btnBeforeLastMonth;
        private Button btnLastMonth;
        private Button btnTwoMonthsAgo;
        private GroupBox groupBox1;
        private Label lblStatistiken;
        private SplitContainer spcUmsatzkontenSplit;
    }
}
