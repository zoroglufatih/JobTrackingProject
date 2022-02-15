using System;
using System.Linq;
using DevExtreme.AspNet.Data;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.Model;
using JobTrackingProject.Entities.Concrete.Entities;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class CategoryApiController : Controller
    {
        private readonly MyContext _dbContext;

        public CategoryApiController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.Categories.OrderBy(x => x.CategoryName).ToList();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpPost]
        public IActionResult Insert(string values)
        {
            var data = new Categories();
            JsonConvert.PopulateObject(values, data);

            if (!TryValidateModel(data))
            {
                return BadRequest(new JsonResponseDTO()
                {
                    IsSuccess = false,
                    ErrorMessage = ModelState.ToFullErrorString()
                });
            }

            _dbContext.Categories.Add(data);
            var result = _dbContext.SaveChanges();

            if (result == 0)
            {
                return BadRequest(new JsonResponseDTO()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kategori kaydedilemedi"
                });
            }


            return Ok(new JsonResponseDTO());
        }
    }
}
