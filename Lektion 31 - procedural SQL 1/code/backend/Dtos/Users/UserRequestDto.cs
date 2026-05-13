namespace Solution.Dtos.Users
{
    public class UserRequestDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}