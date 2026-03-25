
namespace AppII_LoggerSingleton
{
    public class Logger
    {
        private readonly string _logFilePath;
        private static Logger? _inst = null;

        private Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public static Logger GetInst(string logFilePath)
        {
            if ( _inst == null)
            {
                _inst = new Logger(logFilePath);
            }
            return _inst;
        }

        public void Write(string message)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}";
            File.AppendAllText(_logFilePath, line);
        }
    }

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
            string logFilePath = "app.log";

            Logger logger = Logger.GetInst(logFilePath);

            AuthService auth = new AuthService(logger);
            OrderService orders = new OrderService(logger);

            bool loggedIn = auth.Login("stefan", "password");
            if (loggedIn)
            {
                orders.CreateOrder("stefan", "Coffee");
                orders.CreateOrder("stefan", "Chokolade");
            }

            Console.WriteLine("Done. Check app.log");
        }
    }
}