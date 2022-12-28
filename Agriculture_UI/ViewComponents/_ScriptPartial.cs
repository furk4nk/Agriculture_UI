using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.ViewComponents
{
	public class _ScriptPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
