﻿using Microsoft.AspNetCore.Mvc;

namespace KatieSite
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }
    }
}