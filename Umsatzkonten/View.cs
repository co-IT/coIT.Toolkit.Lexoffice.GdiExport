using coIT.Libraries.Toolkit.Datengrundlagen.Umsatzkonten;
using coIT.Libraries.WinForms;

namespace coIT.Toolkit.Lexoffice.GdiExport.Umsatzkonten;

public partial class View : UserControl
{
  private readonly IKontoRepository _repository;
  private SortableBindingList<Umsatzkonto> _kontoDetailListe;

  internal View(IKontoRepository kontoRepository)
  {
    InitializeComponent();
    dgvAccounts.ConfigureWithDefaultBehaviour();
    _repository = kontoRepository;
  }

  private async void AccountControl_Load(object sender, EventArgs e)
  {
    var debitorDetailsList = (await _repository.GetAll()).Value;
    _kontoDetailListe = new SortableBindingList<Umsatzkonto>(debitorDetailsList.ToList());
    dgvAccounts.DataSource = _kontoDetailListe;
    dgvAccounts.AutoGenerateColumns = false;
    SetzeÜberschriften();
  }

  private void SetzeÜberschriften()
  {
    dgvAccounts.Columns.Remove("Id");
    dgvAccounts.Columns.Remove("Timestamp");
    dgvAccounts.Columns.Remove("ETag");

    var ÜberschriftenListe = new List<string>
    {
      "Kontoname",
      "Kontonummer",
      "Kalkulatorisches Konto",
      "Geschäftssparte",
      "Ist Beratung",
      "Ist Abrechenbar",
      "Steuerlicher Hinweis",
      "Steuerschlüssel",
      "Steuerrate",
    };

    dgvAccounts.SetHeadersTo(ÜberschriftenListe);
  }

  private void dgvAccounts_DoubleClick(object sender, EventArgs e)
  {
    dgvAccounts.ExecuteWithSelectedItem<Umsatzkonto>(x => Bearbeiten(x));
  }

  private async Task Bearbeiten(Umsatzkonto konto)
  {
    var otherAccountNumbers = _kontoDetailListe
      .Where(kontoDetails => kontoDetails != konto)
      .Select(account => account.KontoNummer)
      .ToList();

    var editForm = new Bearbeiten(konto, otherAccountNumbers);
    var editResult = editForm.ShowDialog();

    if (editResult != DialogResult.OK)
      return;

    var updatedKonto = editForm.KontoDetails;

    var upsertResult = await _repository.UpsertAsync(updatedKonto);

    if (upsertResult.IsFailure)
    {
      MessageBox.Show(upsertResult.Error);
      return;
    }

    var index = _kontoDetailListe.IndexOf(konto);
    _kontoDetailListe[index] = updatedKonto;

    dgvAccounts.Invalidate();
  }
}
