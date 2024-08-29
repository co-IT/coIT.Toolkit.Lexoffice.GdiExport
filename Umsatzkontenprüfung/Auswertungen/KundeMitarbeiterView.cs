using coIT.Libraries.LexOffice;
using coIT.Libraries.LexOffice.DataContracts.Contacts;
using coIT.Libraries.LexOffice.DataContracts.Invoice;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using CSharpFunctionalExtensions;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.TreeGridView;

namespace coIT.Toolkit.Lexoffice.GdiExport.Umsatzkontenprüfung.Auswertungen
{
    public partial class KundeMitarbeiterView : UserControl
    {
        public KundeMitarbeiterView()
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
                        HeaderText = "Mitarbeiter",
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

        public void Aktualisieren(
            IEnumerable<Invoice> rechnungen,
            List<ContactInformation> kunden,
            MitarbeiterListe mitarbeiterListe
        )
        {
            if (treeGridView.InvokeRequired)
            {
                Action sichererAufruf = delegate
                {
                    Aktualisieren(rechnungen, kunden, mitarbeiterListe);
                };
                treeGridView.Invoke(sichererAufruf);
                return;
            }

            var gruppierteRechnungszeilen = ErweiterteRechnungszeilenBerechnen(
                    rechnungen,
                    kunden,
                    mitarbeiterListe
                )
                .GroupBy(zeile => new { zeile.Mitarbeiter, zeile.Kunde })
                .GroupBy(zeile => zeile.Key.Kunde);

            foreach (var kunde in gruppierteRechnungszeilen.OrderBy(kunden => kunden.Key))
            {
                var kundenNode = treeGridView.GridNodes.Add(kunde.Key, "", "", "");
                var kundenSumme = 0m;

                foreach (var mitarbeiter in kunde.OrderBy(kunden => kunden.Key.Mitarbeiter))
                {
                    var mitarbeiterNode = kundenNode.Nodes.Add(
                        "",
                        mitarbeiter.Key.Mitarbeiter,
                        "",
                        ""
                    );
                    var mitarbeiterSumme = 0m;

                    foreach (
                        var rechnung in mitarbeiter.OrderBy(rechnungen =>
                            rechnungen.Rechnungsnummer
                        )
                    )
                    {
                        var rechnungNode = mitarbeiterNode.Nodes.Add(
                            "",
                            "",
                            rechnung.Rechnungsnummer,
                            rechnung.Betrag.ToString("C")
                        );

                        kundenSumme += rechnung.Betrag;
                        mitarbeiterSumme += rechnung.Betrag;
                    }

                    mitarbeiterNode.Cells[2].Value = mitarbeiterSumme.ToString("C");
                    ZelleFettMarkieren(mitarbeiterNode.Cells[2]);
                }
                kundenNode.Cells[1].Value = kundenSumme.ToString("C");
                ZelleFettMarkieren(kundenNode.Cells[1]);
            }
        }

        private IEnumerable<ErweiterteRechnungszeile> ErweiterteRechnungszeilenBerechnen(
            IEnumerable<Invoice> rechnungen,
            List<ContactInformation> kunden,
            MitarbeiterListe mitarbeiterListe
        )
        {
            foreach (var rechnung in rechnungen)
            {
                var kunde = KundenNameErmitteln(kunden, rechnung);

                foreach (var zeile in rechnung.LineItems)
                {
                    var mitarbeiterNummerErgebnis = zeile.MitarbeiterErmitteln();

                    if (mitarbeiterNummerErgebnis.IsFailure)
                    {
                        MessageBox.Show(
                            $"Für Zeile '{zeile.Name}' der Rechnung {rechnung.VoucherNumber} konnte kein Mitarbeiter ermittelt werden",
                            "Hinweis",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        continue;
                    }

                    var mitarbeiter = MitarbeiterNameErmitteln(
                        mitarbeiterListe,
                        mitarbeiterNummerErgebnis.Value
                    );

                    yield return new ErweiterteRechnungszeile
                    {
                        Kunde = kunde,
                        Mitarbeiter = mitarbeiter,
                        Rechnungsnummer = rechnung.VoucherNumber,
                        Betrag = zeile.UnitPrice.NetAmount * zeile.Quantity,
                    };
                }
            }
        }

        private string MitarbeiterNameErmitteln(MitarbeiterListe mitarbeiter, int nummer)
        {
            return mitarbeiter
                    .Where(mitarbeiter => mitarbeiter.Nummer == nummer)
                    .FirstOrDefault()
                    ?.Name ?? nummer.ToString();
        }

        private string KundenNameErmitteln(List<ContactInformation> kunden, Invoice rechnung)
        {
            return kunden
                    .SingleOrDefault(kunde => kunde.Id == rechnung.Address.ContactId)
                    ?.Company?.Name ?? string.Empty;
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
