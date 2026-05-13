namespace Solution.Models
{
    public class UserModel
    {
        // Key
        public int UserId { get; set; } = -1;

        // Attributes
        public string Name { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        // Navigation
        public List<LoanModel> Loans { get; set; } = new();
    }
}