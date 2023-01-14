using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardNavbarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _DashboardNavbarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.values = User.Identity.Name;
            return View();
        }
    }
}
