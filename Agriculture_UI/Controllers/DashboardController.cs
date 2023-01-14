using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture_UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly Context c = new Context();

        public DashboardController(Context c)
        {
            this.c = c;
        }

        public IActionResult Index()
        {
            ViewBag.announcementCount = c.announcements.Count();
            ViewBag.teamCount = c.teams.Count();
            ViewBag.serviceCount = c.services.Count();
            ViewBag.CurrentMonthMessage = c.contacts.Where(x => x.Date.Month == System.DateTime.Now.Month).Count();

            ViewBag.differentJob = c.teams.GroupBy(x => x.Title).Count();
            var values = c.teams.Select(x => x.Title).ToList();
            
            ViewBag.TeamList = c.teams.Select(x => x.PersonName).ToList();
            ViewBag.announcementCountTrue = c.announcements.Where(x => x.Status == true).Count();
            ViewBag.messageCount = c.contacts.Count();

            return View(values);
        }
    }
}


    