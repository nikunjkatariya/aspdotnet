using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyFifthDayApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File Reading with Different Fields
            /*string path = @"C:\Users\raytex\source\repos\csharp-examples\MyFifthDayApp\MyFifthDayApp\records.txt";
            StreamReader sr = new StreamReader(path);
            string line;
            char seprator = ',';

            var student = new List<StudentData>();

            while ((line = sr.ReadLine()) != null)
            {
                string[] strlist = line.Split(seprator);
                student.Add(new StudentData() { Id = strlist[2], Name = strlist[0], CollegeName = strlist[1] });
            }
            sr.Close();
            foreach (StudentData s in student)
                Console.WriteLine("{0} {1} {2}",s.Id,s.Name,s.CollegeName);*/

            //EDI File Reading Operation
            /*string ediX12path = @"D:\Major Project\Files Shared By Swaroop\03_ShipmentStatus.txt";

            IDictionary<int, string[]> ediY12 = new Dictionary<int, string[]>();

            StreamReader sr = new StreamReader(ediX12path);
            string line;
            int count = 0;
            //char[] seprator = { '~','*' };
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
               {
//                    Console.Write(line);
                    if (line[i] == '~')
                    {
                        Console.WriteLine();
                    }
                }
            //    string[] strlist = line.Split(seprator[0]);
            //    ediY12.Add(++count, strlist);
            }*/
            string ediX12path = @"D:\testedi.txt";
            StreamReader sr = new StreamReader(ediX12path);
            string data = sr.ReadToEnd();
            sr.Close();
            string[] value = data.Split('*');

            string sender = value[0];
            for (int v = 0; v < value.Length; v++)
            {
                if (value[v].Contains("GS"))
                {
                    Console.WriteLine("12345");
                    continue;
                }
                Console.WriteLine(value[v]);
            }
                sr.Close();
        }
        public class StudentData
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string CollegeName { get; set; }
        }
    }
}
