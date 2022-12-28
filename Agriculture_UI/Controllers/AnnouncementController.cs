using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agriculture_UI.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
           var values= _announcementService.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            AnnouncementValidator validationRules = new AnnouncementValidator();
            ValidationResult result = validationRules.Validate(announcement);

            if (result.IsValid)
            {
                announcement.Date = System.DateTime.Now;
                _announcementService.TInsert(announcement);
                return RedirectToAction("Index", "Announcement");
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
        public IActionResult DeleteAnnouncement(int id)
        {
            _announcementService.TDelete(_announcementService.TGetById(id));
            return RedirectToAction("Index","Announcement");
        }
        [HttpGet]
        public IActionResult EditAnnouncement(int ID) 
        {
            var values = _announcementService.TGetById(ID);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement) 
        {
            AnnouncementValidator validationRules = new AnnouncementValidator();
            ValidationResult result = validationRules.Validate(announcement);

            if (result.IsValid)
            {
                announcement.Date = System.DateTime.Now;
                _announcementService.TUpdate(announcement);
                return RedirectToAction("Index", "Announcement");
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
        
        #region aktif veya pasif seçeneği
        public IActionResult Enabled(int ID) 
        {
            _announcementService.TAnnouncementChangeStatusEnabled(ID);
            return RedirectToAction("Index","Announcement");
        }
        public IActionResult Disabled(int ID)
        {
            _announcementService.TAnnouncementChangeStatusDisabled(ID);
            return RedirectToAction("Index", "Announcement");
        }
        #endregion
    }
}
