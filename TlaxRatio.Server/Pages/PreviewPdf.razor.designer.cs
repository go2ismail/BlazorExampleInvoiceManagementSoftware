using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Threading.Tasks;
using TlaxRatio.Reporting.Api.SDK;

namespace TlaxRatio.Server.Pages
{
    public partial class PreviewPdfComponent : ComponentBase
    {
        public string InvoiceContent { get; set; }
        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }
        [Parameter]
        public dynamic InvoiceId { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        [Inject]
        protected IReportApi reportApi { get; set; }
        [Inject]
        protected RatioDataService SimpleInvoice { get; set; }


        [Inject]
        protected IJSRuntime JS { get; set; }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }

        protected async System.Threading.Tasks.Task Load()
        {
            InvoiceId = int.Parse(InvoiceId);
            var bytes = await reportApi.ExportInvoiceToPdf(InvoiceId);
            string base64 = Convert.ToBase64String(bytes);
            var result = await JS.InvokeAsync<string>("showPdf", base64);
            Console.WriteLine(result);
        }

        protected void BtnBacktoInvoiceClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo($"edit-invoice/{InvoiceId}");
        }
    }
}
