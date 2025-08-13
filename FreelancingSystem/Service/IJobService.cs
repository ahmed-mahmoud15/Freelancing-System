using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IJobService
    {
        // Job CRUD
        IEnumerable<Job> GetAllJobs();
        IEnumerable<Job> GetJobsByClinetId(int id);
        Job GetJobById(int id);
        void AddJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(int id);

        // Job Categories
        IEnumerable<JobCategory> GetJobCategoriesForJob(int jobId, int categoryId);
        void AssignJobCategoryToJob(int jobId, int categoryId);
        void RemoveJobCategoryFromJob(int jobId, int categoryId);

        // Job Skills
        IEnumerable<JobSkill> GetJobSkillsForJob(int jobId, int skillId);
        void AssignJobSkillToJob(int jobId, int skillId);
        void RemoveJobSkillFromJob(int jobId, int skillId);
    }
}
