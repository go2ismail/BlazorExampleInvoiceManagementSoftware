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
using TlaxRatio.Models.SimpleInvoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TlaxRatio.Models;

namespace TlaxRatio.Server.Pages
{
    public partial class ProfileComponent : ComponentBase
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

        ApplicationUser _user;
        protected ApplicationUser user
        {
            get
            {
                return _user;
            }
            set
            {
                if (!object.Equals(_user, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "user", NewValue = value, OldValue = _user };
                    _user = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _OldPassword;
        protected string OldPassword
        {
            get
            {
                return _OldPassword;
            }
            set
            {
                if (!object.Equals(_OldPassword, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "OldPassword", NewValue = value, OldValue = _OldPassword };
                    _OldPassword = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _NewPassword;
        protected string NewPassword
        {
            get
            {
                return _NewPassword;
            }
            set
            {
                if (!object.Equals(_NewPassword, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "NewPassword", NewValue = value, OldValue = _NewPassword };
                    _NewPassword = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _ConfirmPassword;
        protected string ConfirmPassword
        {
            get
            {
                return _ConfirmPassword;
            }
            set
            {
                if (!object.Equals(_ConfirmPassword, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "ConfirmPassword", NewValue = value, OldValue = _ConfirmPassword };
                    _ConfirmPassword = value;
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
            if (Security.User != null)
            {
                var securityGetUserByIdResult = await Security.GetUserById($"{Security.User.Id}");
                user = securityGetUserByIdResult;
            }

            OldPassword = "";

            NewPassword = "";

            ConfirmPassword = "";
        }

        protected async System.Threading.Tasks.Task Form0Submit(ApplicationUser args)
        {
            try
            {
                var procesChangePasswordResult = await ProcesChangePassword(user,$"{OldPassword}",$"{NewPassword}",$"{ConfirmPassword}");
                if (procesChangePasswordResult.Succeeded == true)
                {
                    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"Success",Detail = $"Change password success!" });
                }

                if (procesChangePasswordResult.Succeeded == true)
                {
                    await Relogin();
                }
            }
            catch (System.Exception procesChangePasswordException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"{procesChangePasswordException.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task BtnCancelClick(MouseEventArgs args)
        {
            DialogService.Close();
            await JSRuntime.InvokeAsync<string>("window.history.back");
        }
    }
}
