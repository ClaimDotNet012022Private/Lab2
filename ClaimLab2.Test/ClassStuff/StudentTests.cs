using System.Collections.Generic;
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
        
        
        
        
        [TestMethod]
        public void Test_TryRemoveAssignment_EmptyList_ReturnsFalse()
        {
            // Arrange
            Student target = new Student("DUMMY_VALUE");

            // Act
            bool actual = target.TryRemoveAssignment("DoesNotExist");

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_TryRemoveAssignment_DoesNotExist_ReturnsFalse()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = "DoesNotExist";
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            bool actual = target.TryRemoveAssignment(removeName);

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_TryRemoveAssignment_ValidInput_AssignmentIsRemoved()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            target.TryRemoveAssignment(removeName);
            Assignment actual = target.GetAssignment(removeName);

            // Assert
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void Test_TryRemoveAssignment_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            bool actual = target.TryRemoveAssignment(removeName);

            // Assert
            Assert.IsTrue(actual);
        }
        
        
        
        
        [TestMethod]
        public void Test_TryGradeAssignment_EmptyList_ReturnsFalse()
        {
            // Arrange
            double grade = 42;
            Student target = new Student("DUMMY_VALUE");

            // Act
            bool actual = target.TryGradeAssignment("DoesNotExist", grade);

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_TryGradeAssignment_DoesNotExist_ReturnsFalse()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string nameToGrade = "DoesNotExist";
            double grade = 42;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            bool actual = target.TryGradeAssignment(nameToGrade, grade);

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_TryGradeAssignment_ValidInput_AssignmentIsCompleted()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string nameToGrade = inputName2;
            double grade = 42;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            target.TryGradeAssignment(nameToGrade, grade);
            Assignment actual = target.GetAssignment(nameToGrade);

            // Assert
            Assert.IsTrue(actual.IsComplete);
        }
        
        [TestMethod]
        public void Test_TryGradeAssignment_ValidInput_AssignmentHasCorrectGrade()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string nameToGrade = inputName2;
            double expected = 42;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            target.TryGradeAssignment(nameToGrade, expected);
            Assignment actual = target.GetAssignment(nameToGrade);

            // Assert
            Assert.AreEqual(expected, actual.Grade);
        }
        
        [TestMethod]
        public void Test_TryGradeAssignment_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            double grade = 42;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);

            // Act
            bool actual = target.TryGradeAssignment(removeName, grade);

            // Assert
            Assert.IsTrue(actual);
        }
        
        
        
        
        [TestMethod]
        public void Test_GetAverageGrade_NoGradedAssignments_ReturnsNaN()
        {
            // I've chosen to ignore ungraded assignments for the average.
            // That decision affects the existence of this test.
            
            
            // Arrange
            Student target = new Student("DUMMY_VALUE");
            
            

            // Act
            double actual = target.GetAverageGrade();

            // Assert
            Assert.IsTrue(double.IsNaN(actual));
        }
        
        [TestMethod]
        public void Test_GetAverageGrade_ValidInput_ReturnsCorrectAverage()
        {
            // I've chosen to ignore ungraded assignments for the average.
            // That decision affects the outcome of this test.
            
            
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            double grade1 = 42;
            double grade3 = 63;
            double expected = 52.5;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);
            target.TryGradeAssignment(inputName1, grade1);
            target.TryGradeAssignment(inputName3, grade3);
            
            

            // Act
            double actual = target.GetAverageGrade();

            // Assert
            Assert.AreEqual(expected, actual, 0.000001);
        }
        
        
        
        
        [TestMethod]
        public void Test_AreAllAssignmentsComplete_NoAssignments_ReturnsTrue()
        {
            // Arrange
            Student target = new Student("DUMMY_VALUE");

            // Act
            bool actual = target.AreAllAssignmentsComplete();

            // Assert
            Assert.IsTrue(actual);
        }
        
        [TestMethod]
        public void Test_AreAllAssignmentsComplete_No_ReturnsFalse()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            double grade1 = 42;
            double grade3 = 63;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);
            target.TryGradeAssignment(inputName1, grade1);
            target.TryGradeAssignment(inputName3, grade3);
            
            

            // Act
            bool actual = target.AreAllAssignmentsComplete();

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_AreAllAssignmentsComplete_Yes_ReturnsTrue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            double grade1 = 42;
            double grade2 = 42;
            double grade3 = 63;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(inputName1);
            target.TryAddAssignment(inputName2);
            target.TryAddAssignment(inputName3);
            target.TryGradeAssignment(inputName1, grade1);
            target.TryGradeAssignment(inputName2, grade2);
            target.TryGradeAssignment(inputName3, grade3);
            
            

            // Act
            bool actual = target.AreAllAssignmentsComplete();

            // Assert
            Assert.IsTrue(actual);
        }
        
        
        
        
        [TestMethod]
        public void Test_ListAssignmentSummaries_NoAssignments_ReturnsEmpty()
        {
            // Arrange
            int expected = 0;
            Student target = new Student("DUMMY_VALUE");

            // Act
            List<string> actual = target.ListAssignmentSummaries();

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }
        
        
        [TestMethod]
        public void Test_ListAssignmentSummaries_HasAssignments_ReturnsList()
        {
            // Arrange
            int expected = 3;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment("TestValue1");
            target.TryAddAssignment("TestValue2");
            target.TryAddAssignment("TestValue3");

            // Act
            List<string> actual = target.ListAssignmentSummaries();

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }
        
        
        
        
        [TestMethod]
        public void Test_GetBestAssignmentSummary_NoAssignments_ReturnsNull()
        {
            // Arrange
            Student target = new Student("DUMMY_VALUE");

            // Act
            string actual = target.GetBestAssignmentSummary();

            // Assert
            Assert.IsNull(actual);
        }
        
        
        [TestMethod]
        public void Test_GetBestAssignmentSummary_HasAssignments_ReturnsHighestGrade()
        {
            // Arrange
            string name1 = "TestValue1";
            string name2 = "TestValue2";
            string name3 = "TestValue3";
            double grade1 = 72.4;
            double grade3 = 76.7;
            Student target = new Student("DUMMY_VALUE");
            target.TryAddAssignment(name1);
            target.TryAddAssignment(name2);
            target.TryAddAssignment(name3);
            target.TryGradeAssignment(name1, grade1);
            target.TryGradeAssignment(name3, grade3);

            // Act
            string actual = target.GetBestAssignmentSummary();

            // Assert
            Assert.IsTrue(actual.Contains(name3));
            Assert.IsTrue(actual.Contains(grade3.ToString()));
        }
    }
}