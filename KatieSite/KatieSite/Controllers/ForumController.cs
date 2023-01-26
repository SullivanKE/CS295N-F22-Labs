using KatieSite.Data;
using KatieSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatieSite.Controllers
{
    public class ForumController : Controller
    {


        IForumRepository repo;
        UserManager<AppUser> userManager;

        public ForumController(IForumRepository repo, UserManager<AppUser> userMngr)
        {
            this.repo = repo;
            this.userManager = userMngr;
        }
        public IActionResult Index(string Head, DateTime Date)
        {
            List<ForumPost> posts = new List<ForumPost>();

            // Searching for posts by head or date, otherwise return all
            if (Head != null)
                posts = (
                    from p in repo.Posts
                    where p.Head == Head
                    select p
                    ).ToList<ForumPost>();

            else if (Date != DateTime.Parse("1/1/0001 12:00:00 AM"))
                posts = (
                    from p in repo.Posts
                    where p.Date.Date == Date.Date
                    select p
                    ).ToList<ForumPost>();
            else
                posts = repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forum(ForumPost post)
        {
            // Get the AppUser object for the current user
			post.User = userManager.GetUserAsync(User).Result;

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
