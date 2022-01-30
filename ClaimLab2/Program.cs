using ClaimLab2.TextMenu;

namespace ClaimLab2
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            AbstractTextMenu mainMenu = new MainTextMenu();
            mainMenu.DoMenuLoop();
        }

        
    }
}