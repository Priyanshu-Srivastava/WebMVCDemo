using Microsoft.AspNetCore.Mvc;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
