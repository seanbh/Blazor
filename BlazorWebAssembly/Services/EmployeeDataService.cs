using Blazor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services
{
	public class EmployeeDataService : IEmployeeDataService
	{
		private readonly HttpClient httpClient;

		public EmployeeDataService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IEnumerable<Employee>> GetEmployees()
		{
			return await httpClient.GetFromJsonAsync<List<Employee>>("employee");
		}
	}
}
