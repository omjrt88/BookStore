using Bookstore.DAL;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Business
{
    public class BookBusiness
    {
        private static BookData _bookData;
        public BookBusiness(BookStoreContext context)
        {
            _bookData = new BookData(context);
        }

        public IEnumerable<dynamic> Get()
        {
            return _bookData.Get();
        }

        public dynamic Get(int id)
        {
            return _bookData.Get(id);
        }

        public int Add(Book model)
        {
            return _bookData.Add(model); ;
        }

        public Book Update(Book model)
        {
            return _bookData.Update(model);
        }

        public bool Delete(int id)
        {
            return _bookData.Delete(id);
        }

        public IEnumerable<dynamic> TrendingBooks()
        {
            return _bookData.TrendingBooks();
        }

        public IEnumerable<dynamic> NewestBooks()
        {
            return _bookData.NewestBooks();
        }
    }
}