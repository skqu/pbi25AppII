using livecode.Observer;
namespace livecode.Service.Customer
{
    class Order : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _status = string.Empty;

        public Order()
        {
            _status = "init";
        }

        public void ChangeStatus(string status)
        {
            _status = status; 
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach(IObserver obs in _observers)
            {
                obs.Update();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}