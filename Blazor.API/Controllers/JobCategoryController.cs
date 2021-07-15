using Blazor.API.Repository;
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
	public class JobCategoryController : ControllerBase
	{
		private readonly IJobCategoryRepository jobCategoryRepository;

		public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
		{
			this.jobCategoryRepository = jobCategoryRepository;
		}

		// GET: api/<controller>
		[HttpGet]
		public IActionResult GetJobCategories()
		{
			return Ok(jobCategoryRepository.GetAllJobCategories());
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public IActionResult GetJobCategoryById(int id)
		{
			return Ok(jobCategoryRepository.GetJobCategoryById(id));
		}
	}
}
