using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IProposalRepository _proposalRepository;

        public FreelancerService(
            IFreelancerRepository freelancerRepository,
            IProposalRepository proposalRepository)
        {
            _freelancerRepository = freelancerRepository;
            _proposalRepository = proposalRepository;
        }

        // ---------------- Freelancer CRUD ----------------
        public IEnumerable<Freelancer> GetAllFreelancers()
            => _freelancerRepository.GetAll();

        public Freelancer GetFreelancerById(int id)
            => _freelancerRepository.GetById(id);

        public Freelancer GetFreelancerByIdentity(string id)
            => _freelancerRepository.GetFreelancerByIdentityId(id);

        public void AddFreelancer(Freelancer freelancer)
            => _freelancerRepository.Add(freelancer);

        public void UpdateFreelancer(Freelancer freelancer)
            => _freelancerRepository.Update(freelancer);

        public void DeleteFreelancer(int id)
            => _freelancerRepository.Delete(id);

        // ---------------- Proposal Management ----------------
        public void AddProposal(int freelancerId, Proposal proposal)
        {
            var freelancer = _freelancerRepository.GetById(freelancerId);
            if (freelancer != null)
            {
                proposal.FreelancerId = freelancerId;
                _proposalRepository.Add(proposal);
            }
        }

        public void DeleteProposal(int freelancerId, int proposalId)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal != null && proposal.FreelancerId == freelancerId)
            {
                _proposalRepository.Delete(proposalId);
            }
        }
    }
}
