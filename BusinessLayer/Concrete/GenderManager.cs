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
    public class GenderManager : IGenderService
    {
        private readonly IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        public List<Gender> GetList()
        {
            return _genderDal.GetList();
        }

        public void TDelete(Gender t)
        {
            _genderDal.Delete(t);
        }

        public Gender TGetById(int ID)
        {
            return _genderDal.GetById(ID);
        }

        public void TInsert(Gender t)
        {
            _genderDal.Insert(t);
        }

        public void TUpdate(Gender t)
        {
            _genderDal.Update(t);
        }
    }
}
