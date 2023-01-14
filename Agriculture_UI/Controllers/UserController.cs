using Agriculture_UI.Models;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Agriculture_UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        GenderManager _genderManager = new GenderManager(new EfGenderDal());

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            List<SelectListItem> values = dropDownListGender();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(CreateViewModel model)
        {
            AppUser user = new AppUser()
            {
                UserName = model.UserName.Trim(),
                FullName = model.FullName.Trim(),
                NormalizedFullName = model.FullName.ToUpper(),
                Email = model.Email.Trim(),
                Address = model.Address.Trim(),
                BirthDate = model.BirthDay,
                GenderID = model.GenderID
            };

            UserValidator validations = new UserValidator();
            ValidationResult result = validations.Validate(user);
            if (result.IsValid)
            {
                IdentityResult resultAccount = await _userManager.CreateAsync(user, model.Password);
                if (resultAccount.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in resultAccount.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.values = dropDownListGender();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UserEdit()
        {
            if (User.Identity.Name != null)
            {
                AppUser values = await _userManager.FindByNameAsync(User.Identity.Name);
                UserEditViewModel model = new UserEditViewModel()
                {
                    Address=values.Address,
                    BirthDay=values.BirthDate,
                    Email=values.Email,
                    FullName=values.FullName,
                    GenderID = values.GenderID,
                    UserName= values.UserName                    
                };
                ViewBag.values = dropDownListGender();
                return View(model);
            }
            else
            {
                 return RedirectToAction("Index","Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel model)
        {           
            AppUser user = new AppUser()
            {
                Address = model.Address,
                BirthDate=model.BirthDay,
                Email=model.Email,
                GenderID=model.GenderID,
                UserName = model.UserName,
                FullName = model.FullName
            };
            UserValidator validations = new UserValidator();
            ValidationResult result = validations.Validate(user);
            if (result.IsValid)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                values.Address = user.Address.Trim();
                values.UserName = user.UserName.Trim();
                values.BirthDate = user.BirthDate;
                values.FullName = user.FullName.Trim();
                values.NormalizedFullName = user.FullName.ToUpper().Trim();
                values.GenderID = user.GenderID;
                values.Email= user.Email;
                IdentityResult Updateresult = await _userManager.UpdateAsync(values);
                if (Updateresult.Succeeded)
                {
                    return RedirectToAction("UserEdit", "User");
                }
                else
                {
                    foreach (var item in Updateresult.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }   
            }
            ViewBag.values = dropDownListGender();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> ChangePassword()
        //{

        //    şifre değişikliği yapılacak değiştirilen şifre uygunluğu kontrol edilecek
        //    return RedirectToAction("Index", "Login");
        //}


        // drop down list için cinsiyet listesi
        // return -- Gender List --
        public List<SelectListItem> dropDownListGender()
        {
            List<SelectListItem> sendValues = (from x in _genderManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.GenderName,
                                                   Value = x.GenderID.ToString()
                                               }).ToList();
            return sendValues;
        }
    }
}
