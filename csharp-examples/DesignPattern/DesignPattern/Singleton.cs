using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class Singleton
    {
        public static void SingletonMain(string[] args)
        {
 /*           President biden = President.GetInstance();
            President trump = President.GetInstance();
            Console.WriteLine(biden==trump);
*/        }
    }
    public class President
    {
/*        static President;*/
        private President()
        {

        }
/*        public static President GetInstance()
        {
            if(instance == null)
            {
                instance = new President();
            }
            return instance();
        }*/
    }
}
