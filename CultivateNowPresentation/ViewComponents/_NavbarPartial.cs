using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.ViewComponents
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
