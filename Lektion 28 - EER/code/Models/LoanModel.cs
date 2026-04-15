namespace code.Models
{
    public class LoanModel
    {
        public int BookId { get; set; }
        public int CopyNumber { get; set; }
        public int UserId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public BooksCopyModel BookCopy { get; set; } = null!;
        public UserModel User { get; set; } = null!;
    }
}