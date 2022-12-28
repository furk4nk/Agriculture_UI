using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Agriculture_UI.ViewComponents
{
	public class _MapPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			Context context = new Context();
			var values = context.addresses.Select(x=>x.MapInfo).FirstOrDefault();
			ViewBag.v = values;
			return View();
		}
	}
}
