using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralDesignPatterns
{
    interface IChatRoomMediator
    {
        void ShowMessage(User user, string message);
    }

    class ChatRoom: IChatRoomMediator
    {
        public void ShowMessage(User user, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("MMMM dd, H:mm")} [{user.GetName()}]:{message}");
        }
    }
    class User
    {
        private string mName;
        private IChatRoomMediator mChatRoom;
        public User(string name, IChatRoomMediator chatRoom)
        {
            mChatRoom = chatRoom;
            mName = name;
        }
        public string GetName()
        {
            return mName;
        }
        public void Send(string message)
        {
            mChatRoom.ShowMessage(this, message);
        }
    }
    internal class MediatorDP
    {
        public void Main()
        {
            var mediator= new ChatRoom();
            var james = new User("James",mediator);
            var Jp = new User("Jp", mediator);
            james.Send("Hi There!");
            Jp.Send("Hey!");
        }
    }
}
