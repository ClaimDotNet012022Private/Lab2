using System;
using System.Collections.Generic;
using System.IO;

namespace ClaimLab2.TextMenu
{
    public abstract class AbstractTextMenu
    {
        protected abstract List<MenuItem> MenuItems { get; } 
        
        protected abstract string HeaderText { get; }

        protected virtual string PromptText { get; set; } = "Please choose an option listed above:";
        
        protected TextReader InputReader { get; }

        // Derived classes are encouraged to add a default value for inputReader
        // on their own constructors (default to null, which will end up using
        // Console.In), so calling code won't have to specify it. But there is
        // no default here, so that derived classes won't forget to specify it.
        public AbstractTextMenu(TextReader inputReader)
        {
            InputReader = inputReader ?? Console.In;
        }
        

        public virtual void DoMenuLoop()
        {
            MenuResult result;

            do
            {
                DrawMenu();
                int index = GetUserSelectionIndex();
                MenuItem selectedItem = MenuItems[index];
                result = selectedItem.Action();
                if (result == MenuResult.Continue)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
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
        
        public virtual MenuResult Quit()
        {
            return MenuResult.End;
        }
    }
}