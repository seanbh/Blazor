using Blazor.Domain;
using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Pages
{
	public partial class EmployeeDetail : ComponentBase
	{
		[Parameter]
		public string EmployeeId { get; set; }

		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		public Employee Employee { get; set; } = new Employee();

		public IEnumerable<Employee> Employees { get; set; }

		private List<Country> Countries { get; set; }

		private List<JobCategory> JobCategories { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Employee = await EmployeeDataService.GetEmployee(int.Parse(EmployeeId));
		}
	}
}
