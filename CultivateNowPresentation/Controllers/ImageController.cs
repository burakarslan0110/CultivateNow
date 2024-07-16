using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CultivateNowPresentation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values = _imageService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(Image p)
        {
            _imageService.Insert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteImage(int id)
        {
            var values = _imageService.GetByID(id);
            _imageService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var values = _imageService.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditImage(Image p)
        {
            _imageService.Update(p);
            return RedirectToAction("Index");
        }
    }
}
