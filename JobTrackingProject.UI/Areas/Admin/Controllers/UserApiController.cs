using DevExtreme.AspNet.Data;
using JobTrackingProject.Entities.Concrete.Identity;
using JobTrackingProject.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles ="Admin")]
    public class UserApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users;
            return Ok(DataSourceLoader.Load(data,loadOptions));
        }
        
    }
}
