using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
	public class _GalleryPartial : ViewComponent
	{
		private readonly IImageService _ımageService;

		public _GalleryPartial(IImageService ımageService)
		{
			_ımageService = ımageService;
		}

		public IViewComponentResult Invoke()
		{
			List<Image>	values = _ımageService.GetList();
			return View(values);
		}
	}
}
