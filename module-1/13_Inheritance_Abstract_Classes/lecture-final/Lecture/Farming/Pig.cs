using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public Pig(decimal weight, decimal price) : base("PIG")
        {
            this.Weight = weight;
            this.Price = price;
        }

        public decimal Weight { get; set; }
        public decimal Price { get; set; }

        public override string MakeSoundOnce()
        {
            return "OINK";
        }

        public override string MakeSoundTwice()
        {
            return "OINK OINK";
        }

        public void Sell()
        {
            Console.WriteLine($"\r\nThis pig sold for {this.Price}\r\n");
        }
    }
}
