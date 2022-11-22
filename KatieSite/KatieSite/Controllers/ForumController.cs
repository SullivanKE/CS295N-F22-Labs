using KatieSite.Data;
using KatieSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatieSite.Controllers
{
    public class ForumController : Controller
    {

        DbContext context;
        IForumRepository repo;

        public ForumController(DbContext c, IForumRepository repo)
        {
            this.context = c;
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(repo.GetAllPosts());
        }

        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forum(ForumPost post)
        {
            post.Date = DateTime.Now;

            repo.SavePost(post);


            return RedirectToAction("Index");

        }

        public IActionResult Post(int postId)
        {
            ForumPost post = repo.GetPostById(postId);

            if (post != null)
                return View(post);

            return View();

        }
    }
}
