using Agriculture_UI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Threading.Tasks;

namespace Agriculture_UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name !=null)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                AppUser appUser = new AppUser();
                appUser = values;
                return View(values);
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı Girişi yapılmadı");
                return RedirectToAction("Index","Login");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser user)
        {
            var values = await _userManager.FindByNameAsync(user.UserName);
            values.FullName = user.FullName;
            values.PhoneNumber = user.PhoneNumber;
            values.UserName = user.UserName;
            values.Address = user.Address;
            values.Email = user.Email;
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateViewModel model)
        {
            AppUser appUser = new AppUser
            {
                UserName = model.UserName,
                FullName = model.FullName,
                NormalizedFullName=model.FullName.ToUpper(),
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                BirthDate = model.BirthDay,
                createDate = System.DateTime.Now

            };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
        }
    }
}
