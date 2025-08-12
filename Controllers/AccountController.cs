using FreelancingSystem.Models;
using FreelancingSystem.Service;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelancingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(
            RegisterViewModel model,
            [FromServices] UserManager<IdentityUser> userManager,
            [FromServices] RoleManager<IdentityRole> roleManager
            )
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ProfileImagePath = model.PhotoPath,
                    IdentityId = HttpContext.Session.GetString("user_id")
                };
                userService.AddUser(user);

                var identityUser = await userManager.FindByIdAsync(user.IdentityId);

                if(model.Role == RoleViewModel.Client)
                {
                    if (!await roleManager.RoleExistsAsync("Client"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Client"));
                    }
                    Client client = new Client()
                    {
                        CompanyName = model.ClientCompanyName,
                        Id = user.Id
                    };

                    // clientService.AddClient(client);

                    var result = await userManager.AddToRoleAsync(identityUser, "Client");

                    if (result.Succeeded)
                    {
                        return RedirectToAction(); // client dashboard
                    }

                }
                else if(model.Role == RoleViewModel.Freelancer)
                {
                    if (!await roleManager.RoleExistsAsync("Freelancer"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Freelancer"));
                    }

                    Freelancer freelancer = new Freelancer()
                    {
                        Bio = model.FreelancerBio,
                        Id = user.Id
                    };

                    // freelancerService.AddFreelancer(freelancer);

                    var result = await userManager.AddToRoleAsync(identityUser, "Freelancer");

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home"); // freelancer dashboard
                    }
                }
            }
            return View(model);
        }
    }
}
