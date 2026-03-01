using System;
using System.IO;

namespace AppII_LoggerSingleton
{
    // Starter Logger (IKKE singleton endnu)
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void Write(string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}";
            File.AppendAllText(_logFilePath, line);
        }
    }

    // Klasse 1 der bruger Logger
    public class AuthService
    {
        private readonly Logger _logger;

        public AuthService(Logger logger)
        {
            _logger = logger;
        }

        public bool Login(string username, string password)
        {
            _logger.Write($"AuthService: Login attempt for user '{username}'");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                _logger.Write("AuthService: Login failed (missing credentials)");
                return false;
            }

            // Dummy check
            bool success = password == "password";
            _logger.Write(success
                ? "AuthService: Login success"
                : "AuthService: Login failed (invalid password)");

            return success;
        }
    }

    // Klasse 2 der bruger Logger
    public class OrderService
    {
        private readonly Logger _logger;

        public OrderService(Logger logger)
        {
            _logger = logger;
        }

        public void CreateOrder(string username, string productName)
        {
            _logger.Write($"OrderService: Creating order for '{username}' with product '{productName}'");

            if (string.IsNullOrWhiteSpace(productName))
            {
                _logger.Write("OrderService: Order failed (missing product name)");
                return;
            }

            // Dummy order creation
            _logger.Write("OrderService: Order created successfully");
        }
    }

    class Program
    {
        static void Main()
        {
            // Logfil (ligger i projektmappen ved kørsel)
            string logFilePath = "app.log";

            // Starter-løsning: Logger oprettes her og sendes ind (skal ændres til singleton i opgaven)
            Logger logger = new Logger(logFilePath);

            AuthService auth = new AuthService(logger);
            OrderService orders = new OrderService(logger);

            bool loggedIn = auth.Login("stefan", "password");
            if (loggedIn)
            {
                orders.CreateOrder("stefan", "Coffee");
                orders.CreateOrder("stefan", "");
            }

            Console.WriteLine("Done. Check app.log");
        }
    }
}