using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TlaxRatio.Models;

namespace TlaxRatio
{
    public partial class Startup
    {
        public static string ConnectionString;

        public static string WebRootPath;

        partial void OnConfiguringServices(IServiceCollection services)
        {
            ConnectionString = Configuration.GetConnectionString("SimpleInvoiceConnection");
        }

        partial void OnConfigureServices(IServiceCollection services)
        {
            //reconfigure custom password options
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = Configuration["CustomSettings:Password:RequireDigit"].Equals("true") ? true : false;
                options.Password.RequireLowercase = Configuration["CustomSettings:Password:RequireLowercase"].Equals("true") ? true : false;
                options.Password.RequireNonAlphanumeric = Configuration["CustomSettings:Password:RequireNonAlphanumeric"].Equals("true") ? true : false;
                options.Password.RequireUppercase = Configuration["CustomSettings:Password:RequireUppercase"].Equals("true") ? true : false;
                options.Password.RequiredLength = Convert.ToInt32(Configuration["CustomSettings:Password:RequiredLength"]);
                options.Password.RequiredUniqueChars = Convert.ToInt32(Configuration["CustomSettings:Password:RequiredUniqueChars"]);
            });

            services.AddDbContext<CustomContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SimpleInvoiceConnection"));
            });

        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            GenerateDatabase();

            DataInitialization(app);

            WebRootPath = env.WebRootPath;

        }

        private void GenerateDatabase()
        {
            var options = new DbContextOptionsBuilder<CustomContext>()
                .UseSqlServer(ConnectionString).Options;

            using (var ctx = new CustomContext(options))
            {
                ctx.Database.Migrate();
            }

        }

        private void DataInitialization(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var invoiceService = scope.ServiceProvider.GetService<SimpleInvoiceService>();

                if (invoiceService.DataInitializationOk())
                {
                    invoiceService.DataInitialization();

                    using (var serviceScope = app
                      .ApplicationServices
                      .GetRequiredService<IServiceScopeFactory>()
                      .CreateScope()) 
                    {
                        var securityService = serviceScope.ServiceProvider.GetService<SecurityService>();

                        var invoicing = new IdentityRole()
                        {
                            Name = "Invoicing"
                        };

                        var security = new IdentityRole()
                        {
                            Name = "Security"
                        };

                        securityService.CreateRole(invoicing).Wait();
                        securityService.CreateRole(security).Wait();

                        var administrator = new ApplicationUser();
                        administrator.Name = Configuration["CustomSettings:UserAdministrator:Name"];
                        administrator.Email = Configuration["CustomSettings:UserAdministrator:Name"];
                        administrator.Password = Configuration["CustomSettings:UserAdministrator:Password"];
                        administrator.ConfirmPassword = administrator.Password;
                        administrator.RoleNames = new List<string>() { invoicing.Name, security.Name };

                        securityService.CreateUser(administrator).Wait();
                    }


                }


            }
        }

    }
}
