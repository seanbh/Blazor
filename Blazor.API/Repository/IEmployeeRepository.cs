using Blazor.Domain;
using System.Collections.Generic;

namespace Blazor.API.Repository
{
	public interface IEmployeeRepository
	{
		Employee AddEmployee(Employee employee);
		void DeleteEmployee(int employeeId);
		Employee GetEmployeeById(int employeeId);
		IEnumerable<Employee> GetEmployees();
		Employee UpdateEmployee(Employee employee);
	}
}