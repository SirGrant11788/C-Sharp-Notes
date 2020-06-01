using System;

namespace OOP_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, d, minusResult=0;
            a = 5;
            b = 3;
            PerformAddOperation(a, b);
            minusResult = PerformMinusOperation(a, b);
            Console.WriteLine($"{a} - {b} = {minusResult}");
            c = 10;
            d = 15;
            PerformAddOperation(c, d);
            //passing by value and ref
            string firstEmployee, SecondEmployee;
            firstEmployee = "John Smith";
            //SecondEmployee = "Bob Sieger"; use out instead of ref
            Console.WriteLine($"given employees: {firstEmployee}  ");//and {SecondEmployee}
            ChangeNamesByRef(ref firstEmployee,out SecondEmployee, out string thirdEmployee);
            Console.WriteLine($"after ChangeNameByRef Method: {firstEmployee} and {SecondEmployee} and {thirdEmployee}");
            //overload (static)
            string guestName = "";
            Console.WriteLine("Hello, what is your name?");
            guestName = Console.ReadLine();
            if (guestName == "")
            {
                WelcomeGuest();
            }
            else
            {
                WelcomeGuest(guestName);
            }
        }

        static void WelcomeGuest()
        {
            Console.WriteLine("Hope you enjoy your stay with us");
        }
        static void WelcomeGuest(string name)
        {
            Console.WriteLine($"Hope you enjoy your stay with us, {name}");
        }

        static void ChangeNamesByRef(ref string firstEmp,out string secondEmp, out string thirdEmp)
        {
            firstEmp = "Alan Thick";
            secondEmp = "Zebra Horder";
            thirdEmp = "Brian Apple";
            Console.WriteLine($"in ChangeNameByRef Method: {firstEmp} and {secondEmp} and {thirdEmp}");
        }

        static int PerformMinusOperation(int x, int y)
        {
            int minusResult = x - y;
            return minusResult;
        }
        static void PerformAddOperation(int x, int y)
        {
            int addResult = x + y;
            Console.WriteLine($"{x}+{y} = {addResult}");
            DisplayMessage();
        }

        static void DisplayMessage()
        {
            Console.WriteLine("Prcess is done");
            Console.WriteLine("Message from static void method DisplayMessage() at "+DateTime.Now.ToShortTimeString());
        }
    }
}
