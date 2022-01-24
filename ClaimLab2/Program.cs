using System;

namespace ClaimLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractTextMenu mainMenu = new MainTextMenu();
            mainMenu.DoMenuLoop();
        }

        
    }
}