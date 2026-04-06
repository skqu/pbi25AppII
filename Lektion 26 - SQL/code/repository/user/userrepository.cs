using Microsoft.EntityFrameworkCore;
using code.data;
using code.model;

namespace code.repository.user
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}