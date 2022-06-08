using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyThirdDayApp
{
    internal class Program
    {
        
        struct Port
        {
            public int id;
            public string name;

            public Port(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
        static void Main(string[] args)
        {
//List
            /*var numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);

            int[] arr = { 10, 21, 25, 37 };
            numbers.AddRange(arr);

            Console.WriteLine(numbers.Count);

            foreach (int i in numbers)
                Console.WriteLine(i);

            var customers = new List<Customer>() //Linq Syntax
            {
                new Customer(){Id=1, Name="Mosh"},
            };

            foreach (Customer customer in customers)
                Console.WriteLine(customer.Id+" "+customer.Name);*/
//***************************Linq Syntax********************************************************************
//Create a list and Insert one value After initialization.
/*            var customers = new List<Customer>()
            {
                new Customer(){Id=101,Name="Bill" },
                new Customer(){Id=102,Name="Ajay" },
                new Customer(){Id=103,Name="jons"},
                new Customer(){Id=104,Name="Dollar" }
            };

            string choice= "Y";
            int id = 0;
            Console.WriteLine("UserId\tFirst Name\tLastName");
            foreach (var c in customers)
                Console.WriteLine(c.Id + "\t" + c.Name + "\t" + c.LastName);

            while (choice=="Y"|choice=="y")
            {
                Console.WriteLine("Enter Customer ID:");
                id=Convert.ToInt32(Console.ReadLine());
                for(int c= 0;c < customers.Count;c++)
                {
                    if (customers[c].Id == id)
                    {
                        Console.WriteLine("Give Last Name");
                        customers[c].LastName = Console.ReadLine();
                    }
                }
                Console.WriteLine("Want to edit other ID[Y|N]:");
                choice = Console.ReadLine();
            }
            Console.WriteLine("UserId\tFirst Name\tLastName");
            foreach (var c in customers)
                Console.WriteLine(c.Id + "\t" + c.Name + "\t" + c.LastName);*/


            //Other Way Working On
//            var result = from c in customers where c.Name == "Bill" select c;

//Sorted List
/*            SortedList<string,string> list = new SortedList<string,string>();
            list.Add("James", "1");
            list.Add("Roy", "3");
            list.Add("Ajay", "4");
            list.Add("Jonny", "2");
            foreach (var i in list)
                Console.WriteLine("Key: {0}, Value: {1}",i.Key,i.Value);*/

//***********************************************************************************************
//Container Booking System
/*            Port[] port = {new Port(), new Port(), new Port()};
            port[0] = new Port(1,"India");
            port[1] = new Port(2, "NewYork");
            port[2] = new Port(3, "London");*/

            IDictionary<int, string> port = new Dictionary<int, string>();
            port.Add(1, "India");
            port.Add(2, "NewYork");
            port.Add(3, "Londan");

            var portcost = new List<Cost>()
            {
                new Cost(){Id=1,fromid=1,toid=2},
                new Cost(){Id=2,fromid=1,toid=3},
                new Cost(){Id=3,fromid=2,toid=1},
                new Cost(){Id=4,fromid=2,toid=3},
                new Cost(){Id=5,fromid=3,toid=1},
                new Cost(){Id=6,fromid=3,toid=2},
            };

            Customer cstm=new Customer();
            var book = new List<Booking>();

            string choice,bookdate;
            DateTime containerdate;
            Console.WriteLine("Want to Book the Container");
            choice = Console.ReadLine();
            int fromid=0, toid=0,cost=0,costid=0;
            bool fromflag = true,toflag=true;

            Console.WriteLine("Provide your ID:");
            cstm.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Provide your Name:");
            cstm.Name = Console.ReadLine();

            while (choice == "Y" || choice == "y")
            {
                Console.Clear();
                //                for (int i = 0; i < port.Length; i++)
                //                    Console.WriteLine("Index: {0} Name: {1}", i, port[i].name);
                foreach (KeyValuePair<int, string> p in port)
                    Console.WriteLine("Index: {0}, Value: {1}", p.Key, p.Value);

                while (fromflag)
                {
                    Console.WriteLine("Provide Index of source port");
                    fromid = Convert.ToInt32(Console.ReadLine());
                    //for (int i = 0; i < port.Length; i++)
                    /*for (int i = 0; i < port.Count; i++)
                    {
                        if (port[i].Key == fromid)
                        {
                            fromflag = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Provide Right ID");
                        }
                    }*/
                    if (port[fromid] != "")
                    {
                        fromflag = false;
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Provide Proper Index.");
                    }
                }
                while (toflag)
                {
                    Console.WriteLine("Provide Destination of your Container");
                    toid = Convert.ToInt32(Console.ReadLine());
                    /*for (int i = 0; i < port.Length; i++)
                    {
                        if (port[i].id == toid)
                        {
                            if (port[i].id != fromid)
                            {
                                toflag = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("From ID and TO ID should Not be Same.");
                            }
                        }
                    }*/
                    if(port[toid] !="")
                    {
                        if (port[toid] != port[fromid])
                        {
                            fromflag = false;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Provide Proper Index.");
                    }
                }
                Console.WriteLine("\nWhen you want Container?\nProvide Date:[DD-MM-YYYY]");
                bookdate=Console.ReadLine();
                containerdate = DateTime.Parse(bookdate);
                for (int i = 0; i < portcost.Count; i++)
                {
                    if (portcost[i].fromid == fromid && portcost[i].toid == toid)
                    {
                        costid = portcost[i].Id;
                        break;
                    }
                }
                switch (costid)
                {
                    case 1:
                        cost = 100;
                        break;
                    case 2:
                        cost = 200;
                        break;
                    case 3:
                        cost = 300;
                        break;
                    case 4:
                        cost = 400;
                        break;
                    case 5:
                        cost = 500;
                        break;
                    case 6:
                        cost = 600;
                        break;
                }
                double days = 0;
                DateTime today = new DateTime();
                days = (today - containerdate).TotalDays;
                Console.WriteLine(days);
                if (days>3)
                {
                    book.Add(new Booking() { userid = cstm.Id, fromid = fromid - 1, toid = toid - 1, cost = cost, BookDate = containerdate });
                }
                else
                    Console.WriteLine("Operation can not perform With in 3 Days!");

                foreach (Booking b in book)
                {
                    //                    Console.WriteLine("Userid: {0} From: {1} To: {2} Cost{3}", b.userid, port[b.fromid].name, port[b.toid].name, b.cost);
                    Console.WriteLine(" Userid: {0}\n From: {1} To: {2}\n Date: {3}\n Cost: {4}", b.userid, port[b.fromid+1], port[b.toid+1],b.BookDate ,b.cost);

                }

                Console.WriteLine("Want to Book Another Container");
                choice = Console.ReadLine();
                fromid = 0;
                toid = 0;
            }

//***********************************************************************************************
//Dictionery
/*            IDictionary<int, string> dnumb = new Dictionary<int, string>();
                dnumb.Add(1,"James");
                dnumb.Add(2,"Roy");
                dnumb.Add(3,"Ajay");
                dnumb.Add(4,"Jonny");
            foreach(KeyValuePair<int, string> s in dnumb)
            {
                Console.WriteLine("Key: {0}, Value: {1}",s.Key, s.Value);
            }*/
        }
    }

        public class Booking
        {
            public int userid { get; set; }
            public int fromid { get; set; }
            public int toid { get; set; }
            public int cost { get; set; }
            public DateTime BookDate {get; set; }
        }
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
        }

        public class Cost
        {
            public int Id { get; set; }
            public int fromid { get; set; }
            public int toid { get; set; }
        }
}
