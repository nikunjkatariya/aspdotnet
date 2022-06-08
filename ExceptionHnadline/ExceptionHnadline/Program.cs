using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHnadline
{
    class UserDefinedException : Exception
    {
        public UserDefinedException(string msg) : base(msg)
        {

        }
    }

    internal class Program
    {
        public static void Calculate(int age)
        {
            if(age <= 18)
            {
                throw new UserDefinedException("Under 18");
            }
            else
            {
                Console.WriteLine("You Pass the Exam!");
            }
        }
        static void Main(string[] args)
        {
            int Age;
            Age = Convert.ToInt32(Console.ReadLine());
            try
            {
                Calculate(Age);
            }
            catch(UserDefinedException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(Age);
        }
    }
}
