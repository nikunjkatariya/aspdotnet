using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class Taskone
    {
        public static void TaskMain(string[] args)
        {
            IInvoice productone =new InvoiceAreaOne();
            Invoice invoiceone = new Invoice(productone);
            Console.WriteLine(invoiceone.GetProductData()+" "+invoiceone.GetDeliveryBoyData());

            IInvoice producttwo = new InvoiceAreaTwo();
            Invoice invoicetwo = new Invoice(producttwo);
            Console.WriteLine(invoicetwo.GetProductData() + " " + invoicetwo.GetDeliveryBoyData());
        }
    }

    interface IInvoice
    {
        Iproduct AddProduct();
        IproductDelivery DeliveryProduct();
    }

    class InvoiceAreaOne : IInvoice
    {
        public Iproduct AddProduct()
        {
            return new Table();
        }

        public IproductDelivery DeliveryProduct()
        {
            return new AreaOne();
        }
    }
    class InvoiceAreaTwo : IInvoice
    {
        public Iproduct AddProduct()
        {
            return new Board();
        }

        public IproductDelivery DeliveryProduct()
        {
            return new AreaTwo();
        }
    }

    interface Iproduct
    {
        string GetDescription();
    }
    interface IproductDelivery
    {
        string GetPersonName();
    }
    class Table : Iproduct
    {
        public string GetDescription()
        {
            return "Table";
        }
    }
    class Board : Iproduct
    {
        public string GetDescription()
        {
            return "Board";
        }
    }
    class AreaOne : IproductDelivery
    {
        public string GetPersonName()
        {
            return "AreaOne \t 100";
        }
    }
    class AreaTwo : IproductDelivery
    {
        public string GetPersonName()
        {
            return "AreaTwo \t 80";
        }
    }
    class Invoice
    {
        Iproduct Iproduct;
        IproductDelivery IproductDelivery;
        public Invoice(IInvoice invoice)
        {
            Iproduct = invoice.AddProduct();
            IproductDelivery = invoice.DeliveryProduct();
        }
        public string GetProductData()
        {
            return Iproduct.GetDescription();
        }
        public string GetDeliveryBoyData()
        {
            return IproductDelivery.GetPersonName();
        }
    }



    class Chair : Iproduct
    {
        public string GetDescription()
        {
            return "Chair";
        }
    }
    class Stool : Iproduct
    {
        public string GetDescription()
        {
            return "Stool";
        }
    }
    class Projector : Iproduct
    {
        public string GetDescription()
        {
            return "Projector";
        }
    }
    class AreaThree : IproductDelivery
    {
        public string GetPersonName()
        {
            return "AreaThree \t 90";
        }
    }
}
