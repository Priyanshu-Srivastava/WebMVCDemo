using Microsoft.EntityFrameworkCore;
using MyBookstoreApp.Infrastructure.DbContexts;
using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public AuthorRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }

        public async Task CreateAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAuthor(Author author)
        {
            _dbContext.Entry(author).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAuthor(Guid id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }

}
