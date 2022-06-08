using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralDesignPatterns
{
    class Bulb
    {
        public void turnOn()
        {
            Console.WriteLine("Bulb has been lit");
        }
        public void turnOff()
        {
            Console.WriteLine("Darkness");
        }
    }

    interface Command
    {
        public void execute();
        public void undo();
        public void redo();
    }

    class TurnOn : Command
    {
        protected Bulb bulb;
        public TurnOn(Bulb bulb)
        {
            this.bulb = bulb;
        }
        public void execute()
        {
            this.bulb.turnOn();
        }

        public void redo()
        {
            this.execute();
        }

        public void undo()
        {
            this.bulb.turnOff();
        }
    }
    class TurnOff : Command
    {
        protected Bulb bulb;
        public TurnOff(Bulb bulb)
        {
            this.bulb = bulb;
        }
        public void execute()
        {
            this.bulb.turnOff();
        }

        public void redo()
        {
            this.execute();
        }

        public void undo()
        {
            this.bulb.turnOn();
        }
    }
    class RemoteControl
    {
        public void Submit(Command command)
        {
            command.execute();
        }
    }

    internal class CommandDP
    {
        public void Main()
        {
            Bulb bulb = new Bulb();
            var turnOn = new TurnOn(bulb);
            var turnOff = new TurnOff(bulb);
            var remote = new RemoteControl();
            remote.Submit(turnOn);
            remote.Submit(turnOff);
        }
    }
}
