using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace Adv_Two
{
    class Program
    {
        static void Main(string[] args)
        {

            #region NonGeneric: Array List
            Console.WriteLine("ARRAY LIST");
            //non generic array list
            //Creating
            ArrayList array = new ArrayList();
            //Adding
            array.Add("James");
            array.Add("David");
            array.Add("Charlie");
            //array.Add(3);
            //array.Add(4.5d);
            Console.WriteLine("--------Adding---------");
            Console.WriteLine("\nAt First\n");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nAfter insertion\n");
            array.Insert(2, "Archie");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------Index---------");
            //Index
            Console.WriteLine(array[2].ToString());

            Console.WriteLine("--------Capacity---------");
            //Capacity
            Console.WriteLine(array.Count);
            Console.WriteLine("---------Sorting--------");
            //Sorting
            array.Sort();
            foreach (var item in array)
            {
                Console.WriteLine(item);//elemts need to be the same type
            }
            
            Console.WriteLine("--------Reversing---------");
            //Reversing
            array.Reverse();
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine("-------Removing----------");
            ////Removing
            //array.Remove("David");
            //array.RemoveAt(1);
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("--------Remove All---------");
            ////Remove All
            //array.Clear();
            ////or
            ////array.RemoveRange(1, 3);
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("--------Contains---------");
            //Contains
            Console.WriteLine(array.Contains("Charlie"));
            Console.WriteLine("--------GetRange---------");
            //GetRange
            ArrayList names = new ArrayList();
            names = array.GetRange(0, 2);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------");
            #endregion

            #region NonGenreic: Hashtable
            Console.WriteLine("HASHTABLE");
            //Creating
            Console.WriteLine("----------Creating--------------");
            Hashtable hash = new Hashtable();

            //Adding
            Console.WriteLine("-----------Adding-------------");
            hash.Add("Microsoft","USA");
            hash.Add("Sony","Japan");
            hash.Add("IKEA","Sweden");
            hash.Add("Mercedes","German");

            //Displaying
            Console.WriteLine("------------Displaying------------");
            foreach (DictionaryEntry item in hash)
            {
                Console.WriteLine(item.Key +" : "+item.Value);
            }

            //Capacity
            Console.WriteLine("-----------Capacity-------------");
            Console.WriteLine(hash.Count);

            //Remove
            Console.WriteLine("----------Remove--------------");
            hash.Remove("Sony");
            foreach (DictionaryEntry item in hash)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            //Contains
            Console.WriteLine("-----------Contains-------------");
            if (hash.Contains("IKEA"))
            {
                Console.WriteLine("Hashtable does contain IKEA");
            }
            else
            {
                Console.WriteLine("Hashtable does not contain IKEA");
            }

            //Copy to ArryList
            Console.WriteLine("----------Copy to ArryList-------------");
            ArrayList arrayHash = new ArrayList(hash.Values);
            foreach (var item in arrayHash)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region NonGenric: Sorted List
            Console.WriteLine("SORTEDLIST");
            //keys must be unique
            //Creating
            Console.WriteLine("-----------Creating----------");
            SortedList sortedList = new SortedList();

            //Adding
            Console.WriteLine("----------Adding-----------");
            sortedList.Add(1,"Jan");
            sortedList.Add(20,"Feb");
            sortedList.Add(3,"March");
            sortedList.Add(4,"April");
            sortedList.Add(5,"May");
            sortedList.Add(6, "May");
            //Displaying
            Console.WriteLine("----------Displaying-----------");
            //Foreach
            Console.WriteLine("--------Foreach-------------");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine(item.Key +" : "+item.Value);
            }
            //For
            Console.WriteLine("-------For--------------");
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine(sortedList.GetKey(i)+ " : "+sortedList.GetByIndex(i));
            }
            //Index
            Console.WriteLine("---------Index------------");
            Console.WriteLine(sortedList[4].ToString());
            //Capicity
            Console.WriteLine("--------Capicity-------------");
            Console.WriteLine(sortedList.Count);
            //Remove
            Console.WriteLine("-------Remove--------------");
            sortedList.RemoveAt(1);
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
            //Contains
            Console.WriteLine("---------Contains------------");
            if (sortedList.ContainsValue("April"))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

            #endregion

            #region BitArray
            //bitarray
            //creating
            bool[] boolArr = new bool[4];
            boolArr[0] = false;
            boolArr[1] = false;
            boolArr[2] = false;
            boolArr[3] = true;

            BitArray bitArrOne = new BitArray(4);
            BitArray bitArrTwo = new BitArray(boolArr);
            //setting value
            bitArrOne.Set(0, false);
            bitArrOne.Set(1, false);
            bitArrOne.Set(2, true);
            bitArrOne.Set(3, true);
            foreach (var item in bitArrOne)
            {
                Console.WriteLine(item);
            }
            //AND - OR - NOT
            BitArray bitResult1 = new BitArray(4);
            BitArray bitResult2 = new BitArray(4);
            BitArray bitResult3 = new BitArray(4);
            bitResult1 = bitArrOne.And(bitArrTwo);
            foreach (var item in bitResult1)
            {
                Console.WriteLine("AND: "+item);
            }
            bitResult2 = bitArrOne.Or(bitArrTwo);
            foreach (var item in bitResult2)
            {
                Console.WriteLine("OR: " + item);
            }
            bitResult3 = bitArrOne.Not();
            foreach (var item in bitResult3)
            {
                Console.WriteLine("NOT: " + item);
            }

            #endregion

            #region Genric: List<T>
            //List<T> - similar to ArrayList but specific type, grow auto, store null and dups, uses indexer loop
            //Creating
            Console.WriteLine("--------Creating-------");
            List<string> firstList = new List<string>();
            IList<string> secondList = new List<string>();

            //Adding
            Console.WriteLine("------Adding---------");
            firstList.Add("England");
            firstList.Add("Hungary");
            firstList.Add("China");
            firstList.Add("Germany");

            //Displaying
            Console.WriteLine("------Displaying---------");
            foreach (var item in firstList)
            {
                Console.WriteLine(item);
            }

            //Index
            Console.WriteLine("------Index---------");
            Console.WriteLine(firstList[2]);
            firstList[2] = "Spain";
            Console.WriteLine(firstList[2]);

            //Capacity
            Console.WriteLine("-------Capacity--------");
            Console.WriteLine("Count is: "+firstList.Count);
            //Sorting
            Console.WriteLine("-----Sorting----------");
            firstList.Sort();
            foreach (var item in firstList)
            {
                Console.WriteLine(item);
            }

            //Reversing
            Console.WriteLine("------Reversing---------");
            firstList.Reverse();
            foreach (var item in firstList)
            {
                Console.WriteLine(item);
            }

            //Removing
            Console.WriteLine("------Removing---------");
            firstList.Remove("Germany");
            firstList.RemoveAt(0);
            foreach (var item in firstList)
            {
                Console.WriteLine(item);
            }

            //Remove all
            Console.WriteLine("------Remove all---------");
            //firstList.Clear();

            //Contains
            Console.WriteLine("------Contains---------");
            Console.WriteLine(firstList.Contains("Hungary"));

            secondList = firstList.GetRange(0, 2);
            foreach (var item in secondList)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Generic: Dictionary
            //Dictionary
            //Creating
            Console.WriteLine("---------Creating------------");
            Dictionary<string, string> capitals = new Dictionary<string, string>();

            //Creating with initialization
            Console.WriteLine("--------Creating with initialization-------------");
            Dictionary<int, string> nameBoys = new Dictionary<int, string>()
            {
                {1,"James" },
                {2,"James" },
                {3,"David" },
                {4,"Matthew" },
            };
            foreach (var item in nameBoys)
            {
                Console.WriteLine(item + "KEY: " + item.Key + " Value: " + item.Value);
            }

            //Add
            Console.WriteLine("---------Add------------");
            capitals.Add("Russia", "Moscow");
            capitals.Add("Italy", "Rome");
            capitals.Add("England", "London");
            capitals.Add("Spain", "Madrid");
            capitals.Add("Germany", "Berlin");

            //Displaying
            Console.WriteLine("---------Displaying------------");
            foreach (var item in capitals)
            {
                Console.WriteLine(item + "KEY: " + item.Key + " Value: " + item.Value);
            }

            for (int i = 0; i < capitals.Count; i++)
            {
                Console.WriteLine(capitals.Keys.ElementAt(i) +" --> "+ capitals.Values.ElementAt(i));
                Console.WriteLine(capitals[capitals.Keys.ElementAt(i)]);//state the key
            }

            //Index
            Console.WriteLine("--------Index-------------");
            Console.WriteLine(capitals["Russia"]);
            capitals["Russia"] = "Washington";
            Console.WriteLine(capitals["Russia"]);

            //Capacity
            Console.WriteLine("--------Capacity-------------");

            //Try get Value
            Console.WriteLine("---------Try get Value------------");
            capitals.TryGetValue("Germany",out string result);
            Console.WriteLine(result);
            capitals.TryGetValue("China", out result);
            Console.WriteLine(result);


            //Remove
            Console.WriteLine("----------Remove-----------");
            capitals.Remove("Italy");
            foreach (var item in capitals)
            {
                Console.WriteLine(item + "KEY: " + item.Key + " Value: " + item.Value);
            }

            //Remove All
            Console.WriteLine("--------Remove All-------------");
            //capitals.Clear();
            //Contains
            Console.WriteLine("--------Contains-------------");
            Console.WriteLine(capitals.ContainsKey("Germany"));
            Console.WriteLine(capitals.ContainsValue("Berlin"));
            Console.WriteLine(capitals.ContainsKey("USA"));
            Console.WriteLine(capitals.ContainsValue("Washington"));

            #endregion

            #region Generic: KeyValuePair
            //Key Value Pair
            Console.WriteLine("KEYVALUEPAIRS");
            var cities = new List<KeyValuePair<string,string>>();
            cities.Add(new KeyValuePair<string, string>("Russia", "Moscow"));
            cities.Add(new KeyValuePair<string, string>("Sweden", "Stockhol"));
            cities.Add(new KeyValuePair<string, string>("Portual", "Lisbon"));
            cities.Add(new KeyValuePair<string, string>("Japan", "Tokoyo"));

            foreach (var item in cities)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.Key +" : "+item.Value);
            }

            Console.WriteLine(GetFirstAndLast());
            Console.WriteLine("KEY "+ GetFirstAndLast().Key + " VALUE "+ GetFirstAndLast().Value);

            #endregion

            #region NameValueCollection
            //NameValueCollection
            //Creating
            Console.WriteLine("------Creating------");
            NameValueCollection countries = new NameValueCollection();
            //Adding
            Console.WriteLine("-----Adding-------");
            countries.Add("Germany", "Berlin");
            countries.Add("Germany", "Hamburg");
            countries.Add("Germany", "Frankfurt");
            countries.Add("Italy", "Rome");
            countries.Add("Italy", "Milan");
            
            //Displaying
            Console.WriteLine("---Displaying---------");
            foreach (string item in countries)
            {
                Console.WriteLine(item +": ");
                Console.WriteLine(countries[item]);
            }
            //Set
            Console.WriteLine("-----Set-------");
            countries.Set("Italy", "Venice");
            foreach (string item in countries)
            {
                Console.WriteLine(item + ": ");
                Console.WriteLine(countries[item]);
            }
            //Contains
            Console.WriteLine("-----Contains-------");
            Console.WriteLine(countries.HasKeys());
            //Remove
            Console.WriteLine("-----Remove-------");
            countries.Remove("Germany");
            //Remove All
            Console.WriteLine("-----Remove All-------");


            #endregion

            #region GenericClass: Custom

            /*
             * Empire State : 381m, 443m, 365000t, NY
             * Burj Khalifa : 828m, 830m, 450000t, Dubai
             * Eiffel Tower : 300m, 324,  7300t  , Paris 
             */
            Buildings<int> empireState = new Buildings<int>();
            empireState.Name = "Empire State";
            empireState.City = "New York";
            empireState.Height = 443;
            empireState.Weight = 365000;

            Console.WriteLine("Name " + empireState.Name);
            Console.WriteLine("City " + empireState.City);
            Console.WriteLine("Height " + empireState.Height);
            Console.WriteLine("Weight " + empireState.Weight);


            Buildings<double> burjKhalifa = new Buildings<double>();
            burjKhalifa.Name = "Burj Khalifa";
            burjKhalifa.City = "Dubai";
            burjKhalifa.Height = 830;
            burjKhalifa.Weight = 450000;

            Console.WriteLine("-------------");
            Console.WriteLine("Name " + burjKhalifa.Name);
            Console.WriteLine("City " + burjKhalifa.City);
            Console.WriteLine("Height " + burjKhalifa.Height);
            Console.WriteLine("Weight " + burjKhalifa.Weight);

            Buildings<float> eiffelTower = new Buildings<float>();
            eiffelTower.Name = "Eiffel Tower";
            eiffelTower.City = "Paris";
            eiffelTower.Height = 324;
            eiffelTower.Weight = 7300;


            #endregion

            #region Tuples
            //Tuples - ie record. data structure specific number and seq of elements
            Console.WriteLine("TUPLES");
            var empInfo = new Tuple<int, string, string, DateTime, bool>(100,"jack","Williams",new DateTime(2017,10,15),true);
            Console.WriteLine(empInfo.Item1);
            Console.WriteLine(empInfo.Item2);
            Console.WriteLine(empInfo.Item3);
            Console.WriteLine(((DateTime)empInfo.Item4).ToShortDateString());
            Console.WriteLine(empInfo.Item5);

            var stdInfo = Tuple.Create(5, "John", "Smith", new DateTime(2002, 10, 24));
            Console.WriteLine(stdInfo.Item1);
            Console.WriteLine(stdInfo.Item2);
            Console.WriteLine(stdInfo.Item3);
            Console.WriteLine(stdInfo.Item4.ToShortDateString());

            //Nested Tuples
            /*
             * 1.int    : employee number
             * 2.string : first name
             * 3.string : last name
             * 4.string : address
             * 5.string : city
             * 6.string : job title
             * 7.string : nationality
             * 8.tuple  : last 5 salaries
             */

            var employeeInfo = new Tuple<int, string, string, string, string, string, string, Tuple<decimal, decimal, decimal, decimal, decimal>>
                (105, "James", "Watson", "", "", "", "", Tuple.Create(8000m, 3000m, 4000m, 5000m, 5000m));

            Console.WriteLine("Employee name is " + employeeInfo.Item2);
            Console.WriteLine("Last 5 salaries");
            Console.WriteLine(employeeInfo.Rest.Item1);
            Console.WriteLine(employeeInfo.Rest.Item2);
            Console.WriteLine(employeeInfo.Rest.Item3);
            Console.WriteLine(employeeInfo.Rest.Item4);
            Console.WriteLine(employeeInfo.Rest.Item5);

            // Tuples with methods
            var aria = Tuple.Create(12, "Aria", "Stark", "Winterfell");
            DisplayInformation(aria);
            var sansa = Tuple.Create(18, "Sansa", "Stark", "Winterfell");
            DisplayInformation(sansa);
            Console.WriteLine("------------------");
            Console.WriteLine(GetInformation().Item1);
            Console.WriteLine(GetInformation().Item2);
            Console.WriteLine(GetInformation().Item3);
            Console.WriteLine(GetInformation().Item4);

            #endregion

            #region Lambda and Generic List

            Console.WriteLine("-----------Lambda List--------------");
            List<int> list = new List<int>();
            list.Add(5); list.Add(8); list.Add(6); list.Add(15);
            list.Add(7); list.Add(2); list.Add(1); list.Add(12);

            var oddList = list.Where(n => n % 2 != 0).ToList();
            var evenList = list.Where(n => n % 2 == 0).ToList();
            Console.WriteLine("odd numbers");
            foreach (var item in oddList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("even numbers");
            foreach (var item in evenList)
            {
                Console.WriteLine(item);
            }
            #endregion
        }

        // Tuples with methods
        public static void DisplayInformation(Tuple<int, string, string, string> personInfo)
        {
            Console.WriteLine(personInfo.Item1);
            Console.WriteLine(personInfo.Item2);
            Console.WriteLine(personInfo.Item3);
            Console.WriteLine(personInfo.Item4);
        }

        public static Tuple<int, string, string, string> GetInformation()
        {
            var info = Tuple.Create(25, "Rob", "Stark", "Winterfell");

            return info;
        }


        #region GenericClass: Custom
        class Buildings<T>
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string city;

            public string City
            {
                get { return city; }
                set { city = value; }
            }

            private T height;

            public T Height
            {
                get { return height; }
                set { height = value; }
            }

            private T weight;

            public T Weight
            {
                get { return weight; }
                set { weight = value; }
            }
        }
            #endregion

            //keyvaluepair
            //return multiple vars
            public static KeyValuePair<string,string> GetFirstAndLast()
        {
            string firstName = "Grant";
            string lastName = "Verheul";

            return new KeyValuePair<string, string>(firstName, lastName);
        }
    }
}
