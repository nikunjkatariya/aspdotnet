using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Program
    {
        struct Person
        {
            public int id;
            public string FirstName;
            public string Title;
            public Person(int id,string fname,string title,string name)
            {
                this.id = id;
                this.FirstName = fname;
                this.Title = title;
            }
/*            public static Person GetDetails()
            {
                Person(2, "Joshef", "Employee");
            }*/
        }

        struct GetSetName
        {
            private static StringBuilder name = new StringBuilder(20);
            public string Name
            {
                get {
                    Console.WriteLine(name.Capacity); 
                    return name.ToString(); 
                }
                set { name.Append(value); }
            }
        }

        //Use a Switch statement to offer loan based on conditions - large task.
        struct Customer
        {
            public int totalamount;
            public int age;
            public string name;
            public Customer(string Name, int Age, int TotalAmount)
            {
                this.name = Name;
                this.age = Age;
                this.totalamount = TotalAmount;
            }
        }
        static void Main(string[] args)
        {
            //Data types with String Concating 
            //Person person = new Person(1,"Jonson","Employee","White");
            //Static Constructure
            // Person person2 = Person.GetDetails();
            /*            string message = "Hello World";
                        Console.WriteLine("Hello World!");
                        Console.WriteLine(message);
                        //explicitly types
                        int numberone = 100;
                        //implicitly typed
                        var j = 1012;

                        uint gi = 100u;
                        float f = 10.2f;
                        double d = 1222222.4d;
                        long l = 22323123123123123l;
                        ulong r = 98745467984568494ul;
                        decimal dc = 110.12m;
                        Int32 numbertwo = 150;

                        //default values
                        //int =0
                        int im=default(int);
                        float ddf=default(float);
                        //char='\0'
                        //boolean=false

                        //implecit type conversion
                        int ip = 1234;
                        float isadsaf = ip;

                        //explicit type conversion
                        int floattoint = (int)isadsaf;*/
            /*            char[] ch = { 'h', 'e', 'l', 'l', 'o' };
                        string s1 = new string(ch);

                        string s2 = @"test@test.com";

                        string s3 = "hi \nhello \nHow are you?";

                        string s4 = "Dr."+"Mahesh";

                        foreach (char c in ch)
                        {
                            Console.WriteLine(c);
                        }
                        Console.WriteLine(s1);
                        Console.WriteLine(s2);
                        Console.WriteLine(s3);
                        Console.WriteLine(s4);

                        string firstname = "Mahesh";
                        string lastname = "Bhat";
                        string fullname = $"Dr. {firstname} {lastname}";
                        Console.WriteLine(fullname);


//*****************************Even Odd********************************
                        Console.WriteLine("\nNumber is Even or Odd \n Provide Number :");
                        int numone=Convert.ToInt32(Console.ReadLine());

//Check the message based on condition and use the if/else condition.
                        if (numone % 2 == 0)
                        {
                            Console.WriteLine(numone+" is Even");
                        }
                        else
                        {
                            Console.WriteLine(numone + " is Odd");
                        }
//Compare a string to execute a condition. 
                        Console.WriteLine("\nString Concat");
                        string name = Console.ReadLine();
                        string namepartone="";
                        string nameparttwo="";
                        if (name.Length > 5)
                        {
                            numone=name.Length/2;
                            namepartone = name.Substring(0,numone);
                            nameparttwo = name.Substring(numone);
                        }
                        Console.WriteLine(name);
                        Console.WriteLine("\n First Part: "+namepartone+"\n Second Part: "+nameparttwo);

                        Console.WriteLine("\nFactorial of a Number \n Provide Number :");
                        numone=Convert.ToInt32(Console.ReadLine());

                        int i = 0,sum=1;
                        i= numone;
                        while (i != 0)
                        {
                            sum = sum * i;
                            i--;
                        }
                        Console.WriteLine(sum);*/

            //Print The Statement when number is Even or Odd. 
            /*int numone;
            numone=Convert.ToInt32(Console.ReadLine());
            if (numone != 0)
            {
                if (numone % 2 == 0)
                {
                    even();
                }
                else
                {
                    odd();
                }
                void even()
                {
                    Console.WriteLine("\n" + numone + " Is Even Number.\n");
                }
                void odd()
                {
                    Console.WriteLine("\n" + numone + " Is Odd Number.\n");
                }
            }
            else
            {
                Console.WriteLine("0 is Not Right value to check Even Odd");
            }*/

            //*********************************Date Time Functions***********************************

            /*DateTime dt = new DateTime();
            Console.WriteLine(dt);

            DateTime dt2 =new DateTime(2022,03,03,3,10,20,DateTimeKind.Utc);
            Console.WriteLine(dt2);
        
            Console.WriteLine(DateTime.MinValue.Ticks);
            Console.WriteLine(DateTime.MaxValue.Ticks);

            DateTime dt3 = DateTime.Now;
            Console.WriteLine(dt3);

            DateTime todaydate = DateTime.Today;
            Console.WriteLine(todaydate);

            DateTime datetimeutc = DateTime.UtcNow;
            Console.WriteLine(datetimeutc);

            var st = "4/4/1977";
            DateTime dm;
            var isValidDate = DateTime.TryParse(st,out dm);
            if(!isValidDate)
            {
                Console.WriteLine($"{dm} is Valid Date");
            }
            else
            {
                Console.WriteLine($"{dm} is Not Valid Date");
            }*/

            //************************************Age Calculator**********************************
            /*Console.WriteLine("\nAge Calculator: \nProvide Date of Birth in DD/MM/YYYY or YYYY/MM/DDFormat:");
            DateTime dateofbirth= DateTime.Parse(Console.ReadLine());
            int month = Math.Abs(dateofbirth.Month-todaydate.Month); 
            int age = Math.Abs(dateofbirth.Year-todaydate.Year);
            Console.WriteLine(age +" And "+ month+" Months");
            string dob = dateofbirth.Date.ToShortDateString();
            Console.WriteLine(dob);*/

            //Structure
            //Console.WriteLine("\nParameterize Constructure:\n"+person.id+" "+person.FirstName+" "+person.Title);

            //String Builder: Careful during DataManipulation 
            /*StringBuilder SB = new StringBuilder("Good Morning!",20);
            Console.WriteLine("Before Appending:" + SB.Capacity);
            Console.WriteLine(SB);
            SB.Append("Nice Day");
            Console.WriteLine("After Appending:"+SB.Capacity);
            Console.WriteLine(SB);
            SB.Insert(5, "sdf");
            SB.Remove(7, 7);
            SB.Replace("Nice", "Good");
            Console.WriteLine(SB);*/

            /*string FullName;
            Console.WriteLine("Provide Your Full Name: ");
            FullName = Console.ReadLine();
            StringBuilder sb = new StringBuilder(FullName,30);
            Console.WriteLine(sb);
            string choice;
            Console.WriteLine("You Want to Add Text [Y|N]:");
            choice=Console.ReadLine();
            while (choice == "Y" || choice == "y")
            {
                FullName=Console.ReadLine();
                sb.Append(FullName);
                Console.WriteLine(sb);
                Console.WriteLine("You Want to Add More Text [Y|N]:");
                choice = Console.ReadLine();
            }*/

            //Using Getter Setter Values

            /*GetSetName gtn = new GetSetName();
            Console.WriteLine("Provide Your Full Name: ");
            gtn.Name = Console.ReadLine();
            string choice;
            Console.WriteLine("You Want to Add Text [Y|N]:");
            choice = Console.ReadLine();
            while (choice == "Y" || choice == "y")
            {
                Console.WriteLine("Add More Details: ");
                gtn.Name = Console.ReadLine();
                Console.WriteLine(gtn.Name);
                Console.WriteLine("You Want to Add More Text [Y|N]:");
                choice = Console.ReadLine();
            }*/

            //DataType
            /*int i = 0;
            Console.WriteLine(i.GetType());
            Console.WriteLine(i.GetType()==typeof(int));*/

            //Nullable
            /*Nullable<int> j = null;
            Console.WriteLine(j.Value);
            int? a = null;*/

            //Calculate the Loan Amount based on age
            //Switch
            /*Customer[] c = new Customer[5];
            c[0]=new Customer("Morgan", 23, 15000);
            c[1] = new Customer("Josheph", 28, 15000);
            c[2] = new Customer("Luis", 37, 15000);
            c[3] = new Customer("Jack", 101, 15000);
            c[4] = new Customer("Imran", 25, 15000);*/

            Customer[] c = new Customer[] //Or = new[]
            {
                new Customer("Morgan", 23, 15000),
                new Customer("Josheph", 28, 15000),
                new Customer("Luis", 37, 15000),
                new Customer("Jack", 101, 15000),
                new Customer("Imran", 25, 15000)
            };



            int count(int age)
            {
                if (age < 25)
                    return 1;
                else if (age >= 25 && age < 35)
                    return 2;
                else if(age >=35 && age <= 100)
                    return 3;
                else if(age >=100)
                    return 4;
                return 0;
            }

            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine("======================================================");
                switch (c[i].age)//switch (count(c[i].age))
                {
                    case int n when c[i].age<25:
                        Console.WriteLine("\nLoan for " + c[i].name + " is Approved of " + c[i].totalamount * 0.10);
                        break;
                    case int n when c[i].age >= 25 && c[i].age<35:
                        Console.WriteLine("\nLoan for " + c[i].name + " is Approved of " + c[i].totalamount * 0.15);
                        break;
                    case int n when c[i].age >= 35 && c[i].age<100:
                        Console.WriteLine("\nLoan for " + c[i].name + " is Approved of " + c[i].totalamount * 0.45);
                        break;
                    case int n when c[i].age > 100:
                        Console.WriteLine("\nLoan for " + c[i].name + " is Approved of " + c[i].totalamount * 0.50);
                        break;
                    default:
                        Console.WriteLine("\nProvide Proper Age");
                        break;
                }
                Console.WriteLine("======================================================");
            }

            Console.WriteLine();
        }
    }
}
