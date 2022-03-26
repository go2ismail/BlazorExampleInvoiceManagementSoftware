using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Collections.Generic;
using TlaxRatio.Models.RatioModels;

namespace TlaxRatio.Server.Pages
{
    public partial class TaxesComponent : ComponentBase
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
        protected RadzenGrid<Tax> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Tax> _getTaxesResult;
        protected IEnumerable<Tax> getTaxesResult
        {
            get
            {
                return _getTaxesResult;
            }
            set
            {
                if (!object.Equals(_getTaxesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTaxesResult", NewValue = value, OldValue = _getTaxesResult };
                    _getTaxesResult = value;
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
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var simpleInvoiceGetTaxesResult = await SimpleInvoice.GetTaxes(new Query() { Filter = $@"i => i.Name.Contains(@0) || i.Description.Contains(@1)", FilterParameters = new object[] { search, search } });
            getTaxesResult = simpleInvoiceGetTaxesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTax>("Add Tax", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await SimpleInvoice.ExportTaxesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TaxId,Name,Description,TaxTariffPercentage" }, $"Taxes");

            }

            if (args == null || args.Value == "xlsx")
            {
                await SimpleInvoice.ExportTaxesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TaxId,Name,Description,TaxTariffPercentage" }, $"Taxes");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Tax args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTax>("Edit Tax", new Dictionary<string, object>() { {"TaxId", args.TaxId} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var simpleInvoiceDeleteTaxResult = await SimpleInvoice.DeleteTax(data.TaxId);
                    if (simpleInvoiceDeleteTaxResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception simpleInvoiceDeleteTaxException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Tax" });
            }
        }
    }
}
