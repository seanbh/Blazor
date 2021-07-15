using Blazor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.API.Repository
{
	public class JobCategoryRepository : IJobCategoryRepository
	{
		private readonly AppDbContext appDbContext;

		public JobCategoryRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public IEnumerable<JobCategory> GetAllJobCategories()
		{
			return appDbContext.JobCategories;
		}

		public JobCategory GetJobCategoryById(int jobCategoryId)
		{
			return appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
		}
	}
}
