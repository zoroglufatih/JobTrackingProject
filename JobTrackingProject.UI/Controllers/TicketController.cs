using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.TicketDTO;
using JobTrackingProject.Entities.Concrete.Identity;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingProject.UI.Controllers
{
    public class TicketController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly MyContext _dbContext;

        public TicketController(MyContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var model = new TicketDTO()
            {
                UserName = user.Name,
                UserSurname = user.Surname,
                UserEmail = user.Email,
                UserPhoneNumber = user.PhoneNumber
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(TicketDTO model)
        {
            return View();
        }
    }
}
