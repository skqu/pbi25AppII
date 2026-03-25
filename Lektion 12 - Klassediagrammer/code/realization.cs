namespace Abstraction
{
    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}

namespace Interface
{

    interface ICanSwim
    {
        void Swim();
        double GetDepth();
    }

    class Fish : ICanSwim
    {
        private double _depth = 0.0;

        public void Swim()
        {
            Console.WriteLine("Fish is swimming!");
            Console.WriteLine("Splash splash");
        }

        public void SetDepth(double depth)
        {
            _depth = depth;
        }
        
        public double GetDepth() 
        {
            return _depth;
        }
    }
}