using Microsoft.EntityFrameworkCore;

using Solution.Models;


namespace Solution.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> Users {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("user_db");
    }
}