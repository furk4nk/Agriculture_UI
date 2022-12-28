using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Agriculture_UI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        ServiceManager ServiceManager = new ServiceManager(new EfServiceDal());
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetList();           
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team t)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(t);
            #region //görev Listeleme
            //List<SelectListItem> list = (from x in ServiceManager.GetList()
            //                             select new SelectListItem
            //                             {
            //                                 Text = x.Title,
            //                                 Value = x.ServiceID.ToString()
            //                             }).ToList();
            //ViewBag.v = list;
            #endregion
            if (result.IsValid)
            {
                _teamService.TInsert(t);
                return RedirectToAction("Index","Team");
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
        public IActionResult DeleteTeam(int ID) 
        {
            _teamService.TDelete(_teamService.TGetById(ID));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int ID) 
        {
            var values = _teamService.TGetById(ID);           
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTeam(Team t) 
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(t);
            if (result.IsValid)
            {
                _teamService.TUpdate(t);
                return RedirectToAction("Index", "Team");
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
