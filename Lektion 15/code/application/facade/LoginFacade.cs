using Code.Service.Audit;
using Code.Service.Authentication;
using Code.Repository.User;

namespace Code.Application.Facade
{
    class LoginFacade
    {
        private UserRepository? _usr = null;
        private Logger _log = Logger.GetInst();
        private PasswordService _pwd = PasswordService.Empty;
        private TokenService _jwt = TokenService.Empty;

        public LoginFacade()
        {
            // Simple implementation - it is ofcause not a composition to the facade. 
            _pwd = new PasswordService();
            _jwt = new TokenService();
        }

        public string Login(string uname, string pwd)
        {
            string tmp = ""; 
            pwd = _pwd.HashPwd(pwd);
            _usr = _pwd.Validate(uname, pwd);
            tmp = _jwt.Generate(_usr);
            if (tmp != "")
            {
                _log.Log("User: " + _usr.uname + " has succesful logged in");
            }else
            {
                _log.Log("User: " + _usr.uname + " has unsuccesful logged in");
            }
            return tmp;
        }
    }

}