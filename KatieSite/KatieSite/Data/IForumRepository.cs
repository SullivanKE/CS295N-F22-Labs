using KatieSite.Models;
using System.Collections.Generic;

namespace KatieSite.Data
{
    public interface IForumRepository
    {

        public ForumPost GetPostById(int postId);

        public int SavePost(ForumPost post);
        public List<ForumPost> GetAllPosts();
    }
}
