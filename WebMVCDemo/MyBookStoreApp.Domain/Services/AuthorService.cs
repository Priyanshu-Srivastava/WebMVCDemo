using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _authorRepository.GetAuthorById(id);
        }

        public async Task CreateAuthor(Author author)
        {
            await _authorRepository.CreateAuthor(author);
        }

        public async Task UpdateAuthor(Author author)
        {
            await _authorRepository.UpdateAuthor(author);
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _authorRepository.DeleteAuthor(id);
        }
    }
}
