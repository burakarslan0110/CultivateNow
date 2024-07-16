using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.ViewComponents
{
    public class _MapPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            CultivateNowContext cultivateNowContext = new CultivateNowContext();
            var values = cultivateNowContext.Adresses.Select(x=>x.MapInfo).FirstOrDefault();
            ViewBag.v=values;
            return View();
        }
    }
}
