using FreelancingSystem.Data;
using FreelancingSystem.Models;

namespace FreelancingSystem.Repository
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {

        public ProposalRepository(ApplicationDbContext context) : base(context) { }

        public Proposal GetProposalByIdentityId(string id)
        {
            return table.FirstOrDefault(e => e.IdentityId.Equals(id));
        }
    }
}