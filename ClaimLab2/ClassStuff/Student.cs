namespace ClaimLab2.ClassStuff
{
    public class Student
    {
        public string Name { get; }

        public Student(string name)
        {
            Name = name;
        }

        public string GetSummary()
        {
            return $@"Name: {Name}
Average Grade: (Not Implemented)
All Assignments Complete: (Not Implemented)
Number of Assignments: (Not Implemented)";
        }
    }
}