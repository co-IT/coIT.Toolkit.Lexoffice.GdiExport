using System.Text;
using coIT.Lexoffice.GdiExport.Kundenstamm;
using coIT.Libraries.LexOffice;
using coIT.Libraries.LexOffice.DataContracts.Contacts;
using coIT.Libraries.LexOffice.DataContracts.Invoice;
using Newtonsoft.Json;

namespace coIT.Lexoffice.GdiExport.Umsatzkontenprüfung.LexofficeCaching
{
    internal class ErweiterterDateisystemCache : IchCacheLexofficeAbfragen
    {
        private static string _rechnungenCacheDatei = "cache_rechnungen.json";
        private static string _kundenCacheDatei = "cache_kunden.json";

        private static Dictionary<DateOnly, List<Invoice>> _rechnungenCache = new();
        private static List<ContactInformation> _kundenCache;
        private readonly IchCacheLexofficeAbfragen _fallbackCache;

        public static async Task<ErweiterterDateisystemCache> LadeCacheAusLokalerDatei(
            LexofficeService service
        )
        {
            var rechnungenCache = await File.ReadAllTextAsync(_rechnungenCacheDatei, Encoding.UTF8);
            var rechnungen =
                JsonConvert.DeserializeObject<Dictionary<DateOnly, List<Invoice>>>(rechnungenCache)
                ?? throw new InvalidDataException(_rechnungenCacheDatei);

            var kundenCache = await File.ReadAllTextAsync(_kundenCacheDatei, Encoding.UTF8);
            var kunden =
                JsonConvert.DeserializeObject<List<ContactInformation>>(kundenCache)
                ?? throw new InvalidDataException(_kundenCacheDatei);

            var fallbackCache = new TagesbasierterCache(service);
            return new ErweiterterDateisystemCache(fallbackCache, rechnungen, kunden);
        }

        public static ErweiterterDateisystemCache LeerInitialisieren(LexofficeService service)
        {
            var fallbackCache = new TagesbasierterCache(service);
            return new ErweiterterDateisystemCache(fallbackCache, new(), new());
        }

        public ErweiterterDateisystemCache(
            IchCacheLexofficeAbfragen fallbackCache,
            Dictionary<DateOnly, List<Invoice>> rechnungenCache,
            List<ContactInformation> kundenCache
        )
        {
            _fallbackCache = fallbackCache;
            _rechnungenCache = rechnungenCache;
            _kundenCache = kundenCache;
        }

        public async Task LokalenCacheErzeugen()
        {
            var rechnungenCache = JsonConvert.SerializeObject(_rechnungenCache);
            await File.WriteAllTextAsync(
                _rechnungenCacheDatei,
                rechnungenCache,
                Encoding.UTF8,
                CancellationToken.None
            );

            var kundenCache = JsonConvert.SerializeObject(_kundenCache);
            await File.WriteAllTextAsync(
                _kundenCacheDatei,
                kundenCache,
                Encoding.UTF8,
                CancellationToken.None
            );
        }

        public async Task<List<ContactInformation>> KundenAbfragen(bool cacheAktualisieren)
        {
            if (cacheAktualisieren || _kundenCache.Count() == 0)
                _kundenCache = await _fallbackCache.KundenAbfragen(true);

            return _kundenCache;
        }

        public async Task<List<Invoice>> RechnungenAbfragen(
            (DateOnly Von, DateOnly Bis) zeitraum,
            bool cacheAktualisieren
        )
        {
            var tageInZeitraum = TageInAbfrageZeitraumErmitteln(zeitraum);

            var alleRechnungen = new List<Invoice>();
            foreach (var tag in tageInZeitraum)
            {
                var rechnungenFürTag = await RechnungenFürTagAbfragen(tag, cacheAktualisieren);
                alleRechnungen.AddRange(rechnungenFürTag);
            }

            return alleRechnungen;
        }

        public async Task<List<Invoice>> RechnungenFürTagAbfragen(
            DateOnly tag,
            bool cacheAktualisieren
        )
        {
            if (cacheAktualisieren || !_rechnungenCache.ContainsKey(tag))
                _rechnungenCache[tag] = await _fallbackCache.RechnungenAbfragen((tag, tag), true);

            return _rechnungenCache[tag];
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
    }
}
