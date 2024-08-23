using System.Text;
using coIT.Libraries.Gdi.Accounting.Contracts;
using CSharpFunctionalExtensions;

namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung
{
    public class VersendeteRechnung
    {
        public DateOnly Datum { get; set; }
        public int Umsatzkonto { get; set; }
        public string Kundenname { get; set; }
        public string Nummer { get; set; }
        public decimal Netto { get; set; }
        public decimal Brutto { get; set; }
        public int KundennameLänge { get; set; }

        public override string ToString()
        {
            return $"{Nummer}      {Datum}      "
                + $"{Kundenname.PadRight(KundennameLänge + 3)}      "
                + $"{Netto, 12:C2}      ({Brutto, 12:C2})";
        }

        public Result MitBuchungAbgleichen(SaleBooking buchung)
        {
            if (
                !Nummer
                    .Trim()
                    .Equals(
                        buchung.InvoiceNumber.Trim(),
                        StringComparison.InvariantCultureIgnoreCase
                    )
            )
                throw new ArgumentException(
                    $"Ungültiger Vergleich zwischen Buchung und Rechnung da unterschiedliche Dokumentennummern: {Nummer} vs. {buchung.InvoiceNumber}"
                );

            var ergebnis = new StringBuilder();

            if (Umsatzkonto != buchung.AccountNumber)
                ergebnis.AppendLine(
                    $"Unterschiedliche Umsatzkonten: {Umsatzkonto} vs. {buchung.AccountNumber}"
                );

            if (Netto != buchung.NetValue)
                ergebnis.AppendLine($"Unterschiedliche Beträge: {Netto} vs. {buchung.NetValue}");

            if (Datum != buchung.Date)
                ergebnis.AppendLine(
                    $"Unterschiedliche Datumsangaben: {Datum.ToShortDateString()} vs. {buchung.Date.ToShortDateString()}"
                );

            return Result.SuccessIf(ergebnis.Length == 0, ergebnis.ToString());
        }
    }
}
