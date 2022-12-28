using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int ID)
        {
            using var c = new Context();
            return c.Set<T>().Find(ID);
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            try
            {
                if (t != null)
                {
                    using var c = new Context();
                    c.Update(t);
                    c.SaveChanges();
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine("güncelleme işlemi yapılamadı", hata.Message);
            }
        }
    }
}
