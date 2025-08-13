using FreelancingSystem.Models;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace FreelancingSystem.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IFreelancerService _freelancerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(
            IUserService userService,
            IClientService clientService,
            IFreelancerService freelancerService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _clientService = clientService;
            _freelancerService = freelancerService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RegisterAccountAsync(RegisterViewModel model, string identityId, IFormFile ProfileImageFile)
        {
            var identityUser = await _userManager.FindByIdAsync(identityId);
            if (identityUser == null) return false;

            string roleName = model.Role.ToString();
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (model.Role == RoleViewModel.Client)
            {
                var client = new Client
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ProfileImagePath = model.PhotoPath,
                    IdentityId = identityId,
                    CompanyName = model.ClientCompanyName
                };
                _clientService.AddClient(client, ProfileImageFile);
            }
            else if (model.Role == RoleViewModel.Freelancer)
            {
                var freelancer = new Freelancer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ProfileImagePath = model.PhotoPath,
                    IdentityId = identityId,
                    Bio = model.FreelancerBio
                };
                _freelancerService.AddFreelancer(freelancer);
            }

            var result = await _userManager.AddToRoleAsync(identityUser, roleName);
            return result.Succeeded;
        }

    }
}
