using Microsoft.AspNetCore.Mvc;
using Solution.Dtos.Books;
using Solution.Services.Books;

namespace Solution.Controllers.Books
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _service;

        public BooksController(BooksService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateBook([FromBody] BookRequestDto book)
        {
            _service.Book(book);
            return Ok();
        }

        [HttpDelete]
        public ActionResult RemoveBook([FromBody] BookRequestDto book)
        {
            _service.RemoveBook(book);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateBook([FromBody] BookRequestDto book)
        {
            _service.UpdateBook(book);
            return Ok();
        }

        [HttpGet("{bookId}/{copyNumber}")]
        public ActionResult<BookRespondDto> GetBook(int bookId, byte copyNumber)
        {
            BookRequestDto book = new BookRequestDto
            {
                BookId = bookId,
                CopyNumber = copyNumber
            };

            BookRespondDto foundBook = _service.GetBook(book);
            return Ok(foundBook);
        }
    }
}