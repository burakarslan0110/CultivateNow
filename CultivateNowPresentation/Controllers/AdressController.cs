using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.Controllers
{
    public class AdressController : Controller
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        public IActionResult Index()
        {
            var values = _adressService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditAdress(int id)
        {
            var values = _adressService.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAdress(Adress p)
        {
            _adressService.Update(p);
            return RedirectToAction("Index");
        }
    }
}
