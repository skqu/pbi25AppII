namespace livecode.Observer
{
    interface ISubject
    {
        void NotifyObservers();
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }
}