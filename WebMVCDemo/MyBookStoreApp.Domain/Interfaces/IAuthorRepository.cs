using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(Guid id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(Guid id);
    }
}
