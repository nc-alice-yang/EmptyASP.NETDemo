using EmptyASP.NETDemo.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace EmptyASP.NETDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {

        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService) {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAuthors();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var author = _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthorById([FromBody] Author newAuthor)
        {
            if (newAuthor == null)
            {
                return BadRequest("Invalid Author data.");
            }

            _authorService.AddAuthor(newAuthor);
            return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, newAuthor);
        }

        public IActionResult DeleteAuthor(int id)
        {
            bool isDeleted = _authorService.DeleteAuthor(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
    
}
