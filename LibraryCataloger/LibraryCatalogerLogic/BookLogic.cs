using LibraryCataloger.Data;

namespace LibraryCataloger.LibraryCatalogerLogic
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookRepository _bookRepository;

        public BookLogic(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(BookEntity book)
        {
            _bookRepository.CreateBook(book);
        }

        public List<BookEntity> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookEntity GetBookByIsbn(string isbn)
        {
            return _bookRepository.GetBookByIsbn(isbn);
        }
    }
}
