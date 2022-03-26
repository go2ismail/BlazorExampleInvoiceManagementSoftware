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
    public partial class CompaniesComponent : ComponentBase
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
        protected RadzenGrid<Company> grid0;

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

        IEnumerable<Company> _getCompaniesResult;
        protected IEnumerable<Company> getCompaniesResult
        {
            get
            {
                return _getCompaniesResult;
            }
            set
            {
                if (!object.Equals(_getCompaniesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCompaniesResult", NewValue = value, OldValue = _getCompaniesResult };
                    _getCompaniesResult = value;
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

            var simpleInvoiceGetCompaniesResult = await SimpleInvoice.GetCompanies(new Query() { Filter = $@"i => i.Name.Contains(@0) || i.Description.Contains(@1) || i.Address.Contains(@2) || i.City.Contains(@3)", FilterParameters = new object[] { search, search, search, search } });
            getCompaniesResult = simpleInvoiceGetCompaniesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddCompany>("Add Company", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await SimpleInvoice.ExportCompaniesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CompanyId,Name,Description,Address,City" }, $"Companies");

            }

            if (args == null || args.Value == "xlsx")
            {
                await SimpleInvoice.ExportCompaniesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CompanyId,Name,Description,Address,City" }, $"Companies");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Company args)
        {
            var dialogResult = await DialogService.OpenAsync<EditCompany>("Edit Company", new Dictionary<string, object>() { {"CompanyId", args.CompanyId} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var simpleInvoiceDeleteCompanyResult = await SimpleInvoice.DeleteCompany(data.CompanyId);
                    if (simpleInvoiceDeleteCompanyResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception simpleInvoiceDeleteCompanyException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Company" });
            }
        }
    }
}
