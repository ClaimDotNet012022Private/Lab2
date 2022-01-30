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
                new MenuItem("Student Details", OpenStudentDetailMenu),
                new MenuItem("Compare Students", CompareStudents),
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

        public MenuResult OpenStudentDetailMenu()
        {
            if (!_classroom.HasStudents())
            {
                Console.WriteLine("There are no students.");
                return MenuResult.Continue;
            }

            Student student;
            do
            {
                Console.WriteLine("Please enter the student's name:");
                string name = InputReader.ReadLine();
                student = _classroom.GetStudent(name);
                if (student is null)
                {
                    Console.WriteLine($"'{name}' is not a student.");
                }
            } while (student is null);

            StudentDetailMenu newMenu = new StudentDetailMenu(student, InputReader);
            newMenu.DoMenuLoop();

            return MenuResult.Continue;
        }

        public MenuResult CompareStudents()
        {
            Console.WriteLine("Please enter the name of the first student to compare:");
            string name1 = InputReader.ReadLine();
            
            Console.WriteLine("Please enter the name of the second student to compare:");
            string name2 = InputReader.ReadLine();

            string result = _classroom.CompareStudents(name1, name2);
            
            Console.WriteLine(result);

            return MenuResult.Continue;
        }
    }
}