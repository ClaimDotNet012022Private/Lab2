using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClaimLab2.ClassStuff;

namespace ClaimLab2.TextMenu
{
    public class MainTextMenu : AbstractTextMenu
    {
        protected override List<MenuItem> MenuItems { get; }
        protected override string HeaderText { get; } = "Classroom Grade Manager 2.0";

        private readonly Dictionary<string, Classroom> _classRooms;


        public MainTextMenu(TextReader inputReader = null) : base(inputReader)
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Show Classrooms", ShowClassrooms),
                new MenuItem("Add Classroom", AddClassroom),
                new MenuItem("Remove Classroom", RemoveClassroom),
                new MenuItem("Classroom Details", OpenClassroomDetailMenu),
                new MenuItem("Exit Application", Quit)
            };

            _classRooms = new Dictionary<string, Classroom>();
        }

        public Classroom GetClassRoom(string name)
        {
            bool hasKey = _classRooms.TryGetValue(name, out Classroom result);
            if (hasKey)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public MenuResult ShowClassrooms()
        {
            if (_classRooms.Count == 0)
            {
                Console.WriteLine("There are no classrooms.");
            }

            foreach (KeyValuePair<string,Classroom> kvp in _classRooms)
            {
                Classroom classroom = kvp.Value;
                Console.WriteLine(classroom.Name);
            }
            Console.WriteLine();

            return MenuResult.Continue;
        }

        public MenuResult AddClassroom()
        {
            bool succeeded;

            do
            {
                Console.WriteLine("Please enter the name of the classroom to add:");
                string className = InputReader.ReadLine();

                succeeded = _classRooms.TryAdd(className, new Classroom(className));

                if (!succeeded)
                {
                    Console.WriteLine($"'{className}' already exists or is an invalid name.");
                }
            } while (!succeeded);

            return MenuResult.Continue;
        }

        public MenuResult RemoveClassroom()
        {
            string className = PromptForExistingClassroom();

            if (className is not null)
            {
                _classRooms.Remove(className);
            }

            return MenuResult.Continue;
        }


        public MenuResult OpenClassroomDetailMenu()
        {
            string className = PromptForExistingClassroom();
            if (className is not null)
            {
                Classroom classroom = _classRooms[className];
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
        
        
        // Returns null if there were no classrooms to prompt for.
        private string PromptForExistingClassroom()
        {
            ShowClassrooms();
            
            // Don't want to get stuck asking the user for a class if
            // there isn't any class to remove.
            if (_classRooms.Count == 0)
            {
                    return null;
            }

            bool succeeded;
            string className;
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

            return className;
        }

    }
}