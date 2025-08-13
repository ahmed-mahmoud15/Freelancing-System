using FreelancingSystem.Models;
using FreelancingSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FreelancingSystem.Repository
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly ApplicationDbContext context;

        public ProposalRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Proposal> GetAll()
        {
            return context.Proposals
                .Include(p => p.Job)
                .Include(p => p.Freelancer)
                .ToList();
        }

        public Proposal GetByIds(int jobId, int freelancerId)
        {
            return context.Proposals
                .Include(p => p.Job)
                .Include(p => p.Freelancer)
                .FirstOrDefault(p => p.JobId == jobId && p.FreelancerId == freelancerId);
        }

        public void Insert(Proposal proposal)
        {
            context.Proposals.Add(proposal);
        }

        public void Update(Proposal proposal)
        {
            context.Proposals.Update(proposal);
        }

        public void Delete(int jobId, int freelancerId)
        {
            var proposal = GetByIds(jobId, freelancerId);
            if (proposal != null)
            {
                context.Proposals.Remove(proposal);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
