using System.Text.Json;

namespace LibraryCataloger;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Library Cataloger!");
        Console.WriteLine("Type the number of an option below to get started:");
        Console.WriteLine("1. Add a book to your Library");
        Console.WriteLine("2. Add a book to your To Be Read List");
        Console.WriteLine("Type 'exit' to quit");
        string userInput = Console.ReadLine();

        while (userInput?.ToLower() != "exit")
        {
            //TODO: write menu logic for ToBeReadListBook
            if (userInput == "1")
            {
                var library = new Library();
                library.InLibrary = true;
                Console.WriteLine("You are now entering a new book");
                Console.WriteLine("What is the Title of the book?");
                library.Title = Console.ReadLine();

                Console.WriteLine("Who is the Author of the book?");
                library.Author = Console.ReadLine();

                Console.WriteLine("What is the Genre of the book?");
                library.Genre = Console.ReadLine();

                Console.WriteLine("What is the book's ISBN?");
                library.Isbn = (Console.ReadLine());

                Console.WriteLine("Enter a Description for the book");
                library.Description = Console.ReadLine();

                Console.WriteLine("Type 1 to add another book to Library");
                Console.WriteLine("Type exit to quit");
                userInput = Console.ReadLine();

            }
        }
    }
}