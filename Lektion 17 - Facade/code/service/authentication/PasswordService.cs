using Code.Repository.User;
using System.Security.Cryptography;
using System.Text;

namespace Code.Service.Authentication
{
    class PasswordService
    {
        public PasswordService()
        {

        }

        /*
            Non-null empty instance/object. 
        */
        public static readonly PasswordService Empty = new PasswordService();

        public string HashPwd(string pwd)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pwd);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public UserRepository Validate(string username, string pwd)
        {
            UserRepository usr = new UserRepository(username, pwd);
            return usr;
        }
    }
}