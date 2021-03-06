using System;
using System.Collections.Generic;
using System.IO;
using ClaimLab2.ClassStuff;

namespace ClaimLab2.TextMenu
{
    public class StudentDetailMenu : AbstractTextMenu
    {

        protected override List<MenuItem> MenuItems { get; }
        protected override string HeaderText { get; }

        private readonly Student _student;
        
        public StudentDetailMenu(Student student, TextReader inputReader = null) 
            : base(inputReader)
        {
            _student = student;

            HeaderText = $"Student Details: {student.Name}";

            MenuItems = new List<MenuItem>
            {
                new MenuItem("Show Summary", ShowSummary),
                new MenuItem("Assign ", AddAssignment),
                new MenuItem("Unassign", RemoveAssignment),
                new MenuItem("Show Assignments", ShowAssignments),
                new MenuItem("Grade Assignment", GradeAssignment),
                new MenuItem("Show Best Grade", ShowBestGrade),
                new MenuItem("Show Worst Grade", ShowWorstGrade),
                new MenuItem("Return to Classroom Details", Quit),
            };
        }

        // GetAssignment is only used for testing.
        // It is not used anywhere in the project.
        public Assignment GetAssignment(string name)
        {
            return _student.GetAssignment(name);
        }

        public MenuResult AddAssignment()
        {
            bool isValid;
            do
            {
                Console.WriteLine("Please enter the name of the assignment:");
                string name = InputReader.ReadLine();
                isValid = _student.TryAddAssignment(name);

                if (!isValid)
                {
                    Console.WriteLine($"'{name}' already exists or is invalid.");
                }
            } while (!isValid);

            return MenuResult.Continue;
        }

        public MenuResult RemoveAssignment()
        {
            ShowAssignments();
            
            if (_student.GetAssignmentCount() == 0)
            {
                return MenuResult.Continue;
            }

            bool isValid;
            do
            {
                Console.WriteLine("Please enter the name of the assignment to remove:");
                string name = InputReader.ReadLine();
                isValid = _student.TryRemoveAssignment(name);

                if (!isValid)
                {
                    Console.WriteLine($"'{name}' is invalid or does not exist.");
                }
            } while (!isValid);

            return MenuResult.Continue;
        }

        public MenuResult GradeAssignment()
        {
            ShowAssignments();
            
            if (_student.GetAssignmentCount() == 0)
            {
                return MenuResult.Continue;
            }
            
            bool isValid;
            do
            {
                Console.WriteLine("Please enter the name of the assignment to grade:");
                string name = InputReader.ReadLine();
                Console.WriteLine("Please enter the grade:");
                string gradeString = InputReader.ReadLine();

                bool isGradeParsed = double.TryParse(gradeString, out double grade);
                if (isGradeParsed)
                {
                    isValid = _student.TryGradeAssignment(name, grade);
                }
                else
                {
                    Console.WriteLine($"'{gradeString}' is not a valid grade.");
                    isValid = false;
                }

                if (isGradeParsed && !isValid)
                {
                    Console.WriteLine($"'{name}' is not valid or does not exist.");
                }
            } while (!isValid);

            return MenuResult.Continue;
        }

        public MenuResult ShowSummary()
        {
            Console.WriteLine(_student.GetSummary());
            return MenuResult.Continue;
        }

        public MenuResult ShowAssignments()
        {
            List<string> assignments = _student.ListAssignmentSummaries();
            if (assignments.Count == 0)
            {
                Console.WriteLine("There are no assignments.");
            }

            foreach (string assignment in assignments)
            {
                Console.WriteLine(assignment);
            }

            return MenuResult.Continue;
        }

        public MenuResult ShowBestGrade()
        {
            string bestSummary = _student.GetBestAssignmentSummary();

            if (bestSummary is null)
            {
                bestSummary = "There are no graded assignments";
            } 
            
            Console.WriteLine(bestSummary);

            return MenuResult.Continue;
        }
        
        public MenuResult ShowWorstGrade()
        {
            string worstSummary = _student.GetWorstAssignmentSummary();

            if (worstSummary is null)
            {
                worstSummary = "There are no graded assignments";
            } 
            
            Console.WriteLine(worstSummary);

            // Null-coalescing operator:
            //string best = _student.GetBestAssignmentSummary() ?? "There are no graded assignments";
            //Console.WriteLine(best);

            return MenuResult.Continue;
        }

    }
}