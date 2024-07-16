using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Delete(Employee t)
        {
            _employeeDal.Delete(t);
        }

        public Employee GetByID(int id)
        {
            return _employeeDal.GetByID(id);
        }

        public List<Employee> GetListAll()
        {
            return _employeeDal.GetListAll();
        }

        public void Insert(Employee t)
        {
            _employeeDal.Insert(t);
        }

        public void Update(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
