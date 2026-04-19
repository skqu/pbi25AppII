using Solution.Dtos.Loans;

namespace Solution.Dtos.Users
{
    public class UserRespondDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public List<LoanRespondDto> Loans { get; set; } = new();
    }
}