using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyFourthDayApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //HashTable OR #Values
            Console.WriteLine("\nHash Table");
            Hashtable ht = new Hashtable();

            ht.Add(1, "Monday");
            ht.Add(2, "Tuesday");
            ht.Add(3, "Wednesday");
            ht.Add(4, "Thursday");

            foreach (DictionaryEntry kv in ht)
                Console.WriteLine("Key: {0} Values: {1}", kv.Key, kv.Value);


            //Stack
            Console.WriteLine("\nStack");
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            foreach (var s in stack)
                Console.WriteLine(s + ",");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count());
            Console.WriteLine(stack.Peek());
            //pop
            //peek()
            //push
            //clear()
            //Contains();


            //Queqe
            Console.WriteLine("\nQueue");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine(queue.Count());

            foreach (var s in queue)
                Console.WriteLine(s + ", ");

            Console.WriteLine(queue.Contains(3));

            //Tuple
            Console.WriteLine("\nTuple");
            var customer = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8);//Maximum 8 values can be given
            var store = Tuple.Create("Josh", 2, "Mosh");

            var employee = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9));

            Console.WriteLine(employee.Rest.Item1);
            Console.WriteLine(employee.Rest.Item1.Item1);
            Console.WriteLine(employee.Item1);


            Console.Clear();//Clear Screen
                            //Task to insert values in tuple till 8th index after that user gets charged
            /*          string cntnrcode = "",choice="Y";
                        ArrayList containers=new ArrayList();
                        while(choice=="Y"&&choice=="y")
                        {
                            if (containers.Count <= 8)
                            {
                                Console.WriteLine("Enter Container Code:");
                                cntnrcode = Console.ReadLine();
                                containers.Add(cntnrcode);
                                Console.WriteLine("Want Add more Container");
                                choice=Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("You Have Some Amount to Pay for Accessing Extra Features!");
                                Console.WriteLine("Want Add more Container");
                                choice = Console.ReadLine();
                            }
                        }
                        Console.WriteLine("Added Containers");
                        for(int i=0;i<containers.Count;i++)
                            Console.WriteLine(containers[i]);*/

            //Adding Users and Ports at runtime using Generic DataType

            /*            IDictionary<int,Users> user= new Dictionary<int, Users>();
                        IDictionary<int,Ports> port= new Dictionary<int, Ports>();

                        int page = 0,uid=0,pid=0;
                        string uname = "", pname = "";
                        while (page != 5)
                        {
                            Console.WriteLine("*****************************\n1.Add User\n2.Show User\n3.Add Port\n4.Show Ports\n5.Exit");
                            page = Convert.ToInt32(Console.ReadLine());
                            switch (page)
                            {
                                case 1:
                                    Console.WriteLine("Enter User Name: ");
                                    uname=Console.ReadLine();
                                    uid++;
                                    Users udata = new Users() { Id = uid, UserName = uname };
                                    user.Add(uid, udata);
                                    Console.Clear();
                                    Console.WriteLine("User Added Successfully!");
                                    break;
                                case 2:
                                    foreach (var u in user.Values)
                                    {
                                        Console.WriteLine($"Id: {u.Id}\t User Name: {u.UserName}");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Port Name: ");
                                    pname = Console.ReadLine();
                                    pid++;
                                    Ports pdata = new Ports() { Id = pid, PortName = pname };
                                    port.Add(pid, pdata);
                                    Console.Clear();
                                    Console.WriteLine("Port Added Successfully!");
                                    break;
                                case 4:
                                    foreach (var p in port.Values)
                                    {
                                        Console.WriteLine($"Id: {p.Id}\tPort Name: {p.PortName}");
                                    }
                                    break;
                                case 5:
                                    page = 5;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Provide Proper Input!");
                                    break;
                            }
                        }*/

            //File Operations
            /*            IDictionary<int,Users> user= new Dictionary<int, Users>();
                        IDictionary<int,Ports> port= new Dictionary<int, Ports>();

                        string userpath = @"C:\Users\raytex\source\repos\csharp-examples\MyFourthDayApp\MyFourthDayApp\userdata.txt";
                        StreamWriter userwriter = new StreamWriter(userpath);
            //            StreamReader userreader = new StreamReader(userpath);
                        string portpath = @"C:\Users\raytex\source\repos\csharp-examples\MyFourthDayApp\MyFourthDayApp\portdata.txt";
                        StreamWriter portwriter = new StreamWriter(portpath);
            //           StreamReader portreader = new StreamReader (portpath);

                        int page = 0,uid=0,pid=0;
                        string uname = "", pname = "";
                        while (page != 5)
                        {
                            Console.WriteLine("*****************************\n1.Add User\n2.Show User\n3.Add Port\n4.Show Ports\n5.Exit");
                            page = Convert.ToInt32(Console.ReadLine());
                            switch (page)
                            {
                                case 1:
                                    Console.WriteLine("Enter User Name: ");
                                    uname=Console.ReadLine();
                                    uid++;
                                    Users udata = new Users() { Id = uid, UserName = uname };
                                    user.Add(uid, udata);
                                    userwriter.WriteLine("{0} {1}",uid,uname);
                                    Console.Clear();
                                    Console.WriteLine("User Added Successfully!");
                                    break;
                                case 2:
                                    foreach (var u in user.Values)
                                    {
                                        Console.WriteLine($"Id: {u.Id}\t User Name: {u.UserName}");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Port Name: ");
                                    pname = Console.ReadLine();
                                    pid++;
                                    Ports pdata = new Ports() { Id = pid, PortName = pname };
                                    portwriter.WriteLine("{0} {1}", pid, pname);
                                    port.Add(pid, pdata);
                                    Console.Clear();
                                    Console.WriteLine("Port Added Successfully!");
                                    break;
                                case 4:
                                    foreach (var p in port.Values)
                                    {
                                        Console.WriteLine($"Id: {p.Id}\tPort Name: {p.PortName}");
                                    }
                                    break;
                                case 5:
                                    page = 5;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Provide Proper Input!");
                                    break;
                            }
                        }
             //           portreader.Close();
             //           userreader.Close();
                        portwriter.Close();
                        userwriter.Close();*/

//user have to add from port and to port but with that container should have to stop somewhere in list
            var port = new List<Ports>()
            {
                new Ports(){Id=1,PortName="India"},
                new Ports(){Id=2,PortName="London"},
                new Ports(){Id=3,PortName="Paris"},
                new Ports(){Id=4,PortName="Dubai"},
                new Ports(){Id=5,PortName="USA"},
                new Ports(){Id=6,PortName="NewYork"},
            };
            var book = new List<Booking>();
            string choice;
            int fromid = 0, toid = 0, mid = 0, uid = 101;
            bool fromflag = true, toflag = true, midflag = true;

            Console.WriteLine("Want to Book the Container [Y]:");
            choice = Console.ReadLine();

            while (choice == "Y" || choice == "y")
            {
                Console.Clear();
                foreach (var p in port)
                    Console.WriteLine("Index: {0}, Value: {1}", p.Id, p.PortName);

                while (fromflag)
                {
                    Console.WriteLine("Provide Index of source port");
                    fromid = Convert.ToInt32(Console.ReadLine());
                    for(int i = 0; i < port.Count; i++)
                    {
                        if (port[i].Id==fromid)
                        {
                            fromflag = false;
                            break;
                        }
                        else
                        {
                            fromflag = true;
                        }
                    }
                }
                while (midflag)
                {
                    Console.WriteLine("Provide Index of Hold port");
                    mid = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < port.Count; i++)
                    {
                        if (port[i].Id == mid&&mid!=fromid)
                        {
                            midflag = false;
                            break;
                        }
                        else
                        {
                            midflag = true;
                        }
                    }
                }
                while (toflag)
                {
                    Console.WriteLine("Provide Destination of your Container");
                    toid = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < port.Count; i++)
                    {
                        if (port[i].Id == toid&&toid!=fromid&&toid!=mid)
                        {
                            toflag = false;
                            break;
                        }
                        else
                        {
                            toflag = true;
                        }
                    }
                }

                book.Add(new Booking() { userid = uid, fromname = port[fromid].PortName,mname= port[mid].PortName, toname = port[toid].PortName });
                foreach(Booking b in book)
                {
                    Console.WriteLine(" Userid: {0}\n From: {1} Hold: {2} To: {3}", b.userid, b.fromname, b.mname, b.toname);
                }

                Console.WriteLine("Want to Book Another Container[Y]:");
                choice = Console.ReadLine();
                fromflag=toflag=midflag=true;
                fromid =toid=mid= 0;
            }
        }

        class Users
        {
            public int Id { get; set; }
            public string UserName { get; set; }
        }

        class Ports
        {
            public int Id { get; set; }
            public string PortName { get; set; }
        }
        public class Booking
        {
            public int userid { get; set; }
            public string fromname { get; set; }
            public string toname { get; set; }
            public string mname { get; set; }
        }
    }
}
