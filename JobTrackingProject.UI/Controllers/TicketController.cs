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
using JobTrackingProject.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = _dbContext.Categories.OrderBy(x => x.CategoryName);
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem("Kategori yok", null)
            };

            foreach (var category in categories)
            {
                categoryList.Add(new SelectListItem(category.CategoryName, category.CategoryId.ToString()));
            }

            ViewBag.CategoryList = categoryList;
            if (_signInManager.IsSignedIn(HttpContext.User))
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
            
            else
            {
                return View();
            }
            
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(TicketDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var ticket = new Tickets()
            {
                Description = model.Description,
                CategoryId = model.CategoryId,
                UserId = user.Id
            };

            _dbContext.Tickets.Add(ticket);

            try
            {
                _dbContext.SaveChanges();
                TempData["Message"] = "Kaydınız başarıyla alınmıştır";
                return RedirectToAction("Index", "Ticket");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Ticket alınamadı");
                return View(model);
            }
            
        }
    }
}
