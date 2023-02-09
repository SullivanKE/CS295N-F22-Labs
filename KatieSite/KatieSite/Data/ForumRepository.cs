﻿using KatieSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatieSite.Data
{
    public class ForumRepository : IForumRepository
    {
        private RpgDbContext context;

        public ForumRepository(RpgDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ForumPost> Posts 
        {
            get
            {
                return context.ForumPosts.Include(posts => posts.User);
            }
        }

        public async Task<List<ForumPost>> GetAllPosts()
        {
            List<ForumPost> posts = await context.ForumPosts
                .Include(posts => posts.User)
                .OrderByDescending(post => post.Date)
                .ToListAsync();
            return posts;
        }

        public async Task<ForumPost> GetPostById(int postId)
        {
            Task<ForumPost> postTask = context.ForumPosts
                .Where(post => post.PostId == postId)
                .Include(posts => posts.User)
                .SingleOrDefaultAsync();
            ForumPost post = await postTask;
            return post;
        }

        public async Task<int> SavePost(ForumPost post)
        {
            post.Date = DateTime.Now;
            await context.ForumPosts.AddAsync(post);
            return await context.SaveChangesAsync();
            // returns positive value if successful
        }
    }
}
