using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<BookModel> lst_books = new()
        {
            new BookModel{Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Novel", year = "1925"},
            new BookModel{Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Novel", year = "1960"},
            new BookModel{Id = 3, Title = "1984", Author = "George Orwell", Genre = "Dystopian", year = "1949"},
        };

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> GetAll()
        {
            return Ok(lst_books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookModel> GetBook(int id)
        {
            var book = lst_books.FirstOrDefault(book => book.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<BookModel> CreateBook(BookModel newBook)
        {
            newBook.Id = lst_books.Max(book => book.Id) + 1;
            lst_books.Add(newBook);
            return Ok("Book created successfully");

        }

        [HttpGet("{id}")]
        public ActionResult<BookModel> DeleteBook(int id)
        {
            var book = lst_books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            lst_books.Remove(book);
            return Ok("Book Deleted Successfully...");
        }
    }
}
