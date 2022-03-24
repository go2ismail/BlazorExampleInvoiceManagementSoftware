using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using TlaxRatio.Reporting.Api.SDK;
using System;
using System.Net.Http;

namespace TlaxRatio.Server 
{
    public class ReportApiConfig
    {
        public const string SectionName = "ReportApi";
        public string Uri { get; set; }
    }

    public static class ServiceRegistererExtension
    {

        public static void AddReportApi(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ReportApiConfig();
            configuration.GetSection(ReportApiConfig.SectionName).Bind(config);
            services.AddSingleton(config);
            services.AddRefitClient<IReportApi>(new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })))
                      .ConfigureHttpClient(client =>
                      {
                          client.BaseAddress = new Uri(config.Uri);
                      })
                      // .AddHttpMessageHandler<GreyHoundDelegateHandler>()
                      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                      {
                          ClientCertificateOptions = ClientCertificateOption.Automatic,
                          ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
                      });
        }
    }
}
