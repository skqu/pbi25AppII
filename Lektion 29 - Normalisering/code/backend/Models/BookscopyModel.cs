namespace Solution.Models
{
    public class BooksCopyModel
    {
        // Composite key
        public int BookId { get; set; } = -1;
        public int CopyNumber { get; set; } = 0;

        // Foreign key
        public int BookshelfId { get; set; } = 0;

        // Attributes
        public string Status { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;

        // Navigation
        public BooksModel Book { get; set; } = null!;
        public BookshelfsModel Bookshelf { get; set; } = null!;
        public List<LoanModel> Loans { get; set; } = new();
    }
}