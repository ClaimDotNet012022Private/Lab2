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
                new MenuItem("Top Student", ShowTopStudent),
                new MenuItem("Bottom Student", ShowBottomStudent),
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

            StudentCompareResult result = _classroom.CompareStudents(name1, name2);

            switch (result)
            {
                case StudentCompareResult.StudentNotFound:
                    Console.WriteLine("One or both students does/do not exist.");
                    break;
                case StudentCompareResult.NoAverageGrade:
                    Console.WriteLine("One or both students has/have no average grade.");
                    break;
                case StudentCompareResult.LessThan:
                    Console.WriteLine($"{name2} has the higher grade.");
                    break;
                case StudentCompareResult.Equal:
                    Console.WriteLine($"{name1} and {name2} have the same grade.");
                    break;
                case StudentCompareResult.GreaterThan:
                    Console.WriteLine($"{name1} has the higher grade.");
                    break;
                default:    // Only hit the default if we forgot an enum value.
                    Console.WriteLine("An unexpected error occurred");
                    break;
            }

            return MenuResult.Continue;
        }

        public MenuResult ShowTopStudent()
        {
            Student bestStudent = _classroom.GetBestStudent();
            
            // The ?. is null-conditional member access. It's like
            // normal member access (just using .), but it doesn't
            // throw an exception if bestStudent is null.
            string bestName = bestStudent?.Name;

            if (bestName is null)
            {
                Console.WriteLine("There is no student with a grade");
            }
            else
            {
                Console.WriteLine($"{bestName} is the top student");
            }
            
            // // Equivalent using a ternary operator (Note, this is just two
            // // statements. The first is split onto 3 lines for legibility):
            // string message = (bestName is null)
            //     ? "There is no student with a grade"
            //     : $"{bestName} is the top student";
            // Console.WriteLine(message);

            return MenuResult.Continue;
        }
        
        public MenuResult ShowBottomStudent()
        {
            Student worstStudent = _classroom.GetWorstStudent();
            
            // The ?. is null-conditional member access.
            string worstName = worstStudent?.Name;
            
            // Ternary operator:
            //     condition ? value-if-true : value-if-false
            string message = (worstName is null)
                ? "There is no student with a grade"
                : $"{worstName} is the bottom student";
            Console.WriteLine(message);

            return MenuResult.Continue;
        }
    }
}