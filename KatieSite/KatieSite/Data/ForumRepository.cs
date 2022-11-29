using KatieSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KatieSite.Data
{
    public class ForumRepository : IForumRepository
    {
        private DbContext context;

        public ForumRepository(DbContext context)
        {
            this.context = context;
        }

        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> posts = context.ForumPosts
                .Include(posts => posts.Rating)
                .OrderByDescending(post => post.Date)
                .ToList();
            return posts;
        }

        public ForumPost GetPostById(int postId)
        {
            ForumPost post = context.ForumPosts
                .Include(post => post.Rating)
                .Where(post => post.PostId == postId)
                .SingleOrDefault();
            return post;
        }

        public void SavePost(ForumPost post)
        {
            context.ForumPosts.Add(post);
            context.SaveChanges();
        }
    }
}
