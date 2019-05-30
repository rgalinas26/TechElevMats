using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal, ISellable
    {
        public Chicken(decimal weight, decimal price) : base("CHICKEN")
        {
            this.Weight = weight;
            this.Price = price;
        }

        public decimal Weight { get; set; }
        public decimal Price { get; set; }

        public override string MakeSoundOnce()
        {
            return "CLUCK";
        }

        public override string MakeSoundTwice()
        {
            return "CLUCK CLUCK";
        }

        public void Sell()
        {
            Console.WriteLine();
            Console.WriteLine($"This chicken sold for {this.Price}" );
            Console.WriteLine();
        }
    }
}
