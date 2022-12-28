using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Agriculture_UI.ViewComponents
{
	public class _TopAddressPartial : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _TopAddressPartial(IAddressService addressService)
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
