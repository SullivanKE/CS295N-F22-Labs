using KatieSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KatieSite.Data
{
    public class SeedData
    {
        public static void Seed(RpgDbContext context, IServiceProvider provider)
        {
            if (!context.ForumPosts.Any())
            {
                // Generate users
                var userManager = provider.GetRequiredService<UserManager<AppUser>>();

                //TODO: Use user secrets to hide the password
                const string PASSWORD = "password";
                AppUser user1 = new AppUser
                {
                    UserName = "Katie Sullivan"
                };
                userManager.CreateAsync(user1, PASSWORD);

                AppUser user2 = new AppUser
                {
                    UserName = "Grumpy pants"
                };
                userManager.CreateAsync(user2, PASSWORD);

                AppUser user3 = new AppUser
                {
                    UserName = "Throwaway225623"
                };
                userManager.CreateAsync(user3, PASSWORD);


                // Generate forum posts
                ForumPost post;
                post = new ForumPost
                {
                    Head = "Youtube isn't a website yet",
                    Body = "Youtube isn't a website yet, and it won't be for a few years, but I think it's going to change things.",
                    User = user1,
                    Rating = 5,
                    Url = "Youtube.com",
                    Date = DateTime.Parse("1/1/2000")
                };
                context.ForumPosts.Add(post);
                context.SaveChanges();

                post = new ForumPost
                {
                    Head = "Bing is a bad search engine",
                    Body = "This is some sample text about why I don't like bing.",
                    User = user2,
                    Rating = 1,
                    Url = "Bing.com",
                    Date = DateTime.Parse("2/2/2002")
                };
                context.ForumPosts.Add(post);

                post = new ForumPost
                {
                    Head = "Reddit is okay",
                    Body = "It's kind of a bad website because of the people using it, but like, it's okay sometimes?",
                    User = user3,
                    Rating = 3,
                    Url = "Reddit.com",
                    Date = DateTime.Parse("11/23/2022")
                };
                context.ForumPosts.Add(post);
                context.SaveChanges();
            }
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
