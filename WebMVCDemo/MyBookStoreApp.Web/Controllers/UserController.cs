﻿using Microsoft.AspNetCore.Mvc;

namespace MyBookStoreApp.MyBookStoreApp.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
