using FreelancingSystem.Models;
using FreelancingSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreelancingSystem.Repository
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly ApplicationDbContext context;

        public JobCategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<JobCategory> GetAll()
        {
            return context.JobCategories
                .Include(js => js.Job)
                .Include(js => js.Category)
                .AsNoTracking() // Optional: improves performance if no update tracking is needed
                .ToList();
        }

        public JobCategory GetByIds(int jobId, int categoryId)
        {
            return context.JobCategories
                .Include(jc => jc.Job)
                .Include(jc => jc.Category)
                .FirstOrDefault(jc => jc.JobId == jobId && jc.CategoryId == categoryId);
        }

        public void Insert(JobCategory jobcategory)
        {
            context.JobCategories.Add(jobcategory);
        }

        public void Update(JobCategory jobcategory)
        {
            context.JobCategories.Update(jobcategory);
        }

        public void Delete(int jobId, int categoryId)
        {
            var jobcategory = GetByIds(jobId, categoryId);
            if (jobcategory != null)
            {
                context.JobCategories.Remove(jobcategory);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
