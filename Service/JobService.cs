using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IJobCategoryRepository jobCategoryRepository;
        private readonly IJobSkillRepository jobSkillRepository;

        public JobService(
            IJobRepository jobRepository,
            IJobCategoryRepository jobCategoryRepository,
            IJobSkillRepository jobSkillRepository)
        {
            this.jobRepository = jobRepository;
            this.jobCategoryRepository = jobCategoryRepository;
            this.jobSkillRepository = jobSkillRepository;
        }

        // ---------------- Job CRUD ----------------
        public void AddJob(Job job)
        {
            jobRepository.Insert(job);
            jobRepository.Save();
        }

        public void DeleteJob(int id)
        {
            jobRepository.Delete(id);
            jobRepository.Save();
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return jobRepository.GetAll();
        }

        public Job GetJobById(int id)
        {
            return jobRepository.GetById(id);
        }

        public void UpdateJob(Job job)
        {
            jobRepository.Update(job);
            jobRepository.Save();
        }

        // ---------------- Job Categories ----------------
        public IEnumerable<JobCategory> GetJobCategoriesForJob(int jobId, int categoryId)
        {
            var category = jobCategoryRepository.GetByIds(jobId, categoryId);
            if (category == null)
                return Enumerable.Empty<JobCategory>();
            return new List<JobCategory> { category };
        }

        public void AssignJobCategoryToJob(int jobId, int categoryId)
        {
            var existing = jobCategoryRepository.GetByIds(jobId, categoryId);
            if (existing == null)
            {
                var jobCategory = new JobCategory { JobId = jobId, CategoryId = categoryId };
                jobCategoryRepository.Insert(jobCategory);
                jobCategoryRepository.Save();
            }
        }

        public void RemoveJobCategoryFromJob(int jobId, int categoryId)
        {
            var existing = jobCategoryRepository.GetByIds(jobId, categoryId);
            if (existing != null)
            {
                jobCategoryRepository.Delete(jobId, categoryId);
                jobCategoryRepository.Save();
            }
        }

        // ---------------- Job Skills ----------------
        public IEnumerable<JobSkill> GetJobSkillsForJob(int jobId, int skillId)
        {
            var skill = jobSkillRepository.GetByIds(jobId, skillId);
            if (skill == null)
                return Enumerable.Empty<JobSkill>();
            return new List<JobSkill> { skill };
        }

        public void AssignJobSkillToJob(int jobId, int skillId)
        {
            var existing = jobSkillRepository.GetByIds(jobId, skillId);
            if (existing == null)
            {
                var jobSkill = new JobSkill { JobId = jobId, SkillId = skillId };
                jobSkillRepository.Insert(jobSkill);
                jobSkillRepository.Save();
            }
        }

        public void RemoveJobSkillFromJob(int jobId, int skillId)
        {
            var existing = jobSkillRepository.GetByIds(jobId, skillId);
            if (existing != null)
            {
                jobSkillRepository.Delete(jobId, skillId);
                jobSkillRepository.Save();
            }
        }
    }
}
