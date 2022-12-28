using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
	public class _AboutPartial : ViewComponent
	{
		private readonly IAboutUsService _aboutUsService;

		public _AboutPartial(IAboutUsService aboutUsService)
		{
			_aboutUsService = aboutUsService;
		}

		public IViewComponentResult Invoke()
		{
			List<AboutUs> values = _aboutUsService.GetList();
			return View(values);
		}
	}
}
