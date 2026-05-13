using code.observer;

namespace code.service.order
{
    class Stock : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Item remove from stock"); 
        }
    }
}