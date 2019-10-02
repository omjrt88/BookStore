using Bookstore.DAL;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Business
{
    public class ReviewBusiness
    {
        private static ReviewData _reviewData;
        public ReviewBusiness(BookStoreContext context)
        {
            _reviewData = new ReviewData(context);
        }

        public IEnumerable<dynamic> Get()
        {
            return _reviewData.Get();
        }

        public dynamic Get(int id)
        {
            return _reviewData.Get(id);
        }

        public int Add(Review model)
        {
            return _reviewData.Add(model); ;
        }

        public Review Update(Review model)
        {
            return _reviewData.Update(model);
        }

        public bool Delete(int id)
        {
            return _reviewData.Delete(id);
        }
    }
}