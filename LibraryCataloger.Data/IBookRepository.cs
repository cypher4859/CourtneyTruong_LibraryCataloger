using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger.Data
{
    public interface IBookRepository
    {
		public List<BookEntity> GetInLibraryBooks();
        public void CreateBook(BookEntity book);
		public BookEntity? FindBookByID(int? bookId);
		public void UpdateBook(BookEntity book);
		public void DeleteBook(BookEntity book);

	}
}
