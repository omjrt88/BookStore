using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Bookstore.DAL
{
    public class BookData
    {
        public BookStoreContext Context { get; }

        public BookData(BookStoreContext context)
        {
            Context = context;
        }

        public IEnumerable<dynamic> Get()
        {
            var books = Context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToList();
            return books;
        }

        public dynamic Get(int id)
        {
            return (from book in Context.Books
                    from author in Context.Authors.Where(a => a.Id == book.AuthorId)
                    from category in Context.Categories.Where(c => c.Id == book.CategoryId)
                    select new
                    {
                        book.Id,
                        book.Name,
                        book.Published,
                        Author = author,
                        Category = category,
                        Reviews = (from review in Context.Reviews.Where(x => x.BookId == book.Id)
                                   from user in Context.Users.Where(x => x.Id == review.UserId)
                                   where review.BookId == book.Id
                                   orderby review.Qualification descending
                                   select new
                                   {
                                       review.Id,
                                       review.Comment,
                                       review.Qualification,
                                       review.Created,
                                       User = user,
                                   }).ToList()
                    }).FirstOrDefault(x => x.Id == id);
        }

        public int Add(Book model)
        {
            Context.Books.Add(model);
            Context.SaveChanges();

            return model.Id;
        }

        public Book Update(Book model)
        {
            var current = Context.Books.Find(model.Id);
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
            var current = Context.Books.Find(id);
            if (current != null)
            {
                Context.Books.Remove(current);
                Context.SaveChanges();
                validDelete = true;
            }

            return validDelete;
        }

        public IEnumerable<dynamic> TrendingBooks()
        {
            return (from book in Context.Books
                from author in Context.Authors.Where(a => a.Id == book.AuthorId)
                from category in Context.Categories.Where(c => c.Id == book.CategoryId)
                select new
                {
                    book.Id,
                    book.Name,
                    book.Published,
                    Author = author,
                    Category = category,
                    ReviewsSum = (from review in Context.Reviews.Where(x => x.BookId == book.Id)
                        from user in Context.Users.Where(x => x.Id == review.UserId)
                        where review.BookId == book.Id
                        orderby review.Qualification descending
                        select new
                        {
                            review.Id,
                            review.Comment,
                            review.Qualification,
                            review.Created,
                            User = user,
                        }).Sum(x => x.Qualification)
                }).OrderByDescending(x => x.ReviewsSum).Take(5).ToList();
        }

        public IEnumerable<dynamic> NewestBooks()
        {
            return (from book in Context.Books
                from author in Context.Authors.Where(a => a.Id == book.AuthorId)
                from category in Context.Categories.Where(c => c.Id == book.CategoryId)
                select new
                {
                    book.Id,
                    book.Name,
                    book.Published,
                    Author = author,
                    Category = category
                }).OrderByDescending(x => x.Published).Take(5).ToList();
        }

    }
}