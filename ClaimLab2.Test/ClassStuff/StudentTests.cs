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
    }
}