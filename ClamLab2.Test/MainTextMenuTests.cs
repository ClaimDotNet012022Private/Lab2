using System;
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
        
        [TestMethod]
        public void Test_AddClassroom_ReturnsContinue()
        {
            // Arrange
            StringReader testInput = new StringReader(@"TestValue1
");
            MenuResult expectedResult = MenuResult.Continue;
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            MenuResult actual = target.AddClassroom();

            // Assert
            Assert.AreEqual(expectedResult, actual);
            
            
            
            testInput.Dispose();
        }
        
        
        
        
        [TestMethod]
        public void Test_RemoveClassroom_EmptyList_MethodReturns()
        {
            // Arrange
            StringReader testInput = new StringReader(@"");
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.RemoveClassroom();

            // No Assert.
            // If the test ends, it succeeds.
            // If the test runs forever (waiting for user input) or throws an exception, it fails.
            // To see the test instead of running forever, we would need threads, which we aren't covering.


            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveClassroom_ValidInput_ClassIsRemoved()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            StringReader testInput = new StringReader($@"{inputName1}
{inputName2}
{inputName3}
{removeName}
");

            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            target.AddClassroom();
            target.RemoveClassroom();
            ClassRoom actual = target.GetClassRoom(removeName);

            // Assert
            Assert.IsNull(actual);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveClassroom_ValidInput_OtherClassroomsNotRemoved()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            StringReader testInput = new StringReader($@"{inputName1}
{inputName2}
{inputName3}
{removeName}
");
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            target.AddClassroom();
            target.RemoveClassroom();
            ClassRoom actual1 = target.GetClassRoom(inputName1);
            ClassRoom actual3 = target.GetClassRoom(inputName3);

            // Assert
            Assert.IsNotNull(actual1);
            Assert.AreEqual(inputName1, actual1.Name);
            Assert.IsNotNull(actual3);
            Assert.AreEqual(inputName3, actual3.Name);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveClassroom_IncorrectName_NoException()
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
{removeName1}
{removeName2}
");
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            target.AddClassroom();
            target.RemoveClassroom();

            // No Assert. An exception will fail the test.
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveClassroom_ValidInput_ReturnsContinue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            StringReader testInput = new StringReader($@"{inputName1}
{inputName2}
{inputName3}
{removeName}
");
            MenuResult expectedResult = MenuResult.Continue;
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            target.AddClassroom();
            MenuResult actual = target.RemoveClassroom();

            // Assert
            Assert.AreEqual(expectedResult, actual);
            
            
            
            testInput.Dispose();
        }
        
        [TestMethod]
        public void Test_RemoveClassroom_EmptyList_ReturnsContinue()
        {
            // Arrange
            StringReader testInput = new StringReader($@"TestValue
");
            MenuResult expectedResult = MenuResult.Continue;
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            MenuResult actual = target.RemoveClassroom();

            // Assert
            Assert.AreEqual(expectedResult, actual);
            
            
            
            testInput.Dispose();
        }
        
        
        
        
        
        [TestMethod]
        public void Test_ShowClassrooms_ShowsClassroomNames()
        {
            // This test requires more complex setup because we need to
            // capture the results of Console.Write()/Console.WriteLine().
            // That alone makes things strange, but there's the added twist
            // of not being able to use Console.Clear() while the console
            // is redirected. So we have to be careful about when we
            // redirect to a TextWriter and when we set it back to normal.
            
            // This test might not be possible because of the Console.Clear()
            // issue. And if it is possible, future changes might make it
            // impossible. So this test might end up getting removed.
            
            // Arrange
            string expectedName1 = "TestValue1";
            string expectedName2 = "TestValue2";
            string expectedName3 = "TestValue3";
            StringReader testInput = new StringReader($@"{expectedName1}
{expectedName2}
{expectedName3}
");
            TextWriter originalConsoleOut = Console.Out;
            StringWriter testOutput = new StringWriter(); // Set this up, but don't use it yet.
            MainTextMenu target = new MainTextMenu(testInput);

            // Act
            target.AddClassroom();
            target.AddClassroom();
            target.AddClassroom();
            Console.SetOut(testOutput); // Redirect the output after all the classrooms are added
            target.ShowClassrooms();
            Console.SetOut(originalConsoleOut); // Set output back to normal
            testOutput.Flush();
            string actual = testOutput.GetStringBuilder().ToString();   // Magic incantation to get the output as a string

            // Assert
            Assert.IsTrue(actual.Contains(expectedName1));
            Assert.IsTrue(actual.Contains(expectedName2));
            Assert.IsTrue(actual.Contains(expectedName3));
            
            
            testOutput.Dispose();
            testInput.Dispose();
        }
    }
}