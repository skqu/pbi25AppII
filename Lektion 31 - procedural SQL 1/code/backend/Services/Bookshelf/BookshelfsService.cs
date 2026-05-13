using Solution.Dtos.Books;
using Solution.Dtos.Bookshelfs;
using Solution.Models;
using Solution.Repositories;

namespace Solution.Services.Bookshelf
{
    public class BookshelfsService
    {
        private readonly BookshelfsRepository _bookshelfsRepo;
        private readonly BooksCopyRepository _bookCopiesRepo;

        public BookshelfsService(
            BookshelfsRepository bookshelfsRepo,
            BooksCopyRepository bookCopiesRepo)
        {
            _bookshelfsRepo = bookshelfsRepo;
            _bookCopiesRepo = bookCopiesRepo;
        }

        public void NewBookshelf(BookshelfRequestDto bookshelfDto)
        {
            BookshelfsModel bookshelfModel = new BookshelfsModel
            {
                BookshelfId = bookshelfDto.BookshelfId,
                Size = bookshelfDto.Rooms,
                Row = bookshelfDto.Shelfs
            };

            _bookshelfsRepo.CreateEntry(bookshelfModel);
        }

        public void UpdateBookshelf(BookshelfRequestDto bookshelfDto)
        {
            BookshelfsModel? bookshelfModel = _bookshelfsRepo.GetEntries().Find(
                b => b.BookshelfId == bookshelfDto.BookshelfId
            );

            if (bookshelfModel == null)
            {
                return;
            }

            bookshelfModel.Size = bookshelfDto.Rooms;
            bookshelfModel.Row = bookshelfDto.Shelfs;

            _bookshelfsRepo.UpdateEntry(bookshelfModel);
        }

        public void DeleteBookshelf(int id)
        {
            BookshelfsModel? bookshelfModel = _bookshelfsRepo.GetEntries().Find(
                b => b.BookshelfId == id
            );

            if (bookshelfModel == null)
            {
                return;
            }

            List<BooksCopyModel> booksOnShelf = _bookCopiesRepo.GetEntries().FindAll(
                bc => bc.BookshelfId == id
            );

            foreach (BooksCopyModel bookCopy in booksOnShelf)
            {
                bookCopy.BookshelfId = 0;
                _bookCopiesRepo.UpdateEntry(bookCopy);
            }

            _bookshelfsRepo.DeleteEntry(bookshelfModel);
        }

        public BookshelfRespondDto AddBook(BookRequestDto book, int bookshelfId)
        {
            BookshelfRespondDto rtnBookshelf = new BookshelfRespondDto();

            BookshelfsModel? bookshelfModel = _bookshelfsRepo.GetEntries().Find(
                b => b.BookshelfId == bookshelfId
            );

            BooksCopyModel? bookCopyModel = _bookCopiesRepo.GetEntries().Find(
                b => b.BookId == book.BookId &&
                     b.CopyNumber == book.CopyNumber
            );

            if (bookshelfModel == null || bookCopyModel == null)
            {
                return rtnBookshelf;
            }

            List<BooksCopyModel> booksOnShelf = _bookCopiesRepo.GetEntries().FindAll(
                bc => bc.BookshelfId == bookshelfId
            );

            if (booksOnShelf.Count < bookshelfModel.Size * bookshelfModel.Row)
            {
                bookCopyModel.BookshelfId = bookshelfId;
                _bookCopiesRepo.UpdateEntry(bookCopyModel);
            }

            rtnBookshelf.BookshelfId = bookshelfId;

            foreach (BooksCopyModel bookCopy in _bookCopiesRepo.GetEntries().FindAll(
                bc => bc.BookshelfId == bookshelfId))
            {
                rtnBookshelf.Books.Add(new BookRespondDto{BookId = bookCopy.BookId, CopyNumber = bookCopy.CopyNumber} );
            }

            return rtnBookshelf;
        }

        public BookshelfRespondDto RemoveBook(BookRequestDto book, int bookshelfId)
        {
            BookshelfRespondDto rtnBookshelf = new BookshelfRespondDto();

            BookshelfsModel? bookshelfModel = _bookshelfsRepo.GetEntries().Find(
                b => b.BookshelfId == bookshelfId
            );

            BooksCopyModel? bookCopyModel = _bookCopiesRepo.GetEntries().Find(
                b => b.BookId == book.BookId &&
                     b.CopyNumber == book.CopyNumber &&
                     b.BookshelfId == bookshelfId
            );

            if (bookshelfModel == null || bookCopyModel == null)
            {
                return rtnBookshelf;
            }

            bookCopyModel.BookshelfId = 0;
            _bookCopiesRepo.UpdateEntry(bookCopyModel);

            rtnBookshelf.BookshelfId = bookshelfId;

            foreach (BooksCopyModel bookCopy in _bookCopiesRepo.GetEntries().FindAll(
                bc => bc.BookshelfId == bookshelfId))
            {
                rtnBookshelf.Books.Add(new BookRespondDto{BookId = bookCopy.BookId, CopyNumber = bookCopy.CopyNumber} );
            }

            return rtnBookshelf;
        }
    }
}