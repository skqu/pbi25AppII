namespace Solution.Models
{
    public class BooksModel
    {
        // Key
        public int BookId { get; set; } = -1;

        // Attributes
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;

        // Navigation
        public List<BooksCopyModel> BooksCopies { get; set; } = new();
    }
}