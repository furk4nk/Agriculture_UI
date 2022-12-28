using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture_UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int ID)
        {
            var values = _contactService.TGetById(ID);
            return View(values);
        }
    }
}
