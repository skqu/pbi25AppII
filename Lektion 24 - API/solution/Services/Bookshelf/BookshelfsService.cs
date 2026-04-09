using Solution.Dtos.Books;
using Solution.Dtos.Bookshelfs;
namespace Solution.Services.Bookshelf
{
    public class BookshelfsService
    {
        private List<BookshelfsDto> _bookshelfs = new List<BookshelfsDto>();
        private byte _selectedBookshelf = 0;
        private byte _cursor = 0;
        private BooksDto _selectedBook = new BooksDto();

        public BookshelfsService()
        {  
            _bookshelfs.Add(new BookshelfsDto{Id=1, Shelfs=2, Rooms=4});
            _bookshelfs[0].Books = new List<byte>();

        }

        public void SelectBookshelf(byte bookshelfId)
        {
            _selectedBookshelf = bookshelfId;
        }

        public void SelectBook(BooksDto book)
        {
            _selectedBook = book;
        }

        public List<byte> GetBookshelfs(byte bookshelfId)
        {
            return _bookshelfs[bookshelfId].Books;
        }

        public void AddBook()
        {
            BookshelfsDto bookshelf = _bookshelfs[_selectedBookshelf];
            if (_cursor < bookshelf.Shelfs * bookshelf.Rooms)
            {
                bookshelf.Books.Add(_selectedBook.Id);
                _cursor += 1;
            }else
            {
                Console.WriteLine("No more room");
            }

        }

        public void RemoveBook()
        {
            BookshelfsDto bookshelf = _bookshelfs[_selectedBookshelf];
            if ( bookshelf.Books.Remove(_selectedBook.Id))
            {
                _cursor -= 1;
            }
        }
    }
}