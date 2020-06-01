using System;

namespace OOP_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person perOne = new Person();//Creates an instance from the Person class
            
            perOne.FirstName = "Charlie";
            perOne.LastName = "Scheen";
            perOne.Country = "NZ";

            Person perTwo = new Person();//Person() is the constructor
            perTwo.FirstName = "Dave";
            perTwo.LastName = "Mitchel";
            perTwo.Country = "USA";

            Person perThree = new Person();


            Console.WriteLine(perOne.FirstName);
            Console.WriteLine(perTwo.FirstName);
            Console.WriteLine(perThree.FirstName);

            SayHi();
            Person person = new Person();
            person.SayHi();

            //inheritance
            Dogs dog = new Dogs();
            Console.WriteLine($"testing inheritance {dog.animalName} {dog.dogBreed}");

            //Polymorphism
            Shapes[] shapes = new Shapes[4];
            shapes[0] = new Shapes();
            shapes[1] = new Circles();
            shapes[2] = new Lines();
            shapes[3] = new Triangle();

            foreach (var shape in shapes)
            {
                shape.Draw();
            }

            //abstract
            Espresso esp = new Espresso();
            esp.Hello();
            esp.Pressure();

        }

        static void SayHi()//static - no need to instantiate in the class
        {
            Console.WriteLine("Saying hi from the the SayHi static method");
        }
        
        
    }

    #region abstract : demo abstractions
    abstract class Coffee
    {
        abstract public void Pressure();
        public void Hello()
        {
            Console.WriteLine("Hello from the abstract coffe class");
        }
    }
    class Espresso : Coffee
    {
        public override void Pressure()
        {
            Console.WriteLine("100% psi from the abstact pressure method");
        }
    }
    #endregion
    #region polymorphism
    //Polymorphism
    class Shapes//base class. use base. to access variables
    {
        public virtual void Draw()//virtual this method can be overwritten
        {
            Console.WriteLine("I am a shape");
        }
    }
    class Circles:Shapes
    {
        public override void Draw()//override
        {
            Console.WriteLine("I am a Circle");
        }
    }
    class Lines:Shapes
    {
        public override void Draw()
        {
            Console.WriteLine("I am a Line");
        }
    }
    class Triangle:Shapes
    {
        public override void Draw()
        {
            Console.WriteLine("I am a Triangle");
        }
    }
    #endregion
    //parent and child classes
    class Animal//superclass
    {
        public string animalName;
        public DateTime animalBirthDate;

        public void FeedAnimal()
        {

        }
    }
    class Dogs : Animal//subclass
    {
        public string dogBreed;
        public bool easyToTrain;
    }


    //get set data between classes
    class Person
    {
        string firstName;
        string lastname;
        DateTime birthDate;
        string country;

        public string FirstName//get set to move data between classes
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public Person()//constructor
        {
            firstName = "John";
        }

        public void SayHi()
        {
            Console.WriteLine("Saying hi from the non static method in Person class");
        }
    }
}
