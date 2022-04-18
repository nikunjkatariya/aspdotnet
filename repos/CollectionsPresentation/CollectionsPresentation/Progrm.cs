using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPresentation
{
    internal class Progrm
    {
        static void main()
        {
            Queue ts = new Queue();
            ts.Enqueue(1);
            ts.Enqueue('a');
            ts.Enqueue(3);
            ts.Enqueue("ABC");
            foreach (var item in ts)
            {
                Console.Write(item+" ");
            }
            ts.Dequeue();
            Console.WriteLine();
            foreach (var item in ts)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(ts.Peek());
            Console.WriteLine(ts.Contains('a'));



            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);
        }
        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("{0}", obj);  
            Console.WriteLine();
        }
    }
}
