using Microsoft.EntityFrameworkCore;
using Solution.Models;

namespace Solution.Contexts
{
    public class LibraryContext : DbContext
    {

        public DbSet<BooksModel> Books { get; set; }
        public DbSet<BooksCopyModel> BooksCopies { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookshelfsModel> Bookshelfs { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.UserId);

            // BookCopy
            modelBuilder.Entity<BooksCopyModel>()
                .HasKey(bc => new { bc.BookId, bc.CopyNumber });

            // Book
            modelBuilder.Entity<BooksModel>()
                .HasKey(b => b.BookId);

            // Bookshelf
            modelBuilder.Entity<BookshelfsModel>()
                .HasKey(bs => bs.BookshelfId);

            // Loan
            modelBuilder.Entity<LoanModel>()
                .HasKey(l => new { l.UserId, l.BookId, l.CopyNumber });

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
                .WithMany(b => b.BooksCopies)
                .HasForeignKey(bc => bc.BookId);

            // BookCopy -> Bookshelf
            modelBuilder.Entity<BooksCopyModel>()
                .HasOne(bc => bc.Bookshelf)
                .WithMany(bs => bs.BooksCopies)
                .HasForeignKey(bc => bc.BookshelfId);
        }
    }
}