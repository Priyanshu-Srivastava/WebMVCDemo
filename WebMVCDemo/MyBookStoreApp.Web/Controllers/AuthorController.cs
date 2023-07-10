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

        public async Task<IActionResult> Index()
        {
            var allAuthors = new List<AuthorViewModel>();
            var authors = await _authorService.GetAllAuthors();
            foreach (var author in authors)
            {
                var authorViewModel = new AuthorViewModel();
                authorViewModel.AuthorId = author.AuthorId;
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
            try
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
                    ViewBag.SuccessMessage = $"Author {viewModel.FirstName} {viewModel.LastName} added successfully!";
                    //ViewBag.FailureMessage = "";
                    viewModel = null;
                }
                else
                {
                    ViewBag.FailureMessage = "The data you filled in is invalid. Please try again!";
                }
            }
            catch (Exception)
            {
                ViewBag.FailureMessage = "There was some error adding this author. Please try again!";
                //ViewBag.SuccessMessage = "";
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Update(string id)
        {
            var author = await _authorService.GetAuthorById(Guid.Parse(id));
            var authorViewModel = new AuthorViewModel
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                AuthorId = author.AuthorId
            };
            return View(authorViewModel);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(AuthorViewModel authorViewModel)
        {
            var author = await _authorService.GetAuthorById(authorViewModel.AuthorId);
            
            // Map the properties from the view model to the actual author model
            author.FirstName = authorViewModel.FirstName;
            author.LastName = authorViewModel.LastName;
            author.Email = authorViewModel.Email;
            
            await _authorService.UpdateAuthor(author);
            return View(author.AuthorId.ToString());
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            await _authorService.DeleteAuthor(Guid.Parse(id));
            return RedirectToAction("Index");
        }
    }

}
