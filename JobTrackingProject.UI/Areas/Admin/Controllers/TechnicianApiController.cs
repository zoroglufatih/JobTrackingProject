using DevExtreme.AspNet.Data;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.Entities.Concrete.Identity;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Technician")]
    public class TechnicianApiController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public TechnicianApiController(MyContext dbContext, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            //var technician = _userManager.FindByIdAsync(HttpContext.GetUserId()).Result;

            var data = _dbContext.Tickets
                .Include(x => x.ApplicationUser)
                .Include(x => x.Categories).Where(x => x.TechnicianId == _signInManager.Context.GetUserId())
                .ToList();

            return Ok(DataSourceLoader.Load(data, loadOptions));
        }
        [HttpPut]
        public IActionResult Update(string key, string values)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = _dbContext.Tickets.Find(Convert.ToInt32(key));

            JsonConvert.PopulateObject(values, data);
            if (data.IsActive == false)
            {
                data.TicketOverDate = DateTime.Now;
            }
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
