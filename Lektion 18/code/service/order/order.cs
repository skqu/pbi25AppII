using code.observer;

namespace code.service.order
{
    class Order : ISubject
    {

        private List<IObserver> _observers = new List<IObserver>();

        public Order()
        {
            
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            if( _observers == null)
            {
                Console.WriteLine("No observer found");
                return; 
            }

            foreach(IObserver observer in _observers)
            {
                observer.Update();
            }
        }

        public void ChangeState(string state)
        {
            this.NotifyObservers();
        }
    }
}