using KatieSite.Data;
using KatieSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Task<List<ForumPost>> postsTask;

            // Searching for posts by head or date, otherwise return all
            if (Head != null)
                postsTask = (
                    from p in repo.PostsAsync
                    where p.Head == Head
                    select p
                    ).ToListAsync();

            else if (Date != DateTime.Parse("1/1/0001 12:00:00 AM"))
                postsTask = (
                    from p in repo.PostsAsync
                    where p.Date.Date == Date.Date
                    select p
                    ).ToListAsync<ForumPost>();
            else
                postsTask = repo.GetAllPostsAsync();

            posts = await postsTask;
            return View(posts);
        }

        [Authorize]
        public IActionResult Forum()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Forum(ForumPost post)
        {
            // Get the AppUser object for the current user
            post.User = await userManager.GetUserAsync(User);

            if (await repo.SavePostAsync(post) > 0)
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
            ForumPost post = await repo.GetPostByIdAsync(postId);

            if (post != null)
                return View(post);

            return View();

        }
    }
}
