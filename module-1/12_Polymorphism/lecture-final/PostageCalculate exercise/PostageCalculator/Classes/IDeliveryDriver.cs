using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public interface IDeliveryDriver
    {
        double CalculateRate(int distance, double weight);
    }
}
