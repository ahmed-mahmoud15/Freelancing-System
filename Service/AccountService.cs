using FreelancingSystem.Models;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace FreelancingSystem.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        //private readonly IClientService _clientService;
        //private readonly IFreelancerService _freelancerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(
            IUserService userService,
            //IClientService clientService,
            //IFreelancerService freelancerService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            //_clientService = clientService;
            //_freelancerService = freelancerService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RegisterAccountAsync(RegisterViewModel model, string identityId)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfileImagePath = model.PhotoPath,
                IdentityId = identityId
            };
            _userService.AddUser(user);

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
                    CompanyName = model.ClientCompanyName,
                    Id = user.Id
                };
                //_clientService.AddClient(client);
            }
            else if (model.Role == RoleViewModel.Freelancer)
            {
                var freelancer = new Freelancer
                {
                    Bio = model.FreelancerBio,
                    Id = user.Id
                };
                //_freelancerService.AddFreelancer(freelancer);
            }

            var result = await _userManager.AddToRoleAsync(identityUser, roleName);
            return result.Succeeded;
        }
    }
}
