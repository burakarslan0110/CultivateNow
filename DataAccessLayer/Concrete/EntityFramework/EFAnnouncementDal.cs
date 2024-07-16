using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void  AnnouncementStatusToTrue(int id)
        {
            using var context = new CultivateNowContext();
            Announcement p = context.Announcements.Find(id);
            p.Status = true;
            context.SaveChanges();  
        }
        public void AnnouncementStatusToFalse(int id)
        {
            using var context = new CultivateNowContext();
            Announcement p = context.Announcements.Find(id);
            p.Status = false;
            context.SaveChanges();
        }

    }
}
