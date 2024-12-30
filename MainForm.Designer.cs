namespace coIT.Toolkit.Lexoffice.GdiExport
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          tbc = new System.Windows.Forms.TabControl();
          tbpRequest = new System.Windows.Forms.TabPage();
          lblStatistiken = new System.Windows.Forms.Label();
          lview_InvoiceLines = new System.Windows.Forms.ListView();
          groupBox1 = new System.Windows.Forms.GroupBox();
          label2 = new System.Windows.Forms.Label();
          lview_ErkannteFehler = new System.Windows.Forms.ListView();
          gbxGdiExport = new System.Windows.Forms.GroupBox();
          btnTwoMonthsAgo = new System.Windows.Forms.Button();
          btnBeforeLastMonth = new System.Windows.Forms.Button();
          btnLastMonth = new System.Windows.Forms.Button();
          cbxIncludeCustomers = new System.Windows.Forms.CheckBox();
          btnAnzeigen = new System.Windows.Forms.Button();
          label1 = new System.Windows.Forms.Label();
          btnGenerateGdiExportFile = new System.Windows.Forms.Button();
          dtpStart = new System.Windows.Forms.DateTimePicker();
          lblStart = new System.Windows.Forms.Label();
          dtpEnd = new System.Windows.Forms.DateTimePicker();
          tbpDebitorNumber = new System.Windows.Forms.TabPage();
          tbpAccounts = new System.Windows.Forms.TabPage();
          spcUmsatzkontenSplit = new System.Windows.Forms.SplitContainer();
          tbpMiterabeiterliste = new System.Windows.Forms.TabPage();
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
          tbc.Dock = System.Windows.Forms.DockStyle.Fill;
          tbc.Location = new System.Drawing.Point(0, 0);
          tbc.Name = "tbc";
          tbc.SelectedIndex = 0;
          tbc.Size = new System.Drawing.Size(1264, 709);
          tbc.TabIndex = 0;
          // 
          // tbpRequest
          // 
          tbpRequest.Controls.Add(lblStatistiken);
          tbpRequest.Controls.Add(lview_InvoiceLines);
          tbpRequest.Controls.Add(groupBox1);
          tbpRequest.Location = new System.Drawing.Point(4, 24);
          tbpRequest.Name = "tbpRequest";
          tbpRequest.Padding = new System.Windows.Forms.Padding(3);
          tbpRequest.Size = new System.Drawing.Size(1256, 681);
          tbpRequest.TabIndex = 0;
          tbpRequest.Text = "Export";
          tbpRequest.UseVisualStyleBackColor = true;
          // 
          // lblStatistiken
          // 
          lblStatistiken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
          lblStatistiken.Location = new System.Drawing.Point(18, 195);
          lblStatistiken.Name = "lblStatistiken";
          lblStatistiken.Size = new System.Drawing.Size(1220, 110);
          lblStatistiken.TabIndex = 8;
          // 
          // lview_InvoiceLines
          // 
          lview_InvoiceLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
          lview_InvoiceLines.Location = new System.Drawing.Point(18, 307);
          lview_InvoiceLines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          lview_InvoiceLines.Name = "lview_InvoiceLines";
          lview_InvoiceLines.Size = new System.Drawing.Size(1220, 363);
          lview_InvoiceLines.TabIndex = 3;
          lview_InvoiceLines.UseCompatibleStateImageBehavior = false;
          lview_InvoiceLines.View = System.Windows.Forms.View.Details;
          // 
          // groupBox1
          // 
          groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
          groupBox1.Controls.Add(label2);
          groupBox1.Controls.Add(lview_ErkannteFehler);
          groupBox1.Controls.Add(gbxGdiExport);
          groupBox1.Location = new System.Drawing.Point(18, 6);
          groupBox1.MinimumSize = new System.Drawing.Size(1220, 186);
          groupBox1.Name = "groupBox1";
          groupBox1.Size = new System.Drawing.Size(1220, 186);
          groupBox1.TabIndex = 7;
          groupBox1.TabStop = false;
          // 
          // label2
          // 
          label2.AutoSize = true;
          label2.Location = new System.Drawing.Point(426, 15);
          label2.Name = "label2";
          label2.Size = new System.Drawing.Size(153, 15);
          label2.TabIndex = 6;
          label2.Text = "Beim Laden erkannte Fehler";
          // 
          // lview_ErkannteFehler
          // 
          lview_ErkannteFehler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
          lview_ErkannteFehler.Location = new System.Drawing.Point(427, 33);
          lview_ErkannteFehler.Name = "lview_ErkannteFehler";
          lview_ErkannteFehler.Size = new System.Drawing.Size(787, 147);
          lview_ErkannteFehler.TabIndex = 3;
          lview_ErkannteFehler.UseCompatibleStateImageBehavior = false;
          lview_ErkannteFehler.View = System.Windows.Forms.View.Details;
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
          gbxGdiExport.Location = new System.Drawing.Point(6, 15);
          gbxGdiExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          gbxGdiExport.Name = "gbxGdiExport";
          gbxGdiExport.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
          gbxGdiExport.Size = new System.Drawing.Size(405, 166);
          gbxGdiExport.TabIndex = 4;
          gbxGdiExport.TabStop = false;
          gbxGdiExport.Text = "GDI Export";
          // 
          // btnTwoMonthsAgo
          // 
          btnTwoMonthsAgo.Location = new System.Drawing.Point(274, 84);
          btnTwoMonthsAgo.Name = "btnTwoMonthsAgo";
          btnTwoMonthsAgo.Size = new System.Drawing.Size(111, 27);
          btnTwoMonthsAgo.TabIndex = 9;
          btnTwoMonthsAgo.Text = "Vor-vorletzter Monat";
          btnTwoMonthsAgo.UseVisualStyleBackColor = true;
          btnTwoMonthsAgo.Click += btnTwoMonthsAgo_Click;
          // 
          // btnBeforeLastMonth
          // 
          btnBeforeLastMonth.Location = new System.Drawing.Point(274, 51);
          btnBeforeLastMonth.Name = "btnBeforeLastMonth";
          btnBeforeLastMonth.Size = new System.Drawing.Size(111, 27);
          btnBeforeLastMonth.TabIndex = 8;
          btnBeforeLastMonth.Text = "Vorletzter Monat";
          btnBeforeLastMonth.UseVisualStyleBackColor = true;
          btnBeforeLastMonth.Click += btnBeforeLastMonth_Click;
          // 
          // btnLastMonth
          // 
          btnLastMonth.Location = new System.Drawing.Point(274, 18);
          btnLastMonth.Name = "btnLastMonth";
          btnLastMonth.Size = new System.Drawing.Size(111, 27);
          btnLastMonth.TabIndex = 7;
          btnLastMonth.Text = "Letzter Monat";
          btnLastMonth.UseVisualStyleBackColor = true;
          btnLastMonth.Click += btnLastMonth_Click;
          // 
          // cbxIncludeCustomers
          // 
          cbxIncludeCustomers.AutoSize = true;
          cbxIncludeCustomers.Checked = true;
          cbxIncludeCustomers.CheckState = System.Windows.Forms.CheckState.Checked;
          cbxIncludeCustomers.Location = new System.Drawing.Point(61, 89);
          cbxIncludeCustomers.Name = "cbxIncludeCustomers";
          cbxIncludeCustomers.Size = new System.Drawing.Size(189, 19);
          cbxIncludeCustomers.TabIndex = 6;
          cbxIncludeCustomers.Text = "Inkludiere Leistungsempfänger";
          cbxIncludeCustomers.UseVisualStyleBackColor = true;
          // 
          // btnAnzeigen
          // 
          btnAnzeigen.Location = new System.Drawing.Point(25, 125);
          btnAnzeigen.Name = "btnAnzeigen";
          btnAnzeigen.Size = new System.Drawing.Size(106, 27);
          btnAnzeigen.TabIndex = 5;
          btnAnzeigen.Text = "🖥 Anzeigen";
          btnAnzeigen.UseVisualStyleBackColor = true;
          btnAnzeigen.Click += btnAnzeigen_Click;
          // 
          // label1
          // 
          label1.AutoSize = true;
          label1.Location = new System.Drawing.Point(17, 54);
          label1.Name = "label1";
          label1.Size = new System.Drawing.Size(36, 15);
          label1.TabIndex = 4;
          label1.Text = "Ende:";
          // 
          // btnGenerateGdiExportFile
          // 
          btnGenerateGdiExportFile.Location = new System.Drawing.Point(149, 125);
          btnGenerateGdiExportFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          btnGenerateGdiExportFile.Name = "btnGenerateGdiExportFile";
          btnGenerateGdiExportFile.Size = new System.Drawing.Size(106, 27);
          btnGenerateGdiExportFile.TabIndex = 2;
          btnGenerateGdiExportFile.Text = "📃 Exportieren";
          btnGenerateGdiExportFile.UseVisualStyleBackColor = true;
          btnGenerateGdiExportFile.Click += btnGenerateGdiExportFile_Click;
          // 
          // dtpStart
          // 
          dtpStart.CustomFormat = "  ddd dd MMM yyyy";
          dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          dtpStart.Location = new System.Drawing.Point(61, 21);
          dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          dtpStart.Name = "dtpStart";
          dtpStart.Size = new System.Drawing.Size(194, 23);
          dtpStart.TabIndex = 0;
          // 
          // lblStart
          // 
          lblStart.AutoSize = true;
          lblStart.Location = new System.Drawing.Point(19, 23);
          lblStart.Name = "lblStart";
          lblStart.Size = new System.Drawing.Size(34, 15);
          lblStart.TabIndex = 3;
          lblStart.Text = "Start:";
          // 
          // dtpEnd
          // 
          dtpEnd.CustomFormat = "  ddd dd MMM yyyy";
          dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          dtpEnd.Location = new System.Drawing.Point(61, 54);
          dtpEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          dtpEnd.Name = "dtpEnd";
          dtpEnd.Size = new System.Drawing.Size(194, 23);
          dtpEnd.TabIndex = 1;
          // 
          // tbpDebitorNumber
          // 
          tbpDebitorNumber.Location = new System.Drawing.Point(4, 24);
          tbpDebitorNumber.Name = "tbpDebitorNumber";
          tbpDebitorNumber.Padding = new System.Windows.Forms.Padding(3);
          tbpDebitorNumber.Size = new System.Drawing.Size(1256, 681);
          tbpDebitorNumber.TabIndex = 1;
          tbpDebitorNumber.Text = "Leistungsempfänger";
          tbpDebitorNumber.UseVisualStyleBackColor = true;
          // 
          // tbpAccounts
          // 
          tbpAccounts.Controls.Add(spcUmsatzkontenSplit);
          tbpAccounts.Location = new System.Drawing.Point(4, 24);
          tbpAccounts.Name = "tbpAccounts";
          tbpAccounts.Padding = new System.Windows.Forms.Padding(3);
          tbpAccounts.Size = new System.Drawing.Size(1256, 681);
          tbpAccounts.TabIndex = 2;
          tbpAccounts.Text = "Umsätze";
          tbpAccounts.UseVisualStyleBackColor = true;
          // 
          // spcUmsatzkontenSplit
          // 
          spcUmsatzkontenSplit.Dock = System.Windows.Forms.DockStyle.Fill;
          spcUmsatzkontenSplit.Location = new System.Drawing.Point(3, 3);
          spcUmsatzkontenSplit.Name = "spcUmsatzkontenSplit";
          spcUmsatzkontenSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
          spcUmsatzkontenSplit.Size = new System.Drawing.Size(1250, 675);
          spcUmsatzkontenSplit.SplitterDistance = 257;
          spcUmsatzkontenSplit.TabIndex = 0;
          // 
          // tbpMiterabeiterliste
          // 
          tbpMiterabeiterliste.Location = new System.Drawing.Point(4, 24);
          tbpMiterabeiterliste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
          tbpMiterabeiterliste.Name = "tbpMiterabeiterliste";
          tbpMiterabeiterliste.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
          tbpMiterabeiterliste.Size = new System.Drawing.Size(1256, 681);
          tbpMiterabeiterliste.TabIndex = 3;
          tbpMiterabeiterliste.Text = "Mitarbeiter";
          tbpMiterabeiterliste.UseVisualStyleBackColor = true;
          // 
          // MainForm
          // 
          AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
          AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          ClientSize = new System.Drawing.Size(1264, 709);
          Controls.Add(tbc);
          Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
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
