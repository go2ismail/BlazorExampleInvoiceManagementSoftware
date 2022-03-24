using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TlaxRatio.Reporting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        public ReportController(ILogger<ReportController> logger) => _logger = logger;


        [HttpPost("GetReportByteArray")]
        public async Task<byte[]> GetReportByteArray(int invoiceId) => await GetReport(invoiceId);

        [HttpPost("GetReportPdf")]
        public async Task<FileStreamResult> GetReportPdf(int invoiceId, string fileName = null)
        {
            var stream = await GetReport(invoiceId);
            var pdf = new FileStreamResult(new MemoryStream(stream), "application/pdf")
            {
                FileDownloadName = (!string.IsNullOrEmpty(fileName) ? fileName : "Export") + ".pdf"
            };
            return  pdf;
        }

        private static  async Task<byte[]> GetReport(int invoiceId)
        {
            var connectionString = Startup.ConnectionString;
            var options = new DbContextOptionsBuilder<CustomContext>()
                .UseSqlServer(connectionString).Options;
            using var ctx = new CustomContext(options);
            var invoice = ctx.InvoiceLine
                .Include(x => x.Product)
                .Include(x => x.Invoice)
                    .ThenInclude(x => x.Customer)
                .Include(x => x.Invoice)
                    .ThenInclude(x => x.Company)
                .Where(x => x.InvoiceId.Equals(invoiceId))
                .ToList();
            var baserootPath = Startup.WebRootPath;
            var reportpath = System.IO.Path.Combine(baserootPath, "Reports", "Invoice.rdlc");
            var report = new LocalReport(reportpath);
            report.AddDataSource("InvoiceLine", invoice);
            var result = report.Execute(RenderType.Pdf, 1, null, "");
            return await Task.FromResult(result.MainStream);
        }
    }
}
