using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            List<Address> value = _addressService.GetList();
            return View(value);
        }

        #region kullanıma kapalı
        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            if (address != null)
            {
                _addressService.TInsert(address);
                return RedirectToAction("Index", "Address");
            }
            else
            {
                //hata kodları 

                return View();
            }
        }
        public IActionResult DeleteAddress(int ID)
        {
            _addressService.TDelete(_addressService.TGetById(ID));
            return RedirectToAction("Index", "Address");
        }
        #endregion

        [HttpGet]
        public IActionResult EditAddress(int ID)
        {
            Address value = _addressService.TGetById(ID);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAddress(Address address)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult result = validationRules.Validate(address);
            if (result.IsValid)
            {
                _addressService.TUpdate(address);
                return RedirectToAction("Index", "Address");
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
    }
}
