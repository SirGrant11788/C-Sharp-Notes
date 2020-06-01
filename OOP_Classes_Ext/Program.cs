using System;

namespace OOP_Classes_Ext
{
    //static classes
    //can only have static members
    //can't create an instance (object) of it
    //They are sealed
    class Program
    {
        static void Main(string[] args)
        {
            //static class
            Drink.GetAge();//note no need to create instance
            //nested classes
            Beer beer = new Beer();//only beer.beerName;
            Beer.Stout stout = new Beer.Stout();//stout.stoutname; //access nested class
            //namespace
            MyOwnNamespace.Whiskey whiskey = new MyOwnNamespace.Whiskey();
            whiskey.Hello();
            //nested name space
            MyOwnNamespace.NestedNamespace.Cider.Hey();//no instance cause it is static
            //struct
            Employee newEmp = new Employee();
            newEmp.Salary = 12;
            newEmp.empName = "John";
            Console.WriteLine($"Employee name is {newEmp.empName} and earns {newEmp.Salary}");
            newEmp.HelloAgain();
            //enum
            string weekDayName = WeekDay.Monday.ToString();
            WeekDay day = WeekDay.Friday;
            Console.WriteLine(weekDayName +" "+day+" "+ (int)day+" ");
            //this keyword. ref of current instance of the class
            Person person = new Person();
            person.DisplayName("John","Smith");
            //interfaces - contains def for a group/related functionalities that a class can implement
            //interface = what, class = how
            Dogs dog = new Dogs();
            dog.Attack();
            dog.SayHi();
            dog.Run();
            //exception handling. try catch and finally. try code. catch error. finally code runs regardless
            int x = 0, y = 3;
            double div = 0;
            try
            {
                div = y / x;
            }catch(Exception e)
            {
                Console.WriteLine("The Error is: "+e.Message);
            }
            finally
            {
                Console.WriteLine($"{y}/{x}={div}");
            }
        }
    }
    #region Interfaces

    public interface IAnimals
    {
        void Run();
    }
    interface IDogCommands:IAnimals//auto public
    {
        void Stay();//just declaractions
        void Sit();
        void Attack();

        string DogName
        {
            set;
            get;
        }
    }

    class Animals
    {
        string AnimalName;

        public void SayHi()
        {
            Console.WriteLine("Hi from the animal class");
        }
    }

    class Dogs:Animals, IDogCommands
    {
        private string DogBreed;

        public void Stay()
        {
            Console.WriteLine("Dog Stay");
        }
        public void Sit()
        {
            Console.WriteLine("Dog Sit");
        }
        public void Attack()
        {
            Console.WriteLine("Dog Attack");
        }
        public void Run()
        {
            Console.WriteLine("Animal Run");
        }
        public string DogName { get; set; }
    }
    #endregion
    #region this: using this keyword
    class Person
    {
        string firstName;
        string lastName;

        public void DisplayName()
        {
            Console.WriteLine($"{firstName} {lastName}");
        }
        public void DisplayName(string firstName, string lastName)
        {
            Console.WriteLine($"{firstName} {lastName}");
            Console.WriteLine($"{this.firstName} {this.lastName}");//access instance
        }

        public Person()
        {
            firstName = "Empty";
            lastName = "Empty";
        }
    }
    #endregion

    #region enum
    enum WeekDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday=42,
        Saturday,
        Sunday
    }
    #endregion

    #region Structures
    struct Employee
    {
        public string empName;
        private decimal empSalary;

        public decimal Salary
        {
            get { return empSalary; }
            set { empSalary = value; }
        }

        public void HelloAgain()
        {
            Console.WriteLine("Hello from the struct method");
        }
    }
    #endregion

    #region Static Class
    static class Drink
    {
        static public string name;

        static public void GetAge()
        {
            Console.WriteLine(DateTime.Now.Year - DateTime.Now.AddYears(-2).Year);
        }
    }
    #endregion
    #region Nested Classes
    class Beer
    {
        public string beerName;
        public string beerCountry;

        public class Stout
        {
            public string stoutName;
            public string stoutNote;
        }

        public class IPA
        {
            public string ipaName;
            public string ipaNote;
        }
    }
    #endregion
}

#region Namespace : example of how to use multiple namespaces

namespace MyOwnNamespace
{
    class Whiskey
    {
        public string whiskeyStrength;

        public void Hello()
        {
            Console.WriteLine("Hello from custom namespace");
        }
    }

    namespace NestedNamespace
    {
        class Cider
        {
            public static void Hey()
            {
                Console.WriteLine("Hey from the nested name space");
            }
        }
    }
}

#endregion
