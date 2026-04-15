namespace code.Models
{
    public class BooksModel
    {
        public int BookId { get; set; }

        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public List<BooksCopyModel> Copies { get; set; } = new();
    }
}