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
	public class AdminManager : IAdminService
	{
		IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}

		public void Delete(Admin t)
		{
			_adminDal.Delete(t);
		}

		public Admin GetByID(int id)
		{
			return _adminDal.GetByID(id);
		}

		public List<Admin> GetListAll()
		{
			return _adminDal.GetListAll();
		}

		public void Insert(Admin t)
		{
			_adminDal.Insert(t);
		}

		public void Update(Admin t)
		{
			_adminDal.Update(t);
		}
	}
}
