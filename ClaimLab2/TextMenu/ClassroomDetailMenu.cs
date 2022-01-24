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
                new MenuItem("Return to main menu", Quit)
            };
        }

        
    }
}