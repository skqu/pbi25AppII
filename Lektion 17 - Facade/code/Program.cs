using Code.Application.Facade;

namespace Code
{
    class Program
    {
        static void Main()
        {
            LoginFacade facade = new LoginFacade();
            string success = facade.Login("Stefan", "Secret#1");
            if (success != "")
            {
                Console.WriteLine("The client tried to login and was succesful");
            }else
            {
                Console.WriteLine("Unauthorized");
            }
        }
    }
}