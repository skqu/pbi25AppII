using code.observer;
using code.service.audit;
using code.controller;
using code.service.contact;
using code.service.order;

namespace code
{
    class Program
    {
        public static void Main()
        {
            IObserver[] observers = new IObserver[]
            {
                new Log(), 
                new Ui(), 
                new Mail(), 
                new Stock()
            };

            Order order = new Order();

            Console.WriteLine("Register Observers");
            foreach (IObserver observer in observers)
            {
                order.RegisterObserver(observer);
            }
            Console.WriteLine("Order change state");
            order.ChangeState("With currier");
        }
    }
}