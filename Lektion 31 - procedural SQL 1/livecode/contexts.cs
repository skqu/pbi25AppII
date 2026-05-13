using Microsoft.EntityFrameworkCore;

class Context : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}