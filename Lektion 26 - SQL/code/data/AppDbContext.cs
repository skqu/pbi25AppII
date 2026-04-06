using Microsoft.EntityFrameworkCore;
using code.model;

namespace code.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(u => u.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(u => u.SurName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(u => u.Mail)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(u => u.CreatedAt)
                    .IsRequired();
            });
        }
    }
}