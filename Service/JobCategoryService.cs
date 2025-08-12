using FreelancingSystem.Models;
using FreelancingSystem.Repository;
using System.Collections.Generic;

namespace FreelancingSystem.Service
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            return _jobCategoryRepository.GetAll();
        }

        public JobCategory GetJobCategoryByIds(int jobId, int categoryId)
        {
            return _jobCategoryRepository.GetByIds(jobId, categoryId);
        }

        public void CreateJobCategory(JobCategory jobCategory)
        {
            _jobCategoryRepository.Insert(jobCategory);
        }

        public void UpdateJobCategory(JobCategory jobCategory)
        {
            _jobCategoryRepository.Update(jobCategory);
        }

        public void DeleteJobCategory(int jobId, int categoryId)
        {
            _jobCategoryRepository.Delete(jobId, categoryId);
        }
    }
}
