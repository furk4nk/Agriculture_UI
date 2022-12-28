using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnnouncementService : IGenericService<Announcement>
    {
        void TAnnouncementChangeStatusEnabled(int ID);
        void TAnnouncementChangeStatusDisabled(int ID);
        List<Announcement> GetLatestAnnouncementThree();

	}
}
