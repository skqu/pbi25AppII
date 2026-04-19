namespace Solution.Dtos.Bookshelfs
{
    public class BookshelfRequestDto
    {
        public int BookshelfId {get;set;}
        public byte Shelfs {get;set;} = byte.MinValue;
        public byte Rooms {get;set;} = byte.MinValue;
    }
}