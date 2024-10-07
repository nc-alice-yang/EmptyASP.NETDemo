using System.Text.Json;

namespace EmptyASP.NETDemo.Models
{
    public class AuthorsModel
    {
        public List<Author> GetAllAuthors()
        {
            var jsonAuthors = File.ReadAllText("Resources\\Authors.json");
            var authors = JsonSerializer.Deserialize<List<Author>>(jsonAuthors);
            return authors;
        }

        public Author GetAuthorById(int id)
        {
            var jsonAuthors = File.ReadAllText("Resources\\Authors.json");
            var Authors = JsonSerializer.Deserialize<List<Author>>(jsonAuthors);
            var author = Authors.FirstOrDefault(b => b.Id == id);
            return author;

        }

        public Author AddAuthor(Author newAuthor)
        {
            var jsonAuthors = File.ReadAllText("Resources\\Author.json");
            var Authors = JsonSerializer.Deserialize<List<Author>>(jsonAuthors);
            newAuthor.Id = Authors.Max(b => b.Id) + 1;
            Authors.Add(newAuthor);
            return newAuthor;
        }
        public bool DeleteAuthorById(int id)
        {
            var jsonAuthors = File.ReadAllText("Resources\\Authors.json");
            var authors = JsonSerializer.Deserialize<List<Author>>(jsonAuthors);
            var author = authors.FirstOrDefault(b => b.Id == id);
            if (author == null)
            {
                return false;
            }

            authors.Remove(author);
            return true;
        }
    }
}
