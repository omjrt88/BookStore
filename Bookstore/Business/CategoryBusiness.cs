using Bookstore.DAL;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Business
{
    public class CategoryBusiness
    {
        private static CategoryData _categoryData;
        public CategoryBusiness(BookStoreContext context)
        {
            _categoryData = new CategoryData(context);
        }

        public IEnumerable<Category> Get()
        {
            return _categoryData.Get();
        }

        public dynamic Get(int id)
        {
            return _categoryData.Get(id);
        }

        public int Add(Category model)
        {
            return _categoryData.Add(model); ;
        }

        public Category Update(Category model)
        {
            return _categoryData.Update(model);
        }

        public bool Delete(int id)
        {
            return _categoryData.Delete(id);
        }
    }
}
