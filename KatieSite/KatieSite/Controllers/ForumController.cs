using KatieSite.Data;
using KatieSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(string Head, DateTime Date)
        {
            List<ForumPost> posts = new List<ForumPost>();

            // Searching for posts by head or date, otherwise return all
            if (Head != null)
                posts = (
                    from p in repo.Posts
                    where p.Head == Head
                    select p
                    ).ToList();

            else if (Date != DateTime.Parse("1/1/0001 12:00:00 AM"))
                posts = (
                    from p in repo.Posts
                    where p.Date.Date == Date.Date
                    select p
                    ).ToList<ForumPost>();
            else
                posts = await repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forum(ForumPost post)
        {
            // Get the AppUser object for the current user
            post.User = await userManager.GetUserAsync(User);

            if (await repo.SavePost(post) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(); // TODO: Send an error message
            }
        }

        public async Task<IActionResult> Post(int postId)
        {
            ForumPost post = await repo.GetPostById(postId);

            if (post != null)
                return View(post);

            return View();

        }
    }
}
