using System;

namespace Adv_Delegate
{
    // void delegate with no argument
    public delegate void PlayerInfoDel();

    // void delegate with one string argument
    public delegate void PlayerInfoWithNameDel(string playerName);

    // void delegate with one string argument and one int
    public delegate void PlayerInfoNameWithGoalsDel(string name, int goals);

    // string delegate with one int argument 
    public delegate string PlayerBasedOnNumber(int number);

    // void delegate with one string argument and one int
    public delegate void PlayerInformationWithGoals(string playerName, int playerGoals);

    // string delegate with one int argument and one string
    public delegate string PlayerInformationBasedOnNumberAndClub(int playerNo, string club, string country = "Unknown");

    public delegate void SayHiDelegate();

    //genreic delegate
    public delegate T DisplayInfo<T>(T value);

    delegate void DisplayMessage();
    delegate int Multiply(int n);

    delegate void DisplayMessageLambda();
    delegate int MultiplyLambda(int n);

    class Program
    {
        static void Main(string[] args)
        {
            PlayerInfoDel ronaldinho = new PlayerInfoDel(DisplayInformation);
            ronaldinho();

            PlayerInfoWithNameDel playerName = new PlayerInfoWithNameDel(DisplayInformation);
            playerName("Messi");

            PlayerInfoNameWithGoalsDel newPlayer = new PlayerInfoNameWithGoalsDel(DisplayInformation);
            newPlayer("Ronaldo", 60);
            newPlayer("Rooney", 25);

            PlayerBasedOnNumber number = new PlayerBasedOnNumber(DisplayInformation);
            Console.WriteLine(number(8));
            Console.WriteLine(number(10));

            PlayerInformationWithGoals playerOne = new PlayerInformationWithGoals(DisplayInformation2);
            PlayerInformationBasedOnNumberAndClub playerTwo = new PlayerInformationBasedOnNumberAndClub(DisplayInformation2);

            //playerOne("Ronaldo", 50);
            //playerTwo(7, "Real Madrid","Portugal");

            Console.WriteLine(playerTwo.Method);

            foreach (var item in playerTwo.Method.GetParameters())
            {
                Console.WriteLine($"{item.ParameterType.Name}, {item.Name}, {item.Position}, {item.IsOptional}, {item.DefaultValue} ");
            }

            SayHiDelegate sayHi = null;

            sayHi = new SayHiDelegate(SayHiEnglish);
            sayHi += new SayHiDelegate(SayHiSpanish);
            sayHi += new SayHiDelegate(SayHiJapanese);
            sayHi += new SayHiDelegate(SayHiItalian);
            sayHi += new SayHiDelegate(SayHiGerman);
            sayHi += new SayHiDelegate(SayHiArabic);

            sayHi();

            //genreic delegate
            Console.WriteLine("------Generic Delegate------");
            DisplayInfo<int> myNumber = new DisplayInfo<int>(DisplayValue);
            Console.WriteLine(myNumber(42));

            DisplayInfo<double> myDoubleNumber = new DisplayInfo<double>(DisplayValue);
            Console.WriteLine(myDoubleNumber(34.32));

            DisplayInfo<DateTime> myDate = new DisplayInfo<DateTime>(DisplayValue);
            Console.WriteLine(myDate(new DateTime(2010, 2, 23)));

            //Anonymous Method
            Multiply MultiplyNumber = delegate (int n) { { return n * 3; } };
            Console.WriteLine(MultiplyNumber(10));

            DisplayMessage Message = delegate { Console.WriteLine("Hi from the anonymous method "); };
            Message();

            //Lambda\
            Console.WriteLine("-------Lambda-------");
            MultiplyLambda MultiplyNumberLambda = n => n * 3;
            Console.WriteLine(MultiplyNumber(10));

            DisplayMessageLambda MessageLambda = () => Console.WriteLine("Hi from anonymous lambda");
            Message();

            //Func Delegate
            Console.WriteLine("------Func Delegate-----");
            Func<int, int, int> funcOne = AddTwoNumbers;
            Console.WriteLine(AddTwoNumbers(3, 5));

            Func<int> funcTwo = AddTwoNumbers;
            Console.WriteLine(funcTwo());

            //Action Delegate
            Console.WriteLine("------Action Delegate--------");
            Action<int> actionOne = DisplayInformationActionDelegate;
            actionOne(16);

            Action actionTwo = DisplayInformationActionDelegate;
            actionTwo();

            //Predict Delegate
            Console.WriteLine("-------Predict Delegate------");
            Predicate<int> condition = IsAdmin;
            Console.WriteLine(condition(11));
            Console.WriteLine(condition(10));
        }

        public static void DisplayInformation()
        {
            Console.WriteLine("Information about player : Ronaldinho from brazil");
        }

        public static void DisplayInformation(string playerName)
        {
            Console.WriteLine("Information about player : " + playerName);
        }

        public static void DisplayInformation(string playerName, int goals)
        {
            Console.WriteLine("Information about player : " + playerName + " and he score " + goals + " goals");
        }

        public static string DisplayInformation(int number)
        {
            string playerName = string.Empty;
            switch (number)
            {
                case 7: playerName = "Ronaldo"; break;
                case 8: playerName = "Iniesta"; break;
                case 10: playerName = "Messi"; break;
                default: break;
            }
            return playerName;
        }

        public static void DisplayInformation2(string playerName, int goals)
        {
            Console.WriteLine("Information about player : " + playerName + " and he score " + goals);
        }

        public static string DisplayInformation2(int number, string club, string country = "Unknown")
        {
            // Some logic goes in here
            Console.WriteLine("Hi...");
            return string.Empty;
        }

        // Say hi in English
        public static void SayHiEnglish()
        {
            Console.WriteLine("Hi there.");
        }

        // Say hi in Spanish
        public static void SayHiSpanish()
        {
            Console.WriteLine("Hola.");
        }

        // Say hi in Italian
        public static void SayHiItalian()
        {
            Console.WriteLine("Ciao.");
        }

        // Say hi in German
        public static void SayHiGerman()
        {
            Console.WriteLine("Hallo.");
        }

        // Say hi in Arabic (مرحباً)
        public static void SayHiArabic()
        {
            Console.WriteLine("Marhabaan.");
        }

        // Say hi in Japanese (こんにちは)
        public static void SayHiJapanese()
        {
            Console.WriteLine("Kon'nichiwa");
        }

        //genreic delegate
        public static T DisplayValue<T>(T value)
        {
            Console.WriteLine("Now we are accessing var of type" + value.GetType().Name);

            return value;
        }

        public static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }
        public static int AddTwoNumbers()
        {
            int z = 0;
            int x = 5;
            int y = 2;
            z = x + y;
            return z;
        }

        public static void DisplayInformationActionDelegate(int number)
        {
            Console.WriteLine("Hello from the Display Information Action Delegate Method. Number: "+number);
        }
        public static void DisplayInformationActionDelegate()
        {
            Console.WriteLine("Hello from the Display Information Action Delegate Method");
        }

        public static bool IsAdmin(int empNo)
        {
            if (empNo == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
