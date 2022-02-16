using System.Collections.Generic;
using System.Linq;
using DevExtreme.AspNet.Data;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.Model;
using JobTrackingProject.DTO.TicketDTO;
using JobTrackingProject.Entities.Concrete.Identity;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Operator")]
    public class TicketApiController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketApiController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.Tickets
                .Include(x=> x.Categories)
                .Include(x=> x.ApplicationUser)
                .ToList();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpGet]
        public IActionResult GetTeknisyenLookup(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users.ToList();
            var model = new List<ApplicationUser>();
            foreach (var item in data)
            {
                if (_userManager.IsInRoleAsync(item, RoleModels.Technician).Result)
                {
                    model.Add(item);
                }
            }
            return Ok(DataSourceLoader.Load(model, loadOptions));
        }

        [HttpPost]
        public IActionResult Update(int? id, TicketDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // tickettechnician oluşturulacak

            var ticket = _dbContext.Tickets
                .Include(x=> x.TicketTechnicians)
                .FirstOrDefault(x => x.TicketId == id);

            if (ticket == null)
            {
                return NotFound("Ticket bulunamadı");
            }

            return Ok();

        }
    }
}
