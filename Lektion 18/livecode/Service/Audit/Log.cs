using livecode.Observer;
namespace livecode.Service.Audit
{
    class Log : IObserver
    {
        public Log()
        {
            // Implementation
        }

        public void Update()
        {
            Console.WriteLine("Log has been writin");
        }
    }
}