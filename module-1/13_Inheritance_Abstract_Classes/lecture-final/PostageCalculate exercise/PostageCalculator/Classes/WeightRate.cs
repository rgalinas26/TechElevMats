using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class WeightRate
    {
        public WeightRate(int weight, decimal rate)
        {
            this.WeightInOunces = weight;
            this.RatePerMile = rate;
        }
        public int WeightInOunces { get; set; }
        public decimal RatePerMile { get; set; }
    }
}
