using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public IActionResult Index()
		{
			var values = _adminService.GetListAll();
			return View(values);
		}

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin p)
        {
            _adminService.Insert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAdmin(int id)
        {
            var values = _adminService.GetByID(id);
            _adminService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var values = _adminService.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAdmin(Admin p)
        {
            _adminService.Update(p);
            return RedirectToAction("Index");
        }
    }
}
