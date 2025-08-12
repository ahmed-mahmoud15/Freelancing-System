using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{

    public class JobCategoryService : IJobCategoryService
    {
        private readonly IJobCategoryRepository jobCategoryRepository;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository)
        {
            this.jobCategoryRepository = jobCategoryRepository;
        }

        public void AddJobCategory(JobCategory jobcategory)
        {
            jobcategoryRepository.Insert(jobcategory);
            jobcategoryRepository.Save();
        }

        public void DeleteJobCategory(int id)
        {
            jobcategoryRepository.Delete(id);
            jobcategoryRepository.Save();
        }

        public IEnumerable<JobCategory> GetAllJobCategorys()
        {
            return jobcategoryRepository.GetAll();
        }

        public JobCategory GetJobCategoryById(int id)
        {
            return jobcategoryRepository.GetById(id);
        }

        public void UpdateJobCategory(JobCategory jobcategory)
        {
            jobcategoryRepository.Update(jobcategory);
            jobcategoryRepository.Save();
        }

    }
}