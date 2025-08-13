using FreelancingSystem.Models;
using FreelancingSystem.Repository;
using System.Collections.Generic;

namespace FreelancingSystem.Service
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalService(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public IEnumerable<Proposal> GetAllProposals()
        {
            return _proposalRepository.GetAll();
        }

        public Proposal GetProposalById(int jobId, int freelancerId)
        {
            return _proposalRepository.GetByIds(jobId, freelancerId);
        }

        public void AddProposal(Proposal proposal)
        {
            _proposalRepository.Insert(proposal);
            _proposalRepository.Save();
        }

        public void UpdateProposal(Proposal proposal)
        {
            _proposalRepository.Update(proposal);
        }

        public void DeleteProposal(int jobId, int freelancerId)
        {
            _proposalRepository.Delete(jobId, freelancerId);
        }

        public void ApproveProposal(int jobId, int freelancerId)
        {
            var proposal = _proposalRepository.GetByIds(jobId, freelancerId);
            if (proposal != null)
            {
                proposal.Status = Status.Approved;
                _proposalRepository.Update(proposal);
                _proposalRepository.Save();
            }
        }

        public void RejectProposal(int jobId, int freelancerId)
        {
            var proposal = _proposalRepository.GetByIds(jobId, freelancerId);
            if (proposal != null)
            {
                proposal.Status = Status.Rejected;
                _proposalRepository.Update(proposal);
                _proposalRepository.Save();
            }
        }

        public IEnumerable<Proposal> GetAllFreelancersAppliedFor(int jobId)
        {
            return _proposalRepository.GetAllByJobId(jobId);
        }
    }
}
