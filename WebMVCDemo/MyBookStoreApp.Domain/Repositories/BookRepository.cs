using Microsoft.EntityFrameworkCore;
using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using MyBookstoreApp.Infrastructure.DbContexts;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public BookRepository(BookStoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(Guid id)
        {
            return await _dbContext.Books.FindAsync(id);
        }
        public async Task CreateBook(Book book)
        {
            await _dbContext.Books.AddAsync(book);
        }
        public async Task UpdateBook(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBook(Guid id)
        {
            var book = GetBookById(id).Result;
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
