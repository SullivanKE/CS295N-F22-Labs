using KatieSite.Controllers;
using KatieSite.Models;
using KatieSite;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace KatieSite_Tests
{
    public class HomeControllerTests
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

        [Fact]
        public void QuizLogicTest()
        {
            // arrange
            const string RIGHT = "Correct";
            const string WRONG = "Incorrect";
            const string NAQ = "Not a question!";

            QuizVM q1 = new QuizVM();
            q1.UserAnswer1 = "Wrong Answer";
            q1.UserAnswer2 = "Wrong Answer 2";
            q1.UserAnswer3 = "Wrong Answer 3";

            QuizVM q2 = new QuizVM();
            q2.UserAnswer1 = "Right Answer";
            q2.UserAnswer2 = "Right Answer 2";
            q2.UserAnswer3 = "Right Answer 3";

            QuizVM q3 = new QuizVM();
            q3.UserAnswer1 = "Not an Answer";
            q3.UserAnswer2 = "Not an Answer 2";
            q3.UserAnswer3 = "Not an Answer 3";

            // act

            q1.RightOrWrong1 = Quiz.CheckAnswer(1, q1.UserAnswer1);
            q1.RightOrWrong2 = Quiz.CheckAnswer(2, q1.UserAnswer2);
            q1.RightOrWrong3 = Quiz.CheckAnswer(3, q1.UserAnswer3);

            q2.RightOrWrong1 = Quiz.CheckAnswer(1, q2.UserAnswer1);
            q2.RightOrWrong2 = Quiz.CheckAnswer(2, q2.UserAnswer2);
            q2.RightOrWrong3 = Quiz.CheckAnswer(3, q2.UserAnswer3);

            q3.RightOrWrong1 = Quiz.CheckAnswer(4, q3.UserAnswer1);
            q3.RightOrWrong2 = Quiz.CheckAnswer(4, q3.UserAnswer2);
            q3.RightOrWrong3 = Quiz.CheckAnswer(4, q3.UserAnswer3);


            // assert
            Assert.Equal(WRONG, q1.RightOrWrong1);
            Assert.Equal(WRONG, q1.RightOrWrong2);
            Assert.Equal(WRONG, q1.RightOrWrong3);

            Assert.Equal(RIGHT, q1.RightOrWrong1);
            Assert.Equal(RIGHT, q1.RightOrWrong2);
            Assert.Equal(RIGHT, q1.RightOrWrong3);

            Assert.Equal(NAQ, q1.RightOrWrong1);
            Assert.Equal(NAQ, q1.RightOrWrong2);
            Assert.Equal(NAQ, q1.RightOrWrong3);
        }
    }
}
