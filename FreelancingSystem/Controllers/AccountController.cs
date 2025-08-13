using FreelancingSystem.Models;
using FreelancingSystem.Service;
using FreelancingSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelancingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile ProfileImageFile)
        {
            if (!ModelState.IsValid)
            {
                foreach(var error in ModelState)
                {
                    ModelState.AddModelError(error.Key, error.Value.ToString());
                }
                
                return View(model);
            }
                

            string? identityId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(identityId))
            {
                ModelState.AddModelError("", "Session expired. Please log in again.");
                return View(model);
            }

            bool success = await _accountService.RegisterAccountAsync(model, identityId, ProfileImageFile);

            if (success)
            {
                return LocalRedirect("/Identity/Account/Login");
            }

            ModelState.AddModelError("", "Registration failed.");
            return View(model);
        }
    }
}
