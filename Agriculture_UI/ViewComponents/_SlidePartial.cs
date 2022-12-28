using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
	public class _SlidePartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
