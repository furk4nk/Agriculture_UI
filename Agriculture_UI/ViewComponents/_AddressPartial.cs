using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
	public class _AddressPartial : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _AddressPartial(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			List<Address> values = _addressService.GetList();
			return View(values);
		}
	}
}
