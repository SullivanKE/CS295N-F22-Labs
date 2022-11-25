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


        IForumRepository repo;

        public ForumController(IForumRepository repo)
        {
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
            
            if (repo.SavePost(post) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(); // TODO: Send an error message
            }
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
