using System.Security.Cryptography;

namespace Code.Repository.User
{
    class UserRepository
    {

        public string uname 
        {
            private set; 
            get;
        }

        public string pwd
        {
            private set; 
            get;
        }

        public string birthday
        {
            private set; 
            get; 
        }

        public string pepper
        {
            private set;
            get;
        }


        public UserRepository(string username, string password)
        {
            this.uname = username; 
            this.pwd = password;
            this.pepper = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
            this.birthday = "01-01-1900";
        }
    }

}