using Individual.Exercises.Classes;
using System;

namespace Individual.Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeworkAssignment hw;
            // Make sure the constructor works properly to set Properties
            hw = new HomeworkAssignment(200, "Mike");
            Console.WriteLine($"Expected property SubmitterName to be 'Mike', actual value was '{hw.SubmitterName}'");
            Console.WriteLine($"Expected property PossibleMarks to be 200, actual value was '{hw.PossibleMarks}'");

            // Test the 90% is an A
            hw = new HomeworkAssignment(100, "Mike");
            hw.TotalMarks = 90;
            Console.WriteLine($"Expected 90% to be an 'A', actual grade was '{hw.LetterGrade}'");

            // 

            Console.ReadKey();
        }
    }
}
