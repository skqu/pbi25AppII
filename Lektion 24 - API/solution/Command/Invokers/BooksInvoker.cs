using Solution.Command.Books;
using Solution.Command.Interfaces;
using Solution.Services.Books;
using Solution.Services.Users;

namespace Solution.Command.Invokers
{
    public class BooksInvoker
    {
        private Dictionary<BooksCommandType, ICommand> _commands = new Dictionary<BooksCommandType, ICommand>();

        public BooksInvoker(BooksService book, UsersService user)
        {
            _commands[BooksCommandType.RemoveBook] = new RemoveBookCommand(book);
            _commands[BooksCommandType.NewBook] = new NewBookCommand(book);
            _commands[BooksCommandType.RentBook] = new RentBookCommand(book, user);
            _commands[BooksCommandType.ReturnBook] = new ReturnBookCommand(book, user);
        }

        public void AddBook()
        {
            _commands[BooksCommandType.NewBook].Execute();
        }

        public void RemoveBook()
        {
            _commands[BooksCommandType.RemoveBook].Execute();
        }

        public void RentBook()
        {
            _commands[BooksCommandType.RentBook].Execute();
        }

        public void ReturnBook()
        {
            _commands[BooksCommandType.ReturnBook].Execute();
        }
    }

    public enum BooksCommandType
    {
        RemoveBook, 
        NewBook, 
        RentBook, 
        ReturnBook,
    }
}