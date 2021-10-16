using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DependencyInjection.BooksServices
{
    public class BookService : IBooksService
    {
        IList<Books> IBooksService.GetBooks()
        {
            return new List<Books>
           {
                new Books { BookID = 1, BookName = "Milenaya Mektuplar", PageNumber=374},
                new Books { BookID=2, BookName="Tutunamayanlar", PageNumber=874}
           };
        }
    }
}
