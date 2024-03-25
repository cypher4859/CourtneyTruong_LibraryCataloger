using LibraryCataloger.Data;
using LibraryCataloger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryCatalogerWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookRepository _bookRepository;
    public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
    {
        _logger = logger; 
        _bookRepository = bookRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BookEntity book)
    {
        if (ModelState.IsValid)
        {
            _bookRepository.CreateBook(book);
            TempData["success"] = "Book added successfully";
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
