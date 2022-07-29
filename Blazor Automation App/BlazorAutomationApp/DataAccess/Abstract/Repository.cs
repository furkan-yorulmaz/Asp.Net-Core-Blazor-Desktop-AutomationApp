using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorAutomationApp.EfCore;

namespace BlazorAutomationApp.DataAccess.Abstract
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Stock_DBContext db = new Stock_DBContext();
        DbSet<T> _object;
        public Repository()
        {
            _object = db.Set<T>();
        }

        public List<T> _List()
        {
            return _object.ToList();
        }

        public void _Insert(T p)
        {
            _object.Add(p);
            db.SaveChanges();
        }

        public void _Update(T p)
        {
            db.SaveChanges();
        }

        public void _Delete(T p)
        {
            _object.Remove(p);
            db.SaveChanges();
        }

        public List<T> _FilterList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T _Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T _GetById(int id)
        {
            return _object.Find(id);
        }
    }
}
