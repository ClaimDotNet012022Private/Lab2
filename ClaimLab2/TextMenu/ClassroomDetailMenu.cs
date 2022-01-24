using System;
using System.Collections.Generic;
using System.IO;
using ClaimLab2.ClassStuff;

namespace ClaimLab2.TextMenu
{
    public class ClassroomDetailMenu : AbstractTextMenu
    {
        protected override List<MenuItem> MenuItems { get; }
        protected override string HeaderText { get; }
        
        private readonly Classroom _classroom;

        
        
        public ClassroomDetailMenu(Classroom classroom, TextReader inputReader = null) 
            : base(inputReader)
        {
            _classroom = classroom;
            HeaderText = $"Classroom Details: {_classroom.Name}";
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Show Students", ShowStudents),
                new MenuItem("Add Student", AddStudent),
                new MenuItem("Remove Student", RemoveStudent),
                new MenuItem("Return to main menu", Quit),
            };
        }

        public Student GetStudent(string name)
        {
            return _classroom.GetStudent(name);
        }

        public MenuResult ShowStudents()
        {
            List<string> summaries = _classroom.GetStudentSummaries();

            if (summaries.Count == 0)
            {
                Console.WriteLine("There are no students to show.");
            }

            foreach (string summary in summaries)
            {
                Console.WriteLine(summary);
                Console.WriteLine();
            }

            return MenuResult.Continue;
        }

        public MenuResult AddStudent()
        {
            bool success;

            do
            {
                Console.WriteLine("Please enter the name of the student to add:");
                string name = InputReader.ReadLine();
                success = _classroom.TryAddStudent(name);

                if (!success)
                {
                    Console.WriteLine($"'{name}' is invalid or already exists.");
                }
            } while (!success);

            return MenuResult.Continue;
        }

        public MenuResult RemoveStudent()
        {
            if (!_classroom.HasStudents())
            {
                Console.WriteLine("There are no students to remove.");
                return MenuResult.Continue;
            }
            
            bool success;

            do
            {
                Console.WriteLine("Please enter the name of the student to remove:");
                string name = InputReader.ReadLine();
                success = _classroom.TryRemoveStudent(name);

                if (!success)
                {
                    Console.WriteLine($"'{name}' is invalid or does not exist.");
                }
            } while (!success);

            return MenuResult.Continue;
        }
        
    }
}