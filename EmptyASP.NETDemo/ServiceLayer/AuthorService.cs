using EmptyASP.NETDemo.Models;

namespace EmptyASP.NETDemo.ServiceLayer
{
    public class AuthorService
    {
        private readonly AuthorsModel _authorsModel;

        public AuthorService(AuthorsModel authorsModel)
        {
            _authorsModel = authorsModel;
        }

        public List<Author> GetAuthors()
        {
            return _authorsModel.GetAllAuthors();
        }

        public Author GetAuthor(int id)
        {
            return _authorsModel.GetAuthorById(id);
        }

        public Author AddAuthor(Author newAuthor) {
            return _authorsModel.AddAuthor(newAuthor);
                
        }

        public bool DeleteAuthor(int id)
        {
            return _authorsModel.DeleteAuthorById(id);
        } 
    }

}
