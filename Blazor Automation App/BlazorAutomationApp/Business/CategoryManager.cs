using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorAutomationApp.DataAccess.Abstract;
using BlazorAutomationApp.EfCore;

namespace BlazorAutomationApp.Business
{
    internal class CategoryManager
    {
        Repository<Category> categoryRepository = new Repository<Category>();

        public List<Category> List()
        {
            return categoryRepository._List();
        }

        public Category Find(int p)
        {
            return categoryRepository._Find(x => x.Id == p);
        }
    }
}
