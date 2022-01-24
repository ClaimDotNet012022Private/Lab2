using System.IO;
using ClaimLab2.ClassStuff;
using ClaimLab2.TextMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimLab2.Test.TextMenu
{
    [TestClass]
    public class StudentDetailMenuTests
    {
        [TestMethod]
        public void Test_AddStudent_ValidInput_StudentIsAdded()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            string expectedName = "TestValue1";
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            target.AddStudent();
            Student actual = target.GetStudent(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddStudent_MultipleInputs_AllStudentsAreAdded()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
TestValue2
TestValue3");
            string expectedName1 = "TestValue1";
            string expectedName2 = "TestValue2";
            string expectedName3 = "TestValue3";
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            target.AddStudent();
            target.AddStudent();
            target.AddStudent();
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
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddStudent_DuplicateName_NoException()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
TestValue1
TestValue1
TestValue2");
            string expectedName = "TestValue1";
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            target.AddStudent();
            target.AddStudent();
            
            Student actual = target.GetStudent(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddStudent_ReturnsContinue()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            MenuResult expectedResult = MenuResult.Continue;
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            MenuResult actual = target.AddStudent();

            // Assert
            Assert.AreEqual(expectedResult, actual);
            
            
            
            testInput.Dispose();
        }
        
    }
}