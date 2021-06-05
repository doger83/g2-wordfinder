using System;
using WordFinder.ConsoleUI.Utils;

namespace WordFinder.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            try
            {
                Application App = new Application();
                App.Run();
            }
            catch (Exception ex)
            {
                UIManager.HandleException(ex);

                UIManager.ProgrammEndsMassage();
            }
        }
    }
}
