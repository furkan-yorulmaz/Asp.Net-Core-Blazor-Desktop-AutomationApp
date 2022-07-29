using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAutomationApp.DataAccess.Abstract
{
    internal interface IRepository<T>
    {
        void _Insert(T p);
        void _Update(T p);
        void _Delete(T p);
        List<T> _List();
        T _GetById(int id);
        List<T> _FilterList(Expression<Func<T, bool>> filter);
        T _Find(Expression<Func<T, bool>> where);
    }
}
