using KatieSite.Controllers;
using KatieSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace KatieSite_Tests
{
    public class ForumControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // arrange
            HomeController controller = new HomeController();

            ForumPost p = new ForumPost();
            Rating r = new Rating();

            p.user = "user name";
            p.head = "head title";
            r.rating = 5;
            r.url = "url info";
            p.rating = r;
            p.body = "body text";
            p.date = DateTime.Now;

            // act

            ViewResult viewResult = (ViewResult)controller.Index(p.user, p.head, r.rating, r.url, p.body, p.date);

            ForumPost p2 = (ForumPost)viewResult.Model;


            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(p.user, p2.user);
            Assert.Equal(p.head, p2.head);
            Assert.Equal(p.body, p2.body);
            Assert.Equal(p.date, p2.date);
            Assert.Equal(p.rating.rating, p2.rating.rating);
            Assert.Equal(p.rating.url, p2.rating.url);


        }
    }
}
