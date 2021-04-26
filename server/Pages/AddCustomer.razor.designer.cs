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
    public partial class AddCustomerComponent : ComponentBase
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

        SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer _customer;
        protected SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer customer
        {
            get
            {
                return _customer;
            }
            set
            {
                if (!object.Equals(_customer, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "customer", NewValue = value, OldValue = _customer };
                    _customer = value;
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
            customer = new SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(SimpleInvoiceManagementSoftware.Models.SimpleInvoice.Customer args)
        {
            try
            {
                var simpleInvoiceCreateCustomerResult = await SimpleInvoice.CreateCustomer(customer);
                DialogService.Close(customer);
            }
            catch (System.Exception simpleInvoiceCreateCustomerException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Customer!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
