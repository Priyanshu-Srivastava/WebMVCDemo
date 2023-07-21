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
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var (genres, count) = await _genreService.GetPagedGenreData(page - 1, pageSize);
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
            var totalPages = Math.Ceiling((decimal)(count / pageSize));
            var pagedGenreViewModel = new PagedViewModel<GenreViewModel>
            {
                Data = genreList,
                CurrentPage = page - 1,
                PageSize = pageSize,
                TotalPages = (int)totalPages
            };

            return View(pagedGenreViewModel);
        }

        public IActionResult Create()
        {
            var genreViewModel = new GenreViewModel();
            return View(genreViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var genreModel = new Genre
                    {
                        GenreId = Guid.NewGuid(),
                        Name = viewModel.Name,
                        Description = viewModel.Description
                    };

                    await _genreService.CreateGenre(genreModel);
                    return Ok(new { success = true, message = $"Genre {viewModel.Name} created successfully!" });
                }
                else
                {
                    return Ok(new { success = false, message = $"Please validate your data and try again!" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { success = false, message = $"There was an error creating the genre. Please try again!!" });
            }
        }

        public async Task<IActionResult> Update(string id)
        {
            var genre = await _genreService.GetGenreById(Guid.Parse(id));
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
            try
            {
                if (ModelState.IsValid)
                {
                    var genreModel = new Genre
                    {
                        GenreId = viewModel.GenreId,
                        Name = viewModel.Name,
                        Description = viewModel.Description
                    };

                    await _genreService.UpdateGenre(genreModel);
                    return Ok(new { success = true, message = $"Genre details updated successfully!" });
                }
                else
                {
                    return Ok(new { success = false, message = "Failed to update genre details. Validate data and try again" });
                }
            }
            catch
            {
                return StatusCode(500, new { success = false, message = "An error occurred while updating genre details." });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _genreService.DeleteGenre(Guid.Parse(id));
                return Ok(new { success = true, message = "Genre successfully deleted!" });
            }
            catch
            {
                return StatusCode(500, new { success = false, message = "Looks like there was an error deleting the genre. Please try again!" });
            }
        }
    }
}
