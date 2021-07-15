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
	public class CountryController : ControllerBase
	{
		private readonly ICountryRepository countryRepository;

		public CountryController(ICountryRepository countryRepository)
		{
			this.countryRepository = countryRepository;
		}

		[HttpGet]
		public IActionResult GetCountries()
		{
			return Ok(countryRepository.GetAllCountries());
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public IActionResult GetCountryById(int id)
		{
			return Ok(countryRepository.GetCountryById(id));
		}
	}
}
