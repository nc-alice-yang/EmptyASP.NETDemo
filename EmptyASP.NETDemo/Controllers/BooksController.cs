using Microsoft.AspNetCore.Mvc;
using EmptyASP.NETDemo.ServiceLayer;


namespace EmptyASP.NETDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {

        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);

        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBookById([FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Invalid book data.");
            }

            _bookService.AddBook(newBook);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            bool isDeleted = _bookService.DeleteBook(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
        //[Route("/About/{id?}")]
        [HttpGet("authors/{id}")]
        public IActionResult GetBooksByAuthor(int id)
        {
            var books = _bookService.GetBooksByAuthorId(id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
    }

}






//    // DELETE: api/book/{id}
