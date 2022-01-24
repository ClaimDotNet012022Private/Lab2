using System;
using System.Collections.Generic;
using System.IO;

namespace ClaimLab2
{
    public abstract class AbstractTextMenu
    {
        protected abstract List<MenuItem> MenuItems { get; } 
        
        protected abstract string HeaderText { get; }

        protected virtual string PromptText { get; set; } = "Please choose an option listed above";
        

        public virtual void DoMenuLoop()
        {
            MenuResult result;

            do
            {
                DrawMenu();
                int index = GetUserSelectionIndex();
                MenuItem selectedItem = MenuItems[index];
                result = selectedItem.Action();
            } while (result == MenuResult.Continue);
        }

        protected virtual void DrawMenu()
        {
            Console.Clear();
            
            if (!string.IsNullOrEmpty(HeaderText))
            {
                Console.WriteLine(HeaderText);
                Console.WriteLine();
            }
            
            for (int i = 0; i < MenuItems.Count; i++)
            {
                // List has index starting at 0, but display starts at 1.
                int displayNumber = i + 1;
                string itemText = MenuItems[i].Description;
                Console.WriteLine($"{displayNumber}: {itemText}");
            }
            
            Console.WriteLine();
        }

        protected virtual int GetUserSelectionIndex()
        {
            bool isValid;
            int selectionIndex;

            do
            {
                Console.WriteLine(PromptText);

                string selectionString = Console.ReadLine();
                bool isInteger = int.TryParse(selectionString, out int selection);

                // List has index starting at 0, but display starts at 1.
                // If the user chooses Option 3, that's actually index 2
                // in the List.
                selectionIndex = selection - 1;
                bool isInRange = (selectionIndex >= 0 && selectionIndex < MenuItems.Count);

                isValid = isInteger && isInRange;
                if (!isValid)
                {
                    Console.Beep();
                    Console.WriteLine($"'{selectionString}' is not one of the available options.");
                    Console.WriteLine();
                }

            } while (!isValid);

            return selectionIndex;
        } 
    }
}