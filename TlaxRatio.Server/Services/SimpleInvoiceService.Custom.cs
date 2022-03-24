using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace TlaxRatio
{
    public partial class SimpleInvoiceService
    {
        public async Task PrintInvoiceToPDF(int invoiceId, string fileName = null)
        {
            navigationManager.NavigateTo($"export/SimpleInvoice/invoice/pdf(invoiceId={invoiceId},fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public bool DataInitializationOk()
        {
            var result = Context.Companies.Count() > 0;
            return !result;
        }
        public void DataInitialization()
        {
            var company = Context.Companies.FirstOrDefault();
            if (company == null)
            {
                company = new Models.SimpleInvoice.Company();
                company.Name = "YourCompany, Inc.";
                company.Description = "My next great company.";
                company.Address = "1st Pajajaran Street.";
                company.City = "Bandung City.";

                Context.Companies.Add(company);

                var customer = new Models.SimpleInvoice.Customer();
                customer.Name = "Default Customer";
                customer.Description = "My best loyal customer";
                customer.Address = "1st Sudirman Street.";
                customer.City = "Jakarta City.";

                Context.Customers.Add(customer);

                var officeBasic = new Models.SimpleInvoice.Product();
                officeBasic.Name = "Basic, MS Office 365.";
                officeBasic.UnitPrice = 50;

                var officeStandard = new Models.SimpleInvoice.Product();
                officeStandard.Name = "Standard, MS Office 365.";
                officeStandard.UnitPrice = 100;

                var officePremium = new Models.SimpleInvoice.Product();
                officePremium.Name = "Premium, MS Office 365.";
                officePremium.UnitPrice = 200;

                Context.Products.AddRange(officeBasic, officeStandard, officePremium);

                var tax = new Models.SimpleInvoice.Tax();
                tax.Name = "VAT";
                tax.TaxTariffPercentage = 10;

                Context.Taxes.Add(tax);

                Context.SaveChanges();


            }
        }
    }
}
