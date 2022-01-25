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
                new MenuItem("Add Assignment", AddAssignment),
                new MenuItem("Return to Classroom Details", Quit),
            };
        }

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

    }
}