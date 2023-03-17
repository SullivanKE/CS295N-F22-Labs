/*using KatieSite.Controllers;
using KatieSite.Models;
using KatieSite;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using KatieSite.Data;
using NuGet.Frameworks;

namespace KatieSite_Tests
{
    public class ForumControllerTests
    {
        IForumRepository repo;
        ForumController controller;

        public ForumControllerTests()
        {
            repo = new FakeForumRepository();
            controller = new ForumController(repo);
        }
        [Fact]
        public void ForumTest_Success()
        {
            // arrange
            // Done in constructor

            // act
            // Check to see if I got a RedirectToActionResult

            var result = controller.Forum(new ForumPost());

            // assert

            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        public void ForumTest_Failure()
        {
            // arrange
            // Done in constructor

            // act
            // Check to see if I got a RedirectToActionResult

            var result = controller.Forum(null);

            // assert

            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}
*/