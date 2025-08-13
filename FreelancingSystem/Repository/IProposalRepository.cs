using FreelancingSystem.Models;
using System.Collections.Generic;

namespace FreelancingSystem.Repository
{
    public interface IProposalRepository
    {
        IEnumerable<Proposal> GetAll();
        IEnumerable<Proposal> GetAllByJobId(int jobId);
        Proposal GetByIds(int jobId, int freelancerId);
        void Insert(Proposal proposal);
        void Update(Proposal proposal);
        void Delete(int jobId, int freelancerId);
        void Save();
    }
}
