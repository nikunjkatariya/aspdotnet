using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create Login & Registration System with Authentication


namespace csharp_new_project
{
    internal class Program
    {
        public class UserDetails
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Mobile { get; set; }
            public string Password { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
        }
        private static string getpassword(int length=5)
        {
            string charset = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
                chars[i] = charset[random.Next(0, charset.Length)];
            return new string(chars);
        }
        static void Main(string[] args)
        {
            var userdata = new List<UserDetails>();
            int page = 0,uid=0;

            //For User
            string ufname = "", ulname = "", password = "", ucontact = "";
            string question = "", answer = "",checkans="";
            string rsetpassword="", newpasswd="",confpasswd="";
            bool loginstatus = false;
            //For Container
            string nestpage="";

            while (true)
            {
                Console.WriteLine("1. Login \n2. Registration\n4. Exit\nProvide your Input: ");
                page =Convert.ToInt32(Console.ReadLine());
                if (page == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Provide UserID: ");
                    ucontact = Console.ReadLine();
                    Console.WriteLine("Provide Password: ");
                    password = Console.ReadLine();
                    for (int i = 0; i < userdata.Count; i++)
                    {
                        if (userdata[i].Mobile == ucontact && userdata[i].Password == password)
                        {
                            Console.Clear();
                            loginstatus = true;
                            Console.WriteLine("Login Successfully!\n");
                            ufname = userdata[i].FirstName;
                            ulname = userdata[i].LastName;
                            uid = userdata[i].Id;
                            question = userdata[i].Question;
                            answer = userdata[i].Answer;
                            Console.WriteLine("\n1. Container Booking\n2. Exit");
                            nestpage=Console.ReadLine();
                            if (nestpage == "1")
                            {

                            }
                            else if (nestpage == "2")
                            {
                                break;
                            }
                        }
                    }
                    if (!loginstatus)
                    {
                        Console.Clear();
                        Console.WriteLine("Provide Proper Details!");
                    }
                    else
                    {
                        Console.WriteLine("Full Name:{0} {1}\nContact: {2}", ufname, ulname, ucontact);
                        Console.WriteLine("\nWant to Reset Password? [1]");
                        if (Console.ReadLine() == "1")
                        {
                            Console.Clear();
                            Console.Write("{0}\n Provide Your Answer:", question);
                            checkans = Console.ReadLine();
                            if (answer == checkans)
                            {
                                Console.Clear();
                                Console.WriteLine("Provide Current Password: ");
                                rsetpassword = Console.ReadLine();
                                Console.WriteLine("Provide New Password: ");
                                newpasswd = Console.ReadLine();
                                Console.WriteLine("Provide Confirm Password: ");
                                confpasswd = Console.ReadLine();
                                if (password == rsetpassword)
                                {
                                    if (confpasswd == newpasswd)
                                    {
                                        userdata[uid - 1].Password = newpasswd;
                                        Console.Clear();
                                        Console.WriteLine("Password Reset Succussfully");
                                        newpasswd = password = confpasswd = answer = question = null;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Password Reset Unsuccessfull");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Your Current Password is Wrong! Kindly Check");
                                }
                            }
                            else
                            {
                                Console.Write("Wrong Answer!");
                            }
                        }
                        Console.WriteLine("\nWant to Go to Main Menu? [Y]");

                        if (Console.ReadLine() == "Y")
                        {
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else if (page == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Provide FirstName: ");
                    ufname = Console.ReadLine();
                    Console.WriteLine("Provide LastName: ");
                    ulname = Console.ReadLine();
                    Console.WriteLine("Provide Mobile Number: ");
                    ucontact = Console.ReadLine();
                    Console.WriteLine("Provide Question: ");
                    question = Console.ReadLine();
                    Console.WriteLine("Provide Answer: ");
                    answer = Console.ReadLine();
                    password = getpassword();
                    userdata.Add(new UserDetails() { Id = ++uid, FirstName = ufname, LastName = ulname, Mobile = ucontact, Password = password, Question = question, Answer = answer });
                    Console.Clear();
                    Console.WriteLine("Your Genarated Password: {0}", password);
                    ufname = ulname = password = ucontact = null;

                    Console.WriteLine("\n User Registration Successfully!!!");
                    Console.WriteLine("\n Want to Go to Main Menu? [Y]");

                    if (Console.ReadLine() == "Y")
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (page == 4)
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nProvide Proper Input!");
                }
            }
        }
    }
}
