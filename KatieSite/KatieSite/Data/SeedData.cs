using KatieSite.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

namespace KatieSite.Data
{
    public class SeedData
    {
        public static void Seed(RpgDbContext context)
        {
            if (!context.ForumPosts.Any())
            {
                ForumPost post;
                post = new ForumPost
                {
                    Head = "Youtube isn't a website yet",
                    Body = "Youtube isn't a website yet, and it won't be for a few years, but I think it's going to change things.",
                    User = "Katie Sullivan",
                    Rating = new Rating
                    {
                        PostRating = 5,
                        Url = "Youtube.com"
                    },
                    Date = DateTime.Parse("1/1/2000")
                };
                context.ForumPosts.Add(post);
                context.SaveChanges();

                post = new ForumPost
                {
                    Head = "Bing is a bad search engine",
                    Body = "This is some sample text about why I don't like bing.",
                    User = "Grumpy pants",
                    Rating = new Rating
                    {
                        PostRating = 1,
                        Url = "Bing.com"
                    },
                    Date = DateTime.Parse("2/2/2002")
                };
                context.ForumPosts.Add(post);

                post = new ForumPost
                {
                    Head = "Reddit is okay",
                    Body = "It's kind of a bad website because of the people using it, but like, it's okay sometimes?",
                    User = "Throwaway225623",
                    Rating = new Rating
                    {
                        PostRating = 3,
                        Url = "Reddit.com"
                    },
                    Date = DateTime.Parse("11/23/2022")
                };
                context.ForumPosts.Add(post);
                context.SaveChanges();
            }
        }
    }
}
