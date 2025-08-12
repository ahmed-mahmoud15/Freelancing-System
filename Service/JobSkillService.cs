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
            jobSkillRepository.Insert(jobskill);
            jobSkillRepository.Save();
        }

        public void DeleteJobSkill(int id)
        {
            jobSkillRepository.Delete(id);
            jobSkillRepository.Save();
        }

        public IEnumerable<JobSkill> GetAllJobSkills()
        {
            return jobSkillRepository.GetAll();
        }

        public JobSkill GetJobSkillById(int id)
        {
            return jobSkillRepository.GetById(id);
        }

        public void UpdateJobSkill(JobSkill jobskill)
        {
            jobSkillRepository.Update(jobskill);
            jobSkillRepository.Save();
        }
    }
}