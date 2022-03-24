using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using TlaxRatio.Models.SimpleInvoice;

namespace TlaxRatio.Server.Pages
{
    public partial class EditInvoiceComponent
    {
        protected async System.Threading.Tasks.Task ExportPDF(Invoice invoice)
        {
            await SimpleInvoice.PrintInvoiceToPDF(invoice.InvoiceId, invoice.InvoiceNumber);
        }

        public async Task RecalculateMasterAfterChildDelete(Invoice invoice, IEnumerable<InvoiceLine> invoiceLines)
        {
            invoice.InvoiceLines = invoiceLines.ToList();
            invoice.RecalculateTotal();

            await SimpleInvoice.UpdateInvoice(invoice.InvoiceId, invoice);
        }

        public async Task RecalculateSummary(Invoice invoice, IEnumerable<InvoiceLine> invoiceLines)
        {
            invoice.InvoiceLines = invoiceLines.ToList();
            invoice.RecalculateTotal();

            await SimpleInvoice.UpdateInvoice(invoice.InvoiceId, invoice);
        }

        public async Task SelectedTax(int taxId, IEnumerable<InvoiceLine> invoiceLines)
        {
            invoice.InvoiceLines = invoiceLines.ToList();
            invoice.TaxId = taxId;
            invoice.Tax = await SimpleInvoice.GetTaxByTaxId(taxId);
            invoice.RecalculateTotal();

            await SimpleInvoice.UpdateInvoice(invoice.InvoiceId, invoice);
        }

        public async Task ChangeDiscount(double discountAmount, IEnumerable<InvoiceLine> invoiceLines)
        {
            invoice.InvoiceLines = invoiceLines.ToList();
            invoice.Discount = discountAmount;
            invoice.RecalculateTotal();

            await SimpleInvoice.UpdateInvoice(invoice.InvoiceId, invoice);
        }

        public async Task SelectedCompany(int companyId)
        {
            var company = await SimpleInvoice.GetCompanyByCompanyId(companyId);
            if (company != null)
            {
                CompanyAddress = company.Address;
                CompanyCity = company.City;
            }
        }

        public async Task SelectedCustomer(int customerId)
        {
            var customer = await SimpleInvoice.GetCustomerByCustomerId(customerId);
            if (customer != null)
            {
                CustomerAddress = customer.Address;
                CustomerCity = customer.City;
            }
        }
    }
}
