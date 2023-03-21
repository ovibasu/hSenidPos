using Blazored.Toast;
using hSenidPos.Client.Services.BillDetailsService;
using hSenidPos.Client.Services.BillMasterService;
using hSenidPos.Client.Services.ItemService;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPos.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("hSenidPos.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("hSenidPos.ServerAPI"));

            builder.Services.AddBlazoredToast();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IBillMasterService, BillMasterService>();
            builder.Services.AddScoped<IBillDetailsService, BillDetailsService>();

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
