using LibraryCataloger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger.LibraryCatalogerLogic
{
    public interface IBookLogic
    {
        public void CreateBook(BookEntity book);

        public List<BookEntity> GetAllBooks();

        public BookEntity GetBookByIsbn(string isbn);
    }
}
