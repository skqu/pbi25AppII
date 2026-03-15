using code.observer;

namespace code.controller
{
    class Ui : IObserver
    {
        public void Update()
        {
            Console.WriteLine("UI has been updated"); 
        }
    }
}