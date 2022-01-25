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
        public void Test_AddAssignment_ValidInput_AssignmentIsAdded()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            string expectedName = "TestValue1";
            Student student = new Student("TestStudent");
            StudentDetailMenu target = new StudentDetailMenu(student, testInput);

            // Act
            target.AddAssignment();
            Assignment actual = target.GetAssignment(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddAssignment_ValidInput_AssignmentIsNotComplete()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            string expectedName = "TestValue1";
            Student student = new Student("TestStudent");
            StudentDetailMenu target = new StudentDetailMenu(student, testInput);

            // Act
            target.AddAssignment();
            Assignment actual = target.GetAssignment(expectedName);

            // Assert
            Assert.IsFalse(actual.IsComplete);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddAssignment_MultipleInputs_AllAssignmentsAreAdded()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
TestValue2
TestValue3");
            string expectedName1 = "TestValue1";
            string expectedName2 = "TestValue2";
            string expectedName3 = "TestValue3";
            Student student = new Student("TestStudent");
            StudentDetailMenu target = new StudentDetailMenu(student, testInput);

            // Act
            target.AddAssignment();
            target.AddAssignment();
            target.AddAssignment();
            Assignment actual1 = target.GetAssignment(expectedName1);
            Assignment actual2 = target.GetAssignment(expectedName2);
            Assignment actual3 = target.GetAssignment(expectedName3);

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
        public void Test_AddAssignment_DuplicateName_NoException()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
TestValue1
TestValue1
TestValue2");
            string expectedName = "TestValue1";
            Student student = new Student("TestStudent");
            StudentDetailMenu target = new StudentDetailMenu(student, testInput);

            // Act
            target.AddAssignment();
            target.AddAssignment();
            
            Assignment actual = target.GetAssignment(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddAssignment_ReturnsContinue()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            MenuResult expectedResult = MenuResult.Continue;
            Student student = new Student("TestStudent");
            StudentDetailMenu target = new StudentDetailMenu(student, testInput);

            // Act
            MenuResult actual = target.AddAssignment();

            // Assert
            Assert.AreEqual(expectedResult, actual);
            
            
            
            testInput.Dispose();
        }
        
        
        
        
        
//         [TestMethod]
//         public void Test_RemoveStudent_ValidInput_StudentIsRemoved()
//         {
//             // Arrange
//             string inputName1 = "TestValue1";
//             string inputName2 = "TestValue2";
//             string inputName3 = "TestValue3";
//             string removeName = inputName3;
//             StringReader testInput = new StringReader($@"{inputName1}
// {inputName2}
// {inputName3}
// {removeName}
// ");
//             Student student = new Student("TestStudent");
//             StudentDetailMenu target = new StudentDetailMenu(student, testInput);
//
//             // Act
//             target.AddAssignment();
//             target.AddAssignment();
//             target.AddAssignment();
//             target.RemoveStudent();
//             Student actual = target.GetAssignment(removeName);
//
//             // Assert
//             Assert.IsNull(actual);
//             
//             
//             
//             testInput.Dispose();
//         }
        
//         [TestMethod]
//         public void Test_RemoveStudent_ValidInput_ReturnsContinue()
//         {
//             // Arrange
//             string inputName1 = "TestValue1";
//             string inputName2 = "TestValue2";
//             string inputName3 = "TestValue3";
//             string removeName = inputName3;
//             StringReader testInput = new StringReader($@"{inputName1}
// {inputName2}
// {inputName3}
// {removeName}
// ");
//             MenuResult expected = MenuResult.Continue;
//             Student student = new Student("TestStudent");
//             StudentDetailMenu target = new StudentDetailMenu(student, testInput);
//
//             // Act
//             target.AddAssignment();
//             target.AddAssignment();
//             target.AddAssignment();
//             MenuResult actual = target.RemoveStudent();
//
//             // Assert
//             Assert.AreEqual(expected, actual);
//             
//             
//             
//             testInput.Dispose();
//         }
        
//         [TestMethod]
//         public void Test_RemoveStudent_DoesNotExist_ReturnsContinue()
//         {
//             // Arrange
//             string inputName1 = "TestValue1";
//             string inputName2 = "TestValue2";
//             string inputName3 = "TestValue3";
//             string removeName1 = "DoesNotExist";
//             string removeName2 = inputName1;
//             StringReader testInput = new StringReader($@"{inputName1}
// {inputName2}
// {inputName3}
// {removeName1}
// {removeName2}
// ");
//             MenuResult expected = MenuResult.Continue;
//             Student student = new Student("TestStudent");
//             StudentDetailMenu target = new StudentDetailMenu(student, testInput);
//
//             // Act
//             target.AddAssignment();
//             target.AddAssignment();
//             target.AddAssignment();
//             MenuResult actual = target.RemoveStudent();
//
//             // Assert.
//             Assert.AreEqual(expected, actual);
//             
//             
//             testInput.Dispose();
//         }
    }
}