using Blazor.Domain;
using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Pages
{
	public partial class EmployeeOverview : ComponentBase
	{
		public IEnumerable<Employee> Employees { get; set; }

		private List<Country> Countries { get; set; }

		private List<JobCategory> JobCategories { get; set; }

		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		protected override async Task OnInitializedAsync()
		{
			var employees = await EmployeeDataService.GetEmployees();

			Employees = employees;
		}
	}
}
