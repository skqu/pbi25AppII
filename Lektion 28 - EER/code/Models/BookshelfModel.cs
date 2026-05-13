namespace code.Models
{
    public class BookshelfModel
    {
        public int BookshelfId { get; set; }

        public byte Size { get; set; }
        public byte Row { get; set; }

        public List<BooksCopyModel> Copies { get; set; } = new();
    }
}