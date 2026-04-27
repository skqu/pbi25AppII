namespace Solution.Models
{
    public class UserLoansViewModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CopyNumber { get; set; }
    }
}