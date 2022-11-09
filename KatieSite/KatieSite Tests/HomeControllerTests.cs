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
        public void QuizTest()
        {
            // arrange
            HomeController controller = new HomeController();

            QuizVM q1 = new QuizVM();
            q1.UserAnswer1 = "CHAIN MAIL";
            q1.UserAnswer2 = "PATHFINDER";
            q1.UserAnswer3 = "SIX";



            // act
            ViewResult viewResult = (ViewResult)controller.Quiz(q1);

            QuizVM q2 = (QuizVM)viewResult.Model;

            q1.RightOrWrong1 = QuizLogic.CheckAnswer(1, q1.UserAnswer1);
            q1.RightOrWrong1 = QuizLogic.CheckAnswer(2, q1.UserAnswer2);
            q1.RightOrWrong1 = QuizLogic.CheckAnswer(3, q1.UserAnswer3);


            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(q1.UserAnswer1, q2.UserAnswer1);
            Assert.Equal(q1.UserAnswer2, q2.UserAnswer2);
            Assert.Equal(q1.UserAnswer3, q2.UserAnswer3);
            Assert.Equal(q1.RightOrWrong1, q2.RightOrWrong1);
            Assert.Equal(q1.RightOrWrong2, q2.RightOrWrong2);
            Assert.Equal(q1.RightOrWrong3, q2.RightOrWrong3);

        }

        [Fact]
        public void IndexTest()
        {
            // arrange
            HomeController controller = new HomeController();

            ForumPost p = new ForumPost();
            Rating r = new Rating();

            p.User = "user name";
            p.Head = "head title";
            r.rating = 5;
            r.url = "url info";
            p.Rating = r;
            p.Body = "body text";
            p.Date = DateTime.Now;

            // act

            ViewResult viewResult = (ViewResult)controller.Index(p.User, p.Head, r.rating, r.url, p.Body, p.Date);

            ForumPost p2 = (ForumPost)viewResult.Model;


            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(p.User, p2.User);
            Assert.Equal(p.Head, p2.Head);
            Assert.Equal(p.Body, p2.Body);
            Assert.Equal(p.Date, p2.Date);
            Assert.Equal(p.Rating.rating, p2.Rating.rating);
            Assert.Equal(p.Rating.url, p2.Rating.url);


        }

        [Fact]
        public void QuizLogicTest()
        {
            // arrange
            const string RIGHT = "Correct";
            const string WRONG = "Incorrect: The correct answer is ";
            const string NAQ = "Not a question!";

            QuizVM q1 = new QuizVM();
            q1.UserAnswer1 = "Wrong Answer 1";
            q1.UserAnswer2 = "Wrong Answer 2";
            q1.UserAnswer3 = "Wrong Answer 3";

            QuizVM q2 = new QuizVM();
            q2.UserAnswer1 = "CHAIN MAIL";
            q2.UserAnswer2 = "PATHFINDER";
            q2.UserAnswer3 = "SIX";

            QuizVM q3 = new QuizVM();
            q3.UserAnswer1 = "Not an Answer 1";
            q3.UserAnswer2 = "Not an Answer 2";
            q3.UserAnswer3 = "Not an Answer 3";

            // act
            q1.RightOrWrong1 = QuizLogic.CheckAnswer(1, q1.UserAnswer1);
            q1.RightOrWrong2 = QuizLogic.CheckAnswer(2, q1.UserAnswer2);
            q1.RightOrWrong3 = QuizLogic.CheckAnswer(3, q1.UserAnswer3);

            q2.RightOrWrong1 = QuizLogic.CheckAnswer(1, q2.UserAnswer1);
            q2.RightOrWrong2 = QuizLogic.CheckAnswer(2, q2.UserAnswer2);
            q2.RightOrWrong3 = QuizLogic.CheckAnswer(3, q2.UserAnswer3);

            q3.RightOrWrong1 = QuizLogic.CheckAnswer(4, q3.UserAnswer1);
            q3.RightOrWrong2 = QuizLogic.CheckAnswer(4, q3.UserAnswer2);
            q3.RightOrWrong3 = QuizLogic.CheckAnswer(4, q3.UserAnswer3);


            // assert
            Assert.Equal(WRONG + q2.UserAnswer1, q1.RightOrWrong1);
            Assert.Equal(WRONG + q2.UserAnswer2, q1.RightOrWrong2);
            Assert.Equal(WRONG + q2.UserAnswer3, q1.RightOrWrong3);

            Assert.Equal(RIGHT, q2.RightOrWrong1);
            Assert.Equal(RIGHT, q2.RightOrWrong2);
            Assert.Equal(RIGHT, q2.RightOrWrong3);

            Assert.Equal(NAQ, q3.RightOrWrong1);
            Assert.Equal(NAQ, q3.RightOrWrong2);
            Assert.Equal(NAQ, q3.RightOrWrong3);
        }
    }
}
