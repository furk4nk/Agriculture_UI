using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Agriculture_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Category> values = _categoryService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(category);
            if (result.IsValid)
            {
                _categoryService.TInsert(category);
                return RedirectToAction("Index", "Category");
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
        public IActionResult DeleteCategory(int ID)
        {
            Category _temp = _categoryService.TGetById(ID);
            _categoryService.TDelete(_temp);
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public IActionResult EditCategory(int ID)
        {
            Category SendValue=_categoryService.TGetById(ID);
            return View(SendValue);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(category);
            if (result.IsValid)
            {
                _categoryService.TUpdate(category);
                return RedirectToAction("Index", "Category");
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

        public IActionResult Details(int ID)
        {
            using (var c=new Context())
            {
                var values = c.products.Where(x => x.CategoryID == ID).ToList();
                ViewBag.Title = from x in c.categories select x.CategoryId == ID;
                return View(values);
            }
        }
    }
}
