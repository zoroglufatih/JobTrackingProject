using System.Collections.Generic;
using System.Linq;
using DevExtreme.AspNet.Data;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.DTO.Model;
using JobTrackingProject.Entities.Concrete.Entities;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class ProductApiController : Controller
    {
        private readonly MyContext _dbContext;

        public ProductApiController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.Products
                .Include(x=>x.Categories)
                .OrderBy(x => x.ProductName)
                .ToList();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }
        [HttpGet]
        public IActionResult GetCategoriesLookup(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.Categories.ToList();
            var model = new List<Categories>();
            foreach (var item in data)
            {
                model.Add(item);
            }
            return Ok(DataSourceLoader.Load(model, loadOptions));
        }
        [HttpPost]
        public IActionResult Insert(string values)
        {
            var data = new Products();
            JsonConvert.PopulateObject(values, data);

            if (!TryValidateModel(data))
            {
                return BadRequest(new JsonResponseDTO()
                {
                    IsSuccess = false,
                    ErrorMessage = ModelState.ToFullErrorString()
                });
            }

            _dbContext.Products.Add(data);
            var result = _dbContext.SaveChanges();

            if (result == 0)
            {
                return BadRequest(new JsonResponseDTO()
                {
                    IsSuccess = false,
                    ErrorMessage = "Ürün kaydedilemedi"
                });
            }


            return Ok(new JsonResponseDTO());
        }

    }
}
