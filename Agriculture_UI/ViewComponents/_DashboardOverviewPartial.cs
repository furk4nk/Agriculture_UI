using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
