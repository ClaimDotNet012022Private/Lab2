using System.Collections.Generic;
using System.IO;

namespace ClaimLab2
{
    public class ClassroomDetailMenu : AbstractTextMenu
    {
        protected override List<MenuItem> MenuItems { get; }
        protected override string HeaderText { get; }
        
        private readonly ClassRoom _classroom;

        
        
        public ClassroomDetailMenu(ClassRoom classroom, TextReader inputReader = null) 
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