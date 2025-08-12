using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IJobCategoryService jobCategoryService;
        private readonly IJobSkillService jobSkillService;

        public JobService(
            IJobRepository jobRepository,
            IJobCategoryService jobCategoryService,
            IJobSkillService jobSkillService)
        {
            this.jobRepository = jobRepository;
            this.jobCategoryService = jobCategoryService;
            this.jobSkillService = jobSkillService;
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
        public IEnumerable<JobCategory> GetJobCategoriesForJob(int jobId)
        {
            var job = jobRepository.GetById(jobId);
            return job?.JobCategories ?? Enumerable.Empty<JobCategory>();
        }

        public void AssignJobCategoryToJob(int jobId, int categoryId)
        {
            var job = jobRepository.GetById(jobId);
            var category = jobCategoryService.GetJobCategoryById(categoryId);

            if (job != null && category != null && !job.JobCategories.Contains(category))
            {
                job.JobCategories.Add(category);
                jobRepository.Update(job);
            }
        }

        public void RemoveJobCategoryFromJob(int jobId, int categoryId)
        {
            var job = jobRepository.GetById(jobId);
            var category = job?.JobCategories.FirstOrDefault(c => c.Id == categoryId);

            if (job != null && category != null)
            {
                job.JobCategories.Remove(category);
                jobRepository.Update(job);
            }
        }

        // ---------------- Job Skills ----------------
        public IEnumerable<JobSkill> GetJobSkillsForJob(int jobId)
        {
            var job = jobRepository.GetById(jobId);
            return job?.JobSkills ?? Enumerable.Empty<JobSkill>();
        }

        public void AssignJobSkillToJob(int jobId, int skillId)
        {
            var job = jobRepository.GetById(jobId);
            var skill = jobSkillService.GetJobSkillById(skillId);

            if (job != null && skill != null && !job.JobSkills.Contains(skill))
            {
                job.JobSkills.Add(skill);
                jobRepository.Update(job);
            }
        }

        public void RemoveJobSkillFromJob(int jobId, int skillId)
        {
            var job = jobRepository.GetById(jobId);
            var skill = job?.JobSkills.FirstOrDefault(s => s.Id == skillId);

            if (job != null && skill != null)
            {
                job.JobSkills.Remove(skill);
                jobRepository.Update(job);
            }
        }
    }
}


