using Microsoft.AspNetCore.Mvc;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using MyBookStoreApp.MyBookStoreApp.Domain.Services;
using MyBookStoreApp.MyBookStoreApp.Web.ViewModels;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly GenreService _genreService;
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllGenres();
            var genreList = new List<GenreViewModel>();
            if (genres != null)
            {
                foreach (var genre in genres)
                {
                    var genreItem = new GenreViewModel
                    {
                        GenreId = genre.GenreId,
                        Name = genre.Name,
                        Description = genre.Description
                    };
                    genreList.Add(genreItem);
                }
            }
            return View(genreList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var genreViewModel = new GenreViewModel();
            return View(genreViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreViewModel viewModel)
        {
            var genreModel = new Genre
            {
                GenreId = Guid.NewGuid(),
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            await _genreService.CreateGenre(genreModel);

            return View(viewModel);
        }

        public async Task<IActionResult> Update(string id)
        {
            var genre = _genreService.GetGenreById(Guid.Parse(id)).Result;
            var viewModel = new GenreViewModel
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                Description = genre.Description
            };
            return View(viewModel);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(GenreViewModel viewModel)
        {
            var genreModel = new Genre
            {
                GenreId = viewModel.GenreId,
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            await _genreService.UpdateGenre(genreModel);

            return View(viewModel.GenreId);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _genreService.DeleteGenre(Guid.Parse(id));
            return RedirectToAction("Index");
        }
    }
}
