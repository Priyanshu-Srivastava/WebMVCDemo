using Microsoft.EntityFrameworkCore;
using MyBookstoreApp.Infrastructure.DbContexts;
using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreDbContext _dbContext;

        public AuthorRepository(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
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

        public async Task DeleteAuthor(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }

}
