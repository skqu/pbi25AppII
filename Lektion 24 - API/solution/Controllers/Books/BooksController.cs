
using Microsoft.AspNetCore.Mvc;
using Solution.Command.Invokers;
using Solution.Dtos.Books;
using Solution.Services.Books;
using Solution.Services.Users;
namespace Solution.Controllers.Books
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _service;
        private readonly UsersService _user;
        private readonly BooksInvoker _invoker;
        public BooksController(BooksService service, UsersService user)
        {
            _service = service;
            _user = user;
            _invoker = new BooksInvoker(_service, _user);
        }

        [HttpPost]
        public ActionResult NewBook([FromBody] BooksDto book)
        {
            _service.Book(book);
            _invoker.AddBook();
            return Ok(_service.GetBooks());
        }

        [HttpDelete]
        public ActionResult RemoveBook([FromBody] BooksDto book)
        {
            _service.SelectBook(book.Id);
            _invoker.RemoveBook();
            return Ok(_service.GetBooks());
        }

        [HttpPost("{BookId}/loan")]
        public ActionResult RentBook(byte BookId)
        {
            _service.SelectBook(BookId);
            _user.SelectBook(BookId);
            _invoker.RentBook();
            return Ok(_service.GetBook(BookId));
        }

        [HttpDelete("{BookId}/loan")]
        public ActionResult ReturnBook(byte BookId)
        {
            _service.SelectBook(BookId);
            _user.SelectBook(BookId);
            _invoker.ReturnBook();
            return Ok(_service.GetBook(BookId));
        }

    }
}