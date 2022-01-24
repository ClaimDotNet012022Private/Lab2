using System.IO;
using ClaimLab2.ClassStuff;
using ClaimLab2.TextMenu;
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
        
        
        
    }
}