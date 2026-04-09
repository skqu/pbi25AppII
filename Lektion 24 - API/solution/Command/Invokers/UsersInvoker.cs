/*using Solution.Command.Books;
using Solution.Command.Interfaces;
using Solution.Dtos.Books;
using Solution.Services.Books;

namespace Solution.Command.Invokers
{
    class UsersInvoker
    {
        private Dictionary<UsersCommandType, ICommand> _commands = new Dictionary<UsersCommandType, ICommand>();

        public UsersInvoker(BooksService book)
        {
            _commands[UsersCommandType.RentBook] = new RentBookCommand(book);
            _commands[UsersCommandType.ReturnBook] = new ReturnBookCommand(book);
        }

        public void RentBook(BooksDto book)
        {
            _commands[UsersCommandType.RentBook].Dto = book;
            _commands[UsersCommandType.RentBook].Execute();
        }

        public void ReturnBook(BooksDto book)
        {
            _commands[UsersCommandType.ReturnBook].Dto = book;
            _commands[UsersCommandType.ReturnBook].Execute();
        }
    }

    public enum UsersCommandType
    {
        RentBook, 
        ReturnBook,
    }
}*/