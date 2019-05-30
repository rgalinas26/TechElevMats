using PostageCalculator.Classes;
using System;
using System.Collections.Generic;

namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Weight: ");
            string input = Console.ReadLine().Trim();
            int weightInOunces = int.Parse(input);

            Console.Write("(P)ounds or (O)unces? ");
            input = Console.ReadLine().Trim().ToUpper();
            if (input == "P")
            {
                weightInOunces *= 16;
            }

            Console.Write("Enter the Distance: ");
            input = Console.ReadLine().Trim();
            int distanceInMiles = int.Parse(input);

            List<IDeliveryDriver> shippingTypes = new List<IDeliveryDriver>();
            shippingTypes.Add(new PSFirstClass());

            foreach (IDeliveryDriver shippingType in shippingTypes)
            {
                
                double rate = shippingType.CalculateRate(distanceInMiles, weightInOunces);

                // .ToString() will be called on the shippingType object in the code below
                Console.WriteLine($"Rate for type {shippingType} is {rate:C}");
            }

            Console.ReadKey();
        }
    }
}
