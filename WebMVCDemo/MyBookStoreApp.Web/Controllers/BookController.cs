using Microsoft.AspNetCore.Mvc;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using MyBookStoreApp.MyBookStoreApp.Domain.Services;
using MyBookStoreApp.MyBookStoreApp.Domain.Repositories;
using MyBookStoreApp.MyBookStoreApp.Web.ViewModels;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
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
                        Price=book.Price, 
                        PublicationDate = book.PublicationDate 
                    });
            }
            return View(bookViewModel);
        }

        //// GET: /Book/Create
        public IActionResult Create()
        {
            // Create an instance of BookViewModel
            var viewModel = new BookViewModel();

            return View(viewModel);
        }

        // POST: /Book/Create
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel viewModel)
        {
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
                    PublicationDate = viewModel.PublicationDate // Assuming current date
                };

                await _bookService.CreateBook(book);
            }

            return View(viewModel);
        }

        //// GET: /Book/Create
        public async Task<IActionResult> Update(string id)
        {
            // Create an instance of BookViewModel
            var book = await _bookService.GetBookById(Guid.Parse(id));
            var viewModel = new BookViewModel
            {
                BookId= book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Price = book.Price, 
                PublicationDate = book.PublicationDate
            };

            return View(viewModel);
        }
        [HttpPatch]
        public async Task<IActionResult> Update(BookViewModel viewModel)
        {
            // Map the ViewModel data to the Model
            var book = new Book
            {   
                BookId= viewModel.BookId,
                Title = viewModel.Title,
                AuthorId = viewModel.AuthorId,
                GenreId = viewModel.GenreId,
                Price = viewModel.Price,
                PublicationDate = viewModel.PublicationDate // Assuming current date
            };

            await _bookService.UpdateBook(book);
            return View(viewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BookViewModel book)
        {
            await _bookService.DeleteBook(book.BookId);
            return View("Index");
        }
    }
}

