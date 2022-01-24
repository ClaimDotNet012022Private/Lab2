using System;
using System.Collections.Generic;
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
                new MenuItem("Classroom Details", OpenClassroomDetailMenu),
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
            bool shouldRemove = PromptForExistingClassroom(out string className);

            if (shouldRemove)
            {
                _classRooms.Remove(className);
            }

            return MenuResult.Continue;
        }


        public MenuResult OpenClassroomDetailMenu()
        {
            bool shouldOpen = PromptForExistingClassroom(out string className);
            if (shouldOpen)
            {
                ClassRoom classroom = _classRooms[className];
                ClassroomDetailMenu detailMenu = new ClassroomDetailMenu(classroom, InputReader);
                detailMenu.DoMenuLoop();
            }
            
            return MenuResult.Continue;
        }
        
        public override MenuResult Quit()
        {
            Console.WriteLine("Exiting... Press any key.");
            Console.ReadKey(true);
            return MenuResult.End;
        }
        
        
        // Returns true if there are any classrooms to prompt for,
        // false otherwise.
        private bool PromptForExistingClassroom(out string className)
        {
            // Don't want to get stuck asking the user for a class if
            // there isn't any class to remove.
            if (_classRooms.Count == 0)
            {
                Console.WriteLine("There are no classrooms.");
                {
                    className = null;
                    return false;
                }
            }

            bool succeeded;
            do
            {
                Console.WriteLine("Please enter the name of a classroom:");
                className = InputReader.ReadLine() ?? "";

                succeeded = _classRooms.ContainsKey(className);
                if (!succeeded)
                {
                    Console.WriteLine($"'{className}' does not exist.");
                }
            } while (!succeeded);

            return true;
        }

    }
}