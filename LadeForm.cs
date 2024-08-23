namespace coIT.Clockodo.QuickActions
{
    public partial class LadeForm : Form
    {
        private readonly string _text;

        public LadeForm(Progress<float> progress, string label)
        {
            InitializeComponent();

            SetLabelText(0);

            progress.ProgressChanged += SetProgressBar;
            _text = label;
        }

        private void SetProgressBar(object? sender, float e)
        {
            var prozent = Math.Round(e, 4);
            SetLabelText(prozent);

            progressBar1.Value = (int)Math.Floor(prozent * 100);

            if (e >= 1)
                Close();
        }

        private void SetLabelText(double prozent)
        {
            lblStatus.Text = $"{_text} - {prozent:p}";
        }
    }
}
