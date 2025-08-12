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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string? identityId = HttpContext.Session.GetString("user_id");
            if (string.IsNullOrEmpty(identityId))
            {
                ModelState.AddModelError("", "Session expired. Please log in again.");
                return View(model);
            }

            bool success = await _accountService.RegisterAccountAsync(model, identityId);

            if (success)
            {
                return model.Role == RoleViewModel.Client
                    ? RedirectToAction("Dashboard", "Client")
                    : RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Registration failed.");
            return View(model);
        }
    }
}
