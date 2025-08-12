using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{

    public class JobSkillService : IJobSkillService
    {
        private readonly IJobSkillRepository jobSkillRepository;

        public JobSkillService(IJobSkillRepository jobSkillRepository)
        {
            this.jobSkillRepository = jobSkillRepository;
        }

        public void AddJobSkill(JobSkill jobskill)
        {
            jobskillRepository.Insert(jobskill);
            jobskillRepository.Save();
        }

        public void DeleteJobSkill(int id)
        {
            jobskillRepository.Delete(id);
            jobskillRepository.Save();
        }

        public IEnumerable<JobSkill> GetAllJobSkills()
        {
            return jobskillRepository.GetAll();
        }

        public JobSkill GetJobSkillById(int id)
        {
            return jobskillRepository.GetById(id);
        }

        public void UpdateJobSkill(JobSkill jobskill)
        {
            jobskillRepository.Update(jobskill);
            jobskillRepository.Save();
        }
    }
}