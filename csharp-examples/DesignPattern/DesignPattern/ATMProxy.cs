using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class ATMProxy
    {
        public void Main()
        {
            var ATM = new ATMMachine(new Bank());
            ATM.OpenAC("1234");
            ATM.CloseAC();
        }
    }

    interface IMachine
    {
        void ScanATM();
        void OpenAC();
        void MoneyTransfer();
        void CloseAC();
    }

    class Bank : IMachine
    {
        public void CloseAC()
        {
            Console.WriteLine("ATM has been Removed!");
        }

        public void MoneyTransfer()
        {
            Console.WriteLine("Money Withdraw");
        }

        public void OpenAC()
        {
            Console.WriteLine("You Got Access to Your Bank!");
        }
        public void ScanATM()
        {
            Console.WriteLine("Scanning...");
        }
    }

    class ATMMachine : IMachine
    {
        private IMachine mMachine;
        public ATMMachine(IMachine machine)
        {
            mMachine = machine??throw new ArgumentNullException("ATM","ATM pin Should be Entered!");
        }
        public void CloseAC()
        {
            mMachine.CloseAC();
        }
        public void OpenAC(string password)
        {
            mMachine.ScanATM();
            if (Authenticate(password))
            {
                mMachine.OpenAC();
                mMachine.MoneyTransfer();
            }
            else
            {
                Console.WriteLine("We are Happy to let you know that We are Calling Cops for your Better journey to Jail!");
            }
        }
        private bool Authenticate(string password)
        {
            return password == "1234";
        }
        public void ScanATM(){ }
        public void MoneyTransfer() { }
        public void OpenAC(){ }
    }
}
