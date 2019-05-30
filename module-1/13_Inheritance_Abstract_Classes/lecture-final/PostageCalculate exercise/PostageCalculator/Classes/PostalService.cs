using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public abstract class PostalService : IDeliveryDriver
    {
        public double CalculateRate(int distance, double weight)
        {
            // Declare a place to hold the rate per mile that we will lookup in the table
            decimal ratePerMile = 0;
            List<WeightRate> rates = GetRatesTable();
            // Loop through the rates tables and find the first entry with a weight > our package weight
            foreach (WeightRate weightRate in rates)
            {
                if (weight <= weightRate.WeightInOunces)
                {
                    ratePerMile = weightRate.RatePerMile;
                    break;
                }
            }

            // Multiple rate per mile times the distance to get the total rate
            return ((double)ratePerMile) * distance;
        }

        protected abstract List<WeightRate> GetRatesTable();

    }
}
