using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using BusinessLayer.FluentValidation;
using FluentValidation.Results;

namespace Agriculture_UI.Controllers
{
	public class ImageController : Controller
	{
		private readonly IImageService _ımageService;

		public ImageController(IImageService ımageService)
		{
			_ımageService = ımageService;
		}

		public IActionResult Index()
		{
			List<Image> values = _ımageService.GetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddImage()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddImage(Image ımage)
		{
			ImageValidator validationRules = new ImageValidator();
			ValidationResult result = validationRules.Validate(ımage);
			if (result.IsValid)
			{
                _ımageService.TInsert(ımage);
                return RedirectToAction("Index", "Image");

            }
			else
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
				return View();
			}


		}
		public IActionResult DeleteImage(int ID)
		{
			_ımageService.TDelete(_ımageService.TGetById(ID));
			return RedirectToAction("Index", "Image");
		}
		[HttpGet]
		public IActionResult EditImage(int ID)
		{
			Image values = _ımageService.TGetById(ID);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditImage(Image ımage)
		{
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(ımage);
            if (result.IsValid)
            {
                _ımageService.TUpdate(ımage);
                return RedirectToAction("Index", "Image");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
		}

	}
}
