using FreelancingSystem.Models;
using System.Collections.Generic;

namespace FreelancingSystem.Service
{
    public interface IJobCategoryService
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryByIds(int jobId, int categoryId);
        void CreateJobCategory(JobCategory jobCategory);
        void UpdateJobCategory(JobCategory jobCategory);
        void DeleteJobCategory(int jobId, int categoryId);
    }
}
