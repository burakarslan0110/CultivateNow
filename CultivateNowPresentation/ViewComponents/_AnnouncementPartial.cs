using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;

namespace CultivateNowPresentation.ViewComponents
{
    public class _AnnouncementPartial : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _AnnouncementPartial(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }
    }
}
