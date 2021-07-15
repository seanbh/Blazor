using Blazor.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services
{
	public interface IEmployeeDataService
	{
		Task<Employee> AddEmployee(Employee employee);
		Task DeleteEmployee(int employeeId);
		Task<Employee> GetEmployee(int employeeId);
		Task<Employee> GetEmployeeDetails(int employeeId);
		Task<IEnumerable<Employee>> GetEmployees();
		Task<Employee> UpdatedEmployee(Employee employee);
	}
}