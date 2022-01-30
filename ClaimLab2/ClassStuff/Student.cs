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
Average Grade: {GetAverageGrade()}
All Assignments Complete: {AreAllAssignmentsComplete()}
Number of Assignments: {GetAssignmentCount()}";
        }

        public int GetAssignmentCount()
        {
            return _assignments.Count;
        }

        public double GetAverageGrade()
        {
            // Ignore ungraded/incomplete assignments.
            // If there are no graded/complete assignments, then
            // average is NaN (not a number.
            int count = 0;
            double sum = 0;
            foreach (KeyValuePair<string,Assignment> kvp in _assignments)
            {
                Assignment assignment = kvp.Value;
                if (assignment.IsComplete)
                {
                    count++;
                    sum += assignment.Grade;
                }
            }
            
            // // We haven't covered LINQ yet, but this is an alternate solution.
            // // The Select() and DefaultIfEmpty() are there because we have to
            // // handle the possibility of no graded assignments.
            // return _assignments.Values
            //     .Where(a => a.IsComplete)
            //     .Select(a => a.Grade)
            //     .DefaultIfEmpty(Double.NaN)
            //     .Average();

            return sum / count;
            
            
        }

        public bool AreAllAssignmentsComplete()
        {
            foreach (KeyValuePair<string,Assignment> kvp in _assignments)
            {
                if (!kvp.Value.IsComplete)
                {
                    return false;
                }
            }

            return true;

            // LINQ:
            // return _assignments.Values.All(a => a.IsComplete);
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

        public bool TryRemoveAssignment(string name)
        {
            return _assignments.Remove(name);
        }

        public bool TryGradeAssignment(string name, double grade)
        {
            if (!_assignments.TryGetValue(name, out Assignment assignment))
            {
                return false;
            }

            assignment.Grade = grade;
            assignment.IsComplete = true;
            return true;
        }

        public List<string> ListAssignmentSummaries()
        {
            List<string> results = new List<string>();

            foreach (KeyValuePair<string,Assignment> kvp in _assignments)
            {
                results.Add(kvp.Value.GetSummary());
            }
            return results;

            // LINQ version
            // return _assignments.Values
            //     .Select(a => a.GetSummary())
            //     .ToList();
            
        }


        public string GetBestAssignmentSummary()
        {
            Assignment best = null;
            foreach (KeyValuePair<string,Assignment> kvp in _assignments)
            {
                Assignment current = kvp.Value;
                if (current.IsComplete)
                {
                    if (best is null || current.Grade > best.Grade)
                    {
                        best = current;
                    }
                }
            }
            
            if (best is not null)
            {
                return best.GetSummary();
            }
            else
            {
                return null;
            }
            
            // LINQ version. Not tested, but I think it should work.
            // Assignment best = _assignments
            //     .Values
            //     .Where(a => a.IsComplete)
            //     .Aggregate(
            //         (Assignment)null, 
            //         (accum, a) => accum is null || a.Grade > accum.Grade ? a : accum
            //     );
            // return best?.GetSummary();
        }
        
        public string GetWorstAssignmentSummary()
        {
            Assignment worst = null;
            foreach (KeyValuePair<string,Assignment> kvp in _assignments)
            {
                Assignment current = kvp.Value;
                if (current.IsComplete)
                {
                    if (worst is null || current.Grade < worst.Grade)
                    {
                        worst = current;
                    }
                }
            }
            
            if (worst is not null)
            {
                return worst.GetSummary();
            }
            else
            {
                return null;
            }
            
            // LINQ version. Not tested, but I think it should work.
            // Assignment worst = _assignments
            //     .Values
            //     .Where(a => a.IsComplete)
            //     .Aggregate(
            //         (Assignment)null, 
            //         (accum, a) => accum is null || a.Grade < accum.Grade ? a : accum
            //     );
            // return worst?.GetSummary();
        }
    }
}