using KatieSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KatieSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string user, string head, string body, DateTime date)
        {
            ForumPost post = new ForumPost();
            post.user = user;
            post.head = head;
            post.body = body;
            post.date = DateTime.Now;

            return View(post);
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forum(ForumPost post)
        {
            return RedirectToAction("Index", 
                new
                {
                    user = post.user,
                    date = DateTime.Now,
                    head = post.head,
                    body = post.body
                }); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
