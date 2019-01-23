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
                    case MainMenuOptions.AddAlbum:
                        AddAlbum();
                        break;
                    case MainMenuOptions.AddBook:
                        AddBook();
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
                Console.WriteLine();
            }
        }
        static void AddMovie ()
        {
            int movieID = ConsoleHelpers.ReadInt("Enter movie ID: ", 1, 999999999);
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

            // try to create a new Movie object and add to MediaDb list
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

        static void AddAlbum()
        {
            int albumID = ConsoleHelpers.ReadInt("Enter album ID: ", 1, 999999999);
            string albumTitle = ConsoleHelpers.ReadString("Enter album title: ", 1);
            string albumPublisher = ConsoleHelpers.ReadString("Enter album publisher: ", 1);
            string albumCreator = ConsoleHelpers.ReadString("Enter artist: ", 1);
            DateTime albumPublishDate = ConsoleHelpers.ReadDate("Enter release date: ", DateTime.Parse("1/1/1857"), DateTime.Now);
            int albumRunLength = ConsoleHelpers.ReadInt("Enter run length: ", 1);

            //Show media types and prompt user to select
            Console.WriteLine("Media types:");
            foreach (var mediaType in Enum.GetValues(typeof(AlbumMediaType)))
            {
                Console.WriteLine($"\t[{(int)mediaType}] - {mediaType}");
            }
            AlbumMediaType albumMediaType = (AlbumMediaType)ConsoleHelpers.ReadInt("Value: ", 0, 4);

            // try to create a new Movie object and add to MediaDb list
            try
            {
                Album myAlbum = new Album(albumID, albumTitle, albumPublisher, albumCreator, albumPublishDate, albumRunLength, albumMediaType);
                MediaDb.Add(myAlbum);
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

        static void AddBook()
        {
            int bookID = ConsoleHelpers.ReadInt("Enter book ID: ", 1, 999999999);
            string bookTitle = ConsoleHelpers.ReadString("Enter book title: ", 1);
            string bookPublisher = ConsoleHelpers.ReadString("Enter book publisher: ", 1);
            string bookAuthor = ConsoleHelpers.ReadString("Enter book author: ", 1);
            DateTime bookPublishDate = ConsoleHelpers.ReadDate("Enter release date: ", DateTime.MinValue, DateTime.Now); //any date in the past is allowed
            int bookPageNumber = ConsoleHelpers.ReadInt("Enter page: ", 1);

            // try to create a new book object and add to MediaDb list
            try
            {
                Book myBook = new Book(bookID, bookTitle, bookPublisher, bookAuthor, bookPublishDate, bookPageNumber);
                MediaDb.Add(myBook);
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
