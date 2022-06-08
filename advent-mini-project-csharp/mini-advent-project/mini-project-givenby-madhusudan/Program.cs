using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_project_givenby_madhusudan
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var userdata = new List<User>()
            {
                new User(){Id=101,UserName="bill123",Password="123",MobileNumber="321"}
            };

            var containers = new List<Containers>()
            {
                new Containers(){Id="CD101",Capacity=20,Height=10},
                new Containers(){Id="CD102",Capacity=23,Height=20},
                new Containers(){Id="CD103",Capacity=22,Height=13},
                new Containers(){Id="CD104",Capacity=24,Height=16}
            };

            var status = new List<Status>();
            //Login
            bool userloginstatus = false;
            int userid = 0;
            string username = "",password="";

            //Container
            string cntnrid = "";
            string cntnrstatus = "";
            string cntndate;
            //pagging
            string nestpage = "";

            //Status
            int statusid = 0;
            Console.WriteLine("Let's start the Code!");
            while(true)
            {
                Console.WriteLine("Provide Username: ");
                username=Console.ReadLine();
                Console.WriteLine("Provide Password: ");
                password = Console.ReadLine();
                for (int i = 0; i < userdata.Count; i++)
                {
                    if(userdata[i].UserName == username && userdata[i].Password == password)
                    {
                        userloginstatus = true;
                        userid =userdata[i].Id;
                        username = password = null;
                        break;
                    }
                }
                if (userloginstatus)
                {
                    Console.Clear();
                    Console.WriteLine("Hello {0}\n",username);
                    while(userloginstatus)
                    {
                        Console.WriteLine("\nWant to Do Some Operation?\n1.Show Container List\n2.Insert Status\n3.Update Status\n4.Show Status\n0.Exit");
                        nestpage = Console.ReadLine();
                        if (nestpage == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("***********************\nContainer Details\n***********************");
                            foreach (var c in containers)
                                Console.WriteLine("ID: {0} Capacity: {1} Height: {2}", c.Id, c.Capacity, c.Height);

                        }
                        else if (nestpage == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("***********************\nContainer Details\n***********************");
                            foreach (var c in containers)
                                Console.WriteLine("ID: {0} Capacity: {1} Height: {2}", c.Id, c.Capacity, c.Height);
                            Console.WriteLine("Provide Container ID from Above List: ");
                            cntnrid = Console.ReadLine();
                            for(int i=0;i<containers.Count;i++)
                            {
                                if (containers[i].Id == cntnrid)
                                {
                                    Console.WriteLine("Provide Current Status of Container: ");
                                    cntnrstatus = Console.ReadLine();
                                    cntndate = DateTime.Now.ToString();
                                    status.Add(new Status() { Id = ++statusid, UserId = userid, ContainerId = cntnrid, ContainerStatus = cntnrstatus, LastUpdate = cntndate });
                                    Console.WriteLine("Status Ìnserted!");
                                    break;
                                }
                            }
                        }
                        else if (nestpage == "3") {
                            Console.Clear();
                            Console.WriteLine("***********************\nContainer Status Report\n***********************");
                            foreach (var s in status)
                                Console.WriteLine("ID: {0} UserID: {1} ContainerID: {2} Status: {3} LastUpdate: {4}", s.Id, s.UserId, s.ContainerId, s.ContainerStatus, s.LastUpdate);
                            Console.WriteLine("Provide Container ID from Above List: ");
                            cntnrid = Console.ReadLine();
                            for (int i = 0; i < containers.Count; i++)
                            {
                                if (containers[i].Id == cntnrid)
                                {
                                    Console.WriteLine("Provide Current Status of Container: ");
                                    cntnrstatus = Console.ReadLine();
                                    cntndate = DateTime.Now.ToString();
                                    status.Add(new Status() { Id = ++statusid, UserId = userid, ContainerId = cntnrid, ContainerStatus = cntnrstatus, LastUpdate = cntndate });
                                    Console.WriteLine("Status Updated!");
                                    break;
                                }
                            }
                        }
                        else if (nestpage == "4") {
                            Console.Clear();
                            Console.WriteLine("***********************\nContainer Status Report\n***********************");
                            foreach (var s in status)
                                Console.WriteLine("ID: {0} UserID: {1} ContainerID: {2} Status: {3} LastUpdate: {4}", s.Id,s.UserId ,s.ContainerId, s.ContainerStatus,s.LastUpdate);
                        }
                        else if (nestpage == "0")
                        {
                            Console.Clear();
                            userloginstatus=false;
                            Console.WriteLine("Meet You Soon");
                            break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Provide Proper Credencials!");
                }
            }
        }
    }

    public class Status
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ContainerId { get; set; }
        public string ContainerStatus { get; set; }
        public string LastUpdate { get; set; }
    }

    public class Containers
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int Height { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
    }
}
