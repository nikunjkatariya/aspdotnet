using System;
using System.IO;
using System.Threading;

namespace EdiFileGathering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string DirPath = @"D:\EDITransactions\Transactions";
                string TargetPath = @"D:\EDITransactions\Completed";
                string[] FileNames = Directory.GetFiles(DirPath, "*.txt");

                if (FileNames.Length != 0)
                {
                    string SourcePath = TargetPath + "\\" + Path.GetFileName(FileNames[0]);
                    System.IO.File.Move(FileNames[0], SourcePath);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
