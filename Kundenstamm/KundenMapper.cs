using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice.DataContracts.Contacts;
using coIT.Libraries.LexOffice.DataContracts.Country;
using coIT.Libraries.Toolkit.Datengrundlagen.Kunden;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;

internal static class KundenMapper
{
    public static Kunde ZuExportKunden(this ContactInformation contactInformation)
    {
        var contactAddress = contactInformation.Addresses.Billing.FirstOrDefault();

        return new Kunde(
            contactInformation.Role?.Number?.Number ?? -1,
            0,
            contactInformation.Company.Name,
            contactAddress.Street,
            contactAddress.Zip,
            contactAddress.City,
            contactAddress.Country.Name,
            contactAddress.Country.Code,
            "Markt",
            contactAddress.Country.TaxClassification,
            contactInformation.Id
        );
    }

    public static List<Customer> ZuGdiKunden(this List<Kunde> exportCustomers)
    {
        return exportCustomers.Select(customer => customer.ZuGdiKunde()).ToList();
    }

    private static Customer ZuGdiKunde(this Kunde kunde)
    {
        var address = new Address
        {
            Street = kunde.Straße,
            Zip = kunde.Postleitzahl,
            City = kunde.Stadt,
            Country = kunde.Land,
            CountryCode = GdiLkzFürSteuerklassifikation(kunde.Ländersteuerklassifizierung)
        };

        return new Customer
        {
            Name = kunde.DebitorName,
            Number = kunde.Debitorennummer,
            Address = address,
            Type = KundenTyp(kunde.Typ)
        };
    }

    private static char GdiLkzFürSteuerklassifikation(CountryTaxClassification taxClassification)
    {
        return taxClassification switch
        {
            CountryTaxClassification.De => 'I',
            CountryTaxClassification.IntraCommunity => 'E',
            CountryTaxClassification.ThirdPartyCountry => 'D',
        };
    }

    private static CustomerType KundenTyp(string type)
    {
        return type switch
        {
            "Markt" => CustomerType.Market,
            "Verbund" => CustomerType.Network,
            _ => CustomerType.Internal
        };
    }
}
