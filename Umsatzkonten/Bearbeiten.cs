using coIT.Libraries.Toolkit.Datengrundlagen.Konten;

namespace coIT.Lexoffice.GdiExport.Umsatzkonten
{
    internal partial class Bearbeiten : Form
    {
        internal Bearbeiten(KontoDetails kontoDetails, List<int> benutzteKontonummern)
        {
            InitializeComponent();
            KontoDetails = kontoDetails;
            BenutzteKontonummern = benutzteKontonummern;
        }

        private List<int> BenutzteKontonummern { get; }

        private KontoDetails KontoDetails { get; }

        private void FormEditAccount_Load(object sender, EventArgs e)
        {
            ctrl_Kontoname.Text = KontoDetails.KontoName;
            nbx_Kontonummer.Value = KontoDetails.KontoNummer;
            nbx_KalkulatorischesKonto.Text = KontoDetails.KalkulatorischesKonto.ToString();
            ctrl_Geschäftssparte.Text = KontoDetails.Geschäftssparte;
            cb_IstBeratung.Checked = KontoDetails.IstBeratung;
            cb_IstAbrechenbar.Checked = KontoDetails.IstAbrechenbar;
            ctrl_SteuerlicherHinweis.Text = KontoDetails.SteuerlicherHinweis;
            nbx_Steuerschlüssel.Value = KontoDetails.Steuerschlüssel;
            nbx_Steuerrate.Value = (decimal)KontoDetails.Steuerrate;
        }

        private bool ÄnderungSindValide()
        {
            return !BenutzteKontonummern.Contains((int)nbx_Kontonummer.Value);
        }

        private void SpeichereÄnderungen()
        {
            KontoDetails.KontoName = ctrl_Kontoname.Text;
            KontoDetails.KontoNummer = (int)nbx_Kontonummer.Value;
            KontoDetails.KalkulatorischesKonto = (int)nbx_KalkulatorischesKonto.Value;
            KontoDetails.Geschäftssparte = ctrl_Geschäftssparte.Text;
            KontoDetails.IstBeratung = cb_IstBeratung.Checked;
            KontoDetails.IstAbrechenbar = cb_IstAbrechenbar.Checked;
            KontoDetails.SteuerlicherHinweis = ctrl_SteuerlicherHinweis.Text;
            KontoDetails.Steuerschlüssel = (int)nbx_Steuerschlüssel.Value;
            KontoDetails.Steuerrate = (decimal)nbx_Steuerrate.Value;
        }

        private void ctrl_Speichern_Click(object sender, EventArgs e)
        {
            if (!ÄnderungSindValide())
            {
                MessageBox.Show("Die Kontonummer ist bereits in Benutzung!");
                return;
            }
            DialogResult = DialogResult.OK;
            SpeichereÄnderungen();
            Close();
        }

        private void ctrl_Abbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
