using System.ComponentModel;
using Azure;
using coIT.Libraries.LexOffice.DataContracts.Country;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;
using coIT.Libraries.WinForms;
using coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm.Filter;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;

public partial class View : UserControl
{
  private readonly List<CountryInformation> _countryList;

  private readonly KundenFilter _kundenFilter = new();
  private readonly Leistungsempfänger _leistungsempfänger;
  private SortableBindingList<KundeRelation> _kundenList;

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
    ÄndereDataGridÜberschriftenNamen();
  }

  private void ListeAktualisieren()
  {
    var liste = _leistungsempfänger.HoleKundenListe();
    var relevanteKunden = _kundenFilter.Anwenden(liste);
    _kundenList = new SortableBindingList<KundeRelation>(relevanteKunden.ToList());
    dgvCustomers.DataSource = _kundenList;

    dgvCustomers.AutoGenerateColumns = false;
    dgvCustomers.Sort(dgvCustomers.Columns[2], ListSortDirection.Ascending);
  }

  private void ÄndereDataGridÜberschriftenNamen()
  {
    dgvCustomers.Columns.Remove("Id");
    dgvCustomers.Columns.Remove("ETag");
    dgvCustomers.Columns.Remove("Timestamp");

    var viewHeaders = new List<string>
    {
      "Kundennr.",
      "Debitor Nr.",
      "Debitor Name",
      "Straße",
      "Postleitzahl",
      "Stadt",
      "Land",
      "Länderkürzel",
      "Typ",
      "Steuerklassifizierung",
    };

    dgvCustomers.SetHeadersTo(viewHeaders);
  }

  private void dgvCustomers_DoubleClick(object sender, EventArgs e)
  {
    dgvCustomers.ExecuteWithSelectedItem<KundeRelation>(kunde => Bearbeiten(kunde));
  }

  private async Task Bearbeiten(KundeRelation account)
  {
    var editForm = new Edit(account, _countryList);
    var editResult = editForm.ShowDialog();

    if (editResult != DialogResult.OK)
      return;

    var updatedCustomer = editForm.Customer with { ETag = ETag.All, Timestamp = DateTimeOffset.Now };

    var updateResult = await _leistungsempfänger.UpdateKunde(updatedCustomer);

    if (updateResult.IsFailure)
    {
      MessageBox.Show(updateResult.Error);
      return;
    }

    var index = _kundenList.IndexOf(account);
    _kundenList[index] = updatedCustomer;

    dgvCustomers.Invalidate();
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
