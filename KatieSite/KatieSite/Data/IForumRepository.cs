using KatieSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace KatieSite.Data
{
    public interface IForumRepository
    {

        public IQueryable<ForumPost> Posts { get; }
        public ForumPost GetPostById(int postId);

        public int SavePost(ForumPost post);
        public List<ForumPost> GetAllPosts();
    }
}
