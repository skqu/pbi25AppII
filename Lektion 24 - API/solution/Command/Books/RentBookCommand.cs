using Solution.Command.Interfaces;
using Solution.Dtos;
using Solution.Services.Books;
using Solution.Services.Users;

namespace Solution.Command.Books
{
    class RentBookCommand : ICommand
    {
        private BooksService _book;
        private UsersService _user;

        public RentBookCommand(BooksService book, UsersService user)
        {
            _book = book;   
            _user = user;
        }

        public void Execute()
        {
            if ( _user.CanBorrow() )
            {
                _user.RentBook();
                _book.RentBook();
            }
        }
    }
}