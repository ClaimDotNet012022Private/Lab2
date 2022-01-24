using System;
using ClaimLab2.TextMenu;

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