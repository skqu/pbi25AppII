class Program
{
    public static void Main()
    {
        Singleton notOld = Singleton.GetInst(); 
        notOld.text = "This is not a singleton"; 

        Singleton notNew = Singleton.GetInst();
        Console.WriteLine(notNew.text);
    }
}