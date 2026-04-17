using Solution.Contexts;
using Solution.Models;
namespace Solution.Repositories
{
    public class BookshelfsRepository : IGenericRepostirory<BookshelfsModel>
    {
        private readonly LibraryContext _context;

        public BookshelfsRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateEntry(BookshelfsModel model)
        {
            _context.Bookshelfs.Add(model);
            _context.SaveChanges();
        }
        public List<BookshelfsModel> GetEntries()
        {
            return _context.Bookshelfs.ToList();
        }

        public void UpdateEntry(BookshelfsModel newModel)
        {
            _context.Bookshelfs.Update(newModel);
            _context.SaveChanges();
        }

        public void DeleteEntry(BookshelfsModel model)
        {
            _context.Bookshelfs.Remove(model);
            _context.SaveChanges();
        }

    }
}