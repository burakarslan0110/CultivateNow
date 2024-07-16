using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.Controllers
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
            var values = _contactService.GetListAll();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = _contactService.GetByID(id);
            _contactService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = _contactService.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var values = _contactService.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditContact(Contact p)
        {
            _contactService.Update(p);
            return RedirectToAction("Index");
        }
    }
}
