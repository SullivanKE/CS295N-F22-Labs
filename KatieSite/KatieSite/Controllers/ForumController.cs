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

        public ForumController(DbContext c)
        {
            this.context = c;
        }
        public IActionResult Index()
        {
            // Rebuild the ForumPost model from the home/forum post controller
            List<ForumPost> post = context.ForumPosts.OrderBy(post => post.Date).ToList();


            foreach (ForumPost p in post)
            { 
                Rating r = context.Rating.Find(p.PostId);
                p.Rating = r;
            }
            
            return View(post);
        }

        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forum(ForumPost post)
        {
            post.Date = DateTime.Now;

            context.ForumPosts.Add(post);
            context.SaveChanges();


            return RedirectToAction("Index");

        }

        public IActionResult Post(int PostId)
        {
            ForumPost post = context.ForumPosts.Find(PostId);
            Rating r = context.Rating.Find(PostId);
            if (r != null)
            {
                post.Rating = r;
                return View(post);
            }
            else
            {
                return View();
            }
        }
    }
}
