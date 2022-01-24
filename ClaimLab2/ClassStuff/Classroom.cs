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
    }
}