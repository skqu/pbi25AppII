using Solution.Contexts;
using Solution.Models;

namespace Solution.Repositories
{
    public class UsersRepository : IGenericRepostirory<UserModel>
    {
        private readonly LibraryContext _context;

        public UsersRepository(LibraryContext context)
        {
            _context = context;
        }

        public void CreateEntry(UserModel model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public UserModel? GetEntry(params object[] keyValues)
        {
            return _context.Users.Find(keyValues);
        }

        public List<UserModel> GetEntries()
        {
            return _context.Users.ToList();
        }

        public void UpdateEntry(UserModel newModel)
        {
            _context.Users.Update(newModel);
            _context.SaveChanges();
        }

        public void DeleteEntry(UserModel model)
        {
            _context.Users.Remove(model);
            _context.SaveChanges();
        }
    }
}