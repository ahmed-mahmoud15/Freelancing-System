using FreelancingSystem.Models;
using FreelancingSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreelancingSystem.Repository
{
    public class JobSkillRepository : IJobSkillRepository
    {
        private readonly ApplicationDbContext context;

        public JobSkillRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<JobSkill> GetAll()
        {
            return context.JobSkills
                .Include(js => js.Job)
                .Include(js => js.Skill)
                .AsNoTracking() // Optional: improves performance if no update tracking is needed
                .ToList();
        }

        public JobSkill GetByIds(int jobId, int skillId)
        {
            return context.JobSkills
                .Include(js => js.Job)
                .Include(js => js.Skill)
                .FirstOrDefault(js => js.JobId == jobId && js.SkillId == skillId);
        }

        public void Insert(JobSkill jobskill)
        {
            context.JobSkills.Add(jobskill);
        }

        public void Update(JobSkill jobskill)
        {
            context.JobSkills.Update(jobskill);
        }

        public void Delete(int jobId, int skillId)
        {
            var jobskill = GetByIds(jobId, skillId);
            if (jobskill != null)
            {
                context.JobSkills.Remove(jobskill);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
