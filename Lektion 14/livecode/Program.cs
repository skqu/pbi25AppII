class Program
{
    public static void Main(string[] args)
    {
        Factory factory = new Factory();

        foreach (string animalType in args)
        {
            IAnimal? animal = factory.Create(animalType);
            if (animal != null)
            {
                Console.WriteLine(animal.Sound());
            }
        }
    }
}