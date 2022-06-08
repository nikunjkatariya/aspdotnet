using System;
using System.IO;
using System.Threading;

namespace FileExistConsolApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string dirpath = @"D:\EDITransactions\Transactions";
                string targetpath = @"D:\EDITransactions\Completed";
                string[] FileNames = Directory.GetFiles(dirpath,"*.txt");
                foreach (string file in FileNames)
                {
                    Console.WriteLine(file+" "+Path.GetFileName(file));
                }
                Thread.Sleep(1000);
                if (FileNames.Length != 0)
                {
                    string SourcePath = targetpath + "\\" + Path.GetFileName(FileNames[0]);
                    System.IO.File.Move(FileNames[0], SourcePath);
                }
            }
        }
    }
}
