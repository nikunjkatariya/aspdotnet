using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File Reading with Different Fields

            //EDI File Reading Operation
            string ediX12path = @"D:\Major Project\Files Shared By Swaroop\03_ShipmentStatus.txt";

            IDictionary<int, string[]> ediY12 = new Dictionary<int, string[]>();

            StreamReader sr = new StreamReader(ediX12path);
            string line;
            StringBuilder sb = new StringBuilder();
            //char[] seprator = { '~','*' };
            int j = 0;
            while ((line = sr.ReadLine()) != null)
            { 
                string chars= "";
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '*'|| line[i] == '~')
                    {
                        sb.Append(Convert.ToString(chars));
                        Console.WriteLine(chars);
                        chars = "";
                    }
                    if(line[i] != '*' || line[i] != '~')
                    {
                        chars+=Convert.ToString(line[i]);
                    }
                }
            }
/*            for(int i=0;i<sb.Length;i++)
            {
                Console.WriteLine(sb[i]);
            }*/
            sr.Close();
/*            string l1 = "Nikunj";
            string l2 = "Surat";
            string l3 = Convert.ToString(l1[3])+ Convert.ToString(l2[3]);
            Console.WriteLine(l3);*/
        }
    }
}
