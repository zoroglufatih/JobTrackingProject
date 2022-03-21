using System;
using System.Collections.Generic;
using System.Linq;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.Model;
using JobTrackingProject.DTO.TicketDTO;
using JobTrackingProject.Entities.Concrete.Entities;
using JobTrackingProject.Entities.Concrete.Identity;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingProject.UI.Controllers
{
    public class UserTicketsController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserTicketsController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var user = _userManager.FindByIdAsync(HttpContext.GetUserId()).Result;

            if (user == null)
            {
                return BadRequest();
            }

            var data = _dbContext.Tickets
                .Where(x => x.UserId == user.Id)
                .Include(x=> x.Categories)
                .Include(x=> x.TicketProducts)
                .ThenInclude(x=>x.Product)
                .ToList();
            //var tickets = new List<UserTicketsDTO>();

            //foreach (var item in data)
            //{
            //    var tic = new UserTicketsDTO()
            //    {
            //        CategoryName = item.Categories.CategoryName,
            //        CategoryId = item.CategoryId,
            //        CreatedDate = item.CreatedDate,
            //        Description = item.Description,
            //        TechnicianDate = item.TechnicianDate,
            //        TicketOverDate = item.TicketOverDate,
            //        UserId = item.UserId,
            //        TotalPrice = item.TicketProducts.Sum(x => x.Price)
            //    };
            //    tickets.Add(tic);
            //}


            return View(data);
        }
    }
}
