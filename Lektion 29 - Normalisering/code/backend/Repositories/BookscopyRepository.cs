using Solution.Contexts;
using Solution.Models;
namespace Solution.Repositories
{
    public class BooksCopyRepository : IGenericRepostirory<BooksCopyModel>
    {
        private readonly LibraryContext _context;

        public BooksCopyRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateEntry(BooksCopyModel model)
        {
            _context.BooksCopies.Add(model);
            _context.SaveChanges();
        }
        public List<BooksCopyModel> GetEntries()
        {
            return _context.BooksCopies.ToList();
        }

        public void UpdateEntry(BooksCopyModel newModel)
        {
            _context.BooksCopies.Update(newModel);
            _context.SaveChanges();
        }

        public void DeleteEntry(BooksCopyModel model)
        {
            _context.BooksCopies.Remove(model);
            _context.SaveChanges();
        }

    }
}