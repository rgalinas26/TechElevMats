using System;
using System.IO;

namespace FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region File and Directory objects

            // Print out the current working directory
            string path = "";

            //path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(".");

            Console.WriteLine(path);

            // List the folders in the folder that holds the solution file (up 3 from here)
            path = @"..\..\..";
            string[] dirs = Directory.GetDirectories(path);
            Console.WriteLine($"The folders inside path {path} are:");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine("=========================");


            // List the files in that folder
            string[] files = Directory.GetFiles(path);
            Console.WriteLine($"The files inside path {path} are:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("=========================");

            // Get a DirectoryInfo object for the Files folder

            // Use the Path object to append the Files folder
            path = Path.Combine(path, "Files");

            // List the files in that directory
            files = Directory.GetFiles(path);
            Console.WriteLine($"The files inside path {path} are:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("=========================");

            // Get a FileInfo for the Declaration.txt file
            path = Path.Combine(path, "Declaration.txt");
            FileInfo fileInfo = new FileInfo(path);

            // Display file information
            Console.WriteLine($"The file {fileInfo.FullName}, size = {fileInfo.Length}, was created on {fileInfo.CreationTime}.");

            #endregion

            #region Reading a text file

            // Read the file in one chunk and display to the screen
            //using (StreamReader sr = new StreamReader(path))
            //{
            //    // Read it all
            //    string body = sr.ReadToEnd();
            //    Console.WriteLine(body);
            //}

            // Read the file in line-by-line, and number each line on the screen
            int lineNumber = 1;
            int count = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    // Count the number of line on which "free" shows up in the text
                    string line = sr.ReadLine();
//                    Console.WriteLine($" {lineNumber: 000} {line}");
                    if (line.Contains("free", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine($"'free' appears on line {lineNumber}");
                        count++;
                    }
                    lineNumber++;

                }
            }

            Console.WriteLine($"The word 'free' appears in {count} lines in the text.");


            #endregion

            Console.ReadKey();
        }


    }
}
