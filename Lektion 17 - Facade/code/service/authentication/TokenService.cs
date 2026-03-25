using Code.Repository.User;
using System.Security.Cryptography;
using System.Text;

namespace Code.Service.Authentication
{
    class TokenService
    {
        public TokenService()
        {

        }


        /*
            Non-null empty instance/object. 
        */
        public static readonly TokenService Empty = new TokenService();

        public string Generate(UserRepository usr)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(usr.uname + usr.pwd + usr.birthday + usr.pepper);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}