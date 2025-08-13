using FreelancingSystem.ViewModel;

namespace FreelancingSystem.Service
{
    public interface IAccountService
    {
        Task<bool> RegisterAccountAsync(RegisterViewModel model, string identityId, IFormFile file);
    }
}
