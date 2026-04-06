namespace code.dto
{
    public class UserDto
    {
        public string FullName
        {
            set;
            get;
        } = "";

        public string Mail
        {
            set;
            get;
        } = "";

        public int Id
        {
            set;
            get;
        } = 0;


        public UserDto()
        {
            
        }

        public UserDto(string name, string mail)
        {
            FullName = name;
            Mail = mail;
        }
    }
}