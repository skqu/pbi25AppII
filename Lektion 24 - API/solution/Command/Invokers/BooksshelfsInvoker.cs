using Solution.Command.Bookshelfs;
using Solution.Command.Interfaces;
using Solution.Services.Bookshelf;

namespace Solution.Command.Invokers
{
    class BookshelfsInvoker
    {
        private Dictionary<BookshelfsCommandType, ICommand> _commands = new Dictionary<BookshelfsCommandType, ICommand>();

        public BookshelfsInvoker(BookshelfsService bookShelf)
        {
            _commands[BookshelfsCommandType.AddBook] = new AddBookCommand(bookShelf);
            _commands[BookshelfsCommandType.RemoveBook] = new RemoveBookCommand(bookShelf);
        }

        public void AddBook()
        {
            _commands[BookshelfsCommandType.AddBook].Execute();
        }

        public void RemoveBook()
        {
            _commands[BookshelfsCommandType.RemoveBook].Execute();
        }
    }

    public enum BookshelfsCommandType
    {
        AddBook, 
        RemoveBook
    }
}