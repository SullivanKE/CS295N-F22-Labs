using Microsoft.EntityFrameworkCore;
using KatieSite.Models;

namespace KatieSite.Data
{
    public class RpgDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RpgDbContext(
           DbContextOptions<RpgDbContext> options) : base(options) { }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Rating> Rating { get; set; }
    }
}
