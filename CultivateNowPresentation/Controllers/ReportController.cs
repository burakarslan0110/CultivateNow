using CultivateNowPresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace CultivateNowPresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workbook.Cells[1, 1].Value = "Ürün Adı";
            workbook.Cells[1, 2].Value = "Ürün Kategorisi";
            workbook.Cells[1, 3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "Mercimek";
            workbook.Cells[2, 2].Value = "Bakliyat";
            workbook.Cells[2, 3].Value = "785 KG";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "1785 KG";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "1785 KG";

            workbook.Cells[4, 1].Value = "Havuç";
            workbook.Cells[4, 2].Value = "Sebze";
            workbook.Cells[4, 3].Value = "155 KG";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformat-officedocument.spreadsheetml.sheet", "StatikRapor.xlsx");
        }

        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModel = new List<ContactModel>();
            using (var context = new CultivateNowContext())
            {
                contactModel = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName = x.NameSurname,
                    ContactMail = x.Mail,
                    ContactMessage = x.Message,
                    ContactDate = x.Date
                }).ToList();
            }
            return contactModel;
        }
        public IActionResult ContactReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach(var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformat-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
                }
            }
        }
    }
}
