using livecode.Observer;

namespace livecode.Service.Test
{
    class Test : IObserver
    {
        public Test()
        {
            
        }

        public void Update()
        {
            Console.WriteLine("Hello From test");
        }
    }
}