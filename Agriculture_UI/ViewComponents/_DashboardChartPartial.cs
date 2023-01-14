using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardChartPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DashboardChartPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            List<Product> values = _productService.GetList();
            var namelist=( from x in values select x.ProductName).ToArray();
            var pricelist= (from x in values select x.Price).ToArray();
            var stoklist = (from x in values select x.Stok).ToArray();
            ViewBag.namelist = namelist;
            ViewBag.pricelist = pricelist;
            ViewBag.stoklist = stoklist;
            // bar oluştuldu ama databaseden veri çekilemedi script hatası ----
            return View();
        }
    }
}
