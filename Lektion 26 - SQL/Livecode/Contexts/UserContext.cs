using Microsoft.EntityFrameworkCore;
using Livecode.Model;

namespace Livecode.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> userModels {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseInMemoryDatabase("livecode.db");
        }
    }
}