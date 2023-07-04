using Microsoft.AspNetCore.Mvc;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using MyBookStoreApp.MyBookStoreApp.Web.ViewModels;
using MyBookStoreApp.MyBookStoreApp.Domain.Services;
using MyBookStoreApp.MyBookStoreApp.Domain.Repositories;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> ViewAll()
        {
            var allAuthors = new List<AuthorViewModel>();
            var authors = await _authorService.GetAllAuthors();
            foreach(var author in authors)
            {
                var authorViewModel = new AuthorViewModel();
                authorViewModel.FirstName = author.FirstName;
                authorViewModel.LastName = author.LastName;
                authorViewModel.Email = author.Email;
                allAuthors.Add(authorViewModel);
            }
            return View(allAuthors);
        }

        // GET: /Author/Create
        public IActionResult Create()
        {
            var viewModel = new AuthorViewModel();
            return View(viewModel);
        }

        // POST: /Author/Create
        [HttpPost]
        public async Task<IActionResult> Create(AuthorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    AuthorId = Guid.NewGuid(),
                };

                await _authorService.CreateAuthor(author);

                return RedirectToAction("Index", "Book");
            }

            return View(viewModel);
        }
    }

}
