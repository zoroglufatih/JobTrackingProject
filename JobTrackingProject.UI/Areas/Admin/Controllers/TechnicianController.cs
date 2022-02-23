﻿using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.Model;
using JobTrackingProject.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly MyContext _dbContext;

        public TechnicianController(MyContext dbContext)
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
        [HttpGet]
        public IActionResult TicketDetail(int id)
        {
            var data = _dbContext.Tickets
                .Include(x => x.ApplicationUser)
                .Include(x => x.Categories)
                .ThenInclude(x => x.Products)
                .Where(x => x.TicketId == id)
                .FirstOrDefault();
            if (data == null)
            {
                return BadRequest();
            }
            var model = new TicketDetailDTO()
            {
                AddressDescription = data.AddressDescription,
                CategoryId = data.CategoryId,
                CategoryName = data.Categories.CategoryName,
                Description = data.Description,
                Latitude = data.Latitude,
                Longitude = data.Longitude,
                Name = data.ApplicationUser.Name,
                Surname = data.ApplicationUser.Surname,
                TechnicianDate = data.TechnicianDate,
                TicketId = data.TicketId,
                TicketOverDate = data.TicketOverDate,
                UserId = data.UserId,
                Products = data.Categories.Products
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult TicketDetail(TicketDetailDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return View();
        }
    }
}
