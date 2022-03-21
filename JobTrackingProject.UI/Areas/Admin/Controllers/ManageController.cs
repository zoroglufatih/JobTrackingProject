using System.Linq;
using JobTrackingProject.BusinessLayer.Services.Interface;
using JobTrackingProject.DTO.Model;
using JobTrackingProject.DTO.RegisterDTO;
using JobTrackingProject.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JobTrackingProject.DataAccessLayer.Concrete.EntityFrameworkCore.Context;
using JobTrackingProject.Entities.Concrete.Entities;

namespace JobTrackingProject.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly MyContext _dbContext;


        public ManageController(UserManager<ApplicationUser> userManager, IEmailSender emailSender, MyContext dbContext)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {

            return View();
        }
        [HttpGet]
        public IActionResult OperatorRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> OperatorRegister(RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Bu kullanıcı adı ile kayıt yapılmıştır.");
                return View(model);
            }
            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Bu E-mail ile kayıt yapılmıştır.");
                return View(model);
            }
            user = new ApplicationUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, RoleModels.Operator);
                var emailMessage = new EmailMessage()
                {
                    Contacts = new string[]
                    {
                        user.Email,
                    },
                    Body = $"Kullanıcı adınız : {user.UserName} \n Şifreniz: {model.Password}",
                    Subject = "Operatör olarak kayıt edildiniz."
                };
                await _emailSender.SendAsync(emailMessage);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu");
                return View(model);
            }
            return RedirectToAction("Index", "Manage", new { area = "Admin" });


        }

        [HttpGet]
        public IActionResult TechnicianRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TechnicianRegister(RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Bu kullanıcı adı ile kayıt yapılmıştır.");
                return View(model);
            }
            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Bu E-mail ile kayıt yapılmıştır.");
                return View(model);
            }
            user = new ApplicationUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, RoleModels.Technician);
                var emailMessage = new EmailMessage()
                {
                    Contacts = new string[]
                    {
                        user.Email,
                    },
                    Body = $"Kullanıcı adınız : {user.UserName} \n Şifreniz: {model.Password}",
                    Subject = "Teknisyen olarak kayıt edildiniz."
                };
                await _emailSender.SendAsync(emailMessage);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu");
                return View(model);
            }
            return RedirectToAction("Index","Manage",new {area="Admin"});


        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AllTicket()
        {

            return View();
        }
    }
}
