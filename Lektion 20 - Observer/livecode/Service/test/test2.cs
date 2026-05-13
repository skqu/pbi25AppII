using livecode.Observer;

namespace livecode.Service.Test
{
    class Test2 : IObserver
    {
        public Test2()
        {
            
        }

        public void Update()
        {
            Console.WriteLine("Hello From test 2");
        }
    }
}