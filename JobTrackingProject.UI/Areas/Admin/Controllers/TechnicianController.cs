using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Technician")]
    [Area("Admin")]
    public class TechnicianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tickets()
        {
            return View();
        }

        public IActionResult TicketDetail()
        {
            return View();
        }
    }
}
