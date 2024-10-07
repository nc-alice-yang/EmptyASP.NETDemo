using EmptyASP.NETDemo.Models;

namespace EmptyASP.NETDemo.ServiceLayer
{
    public class BookService 
    {
        private readonly BooksModel _booksModel;
        public BookService(BooksModel booksModel)
        {
            _booksModel =  booksModel;
        }
        public List<Book> GetBooks()
        {
           return _booksModel.GetAllBooks();
        }

        public Book GetBook(int id)
        {
            return _booksModel.GetBookById(id);
        }

        public Book AddBook(Book newBook)
        {
            return _booksModel.AddBook(newBook);
        }

        public bool DeleteBook(int id)
        {
            return _booksModel.DeleteBookById(id);
        }

        public List<Book> GetBooksByAuthorId(int id) {
            return _booksModel.GetBooksByAuthorId(id);
        }
    }
}
