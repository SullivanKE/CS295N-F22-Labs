﻿using KatieSite.Models;
using KatieSite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KatieSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

/*        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        DbContext context;

        public HomeController(DbContext c)
        {
            this.context = c;
        }

        [AllowAnonymous]
        public IActionResult Index(string reviewId)
        {

            // Rebuild the ForumPost model from the home/forum post controller
            ForumPost post = context.ForumPosts.OrderBy(post => post.date).LastOrDefault();


            if (post != null)
            {
                Rating r = context.Rating.Find(post.PostId);
                post.rating = r;
                return View(post);
            }
            else
                return View();
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

        public IActionResult Quiz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quiz(QuizVM model)
        {
            model.RightOrWrong1 = QuizLogic.CheckAnswer(1, model.UserAnswer1);
            model.RightOrWrong2 = QuizLogic.CheckAnswer(2, model.UserAnswer2);
            model.RightOrWrong3 = QuizLogic.CheckAnswer(3, model.UserAnswer3);
            return View(model);
        }

        [HttpPost]
        public IActionResult Forum(ForumPost post)
        {
            post.date = DateTime.Now;

            context.ForumPosts.Add(post);
            context.SaveChanges();
            

            return RedirectToAction("Index", new {reviewId = post.PostId});

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
