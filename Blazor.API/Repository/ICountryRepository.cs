using Blazor.Domain;
using System.Collections.Generic;

namespace Blazor.API.Repository
{
	public interface ICountryRepository
	{
		IEnumerable<Country> GetAllCountries();
		Country GetCountryById(int countryId);
	}
}