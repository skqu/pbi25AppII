using Solution.Command.Interfaces;
using Solution.Services.Bookshelf;

namespace Solution.Command.Bookshelfs
{
    class AddBookCommand : ICommand
    {
        private readonly BookshelfsService _bookshelf; 

        public AddBookCommand(BookshelfsService booksshelf)
        {
            _bookshelf = booksshelf;
        }

        public void Execute()
        {
            _bookshelf.AddBook();
        }
    }
}