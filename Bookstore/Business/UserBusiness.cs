using Bookstore.DAL;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Business
{
    public class UserBusiness
    {
        private static UserData _userData;
        public UserBusiness(BookStoreContext context)
        {
            _userData = new UserData(context);
        }

        public IEnumerable<User> Get()
        {
            return _userData.Get();
        }

        public User Get(int id)
        {
            return _userData.Get(id);
        }

        public User Get(string username)
        {
            return _userData.Get(username);
        }

        public User Login(User user)
        {
            var originalUser = _userData.Get(user.Username);
            if (originalUser == null || originalUser.Password != user.Password)
            {
                return null;
            }
            return _userData.Get(user.Username);
        }

        public int Add(User model)
        {
            return _userData.Add(model); ;
        }

        public User Update(User model)
        {
            return _userData.Update(model);
        }

        public bool Delete(int id)
        {
            return _userData.Delete(id);
        }
    }
}
