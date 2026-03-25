using code.observer;

namespace code.service.audit
{
    class Log : IObserver
    {

        public void Update()
        {
            Console.WriteLine("Log has been updated");
        }
    }
}