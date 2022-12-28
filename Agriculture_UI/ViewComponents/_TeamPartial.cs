using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agriculture_UI.ViewComponents
{
	public class _TeamPartial :ViewComponent
	{
		private readonly ITeamService _teamService;

		public _TeamPartial(ITeamService teamService)
		{
			_teamService = teamService;
		}

		public IViewComponentResult Invoke()
		{
			List<Team> values = _teamService.GetList();
			return View(values);
		}
	}
}
