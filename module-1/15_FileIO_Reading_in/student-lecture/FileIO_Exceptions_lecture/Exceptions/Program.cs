using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of three elements, but try to access beyond the array length


            Console.WriteLine();

            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method calls further down the stack
            * Code them from most specific to most general.
            */


            Console.ReadKey();
        }

        private static int DoSomethingDangerous(int a, int b)
        {
            // Fix the zero-divide issue by checking and throwing ArgumentOutOfRangeException if zero



            int result = a / b;

            int[] arr = { 1, 2, 3 };
            return arr[3];

        }
    }
}
