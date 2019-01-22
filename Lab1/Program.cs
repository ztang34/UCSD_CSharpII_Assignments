using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Lab1
{
    class Program
    {
        public enum MainMenuOptions
        {
            Quit,
            AddMovie,
            AddAlbum,
            AddBook
        }
        static void Main(string[] args)
        {
            DisplayMenu();
            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();

        }

        static void DisplayMenu()
        {
            foreach (MainMenuOptions option in Enum.GetValues(typeof(MainMenuOptions)))
            {
                Console.WriteLine($"[{(int)option}]-{option}");
            }            
        }

    }
}
