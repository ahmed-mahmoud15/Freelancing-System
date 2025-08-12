using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository proposalRepository;
        private readonly IJobRepository jobRepository;

        public ProposalService(
            IProposalRepository proposalRepository,
            IJobRepository jobRepository)
        {
            this.proposalRepository = proposalRepository;
            this.jobRepository = jobRepository;
        }

        public void AddProposal(Proposal proposal)
        {
            proposalRepository.Insert(proposal);
            proposalRepository.Save();
        }

        public void DeleteProposal(int id)
        {
            proposalRepository.Delete(id);
            proposalRepository.Save();
        }

        public IEnumerable<Proposal> GetAllProposals()
        {
            return proposalRepository.GetAll();
        }

        public Proposal GetProposalById(int id)
        {
            return proposalRepository.GetById(id);
        }

        public void UpdateProposal(Proposal proposal)
        {
            proposalRepository.Update(proposal);
            proposalRepository.Save();
        }

        // Approve Proposal - only if client owns the job
        public void ApproveProposal(int proposalId, int clientId)
        {
            var proposal = proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new KeyNotFoundException("Proposal not found.");

            var job = jobRepository.GetById(proposal.JobId);
            if (job == null || job.ClientId != clientId)
                throw new UnauthorizedAccessException("Client does not own the job.");

            proposal.Status = ProposalStatus.Approved; // Assuming enum or string
            proposalRepository.Update(proposal);
        }

        // Reject Proposal - only if client owns the job
        public void RejectProposal(int proposalId, int clientId)
        {
            var proposal = proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new KeyNotFoundException("Proposal not found.");

            var job = jobRepository.GetById(proposal.JobId);
            if (job == null || job.ClientId != clientId)
                throw new UnauthorizedAccessException("Client does not own the job.");

            proposal.Status = ProposalStatus.Rejected; // Assuming enum or string
            proposalRepository.Update(proposal);
        }
    }
}
