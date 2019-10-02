using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Bookstore.DAL
{
    public class ReviewData
    {
        public BookStoreContext Context { get; }

        public ReviewData(BookStoreContext context)
        {
            Context = context;
        }

        public IEnumerable<dynamic> Get()
        {
            return Context.Reviews
                .Include(r => r.User)
                .Include(r => r.Book)
                .ToList();
        }

        public dynamic Get(int id)
        {
            return (from reviews in Context.Reviews
                    from user in Context.Users.Where(a => a.Id == reviews.UserId)
                    from book in Context.Books.Where(a => a.Id == reviews.BookId)
                    from author in Context.Authors.Where(a => a.Id == book.AuthorId)
                    from category in Context.Categories.Where(a => a.Id == book.CategoryId)
                    orderby reviews.Qualification descending
                    select new
                    {
                        reviews.Id,
                        reviews.Comment,
                        reviews.Qualification,
                        reviews.Created,
                        User = user,
                        Book = book
                    }).FirstOrDefault(x => x.Id == id);
        }

        public int Add(Review model)
        {
            Context.Reviews.Add(model);
            Context.SaveChanges();

            return model.Id;
        }

        public Review Update(Review model)
        {
            var current = Context.Reviews.Find(model.Id);
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
            var current = Context.Reviews.Find(id);
            if (current != null)
            {
                Context.Reviews.Remove(current);
                Context.SaveChanges();
                validDelete = true;
            }

            return validDelete;
        }

    }
}