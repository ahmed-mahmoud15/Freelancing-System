using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        Proposal GetProposalByIdentityId(string id);
    }
}