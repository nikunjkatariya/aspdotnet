using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class Builder
    {
        public static void ain(string[] args)
        {
            var burger = new BurgerBuilder(4).AddCheese().AddPepperoni().AddLettuce().Build();
            Console.WriteLine(burger.GetDesc());
        }
    }
    class Burger
    {
        private int msize;
        private bool mcheese;
        private bool mpepperoni;
        private bool mlettuce;
        private bool mtomato;

        public Burger(BurgerBuilder builder)
        {
            this.msize = builder.Size;
            this.mcheese = builder.Cheese;
            this.mpepperoni = builder.Pepperoni;
            this.mlettuce = builder.Lettuce;
            this.mtomato = builder.Tomato;
        }

        public string GetDesc()
        {
            var sb = new StringBuilder();
            sb.Append($"this is {this.msize} inch burger with {this.mcheese},{this.mpepperoni},{this.mlettuce},{this.mtomato}");
            return sb.ToString();
        }
    }
    class BurgerBuilder
    {
        public int Size;
        public bool Cheese;
        public bool Pepperoni;
        public bool Lettuce;
        public bool Tomato;
        public BurgerBuilder(int size)
        {
            this.Size = size;
        }
        public BurgerBuilder AddCheese()
        {
            this.Cheese = true;
            return this;
        }
        public BurgerBuilder AddPepperoni()
        {
            this.Pepperoni = true;
            return this;
        }
        public BurgerBuilder AddLettuce()
        {
            this.Lettuce = true;
            return this;
        }
        public BurgerBuilder AddTomato()
        {
            this.Tomato = true;
            return this;
        }
        public Burger Build()
        {
            return new Burger(this);
        }
    }
}
