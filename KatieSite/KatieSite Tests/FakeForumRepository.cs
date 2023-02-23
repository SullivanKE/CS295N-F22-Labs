﻿using KatieSite.Data;
using KatieSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatieSite_Tests
{
    public class FakeForumRepository : IForumRepository
    {
        private List<ForumPost> postList = new List<ForumPost>();

        public IQueryable<ForumPost> PostsAsync => throw new NotImplementedException(); // TODO: Fake Forum IQueryable


        public Task<List<ForumPost>> GetAllPostsAsync()
        {
            return postList;
        }

        public async Task<ForumPost> GetPostByIdAsync(int postId)
        {
            ForumPost post = postList.Find(p => p.PostId == postId);
            return post;
        }

        public async Task<int> SavePostAsync(ForumPost post)
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
