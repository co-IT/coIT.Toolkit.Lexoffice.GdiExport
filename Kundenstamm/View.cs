using System.ComponentModel;
using coIT.Libraries.LexOffice.DataContracts.Country;
using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;
using coIT.Libraries.WinForms;
using coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;
using coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter;

namespace coIT.Lexoffice.GdiExport.Kundenstamm;

public partial class View : UserControl
{
    private readonly List<CountryInformation> _countryList;
    private readonly Leistungsempfänger _leistungsempfänger;

    private readonly KundenFilter _kundenFilter = new();

    public View(Leistungsempfänger leistungsempfänger, List<CountryInformation> countryList)
    {
        InitializeComponent();
        dgvCustomers.ConfigureWithDefaultBehaviour();

        _countryList = countryList;
        _leistungsempfänger = leistungsempfänger;
    }

    private void DebitorennummerKontrolle_Load(object sender, EventArgs e)
    {
        ListeAktualisieren();
    }

    private void ListeAktualisieren()
    {
        var liste = _leistungsempfänger.HoleKundenListe();
        var relevanteKunden = _kundenFilter.Anwenden(liste);

        dgvCustomers.DataSource = new SortableBindingList<Kunde>(relevanteKunden.ToList());
        dgvCustomers.Sort(dgvCustomers.Columns[2], ListSortDirection.Ascending);
        ÄndereDataGridÜberschriftenNamen();
    }

    private void ÄndereDataGridÜberschriftenNamen()
    {
        var viewHeaders = new List<string>
        {
            "Leistungsempfänger Nr.",
            "Leistungsempfänger Art",
            "Debitor Nr.",
            "Debitor Name",
            "Straße",
            "Postleitzahl",
            "Stadt",
            "Land",
            "Länderkürzel",
            "asdf",
            "status"
        };

        dgvCustomers.SetHeadersTo(viewHeaders);
    }

    private void dgvCustomers_DoubleClick(object sender, EventArgs e)
    {
        DataGridViewModelBinder.ExecuteWithSelectedItem<Kunde>(dgvCustomers, Bearbeiten);
    }

    private void Bearbeiten(Kunde account)
    {
        var editForm = new Edit(account, _countryList);
        var editResult = editForm.ShowDialog();

        if (editResult != DialogResult.OK)
            return;

        SpeichereÄnderungen();
        dgvCustomers.Invalidate();
    }

    private void SpeichereÄnderungen()
    {
        _leistungsempfänger.SpeichereÄnderungen();
    }

    private void tbxLeistungsempfaengerFilter_TextChanged(object sender, EventArgs e)
    {
        var aktualisierterFilter = new LeistungsempfängerFilter(tbxLeistungsempfaengerFilter.Text);
        _kundenFilter.SetzeFilter(aktualisierterFilter);

        ListeAktualisieren();
    }

    private void tbxDebitorNummerFilter_TextChanged(object sender, EventArgs e)
    {
        var aktualisierterFilter = new DebitorNummerFilter(tbxDebitorNummerFilter.Text);
        _kundenFilter.SetzeFilter(aktualisierterFilter);

        ListeAktualisieren();
    }

    private void tbxDebitorNameFilter_TextChanged(object sender, EventArgs e)
    {
        var aktualisierterFilter = new DebitorNameFilter(tbxDebitorNameFilter.Text);
        _kundenFilter.SetzeFilter(aktualisierterFilter);

        ListeAktualisieren();
    }
}
