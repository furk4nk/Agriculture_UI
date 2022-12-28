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
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public List<Address> GetList()
        {
            return _addressDal.GetList();
        }

        public void TDelete(Address t)
        {
            _addressDal.Delete(t);
        }

        public Address TGetById(int ID)
        {
           return _addressDal.GetById(ID);
        }

        public void TInsert(Address t)
        {
            _addressDal.Insert(t);
        }

        public void TUpdate(Address t)
        {
            _addressDal.Update(t);
        }
    }
}
