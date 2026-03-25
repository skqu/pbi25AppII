class Program
{
    public static void Main()
    {
        Facade facade = new Facade();

        Console.WriteLine(facade.Login("Stefan", "Secret#1"));
    }
}