using Azure;
using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice.DataContracts.Contacts;
using coIT.Libraries.LexOffice.DataContracts.Country;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;

namespace coIT.Toolkit.Lexoffice.GdiExport.Kundenstamm;

internal static class KundenMapper
{
    public static KundeRelation ZuExportKunden(this ContactInformation contactInformation)
    {
        var contactAddress = contactInformation.Addresses.Billing.FirstOrDefault();

        return new KundeRelation(
            contactInformation.Id,
            contactInformation.Role?.Number?.Number ?? -1,
            0,
            contactInformation.Company.Name,
            contactAddress.Street,
            contactAddress.Zip,
            contactAddress.City,
            contactAddress.Country.Name,
            contactAddress.Country.Code,
            "Markt",
            (LänderSteuerklassifizierung) contactAddress.Country.TaxClassification,
            ETag.All,
            null
        );
    }

    public static List<Customer> ZuGdiKunden(this List<KundeRelation> exportCustomers)
    {
        return exportCustomers.Select(customer => customer.ZuGdiKunde()).ToList();
    }

    private static Customer ZuGdiKunde(this KundeRelation kunde)
    {
        var address = new Address
        {
            Street = kunde.Straße,
            Zip = kunde.Postleitzahl,
            City = kunde.Stadt,
            Country = kunde.Land,
            CountryCode = GdiLkzFürSteuerklassifikation(kunde.Ländersteuerklassifizierung),
        };

        return new Customer
        {
            Name = kunde.DebitorName,
            Number = kunde.DebitorenNummer,
            Address = address,
            Type = KundenTyp(kunde.Typ),
        };
    }

    private static char GdiLkzFürSteuerklassifikation(LänderSteuerklassifizierung taxClassification)
    {
        return taxClassification switch
        {
            LänderSteuerklassifizierung.Deutschland => 'I',
            LänderSteuerklassifizierung.Innergemeinschaftlich => 'E',
            LänderSteuerklassifizierung.Drittland => 'D',
            _ => throw new ArgumentOutOfRangeException(nameof(taxClassification), taxClassification, null)
        };
    }

    private static CustomerType KundenTyp(string type)
    {
        return type switch
        {
            "Markt" => CustomerType.Market,
            "Verbund" => CustomerType.Network,
            _ => CustomerType.Internal,
        };
    }
}
