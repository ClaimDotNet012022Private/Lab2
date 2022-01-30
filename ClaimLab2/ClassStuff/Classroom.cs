using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaimLab2.ClassStuff
{
    public class Classroom
    {
        public string Name { get; }

        private readonly Dictionary<string, Student> _students = new Dictionary<string, Student>();

        public Classroom(string name)
        {
            Name = name;
        }

        public bool HasStudents()
        {
            return (_students.Count > 0);
        }

        public Student GetStudent(string name)
        {
            bool exists = _students.TryGetValue(name, out Student student);
            if (exists)
            {
                return student;
            }
            else
            {
                return null;
            }
        }

        public bool TryAddStudent(string name)
        {
            bool isNotEmpty = !string.IsNullOrEmpty(name);
            bool success = isNotEmpty && !_students.ContainsKey(name);
            if (success)
            {
                Student newStudent = new Student(name);
                _students.Add(name, newStudent);
            }

            return success;
        }

        public bool TryRemoveStudent(string name)
        {
            return _students.Remove(name);
        }

        public List<string> GetStudentSummaries()
        {
            List<string> summaries = new List<string>();
            foreach (KeyValuePair<string,Student> kvp in _students)
            {
                Student student = kvp.Value;
                string summary = student.GetSummary();
                summaries.Add(summary);
            }

            return summaries;
        }

        public StudentCompareResult CompareStudents(string name1, string name2)
        {
            // The comment below is from my original implementation. In that
            // implementation, I was directly returning the string to display
            // in the menu. That's a clear violation of the Single Responsibility
            // Principle. Returning an enum alleviates some of the pain. (Note,
            // I don't consider an enum to be a "single-use" class, since we're
            // still just returning a single value.)
            
            // I've made a decision to avoid:
            // - Exceptions
            // - out parameters (and ref parameters)
            // - Tuples
            // - What I think of as "single-use" classes (classes defined
            //   just for the purpose of allowing a single specific method
            //   to return several values).
            // This is where that decision becomes painful. I'd prefer to
            // just return the name (and let the menu handle displaying it
            // properly), but there are three separate conditions where
            // that doesn't work:
            // - student doesn't exist
            // - student doesn't have a grade
            // - both students are equal
            // We could represent an error by returning null, but that doesn't
            // distinguish between the various problems.
            
            
            
            bool student1Found = _students.TryGetValue(name1, out Student student1);
            bool student2Found = _students.TryGetValue(name2, out Student student2);
            if (!(student1Found && student2Found))
            {
                return StudentCompareResult.StudentNotFound;
            }

            // If stu1 - stu2 > 0, then stu1 > stu2 
            double difference = student1.GetAverageGrade() - student2.GetAverageGrade();
            
            // Can't use switch because we're not looking for specific values.
            // Math.Sign() can convert to specific values (-1, 0, 1), but throws
            // an exception if difference is NaN. So just use a ladder/chain of
            // if/else if.
            if (double.IsNaN(difference))
            {
                return StudentCompareResult.NoAverageGrade;
            }
            else if (Math.Abs(difference) < 0.0000001)  // Give a small space around zero because floating-point math
            {
                return StudentCompareResult.Equal;
            }
            else if (difference < 0.0)
            {
                return StudentCompareResult.LessThan;
            }
            else
            {
                return StudentCompareResult.GreaterThan;
            }
            
        }

        public Student GetBestStudent()
        {
             Student best = null;
             double bestAvg = double.NegativeInfinity;   // Could also use double.MinValue, but this is more expressive.
            
             foreach (KeyValuePair<string,Student> kvp in _students)
             {
                 Student current = kvp.Value;
                 double currentAvg = current.GetAverageGrade();
            
                 // If currentAvg is NaN, any comparison will return false
                 // (so don't replace best if current doesn't have a grade).
                 // If bestAvg hasn't been changed, any currentAvg that is
                 // a number will be greater (so if current is the first
                 // student with a grade, replace best).
                 // If bestAvg has been changed, then replace best only if
                 // current is better.
                 if (currentAvg > bestAvg)
                 {
                     best = current;
                     bestAvg = currentAvg;
                 }
             }
            
             return best;

            
            
             // // One possible LINQ solution.
             // // We could use Max(), but either Student would need to implement
             // // IComparable<Student>, or we would need an implementation of
             // // IComparer<Student> (the other versions of Max would return the
             // // average grade, not the entire Student object). Max() also throws
             // // an exception if the sequence is empty, so we would need to handle
             // // that. On the other hand, Max() is more efficient than OrderBy(),
             // // and it's more expressive of the intent.
             // // I'm not sure whether OrderBy() and OrderByDescending() handle NaN,
             // // so filter those out using Where().
             // return _students.Values
             //     .Where(s => !double.IsNaN(s.GetAverageGrade()))
             //     .OrderByDescending(s => s.GetAverageGrade())
             //     .FirstOrDefault();
        }
    }
}