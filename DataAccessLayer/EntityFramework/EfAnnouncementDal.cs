using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
	{
		public void AnnouncementStatusChangeDisabled(int ID)
		{
			using Context c = new Context();
			Announcement announcement = c.Set<Announcement>().Find(ID);
			announcement.Status = false;
			c.SaveChanges();
		}

		public void AnnouncementStatusChangeEnabled(int ID)
		{
			using Context c = new Context();
			Announcement announcement = c.Set<Announcement>().Find(ID);
			announcement.Status = true;
			c.SaveChanges();

		}

		//aktif olan son 3 veriyi çeken sorgu metodu
		public List<Announcement> GetLatestAnnouncementThree()
		{
			try
			{
				using Context c = new Context();
				List<Announcement> values = (from x in c.announcements
											 where x.Status == true
											 orderby x.Date descending
											 select x).Take(3).ToList();
				return values;

			}
			catch (Exception hata)
			{

				throw new NotImplementedException(hata.Message);
			}

		}
	}
}
