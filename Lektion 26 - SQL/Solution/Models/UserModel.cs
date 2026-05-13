namespace Solution.Models
{
    public class UserModel
    {
        public string Name {set; get;} = string.Empty;
        public byte Id {set; get;} = 0;
        public DateTime Created {get; set;}
    }
}