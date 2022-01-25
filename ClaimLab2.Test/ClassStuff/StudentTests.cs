using ClaimLab2.ClassStuff;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimLab2.Test.ClassStuff
{
    [TestClass]
    public class StudentTests
    {
        
        
        [TestMethod]
        public void Test_GetSummary_IncludesName()
        {
            // Arrange
            string expected = "TestValue1";
            Student target = new Student(expected);

            // Act
            string actual = target.GetSummary();

            // Assert
            Assert.IsTrue(actual.Contains(expected));
        }
        
        
        [TestMethod]
        public void Test_AddAssignment_ValidInput_AssignmentIsAdded()
        {
            // Arrange
            string input = "TestValue1";
            Student target = new Student("DUMMY_VALUE");

            // Act
            target.TryAddAssignment(input);
            Assignment actual = target.GetAssignment(input);

            // Assert
            Assert.IsNotNull(actual);
        }
        
        [TestMethod]
        public void Test_AddAssignment_ValidInput_AssignmentIsNotComplete()
        {
            // Arrange
            string input = "TestValue1";
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(input);

            // Act
            Assignment actual = target.GetAssignment(input);

            // Assert
            Assert.IsFalse(actual.IsComplete);
        }
        
        [TestMethod]
        public void Test_AddAssignment_MultipleAssignments_AssignmentsAreAdded()
        {
            // Arrange
            string input1 = "TestValue1";
            string input2 = "TestValue2";
            string input3 = "TestValue3";
            Student target = new Student("DUMMY_VALUE");

            // Act
            target.TryAddAssignment(input1);
            target.TryAddAssignment(input2);
            target.TryAddAssignment(input3);
            Assignment actual1 = target.GetAssignment(input1);
            Assignment actual2 = target.GetAssignment(input2);
            Assignment actual3 = target.GetAssignment(input3);

            // Assert
            Assert.IsNotNull(actual1);
            Assert.AreEqual(input1, actual1.Name);
            Assert.IsNotNull(actual2);
            Assert.AreEqual(input2, actual2.Name);
            Assert.IsNotNull(actual3);
            Assert.AreEqual(input3, actual3.Name);
        }
        
        [TestMethod]
        public void Test_AddAssignment_ValidInput_ReturnsTrue()
        {
            // Arrange
            string input = "TestValue1";
            Student target = new Student("DUMMY_VALUE");

            // Act
            bool actual = target.TryAddAssignment(input);

            // Assert
            Assert.IsTrue(actual);
        }
        
        [TestMethod]
        public void Test_AddAssignment_DuplicateValue_ReturnsFalse()
        {
            // Arrange
            string input1 = "TestValue1";
            string input2 = "TestValue2";
            string input3 = input2;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(input1);
            target.TryAddAssignment(input2);

            // Act
            bool actual = target.TryAddAssignment(input3);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}