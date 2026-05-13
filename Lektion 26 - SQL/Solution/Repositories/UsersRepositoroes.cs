using Solution.Models;
using Microsoft.EntityFrameworkCore;
using Solution.Context;

namespace Solution.Repositories
{
    public class UserRepositories : IGenericRepositories<UserModel>
    {
        private UserContext _userContext = new UserContext();

        public void Add(UserModel userModel)
        {
            _userContext.Add(userModel);
            _userContext.SaveChanges();
        }

        public void Remove(byte userId)
        {
            UserModel? user = Get(userId);
            if (user == null)
            {
                return;
            }
            _userContext.Remove(user);
            _userContext.SaveChanges();
        }

        public UserModel? Get(byte userId)
        {
            UserModel? user = _userContext.Users.FirstOrDefault(u => u.Id == userId);
            
            return user;

        }
    }
}