using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondDayAPP
{
    public interface Cars
    {
        void car();
    }

    class Vehicle : Cars
    {
        public void car()
        {
            Console.WriteLine("Interface Example");
        }
    }
//    Ask user's birthdate in a string format, parse the date into dateTime and calculate user's current age.
    public interface Age
    {
        void ageCount();
    }
//Use a Switch statement to offer loan based on conditions - large task.
    public interface insuarance
    {
        void insuarancecost();
    }

    public class Client : Age,insuarance
    {
        public string Name;
        public string Date;
        public int Cost;
        int age;
        public Client(string name,string date)
        {
            this.Name = name;
            this.Date = date;
        }
        public void ageCount()
        {
            DateTime dt= DateTime.Parse(Date);
            age = DateTime.Now.Subtract(dt).Days;
            age = age / 365;
            Console.WriteLine($"Age is: {age}");
        }
        public void insuarancecost()
        {
            if (age < 25)
            {
                Console.WriteLine($"Insurance cost is {5000*.10}");
            }
            if(age >=25)
            {
                Console.WriteLine($"Insurance cost is {5000 * .20}");
            }
        }
    }
    internal class Program
    {
        //Enumeration
        enum months
        {
            January,
            February,
            March
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(months.March);

            int p=(int)months.January;
            Console.WriteLine(p);
//            Check the data type of a variable with typeof( ) and gettype()
            //Dynamic Datatype
            dynamic psq = 1;
            dynamic psqw = "James";
            Console.WriteLine(psqw.GetType());
            
           //Interface
            Console.WriteLine("Interface Example");
            Cars v = new Vehicle();
            v.car();

            //Interface Task
            /*1:Age:Function=>Name,date,calculate,Age
            2:Initialize insurance;
            baseinsuarance 0-25*10, >25*20: Cost of insurance*/
            Client c1 = new Client("Nikunj","11/02/1989");
            c1.ageCount();
            c1.insuarancecost();

//===========================================================================================
//Create an arraylist to sort numbers 
            int[] numbers = { 70, 20, 30, 40, 50 };
            Console.WriteLine(numbers);
            foreach(int n in numbers)
                Console.WriteLine(n);
            numbers.Max();
            numbers.Min();
            numbers.Sum();
            numbers.Average();
            Array.Sort(numbers);
            Array.Reverse(numbers);
            Array.BinarySearch(numbers, 10);
            Array.ForEach(numbers, x =>Console.WriteLine(x));

            //Take array 1:username
            //2:age;
            string[] username ={ "Joseph","Martin","Bill","Waren","Rock"};
            int[] age = { 23, 49, 56, 62, 47 };

            Console.WriteLine("Username\tAge");
            for(int i = 0; i < age.Length; i++)
            {
                Console.WriteLine(username[i]+"\t\t"+age[i]);
            }
            Console.Clear();

//===========================================================================================
//Array Devide by gender and make binary search on array
            /*string[] malenames = { };
            string[] femalenames = { };
            string choice = "Y";
            string gender,name;
            while (choice == "Y" || choice=="y")
            {
                Console.WriteLine("\nEnter Gender[M|F]:");
                gender=Console.ReadLine();
                Console.WriteLine("\nEnter Name:");
                name=Console.ReadLine();
                if (gender == "M" || choice == "m")
                {
                    //Array.Resize(ref malenames, malenames.Length+1);
                    //malenames[malenames.Length-1]=name;
                    malenames=malenames.Append(name).ToArray();
                }
                if(gender == "F" || choice == "f")
                {
                    //Array.Resize(ref femalenames,female.Length+1);
                    //femalenames[femalenames.Length-1]=name;
                    femalenames = femalenames.Append(name).ToArray();
                }
                Console.WriteLine("\nWant to Add More Data[Y|N]:");
                choice=Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine(String.Join(",",malenames));
            Console.WriteLine(String.Join(",",femalenames));

            Console.WriteLine("\nAfter Sorting:");
            Array.Sort(malenames);
            Array.Sort(femalenames);
            Console.WriteLine(String.Join(" | ", malenames));
            Console.WriteLine(String.Join(" | ", femalenames));
        
            Console.WriteLine("\nProvide Gender For Searching:");
            gender = Console.ReadLine();
            Console.WriteLine("\nProvide Name For Searching:");
            name = Console.ReadLine();
            int position=0;
            if(gender == "M" || choice == "m")
            {
                position=Array.BinarySearch(malenames, name);
            }
            if(gender=="F" || choice == "f")
            {
                position=Array.BinarySearch(femalenames, name);
            }
            Console.WriteLine("Name is on "+(position+3)+"th Position");*/

//===========================================================================================
//Take value when New value added is Should add into other array
            /*int[] values = {};
            int[] addedvalues = { };
            int value = 0;
            
            string choice = "Y";
            
            while(choice=="Y"||choice=="y")
            {
                Console.WriteLine("\nEnter Value:");
                value=Convert.ToInt32(Console.ReadLine());
                if (values.Length < 5)
                {
                    values = values.Append(value).ToArray();
                }
                else
                {
                    addedvalues = addedvalues.Append(value).ToArray();
                }
                Console.WriteLine("\nWant to Add more Value: ");
                choice =Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("\n First Array:");
            foreach(int i in values)
                Console.WriteLine(i);
            Console.WriteLine("\n Second Array:");
            foreach (int i in addedvalues)
                Console.WriteLine(i);
            */

//===========================================================================================
//Collections -> Array List
//Create interfaces that have functions to calculate the premium cost, implements those methods in the Parent class.
            ArrayList al = new ArrayList();
            al.Add(20);
            al.Add('a');
            al.Add("ABC");
            al.Add(null);
            al.Add(true);
            al.Add(10.20);

            int[] ar = { 10, 20, 30 };
            al.AddRange(ar);//To Add array inside the Arraylist
            Console.WriteLine(al.Count);//Gives Length
            //al.RemoveAt(0);
            al.Remove(10);
            Console.WriteLine(al.Contains(30));//return true if list contains value or not
            Console.WriteLine(al[0]);//Gives Datatype of integer

            Console.Clear();

            ArrayList dal = new ArrayList();
            int[] values = { };
            int value = 0;

            string choice = "Y";

            while (choice == "Y" || choice == "y")
            {
                if (values.Length < 5)
                {
                    Console.WriteLine("\nEnter Value:");
                    value = Convert.ToInt32(Console.ReadLine());
                    values = values.Append(value).ToArray();
                }
                else
                {
                    dal.AddRange(values);
                    values = Enumerable.Empty<int>().ToArray();
                    Console.WriteLine("\nArrayList:");
                    foreach (int i in dal)
                        Console.WriteLine(i);
                    //                    Console.WriteLine(values.Length);
                }
                Console.WriteLine("\nWant to Add more Value: ");
                choice = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\nArray in Queue:");
                foreach (int i in values)
                    Console.WriteLine(i);
            }
        }
    }
}
