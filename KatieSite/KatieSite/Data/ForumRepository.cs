﻿using KatieSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                return context.ForumPosts.Include(post=>post.Rating);
            }
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

        public int SavePost(ForumPost post)
        {
            post.Date = DateTime.Now;
            context.ForumPosts.Add(post);
            return context.SaveChanges();
            // returns positive value if successful
        }
    }
}
