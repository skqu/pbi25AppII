using Microsoft.EntityFrameworkCore;

using Code.Models;

// Add package: 
// dotnet add package Microsoft.EntityFrameworkCore
// For testing
// dotnet add package Microsoft.EntityFrameworkCore.InMemory
// For Sql implementation 
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Also install: 
// dotnet tool install --global dotnet-ef
// dotnet add package Microsoft.EntityFrameworkCore.Design

namespace Code.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
