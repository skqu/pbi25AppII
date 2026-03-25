using System.Data;
using livecode.Observer;
using livecode.Service.Audit;
using livecode.Service.Customer;
using livecode.Service.Test;

namespace livecode
{
    class Program
    {
        public static void Main()
        {
            // pass
            IObserver[] observers = new IObserver[]
            {
                new Log(),
                new Test(),
                new Test2(),
            };
            Order order = new Order();

            foreach(IObserver observer in observers)
            {
                order.RegisterObserver(observer);
            }
            order.ChangeStatus("Confirmed");
        }
    }
}