using Microsoft.VisualStudio.TestTools.UnitTesting;
using Individual.Exercises.Classes;
namespace Individual.Exercises.Tests
{
    [TestClass]
    public class HomeworkAssignmentTests
    {
        [TestMethod]
        public void WhenCreatingNewAssignment_ShouldSaveConstructorProperties()
        {
            // Arrange
            // No arrangment necessary

            // Act
            // Create a HomeworkAssignment object
            HomeworkAssignment hw = new HomeworkAssignment(80, "Mike");

            // Assert
            Assert.AreEqual("Mike", hw.SubmitterName, "The submitter name was not properly set in the HomeworkAssignment constructor");
            Assert.AreEqual(80, hw.PossibleMarks, "The possible marks property was not properly set in the HomeworkAssignment constructor");
        }

        [TestMethod]
        public void WhenTotalMarksGreaterThanPossibleMarks_ShouldGiveAnA()
        {
            // Arrange
            // Create a new homework assignment
            HomeworkAssignment hw = new HomeworkAssignment(100, "Mike");

            // Act
            // Set the total marks > possible marks
            hw.TotalMarks = 102;

            // Assert
            // Verify that > 100% gives an A
            Assert.AreEqual("A", hw.LetterGrade, 
                "Did not properly assign letter grade A when total marks is greater than possible marks");

        }

        [DataTestMethod]
        [DataRow(0, 0, "Z")]
        [DataRow(100, 90, "A")]
        [DataRow(100, 89, "B")]
        [DataRow(100, -20, "F")]
        [DataRow(100, 59, "F")]
        [DataRow(100, 62, "D")]
        [DataRow(100, 105, "A")]
        [DataRow(100, 75, "C")]
        public void LetterGradeTest(int possibleMarks, int totalMarks, string expectedLetterGrade)
        {
            // Arrange
            // Create a new homework assignment with the proper possible marks
            HomeworkAssignment hw = new HomeworkAssignment(possibleMarks, "TEST");

            // Act
            // Set the total marks
            hw.TotalMarks = totalMarks;

            // Assert
            // Compare the letter grade to the expected letter grade passed in
            Assert.AreEqual(expectedLetterGrade, hw.LetterGrade,
                $"Did not properly set the letter grade to {expectedLetterGrade} for a score of {totalMarks} / {possibleMarks}."
                );
        }
    }
}
