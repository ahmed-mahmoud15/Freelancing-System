using FreelancingSystem.Models;

namespace FreelancingSystem.Service
{
    public interface IProposalService
    {
        IEnumerable<Proposal> GetAllProposals();
        Proposal GetProposalById(int id);
        void AddProposal(Proposal proposal);
        void UpdateProposal(Proposal proposal);
        void DeleteProposal(int id);

        // New status methods
        void ApproveProposal(int proposalId, int clientId);
        void RejectProposal(int proposalId, int clientId);
    }
}
