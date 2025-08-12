using FreelancingSystem.Models;
using FreelancingSystem.Repository;

namespace FreelancingSystem.Service
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IJobRepository _jobRepository;

        public ProposalService(
            IProposalRepository proposalRepository,
            IJobRepository jobRepository)
        {
            _proposalRepository = proposalRepository;
            _jobRepository = jobRepository;
        }

        public IEnumerable<Proposal> GetAllProposals()
            => _proposalRepository.GetAll();

        public Proposal GetProposalById(int id)
            => _proposalRepository.GetById(id);

        public void AddProposal(Proposal proposal)
            => _proposalRepository.Add(proposal);

        public void UpdateProposal(Proposal proposal)
            => _proposalRepository.Update(proposal);

        public void DeleteProposal(int id)
            => _proposalRepository.Delete(id);

        // Approve Proposal - only if client owns the job
        public void ApproveProposal(int proposalId, int clientId)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new KeyNotFoundException("Proposal not found.");

            var job = _jobRepository.GetById(proposal.JobId);
            if (job == null || job.ClientId != clientId)
                throw new UnauthorizedAccessException("Client does not own the job.");

            proposal.Status = ProposalStatus.Approved; // Assuming enum or string
            _proposalRepository.Update(proposal);
        }

        // Reject Proposal - only if client owns the job
        public void RejectProposal(int proposalId, int clientId)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new KeyNotFoundException("Proposal not found.");

            var job = _jobRepository.GetById(proposal.JobId);
            if (job == null || job.ClientId != clientId)
                throw new UnauthorizedAccessException("Client does not own the job.");

            proposal.Status = ProposalStatus.Rejected; // Assuming enum or string
            _proposalRepository.Update(proposal);
        }
    }
}
