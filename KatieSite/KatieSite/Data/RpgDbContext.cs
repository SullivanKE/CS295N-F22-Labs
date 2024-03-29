﻿using Microsoft.EntityFrameworkCore;
using KatieSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KatieSite.Data
{
    public class RpgDbContext : IdentityDbContext
    {
        public RpgDbContext(
           DbContextOptions<RpgDbContext> options) : base(options) { }
        public DbSet<ForumPost> ForumPosts { get; set; }
    }
}
