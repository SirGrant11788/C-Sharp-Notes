using System;

namespace Fund
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 5.227;
            int i = 9, j = 4;
            Console.WriteLine("Given: {0} {1} {2}", x, i, j);
            //ceiling
            Console.WriteLine("Ceiling: " + Math.Ceiling(x));
            // floor
            Console.WriteLine("Floor: " + Math.Floor(x));
            //round
            Console.WriteLine("Round: " + Math.Round(x, 2));
            //truncate
            Console.WriteLine("Truncate: " + Math.Truncate(x));
            //Max
            Console.WriteLine("Max: " + Math.Max(i, j));
            //Min
            Console.WriteLine("Min: " + Math.Min(i, j));
            //sqrt
            Console.WriteLine("sqrt: " + Math.Sqrt(i));
            //pow
            Console.WriteLine("pow: " + Math.Pow(3, 2));
            //pi
            Console.WriteLine("pi: " + Math.PI);
            //Random Numbers
            Random rand = new Random();//one def
            int n = 0, m = 0;
            n = rand.Next(1, 7);
            m = rand.Next(1, 7);
            Console.WriteLine("Random Number 1,7: " + n + " and " + m);
            double y = 0;
            // between 0 and 1 double
            y = rand.NextDouble() * 3;
            Console.WriteLine("Random double between 0 and 3: " + Math.Round(y, 2));
            //arrays
            int[] numbers = new int[5];//array size of 6. empty
            numbers[0] = 1;//index 0 equals 5
            numbers[1] = 100;
            numbers[2] = 1000;
            string[] arrWeek = new string[7]{"Mon", "Tue","Wed","Thur","Fri","Sat","Sun"};//not empty
            Console.WriteLine("Array index 0 :" + numbers[0]);
            // 
            Console.WriteLine("numbers Array index 0 :" + numbers[0]);
            foreach(int l in numbers)
            {
                Console.WriteLine("numbers Array :" + l);
            }
            for (int l=0;l<arrWeek.Length;l++)
            {
                Console.WriteLine("arrWeek Array index " + l + " :" + arrWeek[l]);
            }
            //String Interpolation
            string name = "";
            Console.WriteLine("What is your name");
            name = Console.ReadLine();
            Console.WriteLine("Hello: " + name);
            Console.WriteLine("Hello {0}", name);
            Console.WriteLine($"Hello {name}");//Interoplation direct injections
            //try parse
            int k = 0;
            Console.WriteLine("try parse. enter number");
            k = int.Parse(Console.ReadLine());// will expect an int. cannot parse
            Console.WriteLine("You have entered: " + k);
            Console.WriteLine("try parse. enter number");
            int.TryParse(Console.ReadLine(), out int h);//will try parse int. if not then display 0
            Console.WriteLine("You have entered: " + h);
            if (h == 0) { Console.WriteLine("Did not enter an int"); }
        }
    }
}
