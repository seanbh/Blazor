using Blazor.API.Repository;
using Blazor.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository employeeRepository;

		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		[HttpGet]
		public IActionResult GetAllEmployees()
		{
			return Ok(employeeRepository.GetEmployees());
		}

		[HttpGet]
		[Route("{employeeId}")]
		public IActionResult GetEmployeeById(int employeeId)
		{
			return Ok(employeeRepository.GetEmployeeById(employeeId));
		}

		[HttpPost]
		public IActionResult AddEmployee([FromBody] Employee employee)
		{
			if (employee == null)
				return BadRequest();

			if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
				ModelState.AddModelError("Name", "Name can't be empty");

			if (!ModelState.IsValid)
				return BadRequest();

			var newEmployee = employeeRepository.AddEmployee(employee);

			return Created("employee", newEmployee);
		}

		[HttpPut]
		public IActionResult UpdateEmployee([FromBody] Employee employee)
		{
			if (employee == null)
				return BadRequest();

			if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
			{
				ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
			}

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var employeeToUpdate = employeeRepository.GetEmployeeById(employee.EmployeeId);

			if (employeeToUpdate == null)
				return NotFound();

			employeeRepository.UpdateEmployee(employee);

			return NoContent();
		}

		[HttpDelete]
		[Route("{employeeId}")]
		public IActionResult DeleteEmployee(int employeeId)
		{
			if (employeeId == 0)
				return BadRequest();

			var employeeToDelete = employeeRepository.GetEmployeeById(employeeId);
			if (employeeToDelete == null)
				return NotFound();

			employeeRepository.DeleteEmployee(employeeId);

			return NoContent();
		}
	}
}
