namespace coIT.Lexoffice.GdiExport.Kundenstamm
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.tbxDebitorNameFilter = new System.Windows.Forms.TextBox();
            this.tbxDebitorNummerFilter = new System.Windows.Forms.TextBox();
            this.tbxLeistungsempfaengerFilter = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.gbxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 29;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1280, 665);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.DoubleClick += new System.EventHandler(this.dgvCustomers_DoubleClick);
            // 
            // gbxFilter
            // 
            this.gbxFilter.Controls.Add(this.tbxDebitorNameFilter);
            this.gbxFilter.Controls.Add(this.tbxDebitorNummerFilter);
            this.gbxFilter.Controls.Add(this.tbxLeistungsempfaengerFilter);
            this.gbxFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxFilter.Location = new System.Drawing.Point(0, 0);
            this.gbxFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxFilter.Size = new System.Drawing.Size(1280, 51);
            this.gbxFilter.TabIndex = 1;
            this.gbxFilter.TabStop = false;
            this.gbxFilter.Text = "Filter";
            // 
            // tbxDebitorNameFilter
            // 
            this.tbxDebitorNameFilter.Location = new System.Drawing.Point(439, 21);
            this.tbxDebitorNameFilter.Name = "tbxDebitorNameFilter";
            this.tbxDebitorNameFilter.Size = new System.Drawing.Size(134, 23);
            this.tbxDebitorNameFilter.TabIndex = 2;
            this.tbxDebitorNameFilter.TextChanged += new System.EventHandler(this.tbxDebitorNameFilter_TextChanged);
            // 
            // tbxDebitorNummerFilter
            // 
            this.tbxDebitorNummerFilter.Location = new System.Drawing.Point(303, 21);
            this.tbxDebitorNummerFilter.Name = "tbxDebitorNummerFilter";
            this.tbxDebitorNummerFilter.Size = new System.Drawing.Size(130, 23);
            this.tbxDebitorNummerFilter.TabIndex = 1;
            this.tbxDebitorNummerFilter.TextChanged += new System.EventHandler(this.tbxDebitorNummerFilter_TextChanged);
            // 
            // tbxLeistungsempfaengerFilter
            // 
            this.tbxLeistungsempfaengerFilter.Location = new System.Drawing.Point(45, 21);
            this.tbxLeistungsempfaengerFilter.Name = "tbxLeistungsempfaengerFilter";
            this.tbxLeistungsempfaengerFilter.Size = new System.Drawing.Size(129, 23);
            this.tbxLeistungsempfaengerFilter.TabIndex = 0;
            this.tbxLeistungsempfaengerFilter.TextChanged += new System.EventHandler(this.tbxLeistungsempfaengerFilter_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbxFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCustomers);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 720);
            this.splitContainer1.SplitterDistance = 51;
            this.splitContainer1.TabIndex = 2;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "View";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.DebitorennummerKontrolle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvCustomers;
        private GroupBox gbxFilter;
        private SplitContainer splitContainer1;
        private TextBox tbxDebitorNameFilter;
        private TextBox tbxDebitorNummerFilter;
        private TextBox tbxLeistungsempfaengerFilter;
    }
}
