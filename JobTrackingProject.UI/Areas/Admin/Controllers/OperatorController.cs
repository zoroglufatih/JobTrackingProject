using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Operator")]
    [Area("Admin")]
    public class OperatorController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
