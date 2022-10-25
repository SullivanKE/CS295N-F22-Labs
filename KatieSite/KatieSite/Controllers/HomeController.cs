using KatieSite.Models;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public IActionResult Index(string user, string head, int rating, string url, string body, DateTime date)
        {

            // Rebuild the ForumPost model from the home/forum post controller
            ForumPost post = new ForumPost();
            post.user = user;
            post.head = head;
            post.body = body;
            post.date = date;

            Rating r = new Rating();
            r.rating = rating;
            r.url = url;

            post.rating = r;

            return View(post);
        }

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
            post.date = DateTime.Now;

            // Break down the post model into individual parts to send to index.
            return RedirectToAction("Index",
                new
                {
                    user = post.user,
                    head = post.head,
                    rating = post.rating.rating,
                    url = post.rating.url,
                    body = post.body,
                    date = post.date
                }
            );

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
