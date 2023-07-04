using Microsoft.AspNetCore.Mvc;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
