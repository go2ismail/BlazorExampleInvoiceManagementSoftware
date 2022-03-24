using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using TlaxRatio.Models.SimpleInvoice;
using Microsoft.AspNetCore.Components;

namespace TlaxRatio.Server.Pages
{
    public partial class AddInvoiceComponent
    {

        public async Task RedirectToEdit(Invoice invoice)
        {
            UriHelper.NavigateTo($"edit-invoice/{invoice.InvoiceId}", false);
        }

        public async Task ResetDraftInvoiceNumber(Invoice invoice)
        {
            if (invoice.InvoiceNumber.Contains("DRAFT"))
            {
                invoice.InvoiceNumber = $"INV#{invoice.InvoiceId.ToString().PadLeft(4, '0')}";
                await SimpleInvoice.UpdateInvoice(invoice.InvoiceId, invoice);
            }
        }

        public async Task DataInitialization()
        {
            invoice.InvoiceDate = DateTime.Now;
            invoice.InvoiceDueDate = invoice.InvoiceDate;
            invoice.CustomerId = 1;
            invoice.CompanyId = 1;
            invoice.TaxId = 1;
            invoice.InvoiceNumber = $"DRAFT-{invoice.InvoiceDate.ToString("yyyyMMddHHmmss")}";

            await CompanySelected(1);
            await CustomerSelected(1);
            
        }

        public async Task CompanySelected(int companyId)
        {
            var company = await SimpleInvoice.GetCompanyByCompanyId(companyId);
            if (company != null)
            {
                CompanyAddress = company.Address;
                CompanyCity = company.City;
            }
        }

        public async Task CustomerSelected(int customerId)
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
