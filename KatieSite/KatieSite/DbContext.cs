using Microsoft.EntityFrameworkCore;
using KatieSite.Models;

namespace KatieSite
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(
           DbContextOptions<DbContext> options) : base(options) { }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Rating> Rating { get; set; }
    }
}
