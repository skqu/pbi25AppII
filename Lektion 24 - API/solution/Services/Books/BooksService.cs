using Solution.Dtos.Books;

namespace Solution.Services.Books
{
    public class BooksService
    {
        private Dictionary<byte, BooksDto> _dictBooks = new Dictionary<byte, BooksDto>();
        private BooksDto? _selectedBook = null;

        private List<BooksDto> _listStoredBooks = new List<BooksDto>();


        public void Book(BooksDto book)
        {
            _dictBooks[book.Id] = book;
        }

        public void RemoveBook()
        {
            _dictBooks.Remove(_selectedBook.Id);
        }

        public void SelectBook(byte BookId)
        {
            _selectedBook = _dictBooks[BookId];
        }

        public BooksDto GetBook(byte BookId)
        {
            if(_dictBooks.Keys.Contains(BookId))
            {
                return _dictBooks[BookId];
            }else
            {
                Console.WriteLine("No books added");
                return new BooksDto();
            }
        }

        public void RentBook()
        {
            if (_selectedBook.Loan == false)
            {
                _selectedBook.Loan = true;
            }
        }

        public void ReturnBook()
        {
            _selectedBook.Loan = false;
        }

        public List<BooksDto> GetBooks()
        {
            return _listStoredBooks;
        }

        public void SaveBooks()
        {
            Console.WriteLine("Book is stored in the DB");
            _listStoredBooks = _dictBooks.Values.ToList<BooksDto>();
        }

    }
}