using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IJobCategoryService
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int id);
        void AddJobCategory(JobCategory category);
        void UpdateJobCategory(JobCategory category);
        void DeleteJobCategory(int id);
    }
}