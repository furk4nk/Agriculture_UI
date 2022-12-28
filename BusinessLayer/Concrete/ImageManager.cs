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
    public class ImageManager : IImageService
    {
        IImageDal _ımageDal;

        public ImageManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public List<Image> GetList()
        {
            return _ımageDal.GetList();
        }

        public void TDelete(Image t)
        {
            _ımageDal.Delete(t);
        }

        public Image TGetById(int ID)
        {
            return _ımageDal.GetById(ID);
        }

        public void TInsert(Image t)
        {
            _ımageDal.Insert(t);
        }

        public void TUpdate(Image t)
        {
            _ımageDal.Update(t);
        }
    }
}
