using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL
{
    public class CategoryData
    {
        public BookStoreContext Context { get; }

        public CategoryData(BookStoreContext context)
        {
            Context = context;
        }

        public IEnumerable<Category> Get()
        {
            return Context.Categories
                .ToList();
        }

        public dynamic Get(int id)
        {
            return Context.Categories
                .FirstOrDefault(x => x.Id == id);
        }

        public int Add(Category model)
        {
            Context.Categories.Add(model);
            Context.SaveChanges();

            return model.Id;
        }

        public Category Update(Category model)
        {
            var current = Context.Categories.Find(model.Id);
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
            var current = Context.Categories.Find(id);
            if (current != null)
            {
                Context.Categories.Remove(current);
                Context.SaveChanges();
                validDelete = true;
            }

            return validDelete;
        }

    }
}
