using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPresentation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*            vehicle<string,string> vehicle = new vehicle<string,string>();
                        vehicle.vehicletype = "car";
                        vehicle.vehicleNumber = "GJ05";
                        Console.WriteLine(vehicle.vehicletype+" "+vehicle.vehicleNumber+" ");

                        vehicle<string, int> vhl = new vehicle<string, int>();
                        vhl.vehicletype = "car";
                        vhl.vehicleNumber = 1235;
                        Console.WriteLine(vhl.vehicletype + " " + vhl.vehicleNumber + " ");*/

            /*            Queue ts = new Queue();
                        ts.Enqueue(1);
                        ts.Enqueue("asd");
                        ts.Enqueue('a');
                        foreach(var item in ts)
                        {
                            Console.WriteLine(item);
                        }
                        ts.Dequeue();
                        foreach (var item in ts)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        Console.WriteLine(ts.Peek());*/

            Stack<string> stack = new Stack<string>();
            stack.Push("cbs");
            stack.Push("asd");
            stack.Push("mimk");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            stack.Pop();
            for(var i=0;i<stack.Count;i++)
            {
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            int[] names = new int[]{ 1, 2, 3, 4};

            IEnumerable enu = new IEnumerable();
            IEnumerable
        }
    }
    class vehicle<type,number>
    {
        public type vehicletype;
        public number vehicleNumber;
    }
}
