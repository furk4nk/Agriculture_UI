using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Agriculture_UI.ViewComponents
{
    public class _DashboardOverviewTeamListPartial : ViewComponent
    {
         
        public IViewComponentResult Invoke()
        {
            
            using (var context = new Context())
            {
                var values = context.teams.Select(x=>x.PersonName).ToList();
                return View(values);
            }
           
        }
    }
}
