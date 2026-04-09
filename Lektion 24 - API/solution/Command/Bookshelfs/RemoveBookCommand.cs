using Solution.Command.Interfaces;
using Solution.Services.Bookshelf;

namespace Solution.Command.Bookshelfs
{
    class RemoveBookCommand : ICommand
    {
        private BookshelfsService _bookshelf; 

        public RemoveBookCommand(BookshelfsService booksshelf)
        {
            _bookshelf = booksshelf;
        }


        public void Execute()
        {
            _bookshelf.RemoveBook();
        }
    }
}