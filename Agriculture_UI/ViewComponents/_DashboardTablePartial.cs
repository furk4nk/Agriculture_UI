using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardTablePartial :ViewComponent
    {
        private readonly ITeamService _teamService;

        public _DashboardTablePartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            List<Team> sendValues = _teamService.GetList();   
            return View(sendValues);
        }
    }
}
