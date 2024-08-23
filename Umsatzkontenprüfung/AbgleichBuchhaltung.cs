using coIT.Libraries.Gdi.Accounting.Contracts;

namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung
{
    public class AbgleichBuchhaltung
    {
        public static IList<Abweichung> FindeAbweichungenZuRechnungen(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            var abweichungen = new List<Abweichung>();

            abweichungen.AddRange(FehlendeBuchungen(buchungen, rechnungen));
            abweichungen.AddRange(FehlendeRechnungen(buchungen, rechnungen));
            abweichungen.AddRange(UngleicheWerte(buchungen, rechnungen));

            return abweichungen;
        }

        private static IEnumerable<Abweichung> UngleicheWerte(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            var fehlendeBuchungen = FehlendeBuchungenErmitteln(buchungen, rechnungen);
            var gebuchteRechnungen = rechnungen.Except(fehlendeBuchungen).ToList();

            return RechnungenMitAbweichendenWertenErmitteln(buchungen, gebuchteRechnungen);
        }

        private static IEnumerable<Abweichung> FehlendeRechnungen(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            return InRechnungenFehlendeBuchungenErmitteln(buchungen, rechnungen)
                .Select(b => Abweichung.NurInBuchungenVorhanden(b.InvoiceNumber));
        }

        private static IEnumerable<Abweichung> FehlendeBuchungen(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            return FehlendeBuchungenErmitteln(buchungen, rechnungen)
                .Select(b => Abweichung.NichtInBuchungenVorhanden(b.Nummer));
        }

        private static List<SaleBooking> InRechnungenFehlendeBuchungenErmitteln(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            return buchungen
                .Where(buchung =>
                    !rechnungen.Any(rechnung => rechnung.Nummer == buchung.InvoiceNumber)
                )
                .ToList();
        }

        private static IEnumerable<Abweichung> RechnungenMitAbweichendenWertenErmitteln(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            foreach (var rechnung in rechnungen)
            {
                var buchung = buchungen.Single(buchung => buchung.InvoiceNumber == rechnung.Nummer);
                var abgleichungsergebnis = rechnung.MitBuchungAbgleichen(buchung);

                if (abgleichungsergebnis.IsFailure)
                    yield return Abweichung.AbweichungGefunden(
                        rechnung,
                        abgleichungsergebnis.Error
                    );
            }
        }

        private static List<VersendeteRechnung> FehlendeBuchungenErmitteln(
            IList<SaleBooking> buchungen,
            IList<VersendeteRechnung> rechnungen
        )
        {
            return rechnungen
                .Where(rechnung =>
                    !buchungen.Any(buchung => buchung.InvoiceNumber == rechnung.Nummer)
                )
                .ToList();
        }
    }
}
