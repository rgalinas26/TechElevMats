using System;

namespace PaintCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Paint Calculator 2.0!");

            // Collect the room width from the user
            Console.Write("Enter the width of the room in feet: ");
            string input = Console.ReadLine();
            int width = int.Parse(input);

            // Collect the room length from the user
            Console.Write("Enter the length of the room in feet: ");
            input = Console.ReadLine();
            int length = int.Parse(input);

            // Calculate the total square footage of all the walls.
            const int height = 8;
            int totalSquareFeet = (2 * width * height) + (2 * length * height);

            const int squareFeetPerGallon = 400;
            double gallonsNeeded = ((double)totalSquareFeet) / squareFeetPerGallon;

            gallonsNeeded = Math.Ceiling(gallonsNeeded);

            Console.WriteLine("For a room that is {0} by {1} feet, you need to buy {2} gallons of our premium paint.",
                width, length, gallonsNeeded);

            Console.ReadKey();
        }
    }
}
