using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public List<BookEntity> GetAllBooks()
        {
            var bookList = _context.Books.ToList();
            return bookList;
        }

        public BookEntity CreateBook(BookEntity book) 
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public BookEntity GetBookByIsbn(string Isbn)
        {
            var isbn = _context.Books.FirstOrDefault(e => e.Isbn == Isbn);
            return isbn;
        }

    }
}
