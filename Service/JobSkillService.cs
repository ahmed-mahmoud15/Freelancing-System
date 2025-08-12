using FreelancingSystem.Models;
using FreelancingSystem.Repository;

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
            => _jobSkillRepository.GetAll();

        public JobSkill GetJobSkillById(int id)
            => _jobSkillRepository.GetById(id);

        public void AddJobSkill(JobSkill skill)
            => _jobSkillRepository.Add(skill);

        public void UpdateJobSkill(JobSkill skill)
            => _jobSkillRepository.Update(skill);

        public void DeleteJobSkill(int id)
            => _jobSkillRepository.Delete(id);
    }
}