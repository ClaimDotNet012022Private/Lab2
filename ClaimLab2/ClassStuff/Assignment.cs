namespace ClaimLab2.ClassStuff
{
    public class Assignment
    {
        public string Name { get; }
        public bool IsComplete { get; set; }
        public double Grade { get; set; }

        public Assignment(string name)
        {
            Name = name;
            IsComplete = false;
            Grade = 0;
        }
    }
}