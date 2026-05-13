using Solution.Command.Interfaces;
using Solution.Dtos;
using Solution.Services.Books;

namespace Solution.Command.Books
{
    class RemoveBookCommand : ICommand
    {
       private BooksService _book;

        public RemoveBookCommand(BooksService book)
        {
            _book = book;   
        }



        public void Execute()
        {
            _book.RemoveBook();
            _book.SaveBooks();
        }
    }
}