class Singleton
{
    private static Singleton? _inst = null;
    public string text
    {
        get; 
        set;
    } = ""; 

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