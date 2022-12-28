using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
	
	public class _ServicePartial : ViewComponent
	{
		private readonly IService _service;

		public _ServicePartial(IService service)
		{
			_service = service;
		}

		public IViewComponentResult Invoke()
		{
			List<Service> values = _service.GetList();
			return View(values);
		}
	}
}
