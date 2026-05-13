using Code.Models;
using Code.Context;

namespace Code.Repositories
{
    public class UserRepository : IGenericRepositories<UserModel>
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Add(UserModel model)
        {
            _userContext.Users.Add(model);
            _userContext.SaveChanges();
        }

        public UserModel? GetById(byte modelId)
        {
            UserModel? user = _userContext.Users.FirstOrDefault(u => u.Id == modelId);

            if (user == null)
            {
                Console.WriteLine("User not found");
            }

            return user;
        }

        public void Remove(byte modelId)
        {
            UserModel? user = _userContext.Users.FirstOrDefault(u => u.Id == modelId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }
    }
}