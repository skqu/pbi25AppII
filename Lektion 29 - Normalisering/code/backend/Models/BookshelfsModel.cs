namespace Solution.Models
{
    public class BookshelfsModel
    {
        // Key
        public int BookshelfId { get; set; } = -1;

        // Attributes
        public byte Size { get; set; } = 0;
        public byte Row { get; set; } = 0;

        // Navigation
        public List<BooksCopyModel> BooksCopies { get; set; } = new();
    }
}