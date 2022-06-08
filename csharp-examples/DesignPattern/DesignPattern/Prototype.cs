using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Sheep
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Sheep(string name,string category)
        {
            Name = name;
            Category = category;
        }
        public Sheep Clone()
        {
            return MemberwiseClone() as Sheep;
        }
    }
    internal class Prototype
    {
        public void PrototypeMain()
        {
            var original = new Sheep("Dolly", "Mountain");
            Console.WriteLine(original.Name);
            var clone = original.Clone();
            clone.Name = "Daizy";
            Console.WriteLine(clone.Name);
        }
    }
}
