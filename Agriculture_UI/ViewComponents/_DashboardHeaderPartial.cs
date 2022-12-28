using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
