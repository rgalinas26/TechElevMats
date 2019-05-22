using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Person / Height Database");
            Console.WriteLine();

            //Console.Write("Would you like to enter another person (yes/no)? ");
            string input = "yes";

            // 1. Let's create a new Dictionary that could hold string, ints
            //      | "Josh"    | 70 |
            //      | "Bob"     | 72 |
            //      | "John"    | 75 |
            //      | "Jack"    | 73 |

            Dictionary<string, int> nameHeight = new Dictionary<string, int>()
            // Add some test data as started data
            {
                {"Mike", 71 },
                {"Bobby", 70 },
                {"Adam", 68 },
            };


            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Check to see if that name is in the dictionary
                //      bool exists = dictionaryVariable.ContainsKey(key)
                bool exists = nameHeight.ContainsKey(name);

                if (exists)
                {
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    //      dictionaryVariable[key] = value;
                    nameHeight[name] = height;
                }
                else   // The name does not yet exist in the dictionary
                {
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary
                    //      dictionaryVariable[key] = value;
                    //      OR dictionaryVariable.Add(key, value);
                    nameHeight.Add(name, height);

                    // (the other way we could have done this is...
                    // nameHeight[name] = height;

                }
                


                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //5. Let's get a specific name from the dictionary
                if (nameHeight.ContainsKey(input))
                {
                    Console.WriteLine($"{input} is {nameHeight[input]} inches tall.");
                }
                else  // This name does not exist
                {
                    Console.WriteLine($"Sorry, we could not find {input} in the database.");
                }

            }
            else if (input == "all")
            {
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Let's print each item in the dictionary
                foreach( KeyValuePair<string, int> person in nameHeight)
                {
                    Console.WriteLine($"{person.Key} is {person.Value} inches tall");
                }

            }

            //7. Let's get the average height of the people in the dictionary
            int sumHeights = 0;
            foreach (KeyValuePair<string, int> person in nameHeight)
            {
                sumHeights += person.Value;
            }
            double averageHeight = ((double)sumHeights) / nameHeight.Count;

            Console.WriteLine($"The average height of the class is {averageHeight}");

            Console.WriteLine();
            Console.WriteLine("Done...");

            Console.ReadLine();
        }

        static void PrintDictionary(Dictionary<string, int> database)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
        }
    }
}
