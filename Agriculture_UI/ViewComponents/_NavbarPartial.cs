using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
	public class _NavbarPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}
