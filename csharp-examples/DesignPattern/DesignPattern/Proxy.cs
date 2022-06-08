using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Proxy[Wrapper]: A Class represents the functionality of another Class
//
namespace DesignPattern
{
    internal class Proxy
    {
        public void Main()
        {
            var Door = new SecureDoor(new Lab());
            Door.Open();
            Door.Close();
        }
    }

    interface IProxyDoor
    {
        void Open();
        void Close();
    }
    
    class Lab : IProxyDoor
    {
        public void Open()
        {
            Console.WriteLine("Door is Open");
        }
        public void Close()
        {
            Console.WriteLine("Closing The Door");
        }
    }

    class SecureDoor : IProxyDoor
    {
        private IProxyDoor mDoor;
        public SecureDoor(IProxyDoor door)
        {
            mDoor = door??throw new ArgumentNullException("Door","Door can not be Null!");
        }
        public void Open(string password)
        {
            if (Authenticate(password))
            {
                mDoor.Open();
            }
            else
            {
                Console.WriteLine("No, You are Not Allowed!");
            }
        }

        private bool Authenticate(string password)
        {
            return password == "abcd";
        }
        public void Close()
        {
            mDoor.Close();
        }
        public void Open()
        {
        }
    }
}
