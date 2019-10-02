using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL
{
    public class AuthorData
    {
        public BookStoreContext Context { get; }

        public AuthorData(BookStoreContext context)
        {
            Context = context;
        }

        public IEnumerable<Author> Get()
        {
            return Context.Authors
                .ToList();
        }

        public Author Get(int id)
        {
            return Context.Authors
                .Find(id);
        }

        public int Add(Author model)
        {
            Context.Authors.Add(model);
            Context.SaveChanges();

            return model.Id;
        }

        public Author Update(Author model)
        {
            var current = Context.Authors.Find(model.Id);
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
            var current = Context.Authors.Find(id);
            if (current != null)
            {
                Context.Authors.Remove(current);
                Context.SaveChanges();
                validDelete = true;
            }

            return validDelete;
        }
    }
}