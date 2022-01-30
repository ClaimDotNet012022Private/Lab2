using System.Collections.Generic;

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

        public string CompareStudents(string name1, string name2)
        {
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
                return "One or both students does/do not exist";
            }

            // If stu1 - stu2 > 0, then stu1 > stu2 
            double difference = student1.GetAverageGrade() - student2.GetAverageGrade();
            
            // Can't use switch because we're not looking for specific values.
            // Math.Sign() can convert to specific values (-1, 0, 1), but throws
            // an exception if difference is NaN. So just use a ladder/chain of
            // if/else if.
            if (double.IsNaN(difference))
            {
                return "One or both students has/have no average grade.";
            }
            else if (difference < 0.0)
            {
                return $"{name2} has the higher grade.";
            }
            else if (difference == 0.0)
            {
                return $"{name1} and {name2} have the same grade.";
            }
            else
            {
                return $"{name1} has the higher grade.";
            }
            
        }
    }
}