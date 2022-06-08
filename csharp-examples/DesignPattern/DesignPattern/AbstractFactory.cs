using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    interface Idoor
    {
        void GetDescription();
    }
    class WoodenDoor : Idoor
    {
        public void GetDescription()
        {
            Console.WriteLine("Wooden Door"); 
        }
    }
    class IronDoor : Idoor
    {
        public void GetDescription()
        {
            Console.WriteLine("Iron Door");
        }
    }
    interface IDoorExpert
    {
        void GetDescription();
    }
    class WoodenDoorExpert : IDoorExpert
    {
        public void GetDescription()
        {
            Console.WriteLine("Wooden Door Expert");
        }
    }
    class IronDoorExpert : IDoorExpert
    {
        public void GetDescription()
        {
            Console.WriteLine("Iron Door Expert");
        }
    }

    interface IDoorFactory
    {
        Idoor MakeDoor();
        IDoorExpert DoorExpert();
    }
    class WoodenDoorFactory : IDoorFactory
    {
        public IDoorExpert DoorExpert()
        {
            return new WoodenDoorExpert();
        }

        public Idoor MakeDoor()
        {
            return new WoodenDoor(); ;
        }
    }
}
