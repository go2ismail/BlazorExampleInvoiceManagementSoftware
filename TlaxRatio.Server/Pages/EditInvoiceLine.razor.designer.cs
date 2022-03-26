using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Radzen;
using System.Collections.Generic;
using TlaxRatio.Models.RatioModels;
 

namespace TlaxRatio.Server.Pages
{
    public partial class EditInvoiceLineComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected RatioDataService SimpleInvoice { get; set; }

        [Parameter]
        public dynamic InvoiceLineId { get; set; }

        InvoiceLine _invoiceline;
        protected InvoiceLine invoiceline
        {
            get
            {
                return _invoiceline;
            }
            set
            {
                if (!object.Equals(_invoiceline, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "invoiceline", NewValue = value, OldValue = _invoiceline };
                    _invoiceline = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Invoice> _getInvoicesForInvoiceIdResult;
        protected IEnumerable<Invoice> getInvoicesForInvoiceIdResult
        {
            get
            {
                return _getInvoicesForInvoiceIdResult;
            }
            set
            {
                if (!object.Equals(_getInvoicesForInvoiceIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvoicesForInvoiceIdResult", NewValue = value, OldValue = _getInvoicesForInvoiceIdResult };
                    _getInvoicesForInvoiceIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Product> _getProductsForProductIdResult;
        protected IEnumerable<Product> getProductsForProductIdResult
        {
            get
            {
                return _getProductsForProductIdResult;
            }
            set
            {
                if (!object.Equals(_getProductsForProductIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsForProductIdResult", NewValue = value, OldValue = _getProductsForProductIdResult };
                    _getProductsForProductIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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
            var simpleInvoiceGetInvoiceLineByInvoiceLineIdResult = await SimpleInvoice.GetInvoiceLineByInvoiceLineId(InvoiceLineId);
            invoiceline = simpleInvoiceGetInvoiceLineByInvoiceLineIdResult;

            var simpleInvoiceGetInvoicesResult = await SimpleInvoice.GetInvoices();
            getInvoicesForInvoiceIdResult = simpleInvoiceGetInvoicesResult;

            var simpleInvoiceGetProductsResult = await SimpleInvoice.GetProducts();
            getProductsForProductIdResult = simpleInvoiceGetProductsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(InvoiceLine args)
        {
            try
            {
                var simpleInvoiceUpdateInvoiceLineResult = await SimpleInvoice.UpdateInvoiceLine(InvoiceLineId, invoiceline);
                DialogService.Close(invoiceline);
            }
            catch (System.Exception simpleInvoiceUpdateInvoiceLineException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update InvoiceLine" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
