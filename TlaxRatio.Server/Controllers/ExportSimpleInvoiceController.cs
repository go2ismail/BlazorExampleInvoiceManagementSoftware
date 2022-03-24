using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TlaxRatio.Data;

namespace TlaxRatio
{
    public partial class ExportSimpleInvoiceController : ExportController
    {
        private readonly SimpleInvoiceContext context;

        public ExportSimpleInvoiceController(SimpleInvoiceContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/SimpleInvoice/companies/csv")]
        [HttpGet("/export/SimpleInvoice/companies/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCompaniesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Companies, Request.Query), fileName);
        }

        [HttpGet("/export/SimpleInvoice/companies/excel")]
        [HttpGet("/export/SimpleInvoice/companies/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCompaniesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Companies, Request.Query), fileName);
        }
        [HttpGet("/export/SimpleInvoice/customers/csv")]
        [HttpGet("/export/SimpleInvoice/customers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCustomersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Customers, Request.Query), fileName);
        }

        [HttpGet("/export/SimpleInvoice/customers/excel")]
        [HttpGet("/export/SimpleInvoice/customers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCustomersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Customers, Request.Query), fileName);
        }
        [HttpGet("/export/SimpleInvoice/invoices/csv")]
        [HttpGet("/export/SimpleInvoice/invoices/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInvoicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Invoices, Request.Query), fileName);
        }

        [HttpGet("/export/SimpleInvoice/invoices/excel")]
        [HttpGet("/export/SimpleInvoice/invoices/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInvoicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Invoices, Request.Query), fileName);
        }
        [HttpGet("/export/SimpleInvoice/invoicelines/csv")]
        [HttpGet("/export/SimpleInvoice/invoicelines/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInvoiceLinesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InvoiceLines, Request.Query), fileName);
        }

        [HttpGet("/export/SimpleInvoice/invoicelines/excel")]
        [HttpGet("/export/SimpleInvoice/invoicelines/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInvoiceLinesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InvoiceLines, Request.Query), fileName);
        }
        [HttpGet("/export/SimpleInvoice/products/csv")]
        [HttpGet("/export/SimpleInvoice/products/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Products, Request.Query), fileName);
        }

        [HttpGet("/export/SimpleInvoice/products/excel")]
        [HttpGet("/export/SimpleInvoice/products/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Products, Request.Query), fileName);
        }
        [HttpGet("/export/SimpleInvoice/taxes/csv")]
        [HttpGet("/export/SimpleInvoice/taxes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTaxesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Taxes, Request.Query), fileName);
        }

        [HttpGet("/export/SimpleInvoice/taxes/excel")]
        [HttpGet("/export/SimpleInvoice/taxes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTaxesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Taxes, Request.Query), fileName);
        }
    }
}
