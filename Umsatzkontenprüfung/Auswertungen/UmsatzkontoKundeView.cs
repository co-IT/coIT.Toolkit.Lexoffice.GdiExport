using CSharpFunctionalExtensions;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.TreeGridView;

namespace coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen
{
    public partial class UmsatzkontoKundeView : UserControl
    {
        public UmsatzkontoKundeView()
        {
            InitializeComponent();

            treeGridView.Columns.AddRange(
                [
                    new KryptonTreeGridColumn()
                    {
                        HeaderText = "Konto",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    },
                    new KryptonDataGridViewTextBoxColumn()
                    {
                        HeaderText = "Kunde",
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
                .GroupBy(zeile => new { zeile.Kundenname, zeile.Umsatzkonto })
                .GroupBy(zeile => zeile.Key.Umsatzkonto);

            foreach (var konto in gruppierteRechnungen.OrderBy(konten => konten.Key))
            {
                var kontoNode = treeGridView.GridNodes.Add(konto.Key, "", "", "");
                var kontoSumme = 0m;

                foreach (var kunde in konto.OrderBy(kunden => kunden.Key.Kundenname))
                {
                    var kundeNode = kontoNode.Nodes.Add("", kunde.Key.Kundenname, "", "");
                    var kundeSumme = 0m;

                    foreach (var rechnung in kunde.OrderBy(rechnungen => rechnungen.Nummer))
                    {
                        var rechnungNode = kundeNode.Nodes.Add(
                            "",
                            "",
                            rechnung.Nummer,
                            rechnung.Netto.ToString("C")
                        );

                        kontoSumme += rechnung.Netto;
                        kundeSumme += rechnung.Netto;
                    }

                    kundeNode.Cells[2].Value = kundeSumme.ToString("C");
                    ZelleFettMarkieren(kundeNode.Cells[2]);
                }
                kontoNode.Cells[1].Value = kontoSumme.ToString("C");
                ZelleFettMarkieren(kontoNode.Cells[1]);
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
