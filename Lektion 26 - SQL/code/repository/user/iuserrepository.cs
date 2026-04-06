using code.model;

namespace code.repository.user
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel?> GetUserByIdAsync(int id);
    }
}