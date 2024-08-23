using coIT.Libraries.LexOffice.DataContracts.Contacts;
using LexOfficeInvoice = coIT.Libraries.LexOffice.DataContracts.Invoice.Invoice;

namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung.LexofficeCaching
{
    public interface IchCacheLexofficeAbfragen
    {
        public Task<List<LexOfficeInvoice>> RechnungenAbfragen(
            (DateOnly Von, DateOnly Bis) zeitraum,
            bool cacheAktualisieren
        );

        public Task<List<ContactInformation>> KundenAbfragen(bool cacheAktualisieren);
    }
}
