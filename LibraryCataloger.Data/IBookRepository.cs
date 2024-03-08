using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger.Data
{
    public interface IBookRepository
    {
        public List<BookEntity> GetAllBooks();
        public BookEntity CreateBook(BookEntity book);
        public BookEntity GetBookByIsbn(string Isbn);
    }
}
