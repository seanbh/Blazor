using Blazor.Domain;
using System.Collections.Generic;

namespace Blazor.API.Repository
{
	public interface IJobCategoryRepository
	{
		IEnumerable<JobCategory> GetAllJobCategories();
		JobCategory GetJobCategoryById(int jobCategoryId);
	}
}