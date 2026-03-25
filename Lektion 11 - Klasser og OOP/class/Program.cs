namespace Program
{
    class Program
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog(),
                new Cat()
            };
            
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.Sound());
            }
        }
    }

    class Animal
    {
        protected string _sound;

        public Animal(){}

        public string Sound()
        {
            return _sound;
        }

        public void SetSound(string newSound)
        {
            _sound = newSound;
        }
    }

    class Dog : Animal
    {
        public Dog()
        {
            _sound = "woof";
        }
    }

    class Cat : Animal
    {
        public Cat()
        {
            _sound = "quack";
        }
    }

}