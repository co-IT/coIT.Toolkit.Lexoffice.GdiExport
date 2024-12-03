using coIT.Libraries.LexOffice.DataContracts.Country;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;

internal partial class Edit : Form
{
  private readonly List<CountryInformation> _countries;
  public KundeRelation Customer;

  internal Edit(KundeRelation customer, List<CountryInformation> countries)
  {
    InitializeComponent();
    Customer = customer;
    _countries = countries.OrderBy(country => country.Name).ToList();
  }

  private void Edit_Load(object sender, EventArgs e)
  {
    foreach (var country in _countries.Select(country => country.Name))
      cbxLand.Items.Add(country);

    tbxName.Text = Customer.DebitorName;
    nbxKundennummer.Value = Customer.Kundennummer;
    nbxDebitorennummer.Value = Customer.DebitorenNummer;
    cbxKundenart.Text = Customer.Typ;

    cbxLand.Text = Customer.Land;
    tbxStraße.Text = Customer.Straße;
    tbxPostleitzahl.Text = Customer.Postleitzahl;
    tbxStadt.Text = Customer.Stadt;
  }

  private void StoreChanges()
  {
    Customer = Customer with
    {
      DebitorName = tbxName.Text,
      Kundennummer = (int)nbxKundennummer.Value,
      DebitorenNummer = (int)nbxDebitorennummer.Value,
      Typ = cbxKundenart.Text,

      Land = cbxLand.Text,
      Straße = tbxStraße.Text,
      Postleitzahl = tbxPostleitzahl.Text,
      Stadt = tbxStadt.Text,
    };
  }

  private void btnSave_Click(object sender, EventArgs e)
  {
    DialogResult = DialogResult.OK;
    StoreChanges();
    Close();
  }

  private void btnAbort_Click(object sender, EventArgs e)
  {
    DialogResult = DialogResult.Abort;
    Close();
  }
}
