namespace code.Models
{
    public class UserModel
    {
        // Primary key - EFCore auto discover it
        public int UserId { get; set; }

        // Attributes
        public string Name { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        // Navigations property
        public List<LoanModel> Loans { get; set; } = new();
    }
}