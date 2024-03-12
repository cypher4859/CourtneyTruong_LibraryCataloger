using LibraryCataloger.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCataloger.Controllers;

public class BookController : Controller
{
    private readonly BookDbContext _dbContext;
    public BookController(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IActionResult Index()
    {
        List<BookEntity> bookList = _dbContext.Books.ToList();
        return View(bookList);   
    }

    public IActionResult Create()
    {
        return View();
    }

	[HttpPost]
    public IActionResult Create(BookEntity book)
		{
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
			return RedirectToAction("Index");
		}
	}