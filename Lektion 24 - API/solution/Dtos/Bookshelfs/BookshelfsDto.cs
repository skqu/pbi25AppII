namespace Solution.Dtos.Bookshelfs
{
    class BookshelfsDto
    {
        public byte Id {set;get;}
        public byte Shelfs {set;get;}  
        public byte Rooms {set;get;} // rooms per shelf
        public List<byte> Books {set; get;}

    }
}