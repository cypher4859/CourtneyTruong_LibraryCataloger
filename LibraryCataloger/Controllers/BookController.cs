using LibraryCataloger.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCataloger.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _dbContext;

        public BookController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<BookEntity> bookList = _dbContext.Books.ToList();
            return View(bookList);
        }
    }
}
