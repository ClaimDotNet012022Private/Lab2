using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ClaimLab2
{
    public class MainTextMenu : AbstractTextMenu
    {
        protected override List<MenuItem> MenuItems { get; }
        protected override string HeaderText { get; } = "Classroom Grade Manager 2.0";

        private readonly Dictionary<string, ClassRoom> _classRooms;


        public MainTextMenu(TextReader inputReader = null) : base(inputReader)
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Add Classroom", AddClassroom),
                new MenuItem("Remove Classroom", RemoveClassroom),
                new MenuItem("Exit Application", Quit)
            };

            _classRooms = new Dictionary<string, ClassRoom>();
        }

        public ClassRoom GetClassRoom(string name)
        {
            bool hasKey = _classRooms.TryGetValue(name, out ClassRoom result);
            if (hasKey)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public MenuResult AddClassroom()
        {
            bool succeeded;

            do
            {
                Console.WriteLine("Please enter the name of the classroom to add:");
                string className = InputReader.ReadLine();

                succeeded = _classRooms.TryAdd(className, new ClassRoom(className));

                if (!succeeded)
                {
                    Console.WriteLine($"'{className}' already exists or is an invalid name.");
                }
            } while (!succeeded);

            return MenuResult.Continue;
        }

        public MenuResult RemoveClassroom()
        {
            // Don't want to get stuck asking the user for a class if
            // there isn't any class to remove.
            if (_classRooms.Count == 0)
            {
                Console.WriteLine("There are no classrooms to remove.");
                return MenuResult.Continue;
            }
            
            bool succeeded;

            do
            {
                Console.WriteLine("Please enter the name of the classroom to add:");
                string className = InputReader.ReadLine();

                succeeded = _classRooms.Remove(className);
                
                if (!succeeded)
                {
                    Console.WriteLine($"'{className}' does not exist.");
                }
            } while (!succeeded);

            return MenuResult.Continue;
        }
        
        public MenuResult Quit()
        {
            Console.Write("Exiting... ");
            return MenuResult.End;
        }
    }
}