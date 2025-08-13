using Microsoft.AspNetCore.Mvc;

namespace FreelancingSystem.Controllers
{
    public class FreelancerController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
