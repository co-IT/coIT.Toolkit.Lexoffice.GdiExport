using System.Collections.Immutable;
using coIT.Libraries.Gdi.Accounting.Contracts;
using coIT.Libraries.LexOffice;
using coIT.Libraries.Lexoffice.BusinessRules.Rechnung;
using coIT.Libraries.Toolkit.Datengrundlagen.KundenRelation;
using coIT.Libraries.Toolkit.Datengrundlagen.Mitarbeiter;
using coIT.Libraries.Toolkit.Datengrundlagen.Umsatzkonten;
using CSharpFunctionalExtensions;
using GdiInvoice = coIT.Libraries.Gdi.Accounting.Contracts.Invoice;
using LexofficeInvoice = coIT.Libraries.LexOffice.DataContracts.Invoice.Invoice;

namespace coIT.Toolkit.Lexoffice.GdiExport;

internal class InvoiceMapper
{
  private readonly IEnumerable<Umsatzkonto> _accounts;
  private readonly IEnumerable<KundeRelation> _customers;
  private readonly AlleRechnungsregeln _rechnungsRegeln;

  internal InvoiceMapper(
    IEnumerable<KundeRelation> customers,
    IEnumerable<Umsatzkonto> accounts,
    IEnumerable<Mitarbeiter> mitarbeiter
  )
  {
    _customers = customers;
    _accounts = accounts;

    _rechnungsRegeln = new AlleRechnungsregeln(
      customers.ToImmutableList(),
      accounts.ToImmutableList(),
      mitarbeiter.ToImmutableList()
    );
  }

  internal Result<GdiInvoice> ToGdiInvoice(LexofficeInvoice lexOfficeInvoice)
  {
    var ergebnis = _rechnungsRegeln.Prüfen(lexOfficeInvoice);

    if (ergebnis.IsFailure)
      return ergebnis.ConvertFailure<GdiInvoice>();

    var exportCustomer = _customers.SingleOrDefault(customer => customer.Id == lexOfficeInvoice.Address.ContactId);

    var accountNumberResult = lexOfficeInvoice.KontoErmitteln();
    if (accountNumberResult.IsFailure)
      return accountNumberResult.ConvertFailure<GdiInvoice>();

    var accountNumber = accountNumberResult.Value;

    var accountDetails = _accounts.FirstOrDefault(account => account.KontoNummer == accountNumber);

    return new GdiInvoice
    {
      Date = DateTimeOffset.Parse(lexOfficeInvoice.VoucherDate),
      Number = lexOfficeInvoice.VoucherNumber,
      Type = InvoiceType.Invoice,
      NetAmount = lexOfficeInvoice.TotalPrice.TotalNetAmount,
      GrossAmount = lexOfficeInvoice.TotalPrice.TotalGrossAmount,
      TaxAmount = lexOfficeInvoice.TotalPrice.TotalTaxAmount,
      DebitorNumber = exportCustomer?.DebitorenNummer ?? -1,
      DebitorName = exportCustomer?.DebitorName ?? "Unbekannt",
      RemoteId = lexOfficeInvoice.Id,
      DataSource = "lexoffice",
      RevenueAccountNumber = accountNumber,
      BillingAccountNumber = accountDetails.Steuerschlüssel,
    };
  }
}
