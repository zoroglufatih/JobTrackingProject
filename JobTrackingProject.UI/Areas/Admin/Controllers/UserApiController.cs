using Microsoft.AspNetCore.Mvc;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    public class UserApiController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
