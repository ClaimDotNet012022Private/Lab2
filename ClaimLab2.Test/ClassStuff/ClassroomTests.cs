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
            // menu goes through Classroom for almost everything - it doesn't
            // manipulate the Classroom's students directly when possible. But if
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
        
        
        
        
        [TestMethod]
        public void Test_GetBestStudent_NoGradedStudent_ReturnsNull()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            
            // Act
            Student actual = target.GetBestStudent();

            // Assert
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void Test_GetBestStudent_ValidInput_ReturnsStudentWithHighestAverage()
        {
            // (Same notes about the Arrange step here as above)
            
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            double grade1_1 = 93;
            double grade1_2 = 87;  // Avg 90, max 93
            double grade2_1 = 20;
            double grade2_2 = 100; // Avg 60, max 100
            string expected = inputName1;   // student1 has lower max but higher avg
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            Student student1 = target.GetStudent(inputName1);
            student1.TryAddAssignment(inputName1);
            student1.TryAddAssignment(inputName2);
            student1.TryAddAssignment(inputName3);
            student1.TryGradeAssignment(inputName1, grade1_1);
            student1.TryGradeAssignment(inputName2, grade1_2);
            Student student2 = target.GetStudent(inputName2);
            student2.TryAddAssignment(inputName1);
            student2.TryAddAssignment(inputName2);
            student2.TryAddAssignment(inputName3);
            student2.TryGradeAssignment(inputName3, grade2_1);
            student2.TryGradeAssignment(inputName2, grade2_2);
            
            // Act
            Student actual = target.GetBestStudent();

            // Assert
            Assert.AreEqual(expected, actual.Name);
        }
        
        
        
        [TestMethod]
        public void Test_GetWorstStudent_NoGradedStudent_ReturnsNull()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            
            // Act
            Student actual = target.GetWorstStudent();

            // Assert
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void Test_GetWorstStudent_ValidInput_ReturnsStudentWithLowestAverage()
        {
            // (Same notes about the Arrange step here as above)
            
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            double grade1_1 = 93;
            double grade1_2 = 87;  // Avg 90, max 93
            double grade2_1 = 20;
            double grade2_2 = 100; // Avg 60, max 100
            string expected = inputName2;   // student1 has lower max but higher avg
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            Student student1 = target.GetStudent(inputName1);
            student1.TryAddAssignment(inputName1);
            student1.TryAddAssignment(inputName2);
            student1.TryAddAssignment(inputName3);
            student1.TryGradeAssignment(inputName1, grade1_1);
            student1.TryGradeAssignment(inputName2, grade1_2);
            Student student2 = target.GetStudent(inputName2);
            student2.TryAddAssignment(inputName1);
            student2.TryAddAssignment(inputName2);
            student2.TryAddAssignment(inputName3);
            student2.TryGradeAssignment(inputName3, grade2_1);
            student2.TryGradeAssignment(inputName2, grade2_2);
            
            // Act
            Student actual = target.GetWorstStudent();

            // Assert
            Assert.AreEqual(expected, actual.Name);
        }
        
        
        
        
        
        [TestMethod]
        public void Test_GetAverageGrade_NoGradedStudent_ReturnsNaN()
        {
            // Arrange
            string inputName1 = "TestValue1";
            string inputName2 = "TestValue2";
            string inputName3 = "TestValue3";
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(inputName1);
            target.TryAddStudent(inputName2);
            target.TryAddStudent(inputName3);
            
            // Act
            double actual = target.GetAverageGrade();

            // Assert
            Assert.IsTrue(double.IsNaN(actual));
        }
        
        [TestMethod]
        public void Test_GetAverageGrade_ValidInput_ReturnsUnweightedAverage()
        {
            // (Same notes about the Arrange step here as above)
            
            // Arrange
            string studentName1 = "TestValue1";
            string studentName2 = "TestValue2";
            string studentName3 = "TestValue3";
            string assignmentName1 = "TestValue1";
            string assignmentName2 = "TestValue2";
            string assignmentName3 = "TestValue3";
            string assignmentName4 = "TestValue4";
            double grade1_1 = 10.0;
            double grade1_2 = 20.0;   // avg1 == 15
            double grade2_1 = 30.0;
            double grade2_2 = 40.0;
            double grade2_3 = 50.0;   // avg2 == 40
            double grade3_1 = 60.0;
            double grade3_2 = 70.0;
            double grade3_3 = 80.0;
            double grade3_4 = 90.0;   // avg3 = 75
            double expected = (15.0 + 40.0 + 75.0) / 3;
            Classroom target = new Classroom("TestClass");
            target.TryAddStudent(studentName1);
            target.TryAddStudent(studentName2);
            target.TryAddStudent(studentName3);
            Student student1 = target.GetStudent(studentName1);
            student1.TryAddAssignment(assignmentName1);
            student1.TryAddAssignment(assignmentName2);
            student1.TryGradeAssignment(assignmentName1, grade1_1);
            student1.TryGradeAssignment(assignmentName2, grade1_2);
            Student student2 = target.GetStudent(studentName2);
            student2.TryAddAssignment(assignmentName1);
            student2.TryAddAssignment(assignmentName2);
            student2.TryAddAssignment(assignmentName3);
            student2.TryGradeAssignment(assignmentName1, grade2_1);
            student2.TryGradeAssignment(assignmentName2, grade2_2);
            student2.TryGradeAssignment(assignmentName3, grade2_3);
            Student student3 = target.GetStudent(studentName3);
            student3.TryAddAssignment(assignmentName1);
            student3.TryAddAssignment(assignmentName2);
            student3.TryAddAssignment(assignmentName3);
            student3.TryAddAssignment(assignmentName4);
            student3.TryGradeAssignment(assignmentName1, grade3_1);
            student3.TryGradeAssignment(assignmentName2, grade3_2);
            student3.TryGradeAssignment(assignmentName3, grade3_3);
            student3.TryGradeAssignment(assignmentName4, grade3_4);
            
            // Act
            double actual = target.GetAverageGrade();

            // Assert
            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}