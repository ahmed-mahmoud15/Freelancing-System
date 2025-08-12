using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository freelancerRepository;
        private readonly IProposalRepository proposalRepository;

        public FreelancerService(
            IFreelancerRepository freelancerRepository,
            IProposalRepository proposalRepository)
        {
            this.freelancerRepository = freelancerRepository;
            this.proposalRepository = proposalRepository;
        }

        // ---------------- Freelancer CRUD ----------------
        public void AddFreelancer(Freelancer freelancer)
        {
            freelancerRepository.Insert(freelancer);
            freelancerRepository.Save();
        }

        public void DeleteFreelancer(int id)
        {
            freelancerRepository.Delete(id);
            freelancerRepository.Save();
        }

        public IEnumerable<Freelancer> GetAllFreelancers()
        {
            return freelancerRepository.GetAll();
        }

        public Freelancer GetFreelancerById(int id)
        {
            return freelancerRepository.GetById(id);
        }

        public Freelancer GetFreelancerByIdentity(string id)
        {
            return freelancerRepository.GetFreelancerByIdentityId(id);
        }

        public void UpdateFreelancer(Freelancer freelancer)
        {
            freelancerRepository.Update(freelancer);
            freelancerRepository.Save();
        }

        // ---------------- Proposal Management ----------------
        public void AddProposal(int freelancerId, Proposal proposal)
        {
            var freelancer = freelancerRepository.GetById(freelancerId);
            if (freelancer != null)
            {
                proposal.FreelancerId = freelancerId;
                proposalRepository.Insert(proposal);
            }
        }

        public void DeleteProposal(int jobId, int freelancerId)
        {
            var proposal = proposalRepository.GetByIds(jobId, freelancerId);
            if (proposal != null && proposal.FreelancerId == freelancerId)
            {
                proposalRepository.Delete(jobId, freelancerId);
            }
        }
    }
}
