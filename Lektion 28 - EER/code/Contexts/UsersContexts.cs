using Microsoft.EntityFrameworkCore;
using code.Models;

namespace code.Contexts
{
    public class UsersContext : DbContext
    {
        public DbSet<UserModel> Users{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseInMemoryDatabase("livecode.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.UserId);

            // Book
            modelBuilder.Entity<BooksModel>()
                .HasKey(b => b.BookId);

            // Bookshelf
            modelBuilder.Entity<BookshelfModel>()
                .HasKey(bs => bs.BookshelfId);

            // BookCopy (weak entity)
            modelBuilder.Entity<BooksCopyModel>()
                .HasKey(bc => new { bc.BookId, bc.CopyNumber });

            // Loan
            modelBuilder.Entity<LoanModel>()
                .HasKey(l => new { l.UserId, l.BookId, l.CopyNumber, l.LoanDate });

            // Loan -> User
            modelBuilder.Entity<LoanModel>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId);

            // Loan -> BookCopy
            modelBuilder.Entity<LoanModel>()
                .HasOne(l => l.BookCopy)
                .WithMany(bc => bc.Loans)
                .HasForeignKey(l => new { l.BookId, l.CopyNumber });

            // BookCopy -> Book
            modelBuilder.Entity<BooksCopyModel>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Copies)
                .HasForeignKey(bc => bc.BookId);

            // BookCopy -> Bookshelf
            modelBuilder.Entity<BooksCopyModel>()
                .HasOne(bc => bc.Bookshelf)
                .WithMany(bs => bs.Copies)
                .HasForeignKey(bc => bc.BookshelfId);
        }
    }
}