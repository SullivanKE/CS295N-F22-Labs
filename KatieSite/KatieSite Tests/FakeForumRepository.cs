using KatieSite.Data;
using KatieSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatieSite_Tests
{
    public class FakeForumRepository : IForumRepository
    {
        private List<ForumPost> posts = new List<ForumPost>();

        public List<ForumPost> GetAllPosts()
        {
            return posts;
        }

        public ForumPost GetPostById(int postId)
        {
            ForumPost post = posts.Find(p => p.PostId == postId);
            return post;
        }

        public int SavePost(ForumPost post)
        {
            int status = 0;
            if (post != null)
            {
                status = 1;
                post.PostId = posts.Count+1;
                posts.Add(post);
            }
            return status;
        }
                
    }
}
