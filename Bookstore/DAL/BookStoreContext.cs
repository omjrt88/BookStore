using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using Bookstore.DAL.Data;
using Bookstore.Models;

namespace Bookstore.DAL
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetCategoryConfig(ref modelBuilder);
            SetUserConfig(ref modelBuilder);
            SetAuthorConfig(ref modelBuilder);
            SetBookConfig(ref modelBuilder);
            SetReviewConfig(ref modelBuilder);

            FillDataCategories(ref modelBuilder);
            FillDataAuthors(ref modelBuilder);
            FillDataUsers(ref modelBuilder);
            FillDataBooks(ref modelBuilder);
            FillDataReviews(ref modelBuilder);
        }

        private void SetUserConfig(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(c => c.Name).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<User>().Property(c => c.Birthday).IsRequired();

            modelBuilder.Entity<User>()
                .HasMany<Review>(c => c.Reviews)
                .WithOne(r => r.User);
        }

        private void SetAuthorConfig(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(c => c.Name).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Author>().Property(c => c.Birthday).IsRequired();

            modelBuilder.Entity<Author>()
                .HasMany<Book>(c => c.Books)
                .WithOne(b => b.Author);
        }

        private void SetReviewConfig(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().Property(c => c.Created).IsRequired();
            modelBuilder.Entity<Review>().Property(c => c.Qualification).IsRequired();
            modelBuilder.Entity<Review>().Property(c => c.Comment).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Review>()
                .HasOne<User>(r => r.User)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne<Book>(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(b => b.BookId);

        }

        private void SetCategoryConfig(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(40);
        }

        private void SetBookConfig(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(c => c.Name).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Book>().Property(c => c.Published).IsRequired();

            modelBuilder.Entity<Book>()
                .HasMany<Review>(b => b.Reviews)
                .WithOne(r => r.Book);

            modelBuilder.Entity<Book>()
                .HasOne<Author>(c => c.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne<Category>(c => c.Category)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.CategoryId);

        }

        private void FillDataCategories(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(SeedDatum.Categories);
        }

        private void FillDataAuthors(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(SeedDatum.Authors);
        }

        private void FillDataUsers(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(SeedDatum.Users);
        }

        private void FillDataBooks(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(SeedDatum.Books);
        }

        private void FillDataReviews(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(SeedDatum.Reviews);
        }
    }
}
