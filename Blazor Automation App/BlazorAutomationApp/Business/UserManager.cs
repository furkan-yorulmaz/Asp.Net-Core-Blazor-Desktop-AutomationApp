using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorAutomationApp.DataAccess.Abstract;
using BlazorAutomationApp.EfCore;

namespace BlazorAutomationApp.Business
{
    internal class UserManager
    {
        Repository<User> userRepository = new Repository<User>();

        public List<User> List()
        {
            return userRepository._List();
        }

        public int Insert(User p)
        {
            try
            {
                userRepository._Insert(p);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(int p)
        {
            try
            {
                User user = userRepository._Find(x => x.UserId == p);
                userRepository._Delete(user);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
