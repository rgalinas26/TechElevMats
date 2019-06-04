using System;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            double slow = PerformanceDemo.SlowPerformance();
            double fast = PerformanceDemo.FastPerformance();
            Console.WriteLine($"It took approx. {Math.Round(slow / fast, 0)} times as long to do it the SLOW way.");


            // Create a file in the local folder to write result to


            // Get a list of folders from a directory on disk


            // First, write the top-level folder


            // Find all the folders in this folder


            // Write this folder name to the text file


            // Go one level deeper

            // Write this folder name to the text file



            // The file is now closed.  We can open it again for append to add more lines

            Console.ReadLine();
        }
    }
}
