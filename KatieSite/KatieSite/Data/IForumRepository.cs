using KatieSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatieSite.Data
{
    public interface IForumRepository
    {

        public IQueryable<ForumPost> Posts { get; }
        public Task<ForumPost> GetPostById(int postId);

        public Task<int> SavePost(ForumPost post);
        public Task<List<ForumPost>> GetAllPosts();
    }
}
