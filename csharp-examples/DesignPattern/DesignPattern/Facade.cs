using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Facade: Very Complex Sub System
//Writing a Interface for a larger body of code

namespace DesignPattern
{
    internal class Facade
    {
        public void Main()
        {
            var Computer = new ComputerFacade(new Computer());
            Computer.TurnOn();
            Console.WriteLine();
            Computer.TurnOff();
            Console.ReadKey();
        }
    }
    class Computer
    {
        public void GetElectricShock()
        {
            Console.WriteLine("OUCHHH!");
        }
        public void MakeSound()
        {
            Console.WriteLine("Beep Beep");
        }
        public void ShowScreen()
        {
            Console.WriteLine("Loading...");
        }
        public void Closeeverything()
        {
            Console.WriteLine("Closing...");
        }
    }

    class ComputerFacade
    {
        private readonly Computer mComputer;
        public ComputerFacade(Computer computer)
        {
            this.mComputer = computer??throw new ArgumentNullException("Computer","Computer can not be Null");
        }
        public void TurnOn()
        {
            mComputer.GetElectricShock();
            mComputer.MakeSound();
            mComputer.ShowScreen();
        }
        public void TurnOff()
        {
            mComputer.Closeeverything();
        }
    }
}
