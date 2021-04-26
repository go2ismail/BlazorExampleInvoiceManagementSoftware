using System;
using System.IO;
using System.Linq;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleInvoiceManagementSoftware.Data;

namespace SimpleInvoiceManagementSoftware.Controllers
{
    public partial class ExportSimpleInvoiceController
    {
        [HttpGet("/export/SimpleInvoice/invoice/pdf")]
        [HttpGet("/export/SimpleInvoice/invoice/pdf(invoiceId={invoiceId},fileName='{fileName}')")]
        public FileStreamResult ExportInvoiceToPdf(int invoiceId, string fileName = null)
        {
            var connectionString = Startup.ConnectionString;
            var options = new DbContextOptionsBuilder<CustomContext>()
                .UseSqlServer(connectionString).Options;
            using (var ctx = new CustomContext(options))
            {
                var invoice = ctx.InvoiceLine    
                    .Include(x => x.Product)
                    .Include(x => x.Invoice)
                        .ThenInclude(x => x.Customer)
                    .Include(x => x.Invoice)
                        .ThenInclude(x => x.Company)
                    .Where(x => x.InvoiceId.Equals(invoiceId))
                    .ToList();


                var wwwroot = Startup.WebRootPath;      
                var reportpath = $"{wwwroot}\\reports\\Invoice.rdlc";


                var report = new LocalReport(reportpath);
                report.AddDataSource("InvoiceLine", invoice);
                var result = report.Execute(RenderType.Pdf, 1, null, "");

                var pdf = new FileStreamResult(new MemoryStream(result.MainStream), "application/pdf");
                pdf.FileDownloadName = (!string.IsNullOrEmpty(fileName) ? fileName : "Export") + ".pdf";
                return pdf;
            }
        }
    }
}
