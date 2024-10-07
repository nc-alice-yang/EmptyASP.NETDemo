using System.Text.Json;

namespace EmptyASP.NETDemo.Models
{
    public class BooksModel
    {

        public List<Book> GetAllBooks()
        {
            var jsonBooks = File.ReadAllText("Resources\\Books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
            return books;
        }

        public Book GetBookById(int id)
        {
            var jsonBooks = File.ReadAllText("Resources\\Books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
            var book = books.FirstOrDefault(b => b.Id == id);
            return book;

        }

        public Book AddBook( Book newBook)
        {
            var jsonBooks = File.ReadAllText("Resources\\Books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return newBook;
        }

        public bool DeleteBookById(int id)
        {
            var jsonBooks = File.ReadAllText("Resources\\Books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return false;
            }

            books.Remove(book);
            return true;
        }
        public List<Book> GetBooksByAuthorId(int authorId)
        {
            var jsonBooks = File.ReadAllText("Resources\\Books.json");
            var books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
            var jsonAuthors = File.ReadAllText("Resources\\Authors.json");
            var authors = JsonSerializer.Deserialize<List<Author>>(jsonAuthors);

            var author = authors.FirstOrDefault(b => b.Id == authorId);
            var filteredBooks = books.Where(book => book.Author == author.Name).ToList();

            return filteredBooks;
        }
    }
}
