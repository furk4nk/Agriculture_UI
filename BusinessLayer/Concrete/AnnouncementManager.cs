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
    public class AnnouncementManager : IAnnouncementService
    {
       private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

		public List<Announcement> GetLatestAnnouncementThree()
		{
			return _announcementDal.GetLatestAnnouncementThree();
		}

		public List<Announcement> GetList()
        {
            return _announcementDal.GetList();
        }

		public void TAnnouncementChangeStatusDisabled(int ID)
		{
            _announcementDal.AnnouncementStatusChangeDisabled(ID);
		}

		public void TAnnouncementChangeStatusEnabled(int ID)
		{
			_announcementDal.AnnouncementStatusChangeEnabled(ID);
		}

		public void TDelete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement TGetById(int ID)
        {
          return _announcementDal.GetById(ID);
        }

        public void TInsert(Announcement t)
        {
            _announcementDal.Insert(t);    
        }

        public void TUpdate(Announcement t)
        {
            _announcementDal.Update(t);
        }
    }
}
