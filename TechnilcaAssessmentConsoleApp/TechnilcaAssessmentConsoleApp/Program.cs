using System;
using System.Collections;
using System.Collections.Generic;

namespace TechnilcaAssessmentConsoleApp
{
    internal class Program
    {

        public class InvalidName:Exception
        {
            public InvalidName(string message): base(message) { }
        }
        static void Main(string[] args)
        {
            bool Status = true; //Boolean
            
            char Charone= 'A'; // Char
            
            int Num = 123; // Integer

            //string Name = "John"; //String 

            dynamic Value = 123; //Integer
            Value = "Mosh"; //String


            /*            if (Number < 10)
                        {
                            Console.WriteLine("Less Than 10");
                        }
                        else if(Number > 10 && Number < 100)
                        {
                            Console.WriteLine("Avrage");
                        }
                        else
                        {
                            Console.WriteLine("More Than 100");
                        }*/

            /*            switch (Number)
                        {
                            case 10:
                                Console.WriteLine("Ten");
                                break;
                            default:
                                Console.WriteLine("Value Required");
                                break;
                        }
            */
            /*            string[] Names = {"Mosh", "John", "Jonothon" };*/

            List<string> Names = new List<string> { "Mosh", "John", "Jonothon" };
/*            string StudnetName = "James";

            try
            {
                if (!Names.Contains(StudnetName))
                {
                    throw new InvalidName($"{StudnetName} is Not Available in Record!");
                }
            }
            catch (InvalidName e)
            {
                Console.WriteLine(e.Message);
            }*/


            /*            int Number = 1;
                        while (Number < 10)
                        {
                            Increment:
                            Number++;
                            if(Number == 5)
                            {
                                goto Increment;
                            }
                            Console.WriteLine(Number);
                        }*/

            /*            int i = 1;
                        while (i <= 5)
                        {
                            Console.WriteLine(i);
                            i++;
                        }*/


            /*            for(int i = 0; i < Names.Length; i++)
                        {
                            Console.WriteLine(Names[i]);
                        }*/
            /*            int a = 10;
                        int b = 0;
                        int sum = 0;
                        try
                        {
                            sum = a / b;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Value cannot be Divided by Zero");
                            sum = a / 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        finally
                        {
                            Console.WriteLine(sum);
                        }*/

            /*            ArrayList al = new ArrayList();
                        al.Add(20);
                        al.Add('a');
                        al.Add("ABC");
                        al.Add(null);
                        al.Add(true);
                        al.Add(10.20);

                        int[] ar = { 10, 20, 30 };
                        al.AddRange(ar);//To Add array inside the Arraylist
                        Console.WriteLine(al.Count);//Gives Length
                        al.RemoveAt(0);
                        al.Remove(10);
                        Console.WriteLine(al.Contains(30));//return true if list contains value or not
                        Console.WriteLine(al[0]);//Gives Datatype of integer*/

            /*            Console.WriteLine("\nStack");
                        Stack stack = new Stack();
                        stack.Push(1);
                        stack.Push(2);
                        stack.Push(3);
                        stack.Push(4);
                        foreach (var s in stack)
                            Console.WriteLine(s + ",");

                        Console.WriteLine("POP: "+stack.Pop());
                        Console.WriteLine("PEEK: " + stack.Peek());*/

            /*            Queue queue = new Queue();
                        queue.Enqueue(1);
                        queue.Enqueue(2);
                        queue.Enqueue(3);
                        queue.Enqueue("ABC");
                        foreach (var s in queue)
                            Console.WriteLine(s + ", ");
                        queue.Dequeue();
                        Console.WriteLine("After Dequeue");
                        foreach(var s in queue)
                        {
                            Console.WriteLine(s + ", ");
                        }
                        Console.WriteLine(queue.Contains(3));*/


            /*            Generic<string> Classone = new Generic<string>();
                        Classone.Value = "ABC XYZ";
                        PrintValue(Classone.Value);

                        Generic<int> Classtwo = new Generic<int>();
                        Classtwo.Value = 1234;
                        PrintValue(Classtwo.Value);*/

            Student[] students =new Student[] { 
                new Student {FirstName="Aj", LastName="Bita",Standard=5 },
                new Student {FirstName="Cosmos", LastName="Dell",Standard=8 },
            };

            foreach(var stud in GetStudents())
            {
                Console.WriteLine(stud.FirstName+" "+stud.LastName+" "+stud.Standard);
            }

            IEnumerable<Student> GetStudents()
            {
                return students;
            }
        }

        class Student : IEnumerable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Standard { get; set; }
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        class Generic<T> //Generic Class
        {
            public T Value { get; set; }
        }
        public static void PrintValue<T>(T Value) //Generic Method
        {
            Console.WriteLine(Value.ToString());
        }

    }
}
