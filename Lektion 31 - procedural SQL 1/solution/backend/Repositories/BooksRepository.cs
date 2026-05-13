using Solution.Contexts;
using Solution.Models;
namespace Solution.Repositories
{
    public class BooksRepository : IGenericRepostirory<BooksModel>
    {
        private readonly LibraryContext _context;

        public BooksRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateEntry(BooksModel model)
        {
            _context.Books.Add(model);
            _context.SaveChanges();
        }
        public List<BooksModel> GetEntries()
        {
            return _context.Books.ToList();
        }

        public void UpdateEntry(BooksModel newModel)
        {
            _context.Books.Update(newModel);
            _context.SaveChanges();
        }

        public void DeleteEntry(BooksModel model)
        {
            _context.Books.Remove(model);
            _context.SaveChanges();
        }

    }
}