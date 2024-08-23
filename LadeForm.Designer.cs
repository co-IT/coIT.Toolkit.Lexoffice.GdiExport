namespace coIT.Clockodo.QuickActions
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
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 65);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(218, 23);
            progressBar1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(224, 39);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "label1";
            lblStatus.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LadeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(247, 103);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LadeForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bitte warten";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblStatus;
    }
}
