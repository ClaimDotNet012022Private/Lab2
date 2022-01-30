using System.Collections.Generic;
using ClaimLab2.ClassStuff;
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
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);

            // Act
            bool actual = target.TryAddStudent(inputName3);

            // Assert
            Assert.IsFalse(actual);
        }
        
        
        
        
        [TestMethod]
        public void Test_TryRemoveStudent_EmptyList_ReturnsFalse()
        {
            // Arrange
            Classroom target = new Classroom("TestClass");

            // Act
            bool actual = target.TryRemoveStudent("DoesNotExist");

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_TryRemoveStudent_DoesNotExist_ReturnsFalse()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = "DoesNotExist";
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);

            // Act
            bool actual = target.TryRemoveStudent(removeName);

            // Assert
            Assert.IsFalse(actual);
        }
        
        [TestMethod]
        public void Test_TryRemoveStudent_ValidInput_StudentIsRemoved()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);

            // Act
            target.TryRemoveStudent(removeName);
            Student actual = target.GetStudent(removeName);

            // Assert
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void Test_TryRemoveStudent_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string removeName = inputName2;
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);

            // Act
            bool actual = target.TryRemoveStudent(removeName);

            // Assert
            Assert.IsTrue(actual);
        }
        
        
        
        
        
        [TestMethod]
        public void Test_GetStudentSummaries_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            int expected = 0;
            Classroom target = new Classroom("TestClass");

            // Act
            List<string> summaries = target.GetStudentSummaries();
            int actual = summaries.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Test_GetStudentSummaries_NonEmptyList_ReturnsCorrectLength()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            int expected = 3;
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            
            // Act
            List<string> summaries = target.GetStudentSummaries();
            int actual = summaries.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        
        
        
        
        [TestMethod]
        public void Test_CompareStudents_StudentDoesNotExist_ReturnsStudentNotFound()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string compareName1 = inputName1;
            string compareName2 = "DoesNotExist";
            StudentCompareResult expected = StudentCompareResult.StudentNotFound;
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            
            // Act
            StudentCompareResult actual = target.CompareStudents(compareName1, compareName2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Test_CompareStudents_NoGrade_ReturnsNoAverageGrade()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string compareName1 = inputName1;
            string compareName2 = inputName3;
            StudentCompareResult expected = StudentCompareResult.NoAverageGrade;
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            
            // Act
            StudentCompareResult actual = target.CompareStudents(compareName1, compareName2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Test_CompareStudents_FirstHasLowerGrade_ReturnsLessThan()
        {
            // This "Arrange" step is getting pretty involved. This is
            // a place where mocking and dependency injection could be
            // useful. Either that, or it's a sign that I'm violating the
            // Single Responsibility rule, and CompareStudents should
            // belong somewhere else. More likely the latter.
            // (Even if the core logic of the method is moved somewhere
            // else, it still needs to be exposed through ClassRoom to
            // avoid violating the Law of Demeter. The ClassRoom Details
            // menu goes through Classroom for everything - it doesn't
            // manipulate the Classroom's students directly. But if
            // the core logic is more easily testable, then we can
            // remove this test and have less of a gap in coverage.
            // Or with dependency injection and mocks, we could just
            // have one Classroom method test that simply verifies
            // that the core logic method gets called with the right
            // parameters.)
            
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string compareName1 = inputName1;
            string compareName2 = inputName3;
            double grade1_1 = 20;
            double grade1_2 = 100; // Avg 60, max 100
            double grade2_1 = 93;
            double grade2_2 = 87;  // Avg 90, max 93
            StudentCompareResult expected = StudentCompareResult.LessThan;   // Left side has lower max but higher avg
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            Student student1 = target.GetStudent(compareName1);
            student1.TryAddAssignment(inputName1);
            student1.TryAddAssignment(inputName2);
            student1.TryAddAssignment(inputName3);
            student1.TryGradeAssignment(inputName1, grade1_1);
            student1.TryGradeAssignment(inputName2, grade1_2);
            Student student2 = target.GetStudent(compareName2);
            student2.TryAddAssignment(inputName1);
            student2.TryAddAssignment(inputName2);
            student2.TryAddAssignment(inputName3);
            student2.TryGradeAssignment(inputName3, grade2_1);
            student2.TryGradeAssignment(inputName2, grade2_2);
            
            // Act
            StudentCompareResult actual = target.CompareStudents(compareName1, compareName2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Test_CompareStudents_FirstHasHigherGrade_ReturnsGreaterThan()
        {
            // (Same notes about the Arrange step here as above)
            
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string compareName1 = inputName1;
            string compareName2 = inputName3;
            double grade2_1 = 20;
            double grade2_2 = 100; // Avg 60, max 100
            double grade1_1 = 93;
            double grade1_2 = 87;  // Avg 90, max 93
            StudentCompareResult expected = StudentCompareResult.GreaterThan;   // Right side has lower max but higher avg
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            Student student1 = target.GetStudent(compareName1);
            student1.TryAddAssignment(inputName1);
            student1.TryAddAssignment(inputName2);
            student1.TryAddAssignment(inputName3);
            student1.TryGradeAssignment(inputName1, grade1_1);
            student1.TryGradeAssignment(inputName2, grade1_2);
            Student student2 = target.GetStudent(compareName2);
            student2.TryAddAssignment(inputName1);
            student2.TryAddAssignment(inputName2);
            student2.TryAddAssignment(inputName3);
            student2.TryGradeAssignment(inputName3, grade2_1);
            student2.TryGradeAssignment(inputName2, grade2_2);
            
            // Act
            StudentCompareResult actual = target.CompareStudents(compareName1, compareName2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Test_CompareStudents_SameAverage_ReturnsEqual()
        {
            // (Same notes about the Arrange step here as above)
            
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            string compareName1 = inputName1;
            string compareName2 = inputName3;
            double grade1_1 = 23.7;
            double grade1_2 = 99.8; // Avg 61.75, max 99.8
            double grade2_1 = 72.1;
            double grade2_2 = 51.4;  // Avg 61.75, max 51.4
            StudentCompareResult expected = StudentCompareResult.Equal;   // Individual grades are different but average is the same
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            Student student1 = target.GetStudent(compareName1);
            student1.TryAddAssignment(inputName1);
            student1.TryAddAssignment(inputName2);
            student1.TryAddAssignment(inputName3);
            student1.TryGradeAssignment(inputName1, grade1_1);
            student1.TryGradeAssignment(inputName2, grade1_2);
            Student student2 = target.GetStudent(compareName2);
            student2.TryAddAssignment(inputName1);
            student2.TryAddAssignment(inputName2);
            student2.TryAddAssignment(inputName3);
            student2.TryGradeAssignment(inputName3, grade2_1);
            student2.TryGradeAssignment(inputName2, grade2_2);
            
            // Act
            StudentCompareResult actual = target.CompareStudents(compareName1, compareName2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}