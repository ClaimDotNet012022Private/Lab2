using System.IO;
using ClaimLab2.ClassStuff;
using ClaimLab2.TextMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimLab2.Test.ClassStuff
{
    [TestClass]
    public class ClassroomTests
    {
        
        
        [TestMethod]
        public void Test_TryAddStudent_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            Classroom target = new Classroom("TestClass");

            // Act
            bool actual1 = target.TryAddStudent(inputName1);
            bool actual2 = target.TryAddStudent(inputName2);
            bool actual3 = target.TryAddStudent(inputName3);

            // Assert
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
            Assert.IsTrue(actual3);
        }
        
        
        [TestMethod]
        public void Test_TryAddStudent_ValidInput_StudentIsAdded()
        {
            // Arrange
            string expectedName = "TestValue1";
            Classroom target = new Classroom("TestClass");

            // Act
            target.TryAddStudent(expectedName);
            Student actual = target.GetStudent(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
        }
        
        [TestMethod]
        public void Test_TryAddStudent_MultipleInputs_AllStudentsAreAdded()
        {
            // Arrange
            string expectedName1 = "TestValue1";
            string expectedName2 = "TestValue2";
            string expectedName3 = "TestValue3";
            Classroom target = new Classroom("TestClass");

            // Act
            target.TryAddStudent(expectedName1);
            target.TryAddStudent(expectedName2);
            target.TryAddStudent(expectedName3);
            Student actual1 = target.GetStudent(expectedName1);
            Student actual2 = target.GetStudent(expectedName2);
            Student actual3 = target.GetStudent(expectedName3);

            // Assert
            Assert.IsNotNull(actual1);
            Assert.AreEqual(expectedName1, actual1.Name);
            Assert.IsNotNull(actual2);
            Assert.AreEqual(expectedName2, actual2.Name);
            Assert.IsNotNull(actual3);
            Assert.AreEqual(expectedName3, actual3.Name);
        }
        
        [TestMethod]
        public void Test_TryAddStudent_DuplicateName_ReturnsFalse()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue1";
            Classroom target = new Classroom("TestClass");

            // Act
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            bool actual = target.TryAddStudent(inputName3);

            // Assert
            Assert.IsFalse(actual);
        }
        
        
    }
}