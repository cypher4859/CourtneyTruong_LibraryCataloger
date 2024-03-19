using Microsoft.AspNetCore.Mvc;
using LibraryCataloger.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryCataloger.Controllers;
public class LibraryController : Controller
{
	private readonly IBookRepository _bookRepository;

	public LibraryController(IBookRepository bookRepository)
	{
		_bookRepository = bookRepository;
	}
	public IActionResult Index()
	{
		try
		{
			var bookList = _bookRepository.GetInLibraryBooks();
			return View(bookList);
		}
		catch (Exception ex)
		{
			return View(ex);
		}
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

	public IActionResult Edit(int? bookId)
	{
		if (bookId == null || bookId == 0)
		{
			return NotFound();
		}
		var bookFromDb = _bookRepository.FindBookByID(bookId);
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
			_bookRepository.UpdateBook(book);
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
		BookEntity? bookFromDb = _bookRepository.FindBookByID(bookId);
		if (bookFromDb == null)
		{
			return NotFound(bookId);
		}
		return View(bookFromDb);
	}

	[HttpPost, ActionName("Delete")]
	public IActionResult DeletePOST(int? bookID)
	{
		BookEntity? book = _bookRepository.FindBookByID(bookID);
		if (book == null)
		{
			return NotFound();
		}
		_bookRepository.DeleteBook(book);
		TempData["success"] = "Book deleted successfully";
		return RedirectToAction("Index");
	}
}


   
