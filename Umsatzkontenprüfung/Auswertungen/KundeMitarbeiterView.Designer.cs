namespace coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen
{
    partial class KundeMitarbeiterView
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
            treeGridView = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView();
            ((System.ComponentModel.ISupportInitialize)treeGridView).BeginInit();
            SuspendLayout();
            // 
            // treeGridView
            // 
            treeGridView.AllowUserToAddRows = false;
            treeGridView.AllowUserToDeleteRows = false;
            treeGridView.BorderStyle = BorderStyle.None;
            treeGridView.DataSource = null;
            treeGridView.Dock = DockStyle.Fill;
            treeGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            treeGridView.ImageList = null;
            treeGridView.Location = new Point(0, 0);
            treeGridView.Name = "treeGridView";
            treeGridView.Size = new Size(781, 544);
            treeGridView.TabIndex = 0;
            // 
            // UmsatzkontoKundeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(treeGridView);
            Name = "UmsatzkontoKundeView";
            Size = new Size(781, 544);
            ((System.ComponentModel.ISupportInitialize)treeGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView treeGridView;
    }
}
