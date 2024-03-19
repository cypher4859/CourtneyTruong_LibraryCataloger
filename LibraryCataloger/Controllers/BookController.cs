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
		// BUG: Handle when the database doesn't have any books yet.
            // The `.ToList()` fails when there are no books in the library
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
        if (ModelState.IsValid)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
			TempData["success"] = "Book added successfully";
			return RedirectToAction("Index");
		}
        return View();
		}

	public IActionResult Edit(int? bookId)
	{
		if(bookId==null || bookId == 0)
		{
			return NotFound();
		}
		BookEntity? bookFromDb = _dbContext.Books.Find(bookId);
		if (bookFromDb == null)
		{
			return NotFound(bookId);
		}
		return View(bookFromDb);
	}

	[HttpPost]
	public IActionResult Edit(BookEntity book)
	{
		if (ModelState.IsValid)
		{
			_dbContext.Books.Update(book);
			_dbContext.SaveChanges();
			TempData["success"] = "Book updated successfully";
			return RedirectToAction("Index");
		}
		return View();
	}

	public IActionResult Delete(int? bookId)
	{
		if (bookId == null || bookId == 0)
		{
			return NotFound();
		}
		BookEntity? bookFromDb = _dbContext.Books.Find(bookId);
		if (bookFromDb == null)
		{
			return NotFound(bookId);
		}
		return View(bookFromDb);
	}

	[HttpPost, ActionName("Delete")]
	public IActionResult DeletePOST(int? bookID)
	{
		BookEntity? book = _dbContext.Books.Find(bookID);
		if (book == null)
		{
			return NotFound();
		}
		_dbContext.Books.Remove(book);
		_dbContext.SaveChanges();
		TempData["success"] = "Book deleted successfully";
		return RedirectToAction("Index");
		}
	}

	

