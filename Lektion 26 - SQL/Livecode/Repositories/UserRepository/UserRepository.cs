using Livecode.Contexts;
using Livecode.Model;
namespace Livecode.Repositories.UserRepository
{
    public class UserRepository : IGenericRepositories<UserModel>
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext context)
        {
            _userContext = context;
        }

        public void Add(UserModel userModel)
        {
            _userContext.userModels.Add(userModel);
            _userContext.SaveChanges();
        }

        public UserModel Get(byte modelId)
        {
            UserModel? userModel = new UserModel();
            // Implement Logic here
            userModel = _userContext.userModels.FirstOrDefault(u => u.Id == modelId);
            return userModel;
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> userModel = new List<UserModel>();
            // Implement Logic here
            userModel = _userContext.userModels.ToList<UserModel>();
            return userModel;
        }
    }
}