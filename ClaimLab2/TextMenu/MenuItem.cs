using System;

namespace ClaimLab2.TextMenu
{
    public class MenuItem
    {
        public string Description { get; }
        public Func<MenuResult> Action { get; }

        public MenuItem(string description, Func<MenuResult> action)
        {
            Description = description;
            Action = action;
        }
    }
}