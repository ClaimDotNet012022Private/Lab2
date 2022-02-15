namespace ClaimLab2.ClassStuff
{
    public class Assignment
    {
        public string Name { get; }
        public bool IsComplete { get; private set; }
        public double Grade { get; private set; }

        public Assignment(string name)
        {
            Name = name;
            IsComplete = false;
            Grade = 0;
        }

        public void SetGrade(double grade)
        {
            Grade = grade;
            IsComplete=true;
        }

        public string GetSummary()
        {
            string completeIndicator = "Incomplete";   // Incomplete
            if (IsComplete)
            {
                completeIndicator = " Completed";    // Complete
            }

            // See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#fixed-point-format-specifier-f
            // 78.9876 -> 78.99
            // 78      -> 78.00
            string formattedGrade = Grade.ToString("F2");
            formattedGrade += '%';
            string paddedGrade = formattedGrade.PadRight(7);
            return $"{paddedGrade} ({completeIndicator}): {Name}";
        }
    }
}