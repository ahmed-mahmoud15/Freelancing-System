using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IJobSkillService _jobSkillService;

        public JobService(
            IJobRepository jobRepository,
            IJobCategoryService jobCategoryService,
            IJobSkillService jobSkillService)
        {
            _jobRepository = jobRepository;
            _jobCategoryService = jobCategoryService;
            _jobSkillService = jobSkillService;
        }

        // ---------------- Job CRUD ----------------
        public IEnumerable<Job> GetAllJobs() => _jobRepository.GetAll();

        public Job GetJobById(int id) => _jobRepository.GetById(id);

        public void AddJob(Job job) => _jobRepository.Add(job);

        public void UpdateJob(Job job) => _jobRepository.Update(job);

        public void DeleteJob(int id) => _jobRepository.Delete(id);

        // ---------------- Job Categories ----------------
        public IEnumerable<JobCategory> GetJobCategoriesForJob(int jobId)
        {
            var job = _jobRepository.GetById(jobId);
            return job?.JobCategories ?? Enumerable.Empty<JobCategory>();
        }

        public void AssignJobCategoryToJob(int jobId, int categoryId)
        {
            var job = _jobRepository.GetById(jobId);
            var category = _jobCategoryService.GetJobCategoryById(categoryId);

            if (job != null && category != null && !job.JobCategories.Contains(category))
            {
                job.JobCategories.Add(category);
                _jobRepository.Update(job);
            }
        }

        public void RemoveJobCategoryFromJob(int jobId, int categoryId)
        {
            var job = _jobRepository.GetById(jobId);
            var category = job?.JobCategories.FirstOrDefault(c => c.Id == categoryId);

            if (job != null && category != null)
            {
                job.JobCategories.Remove(category);
                _jobRepository.Update(job);
            }
        }

        // ---------------- Job Skills ----------------
        public IEnumerable<JobSkill> GetJobSkillsForJob(int jobId)
        {
            var job = _jobRepository.GetById(jobId);
            return job?.JobSkills ?? Enumerable.Empty<JobSkill>();
        }

        public void AssignJobSkillToJob(int jobId, int skillId)
        {
            var job = _jobRepository.GetById(jobId);
            var skill = _jobSkillService.GetJobSkillById(skillId);

            if (job != null && skill != null && !job.JobSkills.Contains(skill))
            {
                job.JobSkills.Add(skill);
                _jobRepository.Update(job);
            }
        }

        public void RemoveJobSkillFromJob(int jobId, int skillId)
        {
            var job = _jobRepository.GetById(jobId);
            var skill = job?.JobSkills.FirstOrDefault(s => s.Id == skillId);

            if (job != null && skill != null)
            {
                job.JobSkills.Remove(skill);
                _jobRepository.Update(job);
            }
        }
    }
}
