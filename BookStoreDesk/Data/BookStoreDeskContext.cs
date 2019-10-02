using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStoreDesk.Models;
using Bookstore.Models;

namespace BookStoreDesk.Models
{
    public class BookStoreDeskContext : DbContext
    {
        public BookStoreDeskContext (DbContextOptions<BookStoreDeskContext> options)
            : base(options)
        {
        }

        public DbSet<BookStoreDesk.Models.CategoryViewModel> CategoryViewModel { get; set; }

        public DbSet<BookStoreDesk.Models.UserViewModel> UserViewModel { get; set; }

        public DbSet<BookStoreDesk.Models.AuthorViewModel> AuthorViewModel { get; set; }

        public DbSet<BookStoreDesk.Models.BookViewModel> BookViewModel { get; set; }

        public DbSet<Bookstore.Models.ReviewViewModel> ReviewViewModel { get; set; }
    }
}
