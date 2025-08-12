using FreelancingSystem.Models;
using FreelancingSystem.Repository;

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
            => _jobCategoryRepository.GetAll();

        public JobCategory GetJobCategoryById(int id)
            => _jobCategoryRepository.GetById(id);

        public void AddJobCategory(JobCategory category)
            => _jobCategoryRepository.Add(category);

        public void UpdateJobCategory(JobCategory category)
            => _jobCategoryRepository.Update(category);

        public void DeleteJobCategory(int id)
            => _jobCategoryRepository.Delete(id);
    }
}