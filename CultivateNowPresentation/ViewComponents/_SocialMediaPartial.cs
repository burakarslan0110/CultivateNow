using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.ViewComponents
{
    public class _SocialMediaPartial : ViewComponent
    {
        private readonly ISocialMediaService _SocialMediaService;

        public _SocialMediaPartial(ISocialMediaService socialMediaService)
        {
            _SocialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _SocialMediaService.GetListAll();
            return View(values);     
        }
    }
}
