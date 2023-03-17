using KatieSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatieSite.Data
{
    public interface IForumRepository
    {

        public IQueryable<ForumPost> PostsAsync { get; }
        public Task<ForumPost> GetPostByIdAsync(int postId);

        public Task<int> SavePostAsync(ForumPost post);
		public Task<int> SaveReplyAsync(ForumPost post);
		public Task<List<ForumPost>> GetAllPostsAsync();
    }
}
