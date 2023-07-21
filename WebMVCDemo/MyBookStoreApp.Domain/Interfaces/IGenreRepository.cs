using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task CreateGenre(Genre genre);
        Task DeleteGenre(Guid id);
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<(IEnumerable<Genre>, int)> GetPagedGenres(int currentPageIndex, int pageSize);
        Task<Genre> GetGenreById(Guid id);
        Task UpdateGenre(Genre genre);
    }
}
