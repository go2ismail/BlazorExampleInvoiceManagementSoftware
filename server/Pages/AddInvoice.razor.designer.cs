using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using SimpleInvoiceManagementSoftware.Models.SimpleInvoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SimpleInvoiceManagementSoftware.Models;

namespace SimpleInvoiceManagementSoftware.Pages
{
    public partial class AddInvoiceComponent : ComponentBase
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
        protected SimpleInvoiceService SimpleInvoice { get; set; }

        IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Company> _getCompaniesForCompanyIdResult;
        protected IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Company> getCompaniesForCompanyIdResult
        {
            get
            {
                return _getCompaniesForCompanyIdResult;
            }
            set
            {
                if (!object.Equals(_getCompaniesForCompanyIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCompaniesForCompanyIdResult", NewValue = value, OldValue = _getCompaniesForCompanyIdResult };
                    _getCompaniesForCompanyIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer> _getCustomersForCustomerIdResult;
        protected IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer> getCustomersForCustomerIdResult
        {
            get
            {
                return _getCustomersForCustomerIdResult;
            }
            set
            {
                if (!object.Equals(_getCustomersForCustomerIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCustomersForCustomerIdResult", NewValue = value, OldValue = _getCustomersForCustomerIdResult };
                    _getCustomersForCustomerIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Tax> _getTaxesForTaxIdResult;
        protected IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Tax> getTaxesForTaxIdResult
        {
            get
            {
                return _getTaxesForTaxIdResult;
            }
            set
            {
                if (!object.Equals(_getTaxesForTaxIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTaxesForTaxIdResult", NewValue = value, OldValue = _getTaxesForTaxIdResult };
                    _getTaxesForTaxIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice _invoice;
        protected SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice invoice
        {
            get
            {
                return _invoice;
            }
            set
            {
                if (!object.Equals(_invoice, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "invoice", NewValue = value, OldValue = _invoice };
                    _invoice = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine> _getInvoiceLinesResult;
        protected IEnumerable<SimpleInvoiceManagementSoftware.Models.SimpleInvoice.InvoiceLine> getInvoiceLinesResult
        {
            get
            {
                return _getInvoiceLinesResult;
            }
            set
            {
                if (!object.Equals(_getInvoiceLinesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvoiceLinesResult", NewValue = value, OldValue = _getInvoiceLinesResult };
                    _getInvoiceLinesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CompanyAddress;
        protected string CompanyAddress
        {
            get
            {
                return _CompanyAddress;
            }
            set
            {
                if (!object.Equals(_CompanyAddress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CompanyAddress", NewValue = value, OldValue = _CompanyAddress };
                    _CompanyAddress = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CompanyCity;
        protected string CompanyCity
        {
            get
            {
                return _CompanyCity;
            }
            set
            {
                if (!object.Equals(_CompanyCity, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CompanyCity", NewValue = value, OldValue = _CompanyCity };
                    _CompanyCity = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CustomerAddress;
        protected string CustomerAddress
        {
            get
            {
                return _CustomerAddress;
            }
            set
            {
                if (!object.Equals(_CustomerAddress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CustomerAddress", NewValue = value, OldValue = _CustomerAddress };
                    _CustomerAddress = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _CustomerCity;
        protected string CustomerCity
        {
            get
            {
                return _CustomerCity;
            }
            set
            {
                if (!object.Equals(_CustomerCity, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CustomerCity", NewValue = value, OldValue = _CustomerCity };
                    _CustomerCity = value;
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
            var simpleInvoiceGetCompaniesResult = await SimpleInvoice.GetCompanies();
            getCompaniesForCompanyIdResult = simpleInvoiceGetCompaniesResult;

            var simpleInvoiceGetCustomersResult = await SimpleInvoice.GetCustomers();
            getCustomersForCustomerIdResult = simpleInvoiceGetCustomersResult;

            var simpleInvoiceGetTaxesResult = await SimpleInvoice.GetTaxes();
            getTaxesForTaxIdResult = simpleInvoiceGetTaxesResult;

            invoice = new SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice(){};

            var simpleInvoiceGetInvoiceLinesResult = await SimpleInvoice.GetInvoiceLines();
            getInvoiceLinesResult = simpleInvoiceGetInvoiceLinesResult;

            CompanyAddress = "";

            CompanyCity = "";

            CustomerAddress = "";

            CustomerCity = "";

            await DataInitialization();
        }

        protected async System.Threading.Tasks.Task Form0Submit(SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Invoice args)
        {
            try
            {
                var simpleInvoiceCreateInvoiceResult = await SimpleInvoice.CreateInvoice(invoice);
                await ResetDraftInvoiceNumber(invoice);

                await RedirectToEdit(invoice);
            }
            catch (System.Exception simpleInvoiceCreateInvoiceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Invoice!" });
            }
        }

        protected async System.Threading.Tasks.Task CompanyIdChange(dynamic args)
        {
            await CompanySelected(args);
        }

        protected async System.Threading.Tasks.Task CustomerIdChange(dynamic args)
        {
            await CustomerSelected(args);
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
