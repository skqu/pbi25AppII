using School;
using Inheritance;
using Abstraction;
using Interface;
using Multiplicity;

class Program
{
    public static void Main()
    {
        
        /*
            First example access modifier
        */
        
        Animal duck = new Animal(2);
        System.Console.WriteLine(duck.GetSound());
        System.Console.WriteLine(duck.GetBeak());
        System.Console.WriteLine(duck.GetLeg());
        

        /*
            Second example Aggregation
        */
        /*
        Console.WriteLine("Aggregation Example:");

        Students student1 = new Students("Alice", 20);
        Students student2 = new Students("Bob", 22);

        Course course = new Course();
        course.AddStudent(student1);
        course.AddStudent(student2);
        Console.WriteLine("Students in the course:");
        foreach (string studentName in course.GetStudents())
        {            
            if (!string.IsNullOrEmpty(studentName))
            {                
                Console.WriteLine(studentName);
            }   
        }

        Students[] studentsArray = new Students[] { student1, student2 };
        Course courseWithStudents = new Course(studentsArray);
        Console.WriteLine("Students in the course with students array:");
        foreach (string studentName in courseWithStudents.GetStudents())
        {            
            if (!string.IsNullOrEmpty(studentName))
            {                
                Console.WriteLine(studentName);
            }   
        }
        
        /*
            Third example Composition
        */
        /*
        Console.WriteLine("Composition Example:");
        School.School school = new School.School("Greenwood High");
        string mathCourse = school.NewCourse("Math");
        if (mathCourse != null)
        {           
             Console.WriteLine(mathCourse);
        }   
        school = null;
        try
        {
            if (school.GetCourses != null)
            {
                Console.WriteLine("Course is still alive: ");
            }
        }catch (ArgumentException)
        {
            school = new School.School("Greenwood High");
            Console.WriteLine("School is destroyed, so rereating school");
        }

        // If no print - coures still destroyed, if print - course is still alive
        if (school.GetCourses() != null)
        {   
            foreach (string courseName in school.GetCourses())
            {
                if (!string.IsNullOrEmpty(courseName))
                {
                    Console.WriteLine(courseName);
                }
            }
        }
        
        /*
            Fourth example Inheritance
        */
        /*
        Console.WriteLine("Inheritance Example:");
        Horse horse = new Horse();
        horse.SetName("Spirit");
        Console.WriteLine("Horse's name: " + horse.GetName());
        

        /*
            Fifth example Abstraction and Interface
        */
        /*
        Console.WriteLine("Abstraction and Interface Example:");
        Circle circle = new Circle(5);          
        Console.WriteLine("Circle area: " + circle.GetArea());
        Fish fish = new Fish();
        fish.SetDepth(10.5);
        Console.WriteLine("Fish depth: " + fish.GetDepth());
        fish.Swim();
        
        /*
            Sixth example Multiplicity
        */
        /*
        Engine engine1 = new Engine("V8");
        Engine eEngine = new Engine("120wh");
        Engine eEngine2 = new Engine("130wh");
        Engine[] engines = new Engine[] { eEngine, eEngine2 };
        Car car = new Car(engine1);
        Console.WriteLine("Car: " + car.GetEngine());
        ECar notTesla = new ECar(engines);
        foreach (Engine engine in notTesla.GetEngines())
        {
            Console.WriteLine("ECar engine: " + engine.Model);
        }
        */
    }
}
