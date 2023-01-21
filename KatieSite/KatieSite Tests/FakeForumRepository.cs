using KatieSite.Data;
using KatieSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatieSite_Tests
{
    public class FakeForumRepository : IForumRepository
    {
        private List<ForumPost> postList = new List<ForumPost>();

        public IQueryable<ForumPost> Posts => throw new NotImplementedException(); // TODO: Fake Forum IQueryable

        public List<ForumPost> GetAllPosts()
        {
            return postList;
        }

        public ForumPost GetPostById(int postId)
        {
            ForumPost post = postList.Find(p => p.PostId == postId);
            return post;
        }

        public int SavePost(ForumPost post)
        {
            int status = 0;
            if (post != null)
            {
                status = 1;
                post.PostId = postList.Count+1;
                postList.Add(post);
            }
            return status;
        }
                
    }
}
