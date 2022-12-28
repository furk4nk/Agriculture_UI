using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
