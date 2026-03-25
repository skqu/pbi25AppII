
class Program
{
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.GetInst();
        Singleton s2 = Singleton.GetInst();

        if (s1 == s2)
        {
            Console.WriteLine("s1 and s2 are the same instance.");
        }
        else
        {
            Console.WriteLine("s1 and s2 are different instances.");
        }
    }
}



class Singleton
{
    private static Singleton _inst = null;

    private Singleton()
    {

    }

    public static Singleton GetInst()
    {
        if ( _inst == null)
        {
            _inst = new Singleton();
        }
        return _inst;
    }
}