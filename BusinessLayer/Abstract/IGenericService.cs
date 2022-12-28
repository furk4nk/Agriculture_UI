using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class , new()
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        T TGetById(int ID);
        List<T> GetList();
    }
}
