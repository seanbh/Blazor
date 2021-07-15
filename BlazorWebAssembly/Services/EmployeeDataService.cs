using Blazor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
			return await httpClient.GetFromJsonAsync<List<Employee>>("api/employee");
		}

		public async Task<Employee> GetEmployee(int employeeId)
		{
			return await httpClient.GetFromJsonAsync<Employee>($"api/employee/{employeeId}");
		}

		public async Task<Employee> GetEmployeeDetails(int employeeId)
		{
			return await httpClient.GetFromJsonAsync<Employee>($"api/employee/{employeeId}");
		}

		public async Task<Employee> AddEmployee(Employee employee)
		{
			var response = await httpClient.PostAsJsonAsync<Employee>("api/employee", employee);
			if (response.IsSuccessStatusCode)
				return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
			else
				return null;
		}

		public async Task<Employee> UpdatedEmployee(Employee employee)
		{
			var response = await httpClient.PutAsJsonAsync<Employee>("api/employee", employee);
			if (response.IsSuccessStatusCode)
				return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
			else
				return null;
		}

		public async Task DeleteEmployee(int employeeId)
		{
			await httpClient.DeleteAsync($"employee/{employeeId}");
		}
	}
}
