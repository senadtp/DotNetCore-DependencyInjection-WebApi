using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Models;

namespace DependencyInjection.BooksServices
{
    public interface IBooksService
    {
        IList<Books> GetBooks();
    }
}
