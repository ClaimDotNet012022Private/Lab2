using System.IO;
using ClaimLab2.ClassStuff;
using ClaimLab2.TextMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimLab2.Test.TextMenu
{
    [TestClass]
    public class ClassroomDetailMenuTests
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
        
        
        
        
        
        [TestMethod]
        public void Test_RemoveStudent_ValidInput_StudentIsRemoved()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName3;
            StringReader testInput = new StringReader($@"{inputName1}
{inputName2}
{inputName3}
{removeName}
");
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            target.AddStudent();
            target.AddStudent();
            target.AddStudent();
            target.RemoveStudent();
            Student actual = target.GetStudent(removeName);

            // Assert
            Assert.IsNull(actual);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveStudent_ValidInput_ReturnsContinue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName3;
            StringReader testInput = new StringReader($@"{inputName1}
{inputName2}
{inputName3}
{removeName}
");
            MenuResult expected = MenuResult.Continue;
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            target.AddStudent();
            target.AddStudent();
            target.AddStudent();
            MenuResult actual = target.RemoveStudent();

            // Assert
            Assert.AreEqual(expected, actual);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveStudent_DoesNotExist_ReturnsContinue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName1 = "DoesNotExist";
            string removeName2 = inputName1;
            StringReader testInput = new StringReader($@"{inputName1}
{inputName2}
{inputName3}
{removeName1}
{removeName2}
");
            MenuResult expected = MenuResult.Continue;
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            target.AddStudent();
            target.AddStudent();
            target.AddStudent();
            MenuResult actual = target.RemoveStudent();

            // Assert.
            Assert.AreEqual(expected, actual);
            
            
            testInput.Dispose();
        }
        
        
        
        [TestMethod]
        public void Test_ShowTopStudent_NoStudents_ReturnsContinueWithNoException()
        {
            // If we're not careful, it would be easy for this method
            // to throw a NullReferenceException, which we don't want.
            
            // Arrange
            StringReader testInput = new StringReader("");
            MenuResult expected = MenuResult.Continue;
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            MenuResult actual = target.ShowTopStudent();

            // Assert. If an exception was thrown, the test already failed.
            Assert.AreEqual(expected, actual);
            
            
            testInput.Dispose();
        }
        
        
        
        [TestMethod]
        public void Test_ShowBottomStudent_NoStudents_ReturnsContinueWithNoException()
        {
            // If we're not careful, it would be easy for this method
            // to throw a NullReferenceException, which we don't want.
            
            // Arrange
            StringReader testInput = new StringReader("");
            MenuResult expected = MenuResult.Continue;
            Classroom classroom = new Classroom("TestClass");
            ClassroomDetailMenu target = new ClassroomDetailMenu(classroom, testInput);

            // Act
            MenuResult actual = target.ShowBottomStudent();

            // Assert. If an exception was thrown, the test has already failed.
            Assert.AreEqual(expected, actual);
            
            
            testInput.Dispose();
        }
    }
}