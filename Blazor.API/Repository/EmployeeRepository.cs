using Blazor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.API.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly AppDbContext appDbContext;

		public EmployeeRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public IEnumerable<Employee> GetEmployees()
		{
			return appDbContext.Employees.ToList();
		}

		public Employee GetEmployeeById(int employeeId)
		{
			return appDbContext.Employees.Find(employeeId);
		}

		public Employee AddEmployee(Employee employee)
		{
			var addedEntity = appDbContext.Employees.Add(employee);
			appDbContext.SaveChanges();
			return addedEntity.Entity;
		}

		public Employee UpdateEmployee(Employee employee)
		{
			var foundEmployee = appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

			if (foundEmployee != null)
			{
				foundEmployee.CountryId = employee.CountryId;
				foundEmployee.MaritalStatus = employee.MaritalStatus;
				foundEmployee.BirthDate = employee.BirthDate;
				foundEmployee.City = employee.City;
				foundEmployee.Email = employee.Email;
				foundEmployee.FirstName = employee.FirstName;
				foundEmployee.LastName = employee.LastName;
				foundEmployee.Gender = employee.Gender;
				foundEmployee.PhoneNumber = employee.PhoneNumber;
				foundEmployee.Smoker = employee.Smoker;
				foundEmployee.Street = employee.Street;
				foundEmployee.Zip = employee.Zip;
				foundEmployee.JobCategoryId = employee.JobCategoryId;
				foundEmployee.Comment = employee.Comment;
				foundEmployee.ExitDate = employee.ExitDate;
				foundEmployee.JoinedDate = employee.JoinedDate;

				appDbContext.SaveChanges();

				return foundEmployee;
			}

			return null;
		}

		public void DeleteEmployee(int employeeId)
		{
			var foundEmployee = appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
			if (foundEmployee == null) return;

			appDbContext.Employees.Remove(foundEmployee);
			appDbContext.SaveChanges();
		}
	}
}
