using Solution.Dtos.Books;
namespace Solution.Dtos.Bookshelfs
{
    public class BookshelfRespondDto
    {
        public byte Shelfs {get;set;} = byte.MinValue;
        public byte Rooms {get;set;} = byte.MinValue;
        public int BookshelfId { get; set; } = byte.MinValue;

        public List<BookRespondDto> Books { get; set; } = new List<BookRespondDto>();
    }
}