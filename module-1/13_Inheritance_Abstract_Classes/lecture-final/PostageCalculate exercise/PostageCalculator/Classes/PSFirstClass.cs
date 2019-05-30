using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class PSFirstClass : PostalService
    {
        static private List<WeightRate> rates = new List<WeightRate>()
        {
            new WeightRate(2, 0.035M),
            new WeightRate(8, 0.040M),
            new WeightRate(15, 0.047M),
            new WeightRate(48, 0.195M),
            new WeightRate(128, 0.45M),
            new WeightRate(int.MaxValue, 0.50M),
        };

        protected override List<WeightRate> GetRatesTable()
        {
            return rates;
        }

        public override string ToString()
        {
            return "Postal Service (First Class)";
        }
    }
}
