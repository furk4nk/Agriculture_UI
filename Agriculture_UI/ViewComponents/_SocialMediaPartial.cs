using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
	public class _SocialMediaPartial : ViewComponent
	{
		private readonly ISocialMediaService _socialMediaService;

		public _SocialMediaPartial(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}

		public IViewComponentResult Invoke()
		{
			List<SocialMedia> values = _socialMediaService.GetList();
			return View(values);
		}
	}
}
