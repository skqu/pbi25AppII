using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Solution.Dtos.Books;
using Solution.Dtos.Bookshelfs;
using Solution.Services.Books;
using Solution.Services.Bookshelf;

namespace Solution.Controllers.Bookshelfs
{
    [ApiController]
    [Route("/api/bookshelfs")]
    public class BookshelfsController : ControllerBase
    {
        private readonly BookshelfsService _bsService;
        private readonly BooksService _bService;

        public BookshelfsController(BookshelfsService bsService, BooksService bService)
        {
            _bsService = bsService;
            _bService = bService;
        }

        [HttpPost]
        public ActionResult AddShelf([FromBody] BookshelfRequestDto bookshelf)
        {
            _bsService.NewBookshelf(bookshelf);
            return Ok();
        }

        [HttpDelete("{bookshelfId}")]
        public ActionResult RemoveShelf(int bookshelfId)
        {
            _bsService.DeleteBookshelf(bookshelfId);
            return Ok();
        }


        [HttpPost("{bookshelfId}/book/")]
        public ActionResult AddBook(byte bookshelfId, [FromBody] BookRequestDto book)
        {
            return Ok(_bsService.AddBook(book, bookshelfId));
        }

        [HttpDelete("{bookshelfId}/book")]
        public ActionResult DeleteBook(byte bookshelfId, [FromBody] BookRequestDto book)
        {
            return Ok(_bsService.RemoveBook(book, bookshelfId));
        }
    }
}