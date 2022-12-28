using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardScriptPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
