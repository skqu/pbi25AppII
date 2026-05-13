using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Solution.Command.Invokers;
using Solution.Dtos.Books;
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
        private readonly BookshelfsInvoker _invoker;

        public BookshelfsController(BookshelfsService bs, BooksService b)
        {
            _bsService = bs;
            _bService = b;
            _invoker = new BookshelfsInvoker(_bsService);
        }

        [HttpPost("{bookshelfId}/book/{bookId}")]
        public ActionResult AddBook(byte bookshelfId, byte bookId)
        {
            _bsService.SelectBookshelf(bookshelfId);
            BooksDto tmp = _bService.GetBook(bookId);
            if (tmp != null)
            {
                _bsService.SelectBook(tmp);
                _invoker.AddBook();
            }
            return Ok(_bsService.GetBookshelfs(bookshelfId));
        }

        [HttpDelete("{bookshelfId}/book/{bookId}")]
        public ActionResult DeleteBook(byte bookshelfId, byte bookId)
        {
            _bsService.SelectBookshelf(bookshelfId);
            _bsService.SelectBook(_bService.GetBook(bookId));
            _invoker.RemoveBook();
            return Ok(_bsService.GetBookshelfs(bookshelfId));
        }
    }
}