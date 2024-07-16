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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _SocialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _SocialMediaDal = socialMediaDal;
        }

        public void Delete(SocialMedia t)
        {
            _SocialMediaDal.Delete(t);
        }

        public SocialMedia GetByID(int id)
        {
            return _SocialMediaDal.GetByID(id);
        }

        public List<SocialMedia> GetListAll()
        {
            return _SocialMediaDal.GetListAll();

        }

        public void Insert(SocialMedia t)
        {
            _SocialMediaDal.Insert(t);
        }

        public void Update(SocialMedia t)
        {
            _SocialMediaDal.Update(t);
        }
    }
}
