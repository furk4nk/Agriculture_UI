using Agriculture_UI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agriculture_UI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,loginViewModel.Password,true,false);
			if (result.Succeeded)
			{
                return RedirectToAction("Index", "Address");
            }
			else
			{
				return View();
			}
		}

		public async Task<IActionResult> LogOut()
		{
			_signInManager.SignOutAsync();
			return RedirectToAction("Index","Login");
		}

	}
}
