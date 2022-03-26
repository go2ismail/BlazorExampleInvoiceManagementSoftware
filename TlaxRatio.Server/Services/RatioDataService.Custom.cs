using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TlaxRatio.Models.RatioModels;
namespace TlaxRatio
{
    public partial class RatioDataService
    {
        partial void OnCompaniesRead(ref IQueryable<Company> items);
        partial void OnCompanyCreated(Company item);
        partial void OnAfterCompanyCreated(Company item);
        partial void OnCustomersRead(ref IQueryable<Customer> items);
        partial void OnCustomerCreated(Customer item);
        partial void OnAfterCustomerCreated(Customer item);
        partial void OnInvoicesRead(ref IQueryable<Invoice> items);
        partial void OnInvoiceCreated(Invoice item);
        partial void OnAfterInvoiceCreated(Invoice item);
        partial void OnInvoiceLinesRead(ref IQueryable<InvoiceLine> items);
        partial void OnInvoiceLineCreated(InvoiceLine item);
        partial void OnAfterInvoiceLineCreated(InvoiceLine item);
        partial void OnProductsRead(ref IQueryable<Product> items);
        partial void OnProductCreated(Product item);
        partial void OnAfterProductCreated(Product item);
        partial void OnTaxesRead(ref IQueryable<Tax> items);
        partial void OnTaxCreated(Tax item);
        partial void OnAfterTaxCreated(Tax item);
        partial void OnCompanyDeleted(Company item);
        partial void OnAfterCompanyDeleted(Company item);
        partial void OnCompanyGet(Company item);
        partial void OnCompanyUpdated(Company item);
        partial void OnAfterCompanyUpdated(Company item);
        partial void OnCustomerDeleted(Customer item);
        partial void OnAfterCustomerDeleted(Customer item);
        partial void OnCustomerGet(Customer item);
        partial void OnTaxUpdated(Tax item);
        partial void OnAfterTaxUpdated(Tax item);
        partial void OnTaxDeleted(Tax item);
        partial void OnAfterTaxDeleted(Tax item);
        partial void OnTaxGet(Tax item);
        partial void OnProductUpdated(Product item);
        partial void OnAfterProductUpdated(Product item);
        partial void OnProductDeleted(Product item);
        partial void OnAfterProductDeleted(Product item);
        partial void OnProductGet(Product item);
        partial void OnInvoiceLineUpdated(InvoiceLine item);
        partial void OnAfterInvoiceLineUpdated(InvoiceLine item);
        partial void OnInvoiceLineGet(InvoiceLine item);
        partial void OnInvoiceLineDeleted(InvoiceLine item);
        partial void OnAfterInvoiceLineDeleted(InvoiceLine item);
        partial void OnInvoiceUpdated(Invoice item);
        partial void OnAfterInvoiceUpdated(Invoice item);
        partial void OnInvoiceGet(Invoice item);
        partial void OnInvoiceDeleted(Invoice item);
        partial void OnAfterInvoiceDeleted(Invoice item);
        partial void OnCustomerUpdated(Customer item);
        partial void OnAfterCustomerUpdated(Customer item);
    }




}
