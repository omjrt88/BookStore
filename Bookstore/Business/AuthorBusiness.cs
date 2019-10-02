using Bookstore.DAL;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Business
{
    public class AuthorBusiness
    {
        private static AuthorData _authorData;
        public AuthorBusiness(BookStoreContext context)
        {
            _authorData = new AuthorData(context);
        }

        public IEnumerable<Author> Get()
        {
            return _authorData.Get();
        }

        public Author Get(int id)
        {
            return _authorData.Get(id);
        }

        public int Add(Author model)
        {
            return _authorData.Add(model); ;
        }

        public Author Update(Author model)
        {
            return _authorData.Update(model);
        }

        public bool Delete(int id)
        {
            return _authorData.Delete(id);
        }
    }
}