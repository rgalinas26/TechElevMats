using System;
using System.IO;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //double slow = PerformanceDemo.SlowPerformance();
            //double fast = PerformanceDemo.FastPerformance();
            //Console.WriteLine($"It took approx. {Math.Round(slow / fast, 0)} times as long to do it the SLOW way.");


            // Create a file in the local folder to write result to
            string outPath = "folders.txt";

            using (StreamWriter sw = new StreamWriter(outPath, false))
            {
                // Get a list of folders from a directory on disk
                string path = @"C:\GIT";
                DirectoryInfo dir1 = new DirectoryInfo(path);

                // First, write the top-level folder
                sw.WriteLine($"The folders under the path {dir1.FullName} are:");

                // Find all the folders in this folder
                foreach (DirectoryInfo dir2 in dir1.EnumerateDirectories())
                {
                    sw.WriteLine(dir2.FullName);
                }

                // Write this folder name to the text file


                // Go one level deeper

                // Write this folder name to the text file
            }


            // The file is now closed.  We can open it again for append to add more lines
            using (StreamWriter sw = new StreamWriter(outPath, true))
            {
                sw.WriteLine();
                sw.WriteLine("And that's all I have to say about that.");
            }

                Console.ReadLine();
        }
    }
}
