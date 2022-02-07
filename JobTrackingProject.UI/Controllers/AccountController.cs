using Microsoft.AspNetCore.Mvc;

namespace JobTrackingProject.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
