namespace Solution.Dtos.Loans
{
    public class LoanRespondDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int CopyNumber { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}