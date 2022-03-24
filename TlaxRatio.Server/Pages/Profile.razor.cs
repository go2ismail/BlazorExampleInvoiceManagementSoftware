using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using TlaxRatio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;

namespace TlaxRatio.Server.Pages
{
    public partial class ProfileComponent
    {
        [Inject] UserManager<ApplicationUser> userManager { get; set; }
        public async Task<IdentityResult> ProcesChangePassword(ApplicationUser user, string oldPassword, string newPassword, string confirmPassword)
        {
            if (!newPassword.Equals(confirmPassword))
            {

                var result = IdentityResult.Failed(new IdentityError() { Description = "Confirm password is different!" });

                EnsureSucceeded(result);

                return result;
            }
            else
            {
                var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

                EnsureSucceeded(result);

                return result;
            }

            
        }


        public async Task Relogin()
        {
            System.Threading.Thread.Sleep(1 * 1000);
            await Security.Logout();
        }

        private void EnsureSucceeded(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var message = string.Join(", ", result.Errors.Select(error => error.Description));

                throw new ApplicationException(message);
            }
        }
    }
}
