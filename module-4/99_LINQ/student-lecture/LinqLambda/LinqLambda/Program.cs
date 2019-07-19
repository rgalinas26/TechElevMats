using LinqLambda.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLambda
{
    class Program
    {
        static List<Person> People = new List<Person>()
        {
            new Person("Bobby", 27, 71),
            new Person("Tyler", 23, 72),
            new Person("El", 26, 60),
            new Person("Jesse", 29, 78),
            new Person("Chris", 29, 74),
            new Person("Sirrena", 24, 71),
            new Person("John S", 42, 70),
            new Person("Jacob", 23, 70),
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(
@"
    1 - Display List RAW
    2 - Sort by Name
    3 - Sort by Name DESC
    4 - Map Person to something else
    5 - Filter by Height
    6 - Get a Count of tall people
    7 - Get the sum of all Heights
    8 - Get the product of all ages
    9 - Get a concatenation of all namess
    Q - Quit
Please make a selection:
");
                IEnumerable<Object> listToPrint = null;
                string key = Console.ReadLine();
                if (key.Length == 0)
                {
                    continue;
                }
                Console.Clear();
                switch (key.Substring(0, 1).ToUpper())
                {
                    case "Q":
                        return;
                    case "1":
                        listToPrint = People;
                        break;
                    case "2":   // Sort by Name
                        Console.WriteLine("NOT YET IMPLEMENTED!!");
                        break;
                    case "3":   // Sort by Name DESC
                        Console.WriteLine("NOT YET IMPLEMENTED!!");
                        break;
                    case "4":   // Select
                        listToPrint = MapHeightToString();
                        break;
                    case "5":
                        listToPrint = FilterByHeight(PromptForMinHeight());
                        break;
                    case "6":
                        int n = PromptForMinHeight();
                        int count = GetCountOfTallPeople(n);
                        Console.WriteLine($"There are {count} people taller than {n} inches.");
                        break;
                    case "7": // add up the heights
                        int totalHeight = GetSumOfHeights();
                        Console.WriteLine($"Total Height is {totalHeight}");
                        break;

                    case "8": // product of ages
                        long product = GetProductOfAges();
                        Console.WriteLine($"Product of ages is {product}");
                        break;

                    case "9": // Concatenate names
                        Console.WriteLine("NOT YET IMPLEMENTED!!");
                        //string longName = People.Aggregate("", (accum, p) => { return accum + ((accum.Length == 0) ? "" : "_") + p.Name; });
                        //Console.WriteLine($"Names aggregated: {longName}");
                        break;

                }
                if (listToPrint != null)
                {
                    PrintList(listToPrint);
                }

            }
        }

        static IEnumerable<Person> FilterByHeight(int minHeight)
        {
            // Filter by height
            List<Person> list = new List<Person>();
            foreach (Person p in People)
            {
                if (p.Height > minHeight)
                {
                    list.Add(p);
                }
            }
            return list;
        }

        static IEnumerable<string> MapHeightToString()
        {
            List<string> list = new List<string>();
            foreach (Person p in People)
            {
                string s = MapPersonToString(p);
                list.Add(s);
            }
            return list;
        }

        static string MapPersonToString(Person p)
        {
            return $"{p.Name} is {p.Height / 12} feet {p.Height % 12} inches tall.";
        }

        static int GetCountOfTallPeople(int minHeight)
        {
            // Get a count of people taller than minHeight
            int count = 0;
            foreach (Person p in People)
            {
                if (p.Height > minHeight)
                {
                    count++;
                }
            }
            return count;
        }

        static int GetSumOfHeights()
        {
            // Get the length of people end-to-end
            int sum = 0;
            foreach (Person p in People)
            {
                sum += p.Height;
            }
            return sum;
        }

        static long GetProductOfAges()
        {
            // Get the length of people end-to-end
            long product = 1;
            foreach (Person p in People)
            {
                product *= p.Height;
            }
            return product;

            //return People.Aggregate(1, (accum, p) => { return accum * p.Age; });

        }

        #region Utility Functions
        /// <summary>
        /// Utility to loop through a list and print it
        /// </summary>
        /// <param name="list"></param>
        static void PrintList(IEnumerable<Object> list)
        {
            Console.WriteLine();
            Console.WriteLine(Person.Heading());
            foreach (Object obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        static int PromptForMinHeight()
        {
            int minHeight;
            do
            {
                Console.Write("\tTaller than (how many inches)? ");
            } while (!int.TryParse(Console.ReadLine(), out minHeight));
            return minHeight;
        }

        #endregion

    }
}
