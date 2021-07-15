using Blazor.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services
{
	public interface IEmployeeDataService
	{
		Task<IEnumerable<Employee>> GetEmployees();
	}
}