using Blazor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.API.Repository
{
	public class CountryRepository : ICountryRepository
	{
		private readonly AppDbContext appDbContext;

		public CountryRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public IEnumerable<Country> GetAllCountries()
		{
			return appDbContext.Countries;
		}

		public Country GetCountryById(int countryId)
		{
			return appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
		}
	}
}
