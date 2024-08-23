using System.Collections.Immutable;
using coIT.Libraries.LexOffice;
using coIT.Libraries.LexOffice.DataContracts.Contacts;
using coIT.Libraries.LexOffice.DataContracts.Voucher;
using coIT.Libraries.WinForms.DateTimeButtons;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LexOfficeInvoice = coIT.Libraries.LexOffice.DataContracts.Invoice.Invoice;

namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung.LexofficeCaching
{
    internal class TagesbasierterCache : IchCacheLexofficeAbfragen
    {
        private static Dictionary<DateOnly, List<LexOfficeInvoice>> _rechnungenCache = new();
        private static List<ContactInformation> _kundenCache;
        private readonly LexofficeService _service;

        public TagesbasierterCache(LexofficeService service)
        {
            _service = service;
        }

        public async Task<List<ContactInformation>> KundenAbfragen(bool cacheAktualisieren)
        {
            if (_kundenCache == null)
                _kundenCache = (await _service!.GetContactsAsync()).ToList();

            return _kundenCache;
        }

        public async Task<List<LexOfficeInvoice>> RechnungenAbfragen(
            (DateOnly Von, DateOnly Bis) zeitraum,
            bool cacheAktualisieren
        )
        {
            var alleVouchersInZeitraum = await _service.GetVouchersInPeriod(
                zeitraum.Von,
                zeitraum.Bis
            );

            var vouchersGruppiertNachTag = alleVouchersInZeitraum
                .GroupBy(voucher => voucher.VoucherDate)
                .Select(voucherGrouping => new
                {
                    Tag = voucherGrouping.First().VoucherDate,
                    Liste = voucherGrouping.ToList()
                })
                .ToDictionary(entry => entry.Tag.ToDateOnly(), entry => entry.Liste);

            var tageInZeitraum = TageInAbfrageZeitraumErmitteln(zeitraum);

            var alleRechnungen = new List<LexOfficeInvoice>();
            foreach (var tag in tageInZeitraum)
            {
                var vouchersFürTag = vouchersGruppiertNachTag.ContainsKey(tag)
                    ? vouchersGruppiertNachTag[tag]
                    : [];

                var rechnungenFürTag = await RechnungenFürTagAbfragen(
                    tag,
                    cacheAktualisieren,
                    vouchersFürTag
                );
                alleRechnungen.AddRange(rechnungenFürTag);
            }

            return alleRechnungen;
        }

        private IEnumerable<DateOnly> TageInAbfrageZeitraumErmitteln(
            (DateOnly Von, DateOnly Bis) zeitraum
        )
        {
            for (
                DateOnly derzeitigerTag = zeitraum.Von;
                derzeitigerTag <= zeitraum.Bis;
                derzeitigerTag = derzeitigerTag.AddDays(1)
            )
            {
                yield return derzeitigerTag;
            }
        }

        public async Task<List<LexOfficeInvoice>> RechnungenFürTagAbfragen(
            DateOnly tag,
            bool cacheAktualisieren,
            List<Voucher> vouchers
        )
        {
            if (!cacheAktualisieren && _rechnungenCache.ContainsKey(tag))
                return _rechnungenCache[tag];

            if (vouchers.Count == 0)
                return [];

            var rechnungenDesTages = await RechnungenVonLexofficeAbrufen(vouchers);
            _rechnungenCache[tag] = rechnungenDesTages;
            return rechnungenDesTages;
        }

        private async Task<List<LexOfficeInvoice>> RechnungenVonLexofficeAbrufen(
            List<Voucher> vouchers
        )
        {
            var rechnungenMitDetails = await _service.GetInvoicesAsync(vouchers.ToImmutableList());
            return rechnungenMitDetails.ToList();
        }
    }
}
