using System.IO;
using ClaimLab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClamLab2.Test
{
    [TestClass]
    public class MainTextMenuTests
    {
        [TestMethod]
        public void Test_AddClassroom_ValidInput_ClassIsAdded()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            string expectedName = "TestValue1";
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            ClassRoom actual = target.GetClassRoom(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_AddClassroom_MultipleInputs_AllClassesAreAdded()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
TestValue2
TestValue3");
            string expectedName1 = "TestValue1";
            string expectedName2 = "TestValue2";
            string expectedName3 = "TestValue3";
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            target.AddClassroom();
            ClassRoom actual1 = target.GetClassRoom(expectedName1);
            ClassRoom actual2 = target.GetClassRoom(expectedName2);
            ClassRoom actual3 = target.GetClassRoom(expectedName3);

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
        public void Test_AddClassroom_DuplicateName_NoException()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
TestValue1
TestValue1
TestValue2");
            string expectedName = "TestValue1";
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            
            ClassRoom actual = target.GetClassRoom(expectedName);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.Name);
            
            
            
            testInput.Dispose();
        }
    }
}