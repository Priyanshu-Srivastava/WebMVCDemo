using Microsoft.AspNetCore.Mvc;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
