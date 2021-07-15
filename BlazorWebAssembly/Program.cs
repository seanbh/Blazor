using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			//this works in webassembly only
			//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44380/") });

			//this works in webassembly and server blazor
			builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri("https://localhost:44380/"));

			await builder.Build().RunAsync();
		}
	}
}
