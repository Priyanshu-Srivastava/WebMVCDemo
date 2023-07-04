using Microsoft.AspNetCore.Mvc;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;
using MyBookStoreApp.MyBookStoreApp.Web.ViewModels;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        //// GET: /Book/Create
        //public IActionResult Create()
        //{
        //    // Create an instance of BookViewModel
        //    var viewModel = new BookViewModel();

        //    return View(viewModel);
        //}

        //// POST: /Book/Create
        //[HttpPost]
        //public IActionResult Create(BookViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Map the ViewModel data to the Model
        //        var book = new Book
        //        {
        //            Title = viewModel.Title,
        //            Author = viewModel.Author,
        //            PublicationDate = DateTime.Now // Assuming current date
        //        };

        //        // Save the book to the database or perform other operations

        //        return RedirectToAction("Index", "Book");
        //    }

        //    return View(viewModel);
        //}
    }
}

