using Solution.Dtos.Books;
using Solution.Models;
using Solution.Repositories;

namespace Solution.Services.Books
{
    public class BooksService
    {
        private readonly BooksRepository _bookRepo;
        private readonly BooksCopyRepository _bookCopyRepo;
        private readonly LoansRepository _loansRepo;

        public BooksService(BooksRepository bookRepo, BooksCopyRepository bookCopyRepo, LoansRepository loansRepo)
        {
            _bookRepo = bookRepo;
            _bookCopyRepo = bookCopyRepo;
            _loansRepo = loansRepo;
        }

        public void Book(BookRequestDto book)
        {
            List<BooksModel> books = _bookRepo.GetEntries();
            BooksModel? bookModel = books.Find(b => b.BookId == book.BookId);

            BooksCopyModel bookCopyModel = new BooksCopyModel
            {
                CopyNumber = 1,
                BookId = book.BookId
            };

            if (bookModel == null)
            {
                bookModel = new BooksModel
                {
                    BookId = book.BookId
                };

                _bookRepo.CreateEntry(bookModel);
            }
            else
            {
                bookCopyModel.CopyNumber = (byte)_bookCopyRepo
                    .GetEntries()
                    .Count(b => b.BookId == bookModel.BookId) + 1;
                
            }

            bookCopyModel.Book = bookModel;

            _bookCopyRepo.CreateEntry(bookCopyModel);
        }

        public void RemoveBook(BookRequestDto book)
        {
            BooksCopyModel? bookCopyModel = _bookCopyRepo.GetEntries().Find(
                b => b.BookId == book.BookId &&
                     b.CopyNumber == book.CopyNumber
            );

            if (bookCopyModel == null)
            {
                return;
            }

            _bookCopyRepo.DeleteEntry(bookCopyModel);

            List<BooksCopyModel> bookCopyModels = _bookCopyRepo.GetEntries().FindAll(
                b => b.BookId == book.BookId
            );

            if (bookCopyModels.Count == 0)
            {
                _bookRepo.DeleteEntry(
                    _bookRepo.GetEntries().Find(b => b.BookId == book.BookId)!
                );
            }
        }

        public void UpdateBook(BookRequestDto book)
        {
            BooksCopyModel? bookCopyModel = _bookCopyRepo.GetEntries().Find(
                b => b.BookId == book.BookId &&
                     b.CopyNumber == book.CopyNumber
            );

            if (bookCopyModel != null)
            {

                _bookCopyRepo.UpdateEntry(bookCopyModel);
            }
        }

        public BookRespondDto GetBook(BookRequestDto book)
        {
            BooksCopyModel? bookCopyModel = _bookCopyRepo.GetEntries().Find(
                b => b.BookId == book.BookId &&
                     b.CopyNumber == book.CopyNumber
            );

            BookRespondDto bookCopy = new BookRespondDto();

            if (bookCopyModel == null)
            {
                return bookCopy;
            }

            bookCopy.BookId = bookCopyModel.BookId;
            bookCopy.CopyNumber = bookCopyModel.CopyNumber;

            bool isAlreadyLoaned = _loansRepo.GetEntries().Any(
                l => l.BookId == book.BookId &&
                     l.CopyNumber == book.CopyNumber
            );

            if (isAlreadyLoaned)
            {
                bookCopy.Loan = true;
            }

            return bookCopy;
        }
    }
}