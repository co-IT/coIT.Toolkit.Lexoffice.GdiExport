namespace coIT.Lexoffice.GdiExport
{
    public partial class CreateCredentials : Form
    {
        public Konfiguration Konfiguration { get; set; }
        public string Kundenstamm { get; internal set; }
        public string Umsatzkonten { get; internal set; }
        public string Mitarbeiter { get; internal set; }

        public CreateCredentials()
        {
            InitializeComponent();
        }

        private void btnCreateConfig_Click(object sender, EventArgs e)
        {
            var clockodoMail = tbxClockodoEmail.Text;
            var clockodoToken = tbxClockodoToken.Text;
            var lexofficeToken = tbxLexofficeKey.Text;

            Kundenstamm = tbxKundenstamm.Text;
            Umsatzkonten = tbxUmsatzkonten.Text;
            Mitarbeiter = tbxMitarbeiter.Text;

            Konfiguration = new Konfiguration(lexofficeToken, clockodoMail, clockodoToken);
            Close();
        }

        private void btnKundenstamm_Click(object sender, EventArgs e)
        {
            TextBoxSelectorKomboHandlen(dlgKundenstamm, tbxKundenstamm);
        }

        private void btnUmsatzkonten_Click(object sender, EventArgs e)
        {
            TextBoxSelectorKomboHandlen(dlgUmsatzkonten, tbxUmsatzkonten);
        }

        private void btnMitarbeiter_Click(object sender, EventArgs e)
        {
            TextBoxSelectorKomboHandlen(dlgMitarbeiter, tbxMitarbeiter);
        }

        private void TextBoxSelectorKomboHandlen(OpenFileDialog dialog, TextBox box)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = dialog.FileName;
                box.Text = filePath;
            }
        }
    }
}
