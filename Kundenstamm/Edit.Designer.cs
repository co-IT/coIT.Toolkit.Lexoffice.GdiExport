namespace coIT.Lexoffice.GdiExport.Kundenstamm
{
    partial class Edit
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
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.gbxAddressData = new System.Windows.Forms.GroupBox();
            this.tbxPostleitzahl = new System.Windows.Forms.TextBox();
            this.cbxLand = new System.Windows.Forms.ComboBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.tbxStadt = new System.Windows.Forms.TextBox();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.tbxStraße = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.gbxCustomerData = new System.Windows.Forms.GroupBox();
            this.nbxDebitorennummer = new System.Windows.Forms.NumericUpDown();
            this.nbxKundennummer = new System.Windows.Forms.NumericUpDown();
            this.cbxKundenart = new System.Windows.Forms.ComboBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblDebitorNumber = new System.Windows.Forms.Label();
            this.lblCustomerNumber = new System.Windows.Forms.Label();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.gbxAddressData.SuspendLayout();
            this.gbxCustomerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxDebitorennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxKundennummer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(356, 384);
            this.btnSpeichern.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(82, 22);
            this.btnSpeichern.TabIndex = 3;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxAddressData
            // 
            this.gbxAddressData.Controls.Add(this.tbxPostleitzahl);
            this.gbxAddressData.Controls.Add(this.cbxLand);
            this.gbxAddressData.Controls.Add(this.lblStreet);
            this.gbxAddressData.Controls.Add(this.tbxStadt);
            this.gbxAddressData.Controls.Add(this.lblZipCode);
            this.gbxAddressData.Controls.Add(this.lblCity);
            this.gbxAddressData.Controls.Add(this.tbxStraße);
            this.gbxAddressData.Controls.Add(this.lblCountry);
            this.gbxAddressData.Location = new System.Drawing.Point(27, 202);
            this.gbxAddressData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxAddressData.Name = "gbxAddressData";
            this.gbxAddressData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxAddressData.Size = new System.Drawing.Size(411, 168);
            this.gbxAddressData.TabIndex = 4;
            this.gbxAddressData.TabStop = false;
            this.gbxAddressData.Text = "Adressinformationen";
            // 
            // tbxPostleitzahl
            // 
            this.tbxPostleitzahl.Location = new System.Drawing.Point(147, 64);
            this.tbxPostleitzahl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxPostleitzahl.Name = "tbxPostleitzahl";
            this.tbxPostleitzahl.Size = new System.Drawing.Size(238, 23);
            this.tbxPostleitzahl.TabIndex = 24;
            // 
            // cbxLand
            // 
            this.cbxLand.FormattingEnabled = true;
            this.cbxLand.Location = new System.Drawing.Point(147, 131);
            this.cbxLand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxLand.Name = "cbxLand";
            this.cbxLand.Size = new System.Drawing.Size(238, 23);
            this.cbxLand.TabIndex = 21;
            // 
            // lblStreet
            // 
            this.lblStreet.Location = new System.Drawing.Point(18, 32);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(123, 19);
            this.lblStreet.TabIndex = 16;
            this.lblStreet.Text = "Straße:";
            // 
            // tbxStadt
            // 
            this.tbxStadt.Location = new System.Drawing.Point(147, 98);
            this.tbxStadt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxStadt.Name = "tbxStadt";
            this.tbxStadt.Size = new System.Drawing.Size(238, 23);
            this.tbxStadt.TabIndex = 20;
            // 
            // lblZipCode
            // 
            this.lblZipCode.Location = new System.Drawing.Point(18, 66);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(123, 19);
            this.lblZipCode.TabIndex = 14;
            this.lblZipCode.Text = "Postleitzahl:";
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(18, 100);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(123, 19);
            this.lblCity.TabIndex = 15;
            this.lblCity.Text = "Stadt:";
            // 
            // tbxStraße
            // 
            this.tbxStraße.Location = new System.Drawing.Point(147, 30);
            this.tbxStraße.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxStraße.Name = "tbxStraße";
            this.tbxStraße.Size = new System.Drawing.Size(238, 23);
            this.tbxStraße.TabIndex = 18;
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(18, 134);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(123, 19);
            this.lblCountry.TabIndex = 17;
            this.lblCountry.Text = "Land:";
            // 
            // gbxCustomerData
            // 
            this.gbxCustomerData.Controls.Add(this.nbxDebitorennummer);
            this.gbxCustomerData.Controls.Add(this.nbxKundennummer);
            this.gbxCustomerData.Controls.Add(this.cbxKundenart);
            this.gbxCustomerData.Controls.Add(this.tbxName);
            this.gbxCustomerData.Controls.Add(this.lblCustomerType);
            this.gbxCustomerData.Controls.Add(this.lblCustomerName);
            this.gbxCustomerData.Controls.Add(this.lblDebitorNumber);
            this.gbxCustomerData.Controls.Add(this.lblCustomerNumber);
            this.gbxCustomerData.Location = new System.Drawing.Point(27, 20);
            this.gbxCustomerData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxCustomerData.Name = "gbxCustomerData";
            this.gbxCustomerData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxCustomerData.Size = new System.Drawing.Size(411, 178);
            this.gbxCustomerData.TabIndex = 5;
            this.gbxCustomerData.TabStop = false;
            this.gbxCustomerData.Text = "Kundeninformationen";
            // 
            // nbxDebitorennummer
            // 
            this.nbxDebitorennummer.Location = new System.Drawing.Point(147, 101);
            this.nbxDebitorennummer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbxDebitorennummer.Maximum = new decimal(new int[] {
            54000,
            0,
            0,
            0});
            this.nbxDebitorennummer.Name = "nbxDebitorennummer";
            this.nbxDebitorennummer.Size = new System.Drawing.Size(237, 23);
            this.nbxDebitorennummer.TabIndex = 15;
            this.nbxDebitorennummer.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // nbxKundennummer
            // 
            this.nbxKundennummer.Enabled = false;
            this.nbxKundennummer.Location = new System.Drawing.Point(147, 68);
            this.nbxKundennummer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbxKundennummer.Maximum = new decimal(new int[] {
            1000000100,
            0,
            0,
            0});
            this.nbxKundennummer.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nbxKundennummer.Name = "nbxKundennummer";
            this.nbxKundennummer.Size = new System.Drawing.Size(237, 23);
            this.nbxKundennummer.TabIndex = 14;
            this.nbxKundennummer.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // cbxKundenart
            // 
            this.cbxKundenart.FormattingEnabled = true;
            this.cbxKundenart.Items.AddRange(new object[] {
            "Mart",
            "Verbund",
            "Intern"});
            this.cbxKundenart.Location = new System.Drawing.Point(147, 134);
            this.cbxKundenart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxKundenart.Name = "cbxKundenart";
            this.cbxKundenart.Size = new System.Drawing.Size(238, 23);
            this.cbxKundenart.TabIndex = 13;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(147, 34);
            this.tbxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(238, 23);
            this.tbxName.TabIndex = 10;
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.Location = new System.Drawing.Point(18, 136);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(133, 19);
            this.lblCustomerType.TabIndex = 9;
            this.lblCustomerType.Text = "Kundenart:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Location = new System.Drawing.Point(18, 37);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(133, 19);
            this.lblCustomerName.TabIndex = 8;
            this.lblCustomerName.Text = "Name:";
            // 
            // lblDebitorNumber
            // 
            this.lblDebitorNumber.Location = new System.Drawing.Point(18, 103);
            this.lblDebitorNumber.Name = "lblDebitorNumber";
            this.lblDebitorNumber.Size = new System.Drawing.Size(133, 19);
            this.lblDebitorNumber.TabIndex = 7;
            this.lblDebitorNumber.Text = "Debitorennummer:";
            // 
            // lblCustomerNumber
            // 
            this.lblCustomerNumber.Location = new System.Drawing.Point(18, 70);
            this.lblCustomerNumber.Name = "lblCustomerNumber";
            this.lblCustomerNumber.Size = new System.Drawing.Size(133, 19);
            this.lblCustomerNumber.TabIndex = 6;
            this.lblCustomerNumber.Text = "Kundennummer:";
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Location = new System.Drawing.Point(269, 384);
            this.btnAbbrechen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(82, 22);
            this.btnAbbrechen.TabIndex = 6;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 417);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.gbxCustomerData);
            this.Controls.Add(this.gbxAddressData);
            this.Controls.Add(this.btnSpeichern);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kundeneditieren";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.gbxAddressData.ResumeLayout(false);
            this.gbxAddressData.PerformLayout();
            this.gbxCustomerData.ResumeLayout(false);
            this.gbxCustomerData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxDebitorennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbxKundennummer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnSpeichern;
        private GroupBox gbxAddressData;
        private GroupBox gbxCustomerData;
        private ComboBox cbxKundenart;
        private TextBox tbxName;
        private Label lblCustomerType;
        private Label lblCustomerName;
        private Label lblDebitorNumber;
        private Label lblCustomerNumber;
        private ComboBox cbxLand;
        private Label lblStreet;
        private TextBox tbxStadt;
        private Label lblZipCode;
        private Label lblCity;
        private TextBox tbxStraße;
        private Label lblCountry;
        private NumericUpDown nbxDebitorennummer;
        private NumericUpDown nbxKundennummer;
        private TextBox tbxPostleitzahl;
        private Button btnAbbrechen;
    }
}