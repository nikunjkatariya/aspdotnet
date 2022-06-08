using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralDesignPatterns
{
    abstract class Account
    {
        protected Account successor;
        protected int balance;
        public void setNext(Account accnt)
        {
            this.successor= accnt;
        }

        public void pay(float amountToPay)
        {
            if (canPay(amountToPay)){
                Console.WriteLine("Paid {0} using {1}",amountToPay);
            }
/*            else if (this.successor)
            {

            }*/
            else
            {
                Console.WriteLine("Cannot Pay");
            }
        }
        public bool canPay(float amount)
        {
            return this.balance >= amount;
        }
    }

    class Bank : Account
    {
        protected float Balance;
        public Bank(float balance)
        {
            Balance = balance;
        }
    }
    class PayPal : Account
    {
        protected float Balance;
        public PayPal(float balance)
        {
            Balance = balance;
        }
    }
    class Bitcoin : Account
    {
        protected float Balance;
        public Bitcoin(float balance)
        {
            Balance= balance;
        }
    }
    internal class ChainofResponsibility
    {
        public void Main()
        {
            Bank bank= new Bank(100);
            PayPal payPal = new PayPal(200);
            Bitcoin bitcoin = new Bitcoin(300);

            bank.setNext(payPal);
            bank.setNext(bitcoin);
            bank.pay(259);
        }
    }
}
