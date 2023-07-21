using Microsoft.AspNetCore.Mvc;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using MyBookStoreApp.MyBookStoreApp.Domain.Services;
using MyBookStoreApp.MyBookStoreApp.Domain.Repositories;
using MyBookStoreApp.MyBookStoreApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly GenreService _genreService;
        private readonly AuthorService _authorService;
        private static SelectList _authors;
        private static SelectList _genres;
        //private Dictionary<Guid, string> _authors = new Dictionary<Guid, string>();
        //private Dictionary<Guid, string> _genres = new Dictionary<Guid, string>();
        public BookController(BookService bookService, AuthorService authorService, GenreService genreService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        private async Task GetAuthorsAndGenres()
        {
            var authors = await _authorService.GetAllAuthors();
            _authors = new SelectList(authors.Select(kv => new SelectListItem { Value = kv.AuthorId.ToString(), Text = $"{kv.FirstName} {kv.LastName}" }).ToList(), "Value", "Text");
            var genres = await _genreService.GetAllGenres();
            _genres = new SelectList(genres.Select(kv => new SelectListItem { Value = kv.GenreId.ToString(), Text = kv.Name }).ToList(), "Value", "Text");
        }

        public async Task<IActionResult> Index()
        {
            await GetAuthorsAndGenres();
            var bookViewModel = new List<BookViewModel>();
            var books = _bookService.GetAllBooks();
            foreach (var book in books.Result)
            {
                bookViewModel.Add(
                    new BookViewModel
                    {
                        Title = book.Title,
                        AuthorId = book.AuthorId,
                        BookId = book.BookId,
                        GenreId = book.GenreId,
                        Price = book.Price,
                        PublicationDate = book.PublicationDate.DateTime,
                        AuthorName = book.Author.FirstName + " " + book.Author.LastName,
                        BookGenre= book.Genre.Name,
                        Authors = _authors,
                        Genres = _genres
                    });
            }
            return View(bookViewModel);
        }

        //// GET: /Book/Create
        public async Task<IActionResult> Create()
        {
            await GetAuthorsAndGenres();
            // Create an instance of BookViewModel
            var viewModel = new BookViewModel
            {
                Authors = _authors,
                Genres = _genres
            };
            return View(viewModel);
        }

        // POST: /Book/Create
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel viewModel)
        {
            ModelState.Remove("Authors");
            ModelState.Remove("Genres");
            ModelState.Remove("AuthorName");
            ModelState.Remove("BookGenre");
            if (ModelState.IsValid)
            {
                // Map the ViewModel data to the Model
                var book = new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = viewModel.Title,
                    AuthorId = viewModel.AuthorId,
                    GenreId = viewModel.GenreId,
                    Price = viewModel.Price,
                    PublicationDate = new DateTimeOffset(viewModel.PublicationDate,TimeSpan.Zero)
                };

                await _bookService.CreateBook(book);
            }
            viewModel.Authors = _authors;   
            viewModel.Genres = _genres; 
            return View(viewModel);
        }

        // GET: /Book/Update
        public async Task<IActionResult> Update(string id)
        {
            var book = await _bookService.GetBookById(Guid.Parse(id));
            var viewModel = new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Price = book.Price,
                PublicationDate = book.PublicationDate.DateTime,
                Authors = _authors,
                Genres = _genres
            };

            return View(viewModel);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(BookViewModel viewModel)
        {
            // Map the ViewModel data to the Model
            var book = new Book
            {
                BookId = viewModel.BookId,
                Title = viewModel.Title,
                AuthorId = viewModel.AuthorId,
                GenreId = viewModel.GenreId,
                Price = viewModel.Price,
                PublicationDate = new DateTimeOffset(viewModel.PublicationDate,TimeSpan.Zero)
                // Assuming current date
            };

            await _bookService.UpdateBook(book);
            return View(viewModel);
        }

   
        public async Task<IActionResult> Delete(string id)
        {
            await _bookService.DeleteBook(Guid.Parse(id));
            return RedirectToAction("Index");
        }
    }
}

