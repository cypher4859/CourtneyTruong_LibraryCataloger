using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger.Data;

//Single Responsibility Principle: BookEntity class is only responsible for creating my programs book object.
//The BookRepository class is only responsible for handling methods related to the book object. These methods are creating a book object(CreateBook),
//getting book by id(FindBookById), getting only books where InLibrary is true(GetInLibraryBooks), getting only book where ToBeReadList is true(GetToBeReadList)
//updating book properties(UpdateBook) and deleting a book from the database(DeleteBook). If I were to add a Review feature methods relating to handling
//reading, creating, updating, deleting, etc would be handled in a seperate class called ReviewRepository.
public class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;
    private readonly List<BookEntity> defaultEmptyBookEntities = new List<BookEntity> { };


    public BookRepository(BookDbContext context)
    {
        _context = context;
    }

    public List<BookEntity> GetInLibraryBooks()
    {
        // BUG: Handle when the database doesn't have any books yet.
        // The `.ToList()` fails when there are no books in the library
        try
        {
            var inLibrary = _context.Books.Where(e => e.InLibrary).ToList();
            return inLibrary;
        }
        catch (Exception ex) 
        {
            return defaultEmptyBookEntities;
        }

    }

    public List<BookEntity> GetToBeReadList()
    {
        // BUG: Handle when the database doesn't have any books yet.
        // The `.ToList()` fails when there are no books in the ToBeReadList
        try
        {
            var toBeReadList = _context.Books.Where(e => e.ToBeReadList).ToList();
            return toBeReadList;
        }
        catch (Exception ex)
        {
            return defaultEmptyBookEntities;
        }
    }

    public void CreateBook(BookEntity book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public BookEntity? FindBookByID(int? bookId)
    {
       return _context.Books.Find(bookId);
    }
        
    public void UpdateBook(BookEntity book)
    {
			_context.Books.Update(book);
			_context.SaveChanges();
		}

    public void DeleteBook(BookEntity book)
    {
			_context.Books.Remove(book);
			_context.SaveChanges();
		}
}


