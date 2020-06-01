using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Adv_Four
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Nullable Types
            int? number = null;
            Console.WriteLine("Nullable Type number: "+number);
            //int numberTwo = (int)number;//cast to int
            #endregion

            #region Conditional Operator
            bool isAdmin = true;
            Console.WriteLine(isAdmin ? "Yes Admin":"No Admin");
            #endregion

            #region Safe Operator
            int[] arr = new int[]{1,2,3,4};
            int? count = 0;
            count = arr?.Length;//check if not null
            Console.WriteLine("Safe Operator: "+count );
            #endregion

            #region Time Span
            TimeSpan ts = new TimeSpan(10, 8, 55);
            Console.WriteLine("Time Span (10, 8, 55): " + ts);
            ts = new TimeSpan(34, 20, 65);
            Console.WriteLine("Time Span (34, 20, 65): " + ts);
            Console.WriteLine("Time Span (34, 20, 65) days: " + ts.Days);
            ts = ts.Add(new TimeSpan(10, 8, 55));
            Console.WriteLine("time span add and total hours: "+ts.TotalHours);
            #endregion

            #region Multithreading
            //creating threads
            Thread t1 = new Thread(new ThreadStart(SayHiEnglish));
            t1.Name = "Thread Number 1 (English)";
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(SayHiSpanish));
            t2.Name = "Thread Number 2 (Spanish)";
            t2.Start();

            //Parameterized Thread
            Helper helper = new Helper();
            Thread t3 = new Thread(new ParameterizedThreadStart(helper.Loop));
            t3.Start(500);

            #endregion
 #region Lock thread and Monitor
            //Lock makes sure the thread is completed before other threads access it
            Files file = new Files();
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(file.Write));
                threads[i].Start($"c:\\accounts{i}.txt");
            }

            #endregion

            #region Async : Task

            Task task = new Task(new Action(sayHowzit));
            task.Start();

            Task task2 = new Task(delegate ()//anon method
            {
                Console.WriteLine("Task 2 has started");
                Console.WriteLine("Task 2 is running");
                Console.WriteLine("Howzit 2");
                Thread.Sleep(2500);
                Console.WriteLine("Task 2 has finished");
            });
            task2.Start();

            //task 3 using lambda
            Task task3 = new Task(()=>
            {
                Console.WriteLine("Task 3 has started");
                Console.WriteLine("Task 3 is running");
                Console.WriteLine("Howzit 3");
                Thread.Sleep(3500);
                Console.WriteLine("Task 3 has finished");

            });

            Console.WriteLine("ENTER YOUR NAME");
            var namne = Console.ReadLine();
            Console.WriteLine("Hi "+namne);
            Console.ReadLine();

            #endregion

            #region Concurrent Bag : Safe Multithreading
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Thread th1 = new Thread(() =>
            {
                Console.WriteLine("Thread (1) has started");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Thread (1) added number " + i);
                    bag.Add(i);
                }
                Console.WriteLine("Thread (1) is complete!");
            });

            Thread th2 = new Thread(() =>
            {
                Console.WriteLine("Thread (2) has started");
                for (int i = 11; i <= 25; i++)
                {
                    Console.WriteLine("Thread (2) added number " + i);
                    bag.Add(i);
                }
                Console.WriteLine("Thread (2) is complete!");
            });

            Thread th3 = new Thread(() =>
            {
                th1.Join();
                th2.Join();
                Console.WriteLine("Thread (3) has started");
                foreach (var item in bag)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Thread (3) is complete!");
            });

            th1.Start();
            th2.Start();
            th3.Start();
            #endregion
        }

        #region Async : Methods
        public static void sayHowzit()
        {
            Console.WriteLine("Task 1 has started");
            Console.WriteLine("Task 1 is running");
            Console.WriteLine("Howzit 1");
            Thread.Sleep(5500);
Console.WriteLine("Task 1 has finished");
        }
        #endregion

        #region MultiThreading Methods
        public static void SayHiEnglish()
        {
            Console.WriteLine("Starting to execute " + Thread.CurrentThread.Name);
            for (int i = 0; i < 50; i++)
            {
                //t2.join();//t2 performs first then the rest of t1
                Thread.Sleep(new TimeSpan(0,0,0,0,500));//managing thread. pause for half a second
                Console.WriteLine(i + " Hi...");
                //if (i == 32)
                //{
                //    t1.abort();
                //}
            }

           
        }

        public static void SayHiSpanish()
        {
            Console.WriteLine("Starting to execute " + Thread.CurrentThread.Name);
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(250);//managing thread. pause for quater a second
                Console.WriteLine(i + " Hola...");
            }
        }
        #endregion
    }

    #region MultiThreading Class
    class Helper
    {
        public void Loop(object number)
        {
            for (int i = 0; i < int.Parse(number.ToString()); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    #endregion

    #region Lock thread and Monitor class
    class Files
    {
        //public Object thisLock = new Object();//lock
        public void Write(object path)
        {
            //lock (thisLock)
            //{
                Monitor.Enter(path);
            try
            {
                // some logic of writing in files goes in where
                Console.WriteLine("Writing in " + path);
                Thread.Sleep(2000);
                Console.WriteLine("Writing process has been completed");
            }
            finally
            {
                Monitor.Exit(path);
            }
            //{
        }

        public void Read(object path)
        {
            //lock (thisLock)
            //{
                // some logic of reading files goes in where
                Console.WriteLine("Reading from " + path);
            Thread.Sleep(1000);
            Console.WriteLine("Reading process has been completed\n");
            //{ 
        }
    }
    #endregion
}
