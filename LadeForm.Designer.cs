namespace coIT.Toolkit.Lexoffice.GdiExport
{
    partial class LadeForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LadeForm));
          progressBar1 = new System.Windows.Forms.ProgressBar();
          lblStatus = new System.Windows.Forms.Label();
          SuspendLayout();
          // 
          // progressBar1
          // 
          progressBar1.Location = new System.Drawing.Point(12, 65);
          progressBar1.Name = "progressBar1";
          progressBar1.Size = new System.Drawing.Size(218, 23);
          progressBar1.TabIndex = 0;
          // 
          // lblStatus
          // 
          lblStatus.Location = new System.Drawing.Point(12, 9);
          lblStatus.Name = "lblStatus";
          lblStatus.Size = new System.Drawing.Size(224, 39);
          lblStatus.TabIndex = 1;
          lblStatus.Text = "label1";
          lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
          // 
          // LadeForm
          // 
          AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
          AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          BackColor = System.Drawing.SystemColors.ControlDark;
          ClientSize = new System.Drawing.Size(247, 103);
          Controls.Add(lblStatus);
          Controls.Add(progressBar1);
          FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
          MaximizeBox = false;
          MinimizeBox = false;
          ShowInTaskbar = false;
          StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          Text = "Bitte warten";
          TopMost = true;
          ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblStatus;
    }
}
