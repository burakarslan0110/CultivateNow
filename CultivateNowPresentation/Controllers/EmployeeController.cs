using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.ValidaditonRules;
using FluentValidation.Results;

namespace CultivateNowPresentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            ModelState.Clear();
            EmployeeValidator validator = new EmployeeValidator();
            ValidationResult results = validator.Validate(employee);
            if (results.IsValid)
            {
                _employeeService.Insert(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult DeleteEmployee(int id)
        {
            var values = _employeeService.GetByID(id);
            _employeeService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var values = _employeeService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee employee, int id)
        {
            ModelState.Clear();
            EmployeeValidator validator = new EmployeeValidator();
            ValidationResult results = validator.Validate(employee);
            if (results.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                var values = _employeeService.GetByID(id);
                return View(values);
            }
            
        }
    }
}
