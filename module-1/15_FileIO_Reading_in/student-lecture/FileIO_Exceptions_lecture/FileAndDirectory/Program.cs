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
            
            Console.WriteLine(path);

            // List the folders in the folder that holds the solution file (up 3 from here)


            // List the files in that folder


            // Get a DirectoryInfo object for the Files folder

            // Use the Path object to append the Files folder

            // List the files in that directory


            // Get a FileInfo for the Declaration.txt file

            // Display file information

            
            #endregion

            #region Reading a text file

            // Read the file in one chunk and display to the screen


            // Read the file in line-by-line, and number each line on the screen

            // Count the number of line on which "free" shows up in the text

            #endregion

            Console.ReadKey();
        }
    }
}
