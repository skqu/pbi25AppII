namespace Solution.Models
{
    public class LoanModel
    {
        public int BookId { get; set; } = -1;
        public int CopyNumber { get; set; } = 0;
        public int UserId { get; set; } = -1;

        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(7);

        public TimeSpan LoanTime => ReturnDate - LoanDate;

        public BooksCopyModel BookCopy { get; set; } = null!;
        public UserModel User { get; set; } = null!;
    }
}