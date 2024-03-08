using LibraryCataloger.Data;
using LibraryCataloger.LibraryCatalogerLogic;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace LibraryCataloger;

public class Program
{
    public static void Main(string[] args)
    {
        var services = CreateServiceCollection();
        var bookLogic = services.GetService<IBookLogic>();
        Console.WriteLine("Welcome to Library Cataloger!");
        Console.WriteLine("Type the number for an option below to continue!");
        Console.WriteLine("1 Add a new book");
        Console.WriteLine("2 Search for book by ISBN");
        string userInput = Console.ReadLine();

        while (userInput?.ToLower() != "exit")
        {
            Console.WriteLine("Confirm option from options below");
            Console.WriteLine("1 Add a new book");
            Console.WriteLine("2 Search for book by ISBN");
            userInput = Console.ReadLine();


            if (userInput == "1")
            {
                
                //create book object using json format
                Console.WriteLine("Please add a Book in JSON format");
                var userInputAsJson = Console.ReadLine();
                var book = JsonSerializer.Deserialize<BookEntity>(userInputAsJson);
                //add book to database                      
                bookLogic?.CreateBook(book);

                Console.WriteLine("New Book added " + JsonSerializer.Serialize(book));
            }

            if (userInput == "2")
            {
                //ask for isbn to search for
                Console.WriteLine("Type ID of product");
                userInput = Console.ReadLine();
                var bookID = Console.ReadLine();
                //return isbn asked for
                var result = bookLogic?.GetBookByIsbn(bookID);
                ///if null return error message, if product exists return product info
                if (result == null)
                {
                    Console.WriteLine("ISBN not Found");
                }
                else
                {
                    Console.WriteLine(JsonSerializer.Serialize(bookLogic.GetBookByIsbn(bookID)));
                }
            }

            //if (userInput == "3")
            {
                //Console.WriteLine("Add an Order in Json format");
                //var userInputAsJson = Console.ReadLine();
                //var order = JsonSerializer.Deserialize<OrderEntity>(userInputAsJson);
                //add order to database                     
                //productLogic?.AddOrder(order);
                //Console.WriteLine("Order info added " + JsonSerializer.Serialize(order));
            }

            //if (userInput == "4")
            {
                //Console.WriteLine("Type ID of order");
                //userInput = Console.ReadLine();
                //var orderID = int.Parse(Console.ReadLine());
                //return product asked for
                //var result = productLogic?.GetOrderByID(orderID);
                ///if null return error message, if product exists return product info
                //if (result == null)
                {
                    //Console.WriteLine("Order not Found");
                }
                //else
                {
                    // Console.WriteLine(JsonSerializer.Serialize(productLogic.GetOrderByID(orderID)));
                }
            }
        }
    }

    public static IServiceProvider CreateServiceCollection()
    {
        return new ServiceCollection()
              .AddTransient<IBookLogic, BookLogic>()
              .AddTransient<IBookRepository, BookRepository>()
              .AddDbContext<BookDbContext>()
              .BuildServiceProvider();
    }
}




//TODO write program logic. set up validators (find class project tutorial), finish setting up database