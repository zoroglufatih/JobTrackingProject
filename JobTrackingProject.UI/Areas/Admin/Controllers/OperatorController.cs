using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.TicketDTO;
using JobTrackingProject.Entities.Concrete.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Operator")]
    [Area("Admin")]
    public class OperatorController : Controller
    {
        private readonly MyContext _dbContext;

        public OperatorController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tickets()
        {
            return View();
        }

    }
}
