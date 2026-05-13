using Solution.Command.Interfaces;
using Solution.Services.Books;
using Solution.Services.Users;


namespace Solution.Command.Books
{
    class ReturnBookCommand : ICommand
    {
        private BooksService _book;
        private UsersService _user;

        public ReturnBookCommand(BooksService book, UsersService user)
        {
            _book = book;   
            _user = user;
        }

        public void Execute()
        {
            _user.ReturnBook();
            _book.ReturnBook();
        }
    }
}