using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.ViewComponents
{
    public class _AdressPartial : ViewComponent
    {
        private readonly IAdressService _adressService;

        public _AdressPartial(IAdressService adressService)
        {
            _adressService = adressService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _adressService.GetListAll();
            return View(values);
        }
    }
}
