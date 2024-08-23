using coIT.Libraries.Toolkit.Datengrundlagen.Konten;
using coIT.Libraries.WinForms;
using coIT.Toolkit.Lexoffice.GdiExport.Helpers;

namespace coIT.Lexoffice.GdiExport.Umsatzkonten;

public partial class View : UserControl
{
    private SortableBindingList<KontoDetails> _kontoDetailListe;
    private readonly JsonRepository<KontoDetails> _repository;

    internal View(JsonRepository<KontoDetails> kontoRepository)
    {
        InitializeComponent();
        dgvAccounts.ConfigureWithDefaultBehaviour();
        _repository = kontoRepository;
    }

    private async void AccountControl_Load(object sender, EventArgs e)
    {
        var debitorDetailsList = await _repository.List();
        _kontoDetailListe = new SortableBindingList<KontoDetails>(debitorDetailsList);
        dgvAccounts.DataSource = _kontoDetailListe;
        SetzeÜberschriften();
    }

    private void SetzeÜberschriften()
    {
        var ÜberschriftenListe = new List<string>()
        {
            "Kontoname",
            "Kontonummer",
            "Kalkulatorisches Konto",
            "Geschäftssparte",
            "Ist Beratung",
            "Ist Abrechenbar",
            "Steuerlicher Hinweis",
            "Steuerschlüssel",
            "Steuerrate"
        };

        dgvAccounts.SetHeadersTo(ÜberschriftenListe);
    }

    private void dgvAccounts_DoubleClick(object sender, EventArgs e)
    {
        dgvAccounts.ExecuteWithSelectedItem<KontoDetails>(Bearbeiten);
    }

    private void Bearbeiten(KontoDetails konto)
    {
        var otherAccountNumbers = _kontoDetailListe
            .Where(kontoDetails => kontoDetails != konto)
            .Select(account => account.KontoNummer)
            .ToList();

        var editForm = new Bearbeiten(konto, otherAccountNumbers);
        var editResult = editForm.ShowDialog();

        if (editResult != DialogResult.OK)
            return;

        SpeicherÄnderungen();
        dgvAccounts.Invalidate();
    }

    private void SpeicherÄnderungen()
    {
        var aenderungen = dgvAccounts.BindList<KontoDetails>();

        _repository.Save(aenderungen);
    }
}
