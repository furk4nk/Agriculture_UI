using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agriculture_UI.Controllers
{
    public class ProductController : Controller ,IDisposable
    {
        private readonly IProductService _productService;
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<Product> sendValues = _productService.TgetCategoryListAll();
            return View(sendValues);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            var values = selectListItems();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator validations = new ProductValidator();
            ValidationResult result = validations.Validate(product);
            if (result.IsValid)
            {
                product.Price.ToString().Replace(".", ",");
                Convert.ToDouble(product.Price);
                _productService.TInsert(product);
                return RedirectToAction("Index", "Product");
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
        public IActionResult DeleteProduct(int ID)
        {
            Product product = _productService.TGetById(ID);
            _productService.TDelete(product);
            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public IActionResult EditProduct(int ID)
        {
            var values = selectListItems();
            ViewBag.values = values;
            Product sendValues = _productService.TGetById(ID);
            return View(sendValues);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            ProductValidator validations = new ProductValidator();
            ValidationResult result = validations.Validate(product);
            if (result.IsValid)
            {
                _productService.TUpdate(product);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
        }

        // dropdownlist içeriğini döndüren methot
        // return -- kategori listesi --
        public List<SelectListItem> selectListItems()
        {
            List<SelectListItem> values = (from x in categoryManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            return values;
        }

    }
}
