using DependencyInjection.BooksServices;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]


        public IActionResult GetBooks()
        {
            var books = booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]

        public IActionResult GetBook(int id)
        {
            var books = booksService.GetBooks();
            var book = books.FirstOrDefault(r => r.BookID == id);
            if (book != null)
            {
                return Ok(book);
            }

            return BadRequest(new { Message = $"{id} idli bir kitap bulunamadı." });
        }

        [HttpGet("Search/{BookName}")]
        public IActionResult GetBooksByBookName(string BookName)
        {
            return Ok();
        }

        [HttpPost]

        public IActionResult AddBook([FromBody] Books books)
        {
            if (ModelState.IsValid)
            {
                var book = booksService.GetBooks();
                book.Add(books);
                books.BookID = book[book.Count - 1].BookID + 1;
                return CreatedAtAction(nameof(GetBook), new { id = books.BookID }, null);
            }
            return BadRequest
                    (ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooks([FromQuery] int id, [FromBody] Books newBook)
        {
            if (id > 0 && isExist(id))
            {
                if (ModelState.IsValid)
                {
                    //güncellendi.....
                    return Ok(newBook);
                }
                return BadRequest(ModelState);
            }
            return NotFound();
        }

        private bool isExist(int id)
        {
            return id % 2 == 0 ? true : false;
        }

        [HttpDelete()]
        public IActionResult DeleteBooks(List<int> id)
        {
            //silindi....
            return Ok();
        }
        [HttpGet("Rest")]
        public Books GetBook()
        {
            return new Books { BookID = 1, BookName = "Test" };
        }
    }
}
