using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;

namespace CultivateNowPresentation.ViewComponents
{
    public class _EmployeePartial : ViewComponent
    {
        private readonly IEmployeeService _employeeService;

        public _EmployeePartial(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _employeeService.GetListAll();
            return View(values);
        }
    }
}
