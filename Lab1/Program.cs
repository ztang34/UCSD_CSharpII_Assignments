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
        public static List<IMedia> MediaDb { get; } = new List<IMedia>(); //List of IMedia objects to store movie,album and book objects
        public enum MainMenuOptions
        {
            Quit,
            AddMovie,
            AddAlbum,
            AddBook
        }
        static void Main(string[] args)
        {
            MainMenuOptions option = MainMenuOptions.Quit;
            do
            {
                DisplayMenu();
                int input = ConsoleHelpers.ReadInt("Value:", 0, 3); //make sure user enters a valid option
                switch (option = (MainMenuOptions)input)
                {
                    case MainMenuOptions.AddMovie:
                        AddMovie();
                        break;
                    default:
                        break;
                }
                PrintMediaDb();
            } while (option != MainMenuOptions.Quit);

            
            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();

        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            foreach (MainMenuOptions option in Enum.GetValues(typeof(MainMenuOptions)))
            {
                Console.WriteLine($"[{(int)option}]-{option}");
            }            
        }

        static void PrintMediaDb()
        {
            foreach (IMedia item in MediaDb)
            {
                item.Print();
            }
        }
        static void AddMovie ()
        {
            int movieID = ConsoleHelpers.ReadInt("Enter movie ID: ", 1);
            string movieTitle = ConsoleHelpers.ReadString("Enter movie title: ", 1);
            string moviePublisher = ConsoleHelpers.ReadString("Enter movie producer/publisher: ", 1);
            string movieCreator = ConsoleHelpers.ReadString("Enter movie screenwriter: ", 1);
            DateTime moviePublishDate = ConsoleHelpers.ReadDate("Enter release date: ", DateTime.Parse("1/1/1878"), DateTime.Now);
            int movieRunLength = ConsoleHelpers.ReadInt("Enter run length: ", 1);

            //Show movie ratings and prompt user to select
            Console.WriteLine("Movie rating:");
            foreach (var rating in Enum.GetValues(typeof(MovieRating)))
            {
                Console.WriteLine($"\t[{(int)rating}] - {rating}");
            }
            MovieRating movieRating = (MovieRating)ConsoleHelpers.ReadInt("Value: ", 0, 5);

            try
            {
                Movie myMovie = new Movie(movieID, movieTitle, moviePublisher, movieCreator, moviePublishDate, movieRunLength, movieRating);
                MediaDb.Add(myMovie);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unknow error has occured: {ex.Message}");
            }

        }

    }
}
