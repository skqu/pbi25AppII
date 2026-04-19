using Solution.Contexts;
using Solution.Models;

namespace Solution.Repositories
{
    public class LoansRepository : IGenericRepostirory<LoanModel>
    {
        private readonly LibraryContext _context;

        public LoansRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateEntry(LoanModel model)
        {
            _context.Loans.Add(model);
            _context.SaveChanges();
        }

        public LoanModel? GetEntry(params object[] keyValues)
        {
            return _context.Loans.Find(keyValues);
        }

        public List<LoanModel> GetEntries()
        {
            return _context.Loans.ToList();
        }

        public void UpdateEntry(LoanModel newModel)
        {
            _context.Loans.Update(newModel);
            _context.SaveChanges();
        }

        public void DeleteEntry(LoanModel model)
        {
            _context.Loans.Remove(model);
            _context.SaveChanges();
        }
    }
}