using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL
{
    public class UserData
    {
        public BookStoreContext Context { get; }

        public UserData(BookStoreContext context)
        {
            Context = context;
        }

        public IEnumerable<User> Get()
        {
            return Context.Users
                .ToList();
        }

        public User Get(int id)
        {
            return Context.Users
                .Find(id);
        }

        public User Get(string username)
        {
            return Context.Users
                .FirstOrDefault(x => x.Username == username);
        }
        public int Add(User model)
        {
            Context.Users.Add(model);
            Context.SaveChanges();

            return model.Id;
        }

        public User Update(User model)
        {
            var current = Context.Users.Find(model.Id);
            if (current != null)
            {
                Context.Entry(current).CurrentValues.SetValues(model);
                Context.SaveChanges();
            }

            return current;
        }

        public bool Delete(int id)
        {
            bool validDelete = false;
            var current = Context.Users.Find(id);
            if (current != null)
            {
                Context.Users.Remove(current);
                Context.SaveChanges();
                validDelete = true;
            }

            return validDelete;
        }
    }
}
