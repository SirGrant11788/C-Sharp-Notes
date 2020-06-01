using System;
using System.Diagnostics;

namespace Adv_Three
{
    //Events
    public delegate void myDelegate(string name);
    //
    class Program
    {

        //Events
        public event myDelegate myEvent;

        public Program()
        {
            myEvent += new myDelegate(SayHiEnglish);
            myEvent += new myDelegate(SayHiArabic);
            myEvent += new myDelegate(SayHiItalian);
        }
        //
        static void Main(string[] args)
        {
            //Recusive
            Console.WriteLine("-------Recusive------------");
            int number = 4;
            Console.WriteLine("RECURSION: "+Factorial(number));
            //Optional Arguments
            Console.WriteLine("---------Optional Arguments----------");
            DisplayPlayerInfo(7, "Ronaldo", 60,"Portugal");
            Console.WriteLine("------");
            DisplayPlayerInfo(7, "Ronaldo", 60);
            Console.WriteLine("------");
            DisplayPlayerInfo(7, "Messi", 60,2);
            //Named Arguments
            Console.WriteLine("------");
            DisplayPlayerInfo(country: "Spain", name: "Jim", no: 2, goals: 42);
            //Generic Arguments
            Console.WriteLine("---Generic Arguments---");
            DisplayInfo("John");
            DisplayInfo(2);
            var playerTuple = (7, "Ranoldo", 55);
            DisplayInfo(playerTuple);
            //nested fucntions
            Console.WriteLine("---nested fucntions---");
            PerformMathOperation(1, 2, 3,4);
            //Extension Method
            Console.WriteLine("----Extension Method----");
            int x = 50;
            Console.WriteLine(x.IsGreater(10));
            Console.WriteLine(x.IsGreater(70));
            string text = "Jimmy";
            Console.WriteLine(text.IsNUmber());
            text = "24";
            Console.WriteLine(text.IsNUmber());
            //Stopwatch
            Console.WriteLine("----------");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Loop(900_000_000);
            watch.Stop();
            Console.WriteLine("mili seconds: "+watch.Elapsed.Milliseconds);
            Console.WriteLine("Seconds: " + watch.Elapsed.Seconds);
            Console.WriteLine("totoal mili seconds: "+watch.Elapsed.TotalMilliseconds);
            //Events
            Console.WriteLine("----Events-----");
            Program prog = new Program();
            prog.myEvent("Jack");
            Football info = new Football();
            info.DisplayClub("Manchester United", "England");
            info.DisplayPlayerInformation("Ronaldo", "Real Madrid");

        }

        #region Recursion
        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
        #endregion
        #region Optional Arguments
        public static void DisplayPlayerInfo(int no, string name, int goals, string country="Default")
        {
            Console.WriteLine(no);
            Console.WriteLine(name);
            Console.WriteLine(goals);
            Console.WriteLine(country);
        }
        public static void DisplayPlayerInfo(int no, string name, int goals,int cards)
        {
            Console.WriteLine(no);
            Console.WriteLine(name);
            Console.WriteLine(goals);
            Console.WriteLine(cards);
        }
        #endregion
        #region Generic Arguments
        public static void DisplayInfo<T>(T info)
        {
            Console.WriteLine(info);
        }
        #endregion
        #region nested fucntions
        public static void PerformMathOperation(params int[] numbers)
        {
            Console.WriteLine("Add = "+AddNumbers()+" Multiply = "+MultiplyNumbers());
            int AddNumbers()
            {
                int result = 0;
                foreach (var number in numbers)
                {
                    result = result + number;
                }
                return result;
            }
            int MultiplyNumbers()
            {
                int result = 1;
                foreach (var number in numbers)
                {
                    result = result * number;
                }
                return result;
            }
        }
        #endregion
        #region Stopwatch
        public static void Loop(long number)
        {
            for (int i = 0; i < number; i++)
            {

            }
            Console.WriteLine("DONE LOOP");
        }
        #endregion
        #region Events
        public void SayHiEnglish(string name)
        {
            Console.WriteLine("Hi " + name);
        }

        public void SayHiArabic(string name)
        {
            Console.WriteLine("Marhaaban " + name);
        }

        public void SayHiItalian(string name)
        {
            Console.WriteLine("Caio " + name);
        }
        #endregion
    }

    #region Extension Method
    static class MyCustomeExtension
    {
        public static bool IsGreater(this int value, int number)
        {
            return value > number;
        }

        public static bool IsNUmber(this string text)
        {
            return int.TryParse(text, out int result);
        }
    }
    #endregion

    #region Events
    class Football
    {
        private DisplayInformation displayInfoInstance;

        public Football()
        {
            displayInfoInstance = new DisplayInformation();
            displayInfoInstance.DisplayDateAfterEvent += DisplayInfoInstance_DisplayDateAfterEvent;
            displayInfoInstance.DisplayMessageBeforeEvent += DisplayInfoInstance_DisplayMessageBeforeEvent;

        }

        private void DisplayInfoInstance_DisplayMessageBeforeEvent()
        {
            Console.WriteLine("Program is about to display information...");
        }

        private void DisplayInfoInstance_DisplayDateAfterEvent()
        {
            Console.WriteLine("Information has been displayed on " + DateTime.Now.ToShortTimeString());
        }

        public void DisplayClub(string club, string country)
        {
            displayInfoInstance.DisplayClub(club, country);
        }

        public void DisplayPlayerInformation(string name, string club)
        {
            displayInfoInstance.DisplayPlayer(name, club);
        }
    }

    class DisplayInformation
    {

        public delegate void DisplayDateAfterDelegate();
        public delegate void DisplayMessageBeforeDelegate();

        public event DisplayDateAfterDelegate DisplayDateAfterEvent;
        public event DisplayMessageBeforeDelegate DisplayMessageBeforeEvent;

        public void DisplayClub(string clubName, string country)
        {
            DisplayMessageBeforeEvent();
            Console.WriteLine($"{clubName} from {country}");
            DisplayDateAfterEvent(); Console.WriteLine();
        }

        public void DisplayPlayer(string playerName, string clubName)
        {
            DisplayMessageBeforeEvent();
            Console.WriteLine($"{playerName} plays for {clubName}");
            DisplayDateAfterEvent();
        }
    }
    #endregion
}
