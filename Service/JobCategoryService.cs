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
            jobCategoryRepository.Insert(jobcategory);
            jobCategoryRepository.Save();
        }

        public void DeleteJobCategory(int id)
        {
            jobCategoryRepository.Delete(id);
            jobCategoryRepository.Save();
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobCategory> GetAllJobCategorys()
        {
            return jobCategoryRepository.GetAll();
        }

        public JobCategory GetJobCategoryById(int id)
        {
            return jobCategoryRepository.GetById(id);
        }

        public void UpdateJobCategory(JobCategory jobcategory)
        {
            jobCategoryRepository.Update(jobcategory);
            jobCategoryRepository.Save();
        }

    }
}