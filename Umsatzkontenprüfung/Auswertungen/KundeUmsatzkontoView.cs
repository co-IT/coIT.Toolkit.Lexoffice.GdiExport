using CSharpFunctionalExtensions;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.TreeGridView;

namespace coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen
{
    public partial class KundeUmsatzkontoView : UserControl
    {
        public KundeUmsatzkontoView()
        {
            InitializeComponent();

            treeGridView.Columns.AddRange(
                [
                    new KryptonTreeGridColumn()
                    {
                        HeaderText = "Kunde",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    },
                    new KryptonDataGridViewTextBoxColumn()
                    {
                        HeaderText = "Konto",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    },
                    new KryptonDataGridViewTextBoxColumn()
                    {
                        HeaderText = "Rechnungsnummer",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    },
                    new KryptonDataGridViewTextBoxColumn()
                    {
                        HeaderText = "Betrag",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    },
                ]
            );
        }

        public void Aktualisieren(IEnumerable<VersendeteRechnung> versendeteRechnungen)
        {
            if (treeGridView.InvokeRequired)
            {
                Action sichererAufruf = delegate
                {
                    Aktualisieren(versendeteRechnungen);
                };
                treeGridView.Invoke(sichererAufruf);
                return;
            }

            var gruppierteRechnungen = versendeteRechnungen
                .GroupBy(zeile => new { zeile.Umsatzkonto, zeile.Kundenname })
                .GroupBy(zeile => zeile.Key.Kundenname);

            foreach (var kunde in gruppierteRechnungen.OrderBy(kunden => kunden.Key))
            {
                var kundenNode = treeGridView.GridNodes.Add(kunde.Key, "", "", "");
                var kundenSumme = 0m;

                foreach (var konto in kunde.OrderBy(kunden => kunden.Key.Umsatzkonto))
                {
                    var kontoNode = kundenNode.Nodes.Add("", konto.Key.Umsatzkonto, "", "");
                    var kontoSumme = 0m;

                    foreach (var rechnung in konto.OrderBy(rechnungen => rechnungen.Nummer))
                    {
                        var rechnungNode = kontoNode.Nodes.Add(
                            "",
                            "",
                            rechnung.Nummer,
                            rechnung.Netto.ToString("C")
                        );

                        kundenSumme += rechnung.Netto;
                        kontoSumme += rechnung.Netto;
                    }

                    kontoNode.Cells[2].Value = kontoSumme.ToString("C");
                    ZelleFettMarkieren(kontoNode.Cells[2]);
                }
                kundenNode.Cells[1].Value = kundenSumme.ToString("C");
                ZelleFettMarkieren(kundenNode.Cells[1]);
            }
        }

        public void ZelleFettMarkieren(DataGridViewCell? zelle)
        {
            var schriftart = treeGridView.Font;
            var schriftartFett = new Font(schriftart.FontFamily, schriftart.Size, FontStyle.Bold);

            Maybe
                .From(zelle)
                .ToResult("Zelle war leer")
                .Tap(zelle => zelle.Style.Font = schriftartFett);
        }
    }
}
