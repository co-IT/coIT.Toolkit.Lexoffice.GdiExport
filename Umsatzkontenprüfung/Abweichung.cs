namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung
{
    public record struct Abweichung(string Ergebnis, string Rechnungsnr, string Fehler)
    {
        public static Abweichung NurInBuchungenVorhanden(string rechnungsnr)
        {
            var ergebnis = "Rechnung fehlt";
            var fehler = "Nur in Buchungen vorhanden, fehlt in Lexoffice";
            return new Abweichung(ergebnis, rechnungsnr, fehler);
        }

        public static Abweichung NichtInBuchungenVorhanden(string rechnungsnr)
        {
            var ergebnis = "Buchung fehlt";
            var fehler = "Die Rechnung wurde noch nicht gebucht.";
            return new Abweichung(ergebnis, rechnungsnr, fehler);
        }

        public static Abweichung AbweichungGefunden(VersendeteRechnung rechnung, string fehler)
        {
            return new Abweichung("Abweichung festgestellt", rechnung.Nummer, fehler);
        }
    }
}
