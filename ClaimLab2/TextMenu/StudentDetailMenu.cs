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
                new MenuItem("Return to Classroom Details", Quit),
            };
        }

    }
}