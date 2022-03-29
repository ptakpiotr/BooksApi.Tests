using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace LibraryAPI.Tests
{
    public class MockingHelpers
    {
        private static List<BookModel> allBooks = new List<BookModel>()
        {
            new BookModel()
            {
                Author="jack@jack.com",
                Book="jack book",
                Country=null,
                CountryId = 1,
                Email="jack@jack.com",
                Id=Guid.NewGuid(),
                Pages = 1
            },
            new BookModel()
            {
                Author="jack2@jack.com",
                Book="jack2 book",
                Country=null,
                CountryId = 1,
                Email="jack2@jack.com",
                Id=Guid.NewGuid(),
                Pages = 2
            },
            new BookModel()
            {
                Author="jack3@jack.com",
                Book="jack3 book",
                Country=null,
                CountryId = 1,
                Email="jack3@jack.com",
                Id=Guid.NewGuid(),
                Pages = 3
            }
        };
        public static BookModel testBook = new BookModel()
        {
            Author = "jim@jim.com",
            Book = "Jim\'s book",
            Country = null,
            CountryId = 1,
            Email = "jim@jim.com",
            Id = Guid.NewGuid(),
            Pages = 100
        };
        public static List<BookModel> GetAllBooksMoq() => allBooks;

        public static BookModel GetOneBookMoq(Guid id) => allBooks.FirstOrDefault(b => b.Id == id);

        public static void AddBookMoq(BookModel md)
        {
            allBooks.Add(md);
        }
        public static void DeleteBookMoq(BookModel md)
        {
            allBooks.Remove(md);
        }
        public static void UpdateBookMoq(BookModel md)
        {
        }
    }
}
