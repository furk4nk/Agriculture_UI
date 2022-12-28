using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardTablePartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
