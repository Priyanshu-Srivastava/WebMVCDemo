using MyBookstoreApp.Infrastructure.DbContexts;
using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public GenreRepository(BookStoreDbContext dbContext) 
        { 
            _dbContext= dbContext;
        }
        public async Task CreateGenre(Genre genre)
        {
            _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGenre(Guid id)
        {
            var genre = GetGenreById(id).Result;
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
       
        public async Task<(IEnumerable<Genre>, int)> GetPagedGenres(int currentPageIndex = 0, int pageSize = 10)
        {
            var offset = currentPageIndex * pageSize;
            var pagedGenres = _dbContext.Genres.OrderBy(x=>x.Name).Skip(offset).Take(pageSize);
            var totalCount = _dbContext.Genres.Count();
            return (pagedGenres, totalCount);
        }
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreById(Guid id)
        {
            return await _dbContext.Genres.FindAsync(id);
        }

        public async Task UpdateGenre(Genre genre)
        {
            _dbContext.Entry(genre).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
