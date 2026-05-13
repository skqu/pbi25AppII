namespace Solution.Dtos.Books
{
    public class BookRespondDto
    {
        public int BookId { get; set; } = byte.MinValue;
        public int CopyNumber { get; set; } = byte.MinValue;
        public bool Loan {get; set; } = false;
    }
}