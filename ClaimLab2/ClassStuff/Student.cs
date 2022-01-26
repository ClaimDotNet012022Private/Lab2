using System.Collections.Generic;

namespace ClaimLab2.ClassStuff
{
    public class Student
    {
        private Dictionary<string, Assignment> _assignments;

        public string Name { get; }

        public Student(string name)
        {
            Name = name;
            _assignments = new Dictionary<string, Assignment>();
        }

        public string GetSummary()
        {
            return $@"Name: {Name}
Average Grade: (Not Implemented)
All Assignments Complete: (Not Implemented)
Number of Assignments: (Not Implemented)";
        }

        public Assignment GetAssignment(string name)
        {
            if (_assignments.TryGetValue(name, out Assignment assignment))
            {
                return assignment;
            }

            return null;
        }

        public bool TryAddAssignment(string name)
        {
            if (_assignments.ContainsKey(name))
            {
                return false;
            }
            
            _assignments.Add(name, new Assignment(name));
            return true;
        }
    }
}