using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccessLayer.EntityFramework;

namespace Agriculture_UI.ViewComponents
{
	public class _AnnouncementPartial :ViewComponent
	{
		private readonly IAnnouncementService _announcementService;

		public _AnnouncementPartial(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}

		public IViewComponentResult Invoke()
		{
			List<string> Class=new List<string>();
			Class.Add("col-md-7 blog-img1-agileits-w3layouts");
			Class.Add("col-md-5 blog-info-w3layouts blog-mid");
			Class.Add("col-md-7 blog-img3-agileits-w3layouts");

			List<string> class2 = new List<string>();
			class2.Add("col-md-5 blog-info-w3layouts");
			class2.Add("col-md-5 blog-info-w3layouts blog-mid");
			class2.Add("col-md-5 blog-info-w3layouts");

			List<string> class3 = new List<string>();
			class3.Add("blog-text-w3ls bar");
			class3.Add("blog-text-w3ls mid-bar");
			class3.Add("blog-text-w3ls bar");

			ViewBag.c1 = Class;
			ViewBag.c2 = class2;
			ViewBag.c3 = class3;
			List<Announcement> values = _announcementService.GetLatestAnnouncementThree();
			return View(values);
		}
	}
}
