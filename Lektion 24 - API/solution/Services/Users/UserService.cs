using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Solution.Command.Books;
using Solution.Dtos.Users;
using Solution.Services.Books;

namespace Solution.Services.Users
{
    public class UsersService
    {
        private UsersDto _user = new UsersDto
        {
            Name = "Stefan",
            Books = new byte[] { 0, 0, 0 }
        };
        private byte _bookId = 0;

        public bool CanBorrow()
        {
            int index = Array.IndexOf(_user.Books, (byte)0);
            bool rtn = false;

            if ( index > -1 )
            {
                rtn = true;
            }
            return rtn;
        }

        public void SelectBook(byte bookId)
        {
            _bookId = bookId;
        }

        public void RentBook()
        {
            int index = Array.IndexOf(_user.Books, 0);
            if ( index > -1 )
            {
                _user.Books[index] = _bookId;
            }
        }

        public void ReturnBook()
        {
            int index = Array.IndexOf(_user.Books, _bookId);
            if ( index > -1 )
            {
                _user.Books[index] = 0;
            }
        }
    }
}