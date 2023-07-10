using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _genreRepository.GetAllGenres();
        }

        public async Task<Genre> GetGenreById(Guid id)
        {
            return await _genreRepository.GetGenreById(id);
        }

        public async Task CreateGenre(Genre genre)
        {
            await _genreRepository.CreateGenre(genre);
        }

        public async Task UpdateGenre(Genre genre)
        {
            await _genreRepository.UpdateGenre(genre);
        }

        public async Task DeleteGenre(Guid id)
        {
            await _genreRepository.DeleteGenre(id);
        }
    }
}
