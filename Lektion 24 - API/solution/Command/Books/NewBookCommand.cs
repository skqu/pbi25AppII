using Solution.Command.Interfaces;
using Solution.Dtos;
using Solution.Dtos.Books;
using Solution.Services.Books;

namespace Solution.Command.Books
{
    public class NewBookCommand : ICommand
    {
        public byte BookId {get; set;} = 0;

        private BooksService _book;

        public NewBookCommand(BooksService book)
        {
            _book = book;   
        }

        public void Execute()
        {
            _book.SaveBooks();
        }
    }
}