using coIT.Libraries.LexOffice.DataContracts.Country;
using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Lexoffice.GdiExport.Kundenstamm
{
    internal partial class Edit : Form
    {
        private readonly Kunde _customer;
        private readonly List<CountryInformation> _countries;

        internal Edit(Kunde customer, List<CountryInformation> countries)
        {
            InitializeComponent();
            _customer = customer;
            _countries = countries.OrderBy(country => country.Name).ToList();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            foreach (var country in _countries.Select(country => country.Name))
                cbxLand.Items.Add(country);

            tbxName.Text = _customer.DebitorName;
            nbxKundennummer.Value = _customer.Kundennummer;
            nbxDebitorennummer.Value = _customer.Debitorennummer;
            cbxKundenart.Text = _customer.Typ;

            cbxLand.Text = _customer.Land;
            tbxStraße.Text = _customer.Straße;
            tbxPostleitzahl.Text = _customer.Postleitzahl;
            tbxStadt.Text = _customer.Stadt;

            if (!_customer.LoadedFromFile)
            {
                tbxName.Enabled = false;
                tbxStraße.Enabled = false;
                tbxPostleitzahl.Enabled = false;
                tbxStadt.Enabled = false;
                cbxLand.Enabled = false;
            }
        }

        public void StoreChanges()
        {
            _customer.DebitorName = tbxName.Text;
            _customer.Kundennummer = (int)nbxKundennummer.Value;
            _customer.Debitorennummer = (int)nbxDebitorennummer.Value;
            _customer.Typ = cbxKundenart.Text;

            _customer.Land = cbxLand.Text;
            _customer.Straße = tbxStraße.Text;
            _customer.Postleitzahl = tbxPostleitzahl.Text;
            _customer.Stadt = tbxStadt.Text;
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
}
