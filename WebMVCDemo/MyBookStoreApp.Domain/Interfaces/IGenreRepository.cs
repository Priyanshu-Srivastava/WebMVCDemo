using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task CreateGenre(Genre genre);
        Task DeleteGenre(Guid id);
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(Guid id);
        Task UpdateGenre(Genre genre);
    }
}
