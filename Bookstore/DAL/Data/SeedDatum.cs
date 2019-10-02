using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Common;
using Bookstore.Models;

namespace Bookstore.DAL.Data
{
    public static class SeedDatum
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Ciencia Ficcion"},
            new Category { Id = 2, Name = "Romance" },
            new Category { Id = 3, Name = "Terror" },
            new Category { Id = 4, Name = "Mystery" }
        };

        public static List<Author> Authors = new List<Author>
        {
            new Author { Id = 1, Name = "J. K. Rowling", Birthday = new DateTime(1965, 7, 31)},
            new Author { Id = 2, Name = "J. R. R. Tolkien", Birthday = new DateTime(1892, 1, 3)},
            new Author { Id = 3, Name = "Jojo Moyes", Birthday = new DateTime(1969, 8, 4)},
            new Author { Id = 4, Name = "Stephen King", Birthday = new DateTime(1947, 9, 21)},
            new Author { Id = 5, Name = "Paula Hawkins", Birthday = new DateTime(1972, 8, 26)}
        };

        public static List<User> Users = new List <User>
        {
            new User { Id = 1, Name = "Omar Rodriguez", Birthday = new DateTime(1988, 8, 12), Username = "omjrt88", Password = "1234", IsAdmin = true},
            new User { Id = 2, Name = "Bruce Wayne", Birthday = new DateTime(1983, 2, 19), Username = "batman", Password = "1234", IsAdmin = false },
            new User { Id = 3, Name = "Naruto Uzumaki", Birthday = new DateTime(2000, 4, 4), Username = "kyubi", Password = "1234", IsAdmin = false },
            new User { Id = 4, Name = "Diane Prince", Birthday = new DateTime(1920, 6, 21), Username = "wwoman", Password = "1234", IsAdmin = false }
        };

        public static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Name = "Harry Potter and the Sorcerer's Stone", Published = new DateTime(1997, 6, 26), AuthorId = Authors[0].Id, CategoryId = 1},
            new Book { Id = 2, Name = "Harry Potter and the Chamber of Secrets", Published = new DateTime(1998, 7, 2), AuthorId = Authors[0].Id, CategoryId = 1 },
            new Book { Id = 3, Name = "Harry Potter and the Prisoner of Azkaban", Published = new DateTime(1999, 7, 8), AuthorId = Authors[0].Id, CategoryId = 1 },
            new Book { Id = 4, Name = "The Hobbit", Published = new DateTime(1937, 9, 21), AuthorId = Authors[1].Id, CategoryId = 1 },
            new Book { Id = 5, Name = "The Silmarillion", Published = new DateTime(1977, 9, 15), AuthorId = Authors[1].Id, CategoryId = 1 },
            new Book { Id = 6, Name = "Me before you", Published = new DateTime(2012, 6, 29), AuthorId = Authors[2].Id, CategoryId = 2 },
            new Book { Id = 7, Name = "Me after you", Published = new DateTime(2014, 8, 14), AuthorId = Authors[2].Id, CategoryId = 2 },
            new Book { Id = 8, Name = "IT", Published = new DateTime(1986, 9, 15), AuthorId = Authors[3].Id, CategoryId = 3 },
            new Book { Id = 9, Name = "The Girl on the Train", Published = new DateTime(2015, 1, 6), AuthorId = Authors[4].Id, CategoryId = 4 },
        };

        public static List<Review> Reviews =new List<Review>
        {
            new Review { Id = 1, UserId = 1, BookId = 1, Created = new DateTime(2018,3,2), Qualification = DictionaryData.Reviews["Great"], Comment = "Amazing Book! Recommended to all ages."},
            new Review { Id = 2, UserId = 1, BookId = 2, Created = new DateTime(2019,7,9), Qualification = DictionaryData.Reviews["Average"], Comment = "Nothing compare to the first one. The author lost imagination."},
            new Review { Id = 3, UserId = 2, BookId = 3, Created = new DateTime(2018,4,12), Qualification = DictionaryData.Reviews["Great"], Comment = "All the mistery related to Sirius and how betrayed Harry's parent was brilliant."},
            new Review { Id = 4, UserId = 2, BookId = 8, Created = new DateTime(2019,1,5), Qualification = DictionaryData.Reviews["Bad"], Comment = "I hate clowns."},
            new Review { Id = 5, UserId = 4, BookId = 8, Created = new DateTime(2019,3,2), Qualification = DictionaryData.Reviews["Great"], Comment = "I'm not clown's fan, but this had a good narrative."},
            new Review { Id = 6, UserId = 3, BookId = 8, Created = new DateTime(2019,5,17), Qualification = DictionaryData.Reviews["Unsatisfactory"], Comment = "Meh!."},
            new Review { Id = 7, UserId = 4, BookId = 6, Created = new DateTime(2018,9,6), Qualification = DictionaryData.Reviews["Excellent"], Comment = "I love it!."},
            new Review { Id = 8, UserId = 4, BookId = 6, Created = new DateTime(2018,9,6), Qualification = DictionaryData.Reviews["Bad"], Comment = "Boring."},
            new Review { Id = 9, UserId = 1, BookId = 9, Created = new DateTime(2015,1,16), Qualification = DictionaryData.Reviews["Excellent"], Comment = "Master piece."},
            new Review { Id = 10, UserId = 2, BookId = 9, Created = new DateTime(2015,1,6), Qualification = DictionaryData.Reviews["Excellent"], Comment = "I'm the best World's detective and I could imagine the end. Awesome book."},
            new Review { Id = 11, UserId = 3, BookId = 9, Created = new DateTime(2015,2,16), Qualification = DictionaryData.Reviews["Excellent"], Comment = "This was the best book I read!."},
            new Review { Id = 12, UserId = 4, BookId = 9, Created = new DateTime(2016,4,3), Qualification = DictionaryData.Reviews["Excellent"], Comment = "OMG, the twist! I had another perspective about what was going on!"}
        };
    }
}
