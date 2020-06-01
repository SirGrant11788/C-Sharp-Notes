using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Console;

namespace Adv_Five
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Process : Start and Stop
            Process.Start("Notepad.exe");
            //Process.Start(@"C:\");
            //Note You can find a process name from task manager
            //Process.Start("chrome.exe");
            //Process.Start("https://www.redit.com");

            Process[] notepads = Process.GetProcessesByName("notepad");//closes all notepads
            foreach (var process in notepads)
            {
                process.Kill();
            }
            #endregion

            #region Multidimensional Array
            string[,] Array2D = new string[3, 2];

            Array2D[0, 0] = "Item 00";
            Array2D[0, 1] = "Item 01";

            Array2D[1, 0] = "Item 10";
            Array2D[1, 1] = "Item 11";

            Array2D[2, 0] = "Item 20";
            Array2D[2, 1] = "Item 21";
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Array Row " + i);
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("Array Col " + j);
                    Console.WriteLine("ARRAY: " + Array2D[i, j]);
                }
            }
            #endregion

            #region Jagged Array
            //array of an array

            int[][] jaggedArrayOne = new int[3][];
            jaggedArrayOne[0] = new int[5] { 0, 1, 2, 3, 4 };
            jaggedArrayOne[1] = new int[2] { 6, 7 };
            jaggedArrayOne[2] = new int[3] { 9, 8, 5 };

            int[][] jaggedArrayTwo =
            {
                new int[]{0,1,2,3},
                new int[]{10,11,12,13},
                new int[]{20,21,22,23},
                new int[]{30,31,32,33},
            };

            Console.WriteLine("jaggedArrayTwo[1][4] : " + jaggedArrayTwo[1][3]);
            for (int i = 0; i < jaggedArrayTwo.Length; i++)
            {
                Console.WriteLine("accesing " + i);
                for (int j = 0; j < jaggedArrayTwo[i].Length; j++)
                {
                    Console.WriteLine("accesing " + j);
                    Console.WriteLine($"jaggedArrayTwo[{i}][{j}] : {jaggedArrayTwo[i][j]}");
                }
            }
            Console.WriteLine();
            #endregion

            #region Static Directives
            Console.WriteLine(Math.Round(2.5465, 2));
            WriteLine(Math.Round(2.5465, 2)); //using static System.Console;
            #endregion

            #region IsNullEmpty
            string naam = " ";
            //if(naam.Trim()=="" || naam is null)
            //{
            //    Console.WriteLine("EMPTY");
            //}
            //else
            //{
            //    Console.WriteLine("NOT EMPTY");
            //}
            if (string.IsNullOrEmpty(naam) || string.IsNullOrWhiteSpace(naam))
            {
                Console.WriteLine("EMPTY");
            }
            else
            {
                Console.WriteLine("NOT EMPTY");
            }
            #endregion

            #region Destructors
            Animals dog = new Animals();
            var name = Console.ReadLine();
            #endregion

            #region Assembly
            Assembly assemObject = Assembly.GetEntryAssembly();
            AssemblyName assemName = assemObject.GetName();

            Console.WriteLine(assemName.FullName);

            Console.WriteLine(assemName.CultureName);
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            assemName.CultureInfo = cultureInfo;
            Console.WriteLine(assemName.CultureInfo.DisplayName);
            Console.WriteLine(assemName.CultureInfo.NativeName);
            Console.WriteLine(assemName.CultureInfo.NumberFormat.CurrencySymbol);
            Console.WriteLine(assemName.CultureInfo.Calendar);

            Console.WriteLine(assemName.Version);
            assemName.Version = new Version(2, 0, 0, 0);
            Console.WriteLine(assemName.Version);
            #endregion

            #region Attributes : Default
            Persons.SayHi();
            Persons.SayHello();
            Persons.DisplayMessage("We are in the debugging mode");
            #endregion

            #region Attributes : Custom

            //reflection
            MemberInfo info = typeof(People);
            object[] attributes = info.GetCustomAttributes(true);
            for (int i = 0; i < attributes.Length; i++)
            {
                Console.WriteLine(attributes[i]);
            }
            #endregion

            #region GUID
            Guid guid = Guid.NewGuid();
            Console.WriteLine(guid);
            guid = Guid.NewGuid();
            Console.WriteLine(guid);
            #endregion

            #region StringBuilder
            StringBuilder builder = new StringBuilder(10, 50);
            builder.Append("John welcome back");
            Console.WriteLine(builder);
            builder.Insert(0, "Hello ");
            Console.WriteLine(builder);
            builder.Remove(18, 5);
            Console.WriteLine(builder);
            builder.Replace('o', '0');
            Console.WriteLine(builder);
            builder.Replace('e', '1', 0, 15);
            string text = builder.ToString();
            Console.WriteLine(text);
            #endregion

            #region Pattern Matching : Main
            Dog max = new Dog();
            max.DogName = "Max";
            Lion simba = new Lion();
            Snake solidSnake = new Snake();
            Lizard liz = new Lizard();
            AnimalSoundWithSwitchAndWhen(max);
            //AnimalSoundWithSwitch(simba);
            //AnimalSoundWithSwitch(solidSnake);
            //AnimalSoundWithSwitch(liz);
            #endregion

            #region Pass by ref
            //passing by value (using a copy)
            //passing by reference (using the variable itself)
            int X1 = 3;
            ref int X2 = ref X1;//same int regardless of which one is changed (ref local)
            Console.WriteLine("X1: " + X1 + " X2: " + X2);
            X1 = 12;
            Console.WriteLine("X1: " + X1 + " X2: " + X2);

            ref var returnValue = ref ReturnByRef();
            Console.WriteLine(returnValue);
            #endregion

            #region IEnumerable and IEnumerator
            //IEnumerable is an interface that defines one method GetEnumerator which returns an
            //IEnumerator interface
            //IEnumerable is sone type (List or array) that you can loop through
            //IEnumerable is read-only
            //read, sort or filter your collection you can use IEnumerable

            IEnumerable<int> result = from value in Enumerable.Range(1, 10)
                                      select value;

            foreach (var value in result)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();

            double avg = result.Average();
            Console.WriteLine(avg);

            List<int> list = result.ToList();
            int[] array = result.ToArray();

            //list.Add(11);list.Add(12);list.Add(13);list.Add(14);list.Add(15);list.Add(100);

            Console.WriteLine("What is in the list now");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            result = list.AsEnumerable();
            Console.WriteLine("What is in the ienumrable now");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------");

            IEnumerator<int> enumrator = list.GetEnumerator();
            while (enumrator.MoveNext())
            {
                Console.WriteLine(enumrator.Current);
            }
            #endregion

            #region Yield
            foreach (var item in PerformMath(3,2))
            {
                Console.WriteLine(item);
            }
            #endregion
        }

        #region Yield : Method
        public static IEnumerable<double> PerformMath(int numOne, int numTwo)
        {
            yield return numOne + numTwo;
            yield return numOne - numTwo;
            yield return numOne * numTwo;
            yield return Math.Round((double)numOne / (double)numTwo,2);
            yield return numOne + numTwo;
        }
        #endregion

        #region Pass by ref : method
        public static ref string ReturnByRef()
        {
            string[] arrayOfNames = { "Jane", "James", "Kim" };
            return ref arrayOfNames[0];
        }

        #endregion

        #region Pattern Matching : Methods
        // using IS
        public static void AnimalSound(object animal)
        {
            if (animal is Dog)
                Console.WriteLine("Woof");
            else if (animal is Cat)
                Console.WriteLine("Meow");
            else if (animal is Lion)
                Console.WriteLine("Roarrrrr");
            else if (animal is Duck)
                Console.WriteLine("Quack");
            else if (animal is Snake)
                Console.WriteLine("Snakes are actually mute :D");
            else
                Console.WriteLine("Unknown animal");

        }
        // using SWITCH
        public static void AnimalSoundWithSwitch(object animal)
        {
            switch (animal)
            {
                case Dog d: Console.WriteLine("Woof"); break;
                case Cat c: Console.WriteLine("Meow"); break;
                case Lion l: Console.WriteLine("Roar"); break;
                case Duck u: Console.WriteLine("Quack"); break;
                case Snake s: Console.WriteLine("Snake is mute"); break;
                default: Console.WriteLine("Unknown animal"); break;
            }
        }
        // using SWITCH and WHEN
        public static void AnimalSoundWithSwitchAndWhen(object animal)
        {
            switch (animal)
            {
                case Dog d when d.DogName == null: Console.WriteLine("Name is not set"); break;
            }
        }
        #endregion
    }



    #region Attributes : Custom Class
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Developer : System.Attribute
    {
        private string developerName;
        private bool isReviewed;
        private string message;

        public Developer(string developerName, bool isReviewed, string message)
        {
            this.developerName = developerName;
            this.isReviewed = isReviewed;
            this.message = message;
        }

        public string DeveloperName
        { get => developerName; set => developerName = value; }

        public bool IsReviewed
        { get => isReviewed; set => isReviewed = value; }

        public string Message
        { get => message; set => message = value; }
    }
    //
    [Developer("Ahmad Mohey", false, "This need to be finished by next friday")]
    class People
    {

    }
    #endregion

    #region Attributes : Default Class
    class Persons
    {
        [Obsolete("This method is not going to be included in the upcoming versions", false)]
        public static void SayHi()
        {

        }

        public static void SayHello()
        {

        }

        [Conditional("DEBUG")]
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    #endregion

    #region Destructors : Class
    class Animals
    {
        public Animals()
        {
            Console.WriteLine("A new animal is created");
        }

        ~Animals()
        {
            Console.WriteLine("Animal Object is about to be destroyed");
        }
    }
    #endregion

    #region Pattern Matching : Classes
    class Dog
    {
        // Woof Woof
        public string DogSound { get; set; }
        public string DogName { get; set; }
    }

    class Cat
    {
        // Meow Meow
        public string CatSound { get; set; }
        public string CatName { get; set; }
    }

    class Lion
    {
        //Roar
        public string LionSound { get; set; }
        public string LionName { get; set; }
    }

    class Duck
    {
        // Quack
        public string DuckSound { get; set; }
        public string DuckName { get; set; }
    }
    class Snake
    {
        // Silent
        public string SnakeSound { get; set; }
        public string SnakeName { get; set; }
    }
    class Lizard
    {

    }
    #endregion

}
