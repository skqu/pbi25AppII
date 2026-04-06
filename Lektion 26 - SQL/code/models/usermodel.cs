namespace code.model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string SurName { get; set; } = "";
        public string Mail { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}