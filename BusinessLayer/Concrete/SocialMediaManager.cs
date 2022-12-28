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
		ISocialMediaDal _socialMediaDal;

		public SocialMediaManager(ISocialMediaDal socialMediaDal)
		{
			_socialMediaDal = socialMediaDal;
		}

		public List<SocialMedia> GetList()
		{
			return _socialMediaDal.GetList();
		}

		public void TDelete(SocialMedia t)
		{
			throw new NotImplementedException();
		}

		public SocialMedia TGetById(int ID)
		{
			throw new NotImplementedException();
		}

		public void TInsert(SocialMedia t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(SocialMedia t)
		{
			throw new NotImplementedException();
		}
	}
}
