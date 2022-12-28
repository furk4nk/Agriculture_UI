using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Agriculture_UI.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
		{
			var values = _service.GetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddService()
		{				
			return View();
		}
		[HttpPost]
		public IActionResult AddService(Service service)
		{
			ServiceValidator validationRules = new ServiceValidator();
			ValidationResult result = validationRules.Validate(service);
			if (result.IsValid)
			{
                _service.TInsert(service);
				return RedirectToAction("Index","Service");
            }
			else
			{
				foreach(var item in result.Errors) 
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}

			return View();
		}
		public IActionResult DeleteService(int ID)
		{
			_service.TDelete(_service.TGetById(ID));
            return RedirectToAction("Index", "Service");
        }
		[HttpGet]
		public IActionResult EditService(int ID)
		{
			var values = _service.TGetById(ID);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditService(Service service)
		{
            ServiceValidator validationRules = new ServiceValidator();
            ValidationResult result = validationRules.Validate(service);
            if (result.IsValid)
            {
                _service.TUpdate(service);
                return RedirectToAction("Index", "Service");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

	}
}
