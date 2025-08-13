using FreelancingSystem.Models;
using FreelancingSystem.Repository;
using System.Collections.Generic;

namespace FreelancingSystem.Service
{
    public class JobSkillService : IJobSkillService
    {
        private readonly IJobSkillRepository _jobSkillRepository;

        public JobSkillService(IJobSkillRepository jobSkillRepository)
        {
            _jobSkillRepository = jobSkillRepository;
        }

        public IEnumerable<JobSkill> GetAllJobSkills()
        {
            return _jobSkillRepository.GetAll();
        }

        public JobSkill GetJobSkillByIds(int jobId, int skillId)
        {
            return _jobSkillRepository.GetByIds(jobId, skillId);
        }

        public void CreateJobSkill(JobSkill jobSkill)
        {
            _jobSkillRepository.Insert(jobSkill);
        }

        public void UpdateJobSkill(JobSkill jobSkill)
        {
            _jobSkillRepository.Update(jobSkill);
        }

        public void DeleteJobSkill(int jobId, int skillId)
        {
            _jobSkillRepository.Delete(jobId, skillId);
        }
    }
}
