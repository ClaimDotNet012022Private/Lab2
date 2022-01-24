using System.Collections.Generic;

namespace ClaimLab2
{
    public class MainTextMenu : AbstractTextMenu
    {
        protected override List<MenuItem> MenuItems { get; }
        protected override string HeaderText { get; } = "Classroom Grade Manager 2.0";

        public MainTextMenu()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Exit Application", Quit)
            };
        }
        
        private MenuResult Quit()
        {
            return MenuResult.End;
        }
    }
}