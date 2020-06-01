using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adv_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlText = string.Empty;
            List<Employees> listOfEmployees = new List<Employees>
            {
                new Employees { EmployeeID=1150, FirstName="Jack",LastName="Steven", Salary=5000m, Age=35,Appraisal = new List<int>{7,7,8,9,7} },
                new Employees { EmployeeID=1150, FirstName="Debora",LastName="Watson", Salary=10000m, Age=45,Appraisal = new List<int>{9,9,8,9,8} },
                new Employees { EmployeeID=1150, FirstName="Claire",LastName="Adam", Salary=7500m, Age=32,Appraisal = new List<int>{9,7,8,9,7} },
                new Employees { EmployeeID=1150, FirstName="Michael",LastName="Rob", Salary=3500m, Age=22,Appraisal = new List<int>{6,7,8,7,7} },
                new Employees { EmployeeID=1150, FirstName="Matthew",LastName="Forest", Salary=4500m, Age=28,Appraisal = new List<int>{7,7,6,6,7} },
                new Employees { EmployeeID=1150, FirstName="Charles",LastName="Kris", Salary=8000m, Age=27,Appraisal = new List<int>{8,9,7,8,8} },
                new Employees { EmployeeID=1150, FirstName="Robert",LastName="Wilson", Salary=8000m, Age=28,Appraisal = new List<int>{8,9,8,9,9} },
                new Employees { EmployeeID=1150, FirstName="Emma",LastName="Brooks", Salary=6000m, Age=23,Appraisal = new List<int>{8,6,9,9,7} },
                new Employees { EmployeeID=1150, FirstName="Jennifer",LastName="Blake", Salary=3000m, Age=38,Appraisal = new List<int>{6,7,7,6,6} },
                new Employees { EmployeeID=1150, FirstName="Terry",LastName="Loyd", Salary=9000m, Age=49,Appraisal = new List<int>{9,9,9,8,7} },
                new Employees { EmployeeID=1150, FirstName="Adam",LastName="Spencer", Salary=7000m, Age=33,Appraisal = new List<int>{8,8,8,6,7} },
                new Employees { EmployeeID=1150, FirstName="Stacy",LastName="Shelton", Salary=4000m, Age=25,Appraisal = new List<int>{8,7,8,6,7} }
            };

            XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Employees>));
            using (StringWriter sw = new StringWriter())
            {
                xmlWriter.Serialize(sw, listOfEmployees);
                xmlText = sw.ToString();
                Console.WriteLine(sw.ToString());
            }

            XmlSerializer xmlReader = new XmlSerializer(typeof(List<Employees>));
            using (StringReader sr = new StringReader(xmlText))
            {
                List<Employees> tempList = (List<Employees>)xmlReader.Deserialize(sr);

                foreach (var employee in tempList)
                {
                    Console.WriteLine(employee.EmployeeID);
                    Console.WriteLine(employee.FirstName);
                    Console.WriteLine(employee.Age);
                    Console.WriteLine(employee.Salary);
                    Console.WriteLine("--------------");
                }
            }
        }
    }

    [Serializable()]
    public class Employees
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private decimal salary;
        private int age;

        private List<int> appraisal;
        [XmlElement("EmployeeNumber")]
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        //[XmlIgnore]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        [XmlIgnore]
        public List<int> Appraisal
        {
            get { return appraisal; }
            set { appraisal = value; }
        }
        public Employees()
        {

        }
    }
}
