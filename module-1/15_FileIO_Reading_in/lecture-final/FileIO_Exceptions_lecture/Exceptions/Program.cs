using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of three elements, but try to access beyond the array length

            Console.WriteLine();

            try
            {
                Console.WriteLine("The following cities:");
                string[] cities = { "Cleveland", "Columbus", "Cincinnati" };
                for (int i = 0; i < cities.Length; i++)
                {
                    Console.WriteLine(cities[i]);
                }

                Console.WriteLine("are all in Ohio.");
            }
            catch (IndexOutOfRangeException ex)
            {
                // Flow of control goes here when there is an index problem
                Console.WriteLine("!!! Uh-oh, something went wrong !!!");
                Console.WriteLine($"The error I got was {ex.Message}.  Please contact the help desk for assistance.");
            }
            finally
            {
                Console.WriteLine("...and that's all I have to say about that.");
            }

            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method calls further down the stack
            * Code them from most specific to most general.
            */
            try
            {
                Console.WriteLine("Hey guys, watch this!");
                int result = DoSomethingDangerous(0, 0);
                Console.WriteLine("Wow, that was cool.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Caught a divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops! There was an error of type {ex.GetType()}, message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("...and that's all I have to say about that.");
            }



            Console.ReadKey();
        }

        private static int DoSomethingDangerous(int a, int b)
        {
            // Fix the zero-divide issue by checking and throwing ArgumentOutOfRangeException if zero
            if (b == 0)
            {
                throw new ArgumentException("Argument should not be zero", "b");
            }

            int result = a / b;

            int[] arr = { 1, 2, 3 };
            return arr[3];

        }
    }
}
