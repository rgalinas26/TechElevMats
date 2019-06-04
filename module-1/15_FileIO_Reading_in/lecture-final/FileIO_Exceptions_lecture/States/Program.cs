using System;
using System.Collections.Generic;

namespace States
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter a state code (Q to Quit): ");
                string stateCode = Console.ReadLine().ToUpper().Trim();

                if (stateCode == "Q")
                {
                    break;
                }

                string stateName = LookupStateName(stateCode);

                Console.WriteLine($"The name of the state with code '{stateCode}' is {stateName}");
            }

            Console.WriteLine("Thanks for using our awesome program! Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        static public string LookupStateName(string stateCode)
        {
            // Declare and create a dictionary to hold state codes and names
            Dictionary<string, string> stateCodes = new Dictionary<string, string>()
            {
                {"AK", "Alaska" },
                {"AL", "Alabama" },
                {"AR", "Arkansas" },
                {"AZ", "Arizona" },
                {"CA", "California" },
                {"CO", "Colorado" },
                {"CT", "Connecticut" },
            };

            if (stateCodes.ContainsKey(stateCode))
            {
                return stateCodes[stateCode];
            }
            else
            {
                return "Unknown";
            }
        }
    }
}
