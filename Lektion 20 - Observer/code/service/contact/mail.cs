using code.observer;

namespace code.service.contact
{
    class Mail : IObserver
    {
        public void Update()
        {
            Console.WriteLine("E-Mail has been sent to customer"); 
        }
    }
}