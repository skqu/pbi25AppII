namespace Livecode.Model
{
    public class UserModel
    {
        public string Name {set;get;} = string.Empty;
        public byte Id {get;set;} = 0;
        public DateTime Created = DateTime.Now;
    }
}