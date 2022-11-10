namespace KatieSite
{
    public class QuizLogic
    {
        public static string CheckAnswer(int questionNum, string userAnswer)
        {
            // Constant strings for responses
            const string RIGHT = "Correct";
            const string WRONG = "Incorrect";
            const string NAQ = "Not a question!";

            // Answer key
            const string A1 = "CHAIN MAIL";
            const string A2 = "PATHFINDER";
            const string A3 = "SIX";

            userAnswer = userAnswer.ToUpper().Trim();

            switch(questionNum)
            {
                case 1:
                    return userAnswer == A1 ? RIGHT : WRONG + ": The correct answer is " + A1;
                case 2:
                    return userAnswer == A2 ? RIGHT : WRONG + ": The correct answer is " + A2;
                case 3:
                    return userAnswer == A3 ? RIGHT : WRONG + ": The correct answer is " + A3;
                default:
                    return NAQ;

            }
        }
    }
}
