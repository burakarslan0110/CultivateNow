using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CultivateNowPresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        CultivateNowContext c = new CultivateNowContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Employees.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = 3;

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.urunPazarlama = c.Employees.Where(x => x.Title == "Ürün Pazarlama").Select(y => y.EmpNameSurname).FirstOrDefault();
            ViewBag.bakliyatYonetimi = c.Employees.Where(x => x.Title == "Bakliyat Yönetimi").Select(y => y.EmpNameSurname).FirstOrDefault();
            ViewBag.sutUretici = c.Employees.Where(x => x.Title == "Süt Üreticisi").Select(y => y.EmpNameSurname).FirstOrDefault();
            ViewBag.gubreYonetimi = c.Employees.Where(x => x.Title == "Gübre Yönetimi").Select(y => y.EmpNameSurname).FirstOrDefault();
            return View();
        }
    }
}
