namespace KatieSite
{
    public class QuizLogic
    {
        public static string CheckAnswer(int questionNum, string userAnswer)
        {
            const string RIGHT = "Correct";
            const string WRONG = "Incorrect";
            const string NAQ = "Not a question!";

            const string A1 = "CHAIN MAIL";
            const string A2 = "PATHFINDER";
            const string A3 = "SIX";

            userAnswer = userAnswer.ToUpper().Trim();

            switch(questionNum)
            {
                case 1:
                    return userAnswer == A1 ? RIGHT : WRONG;
                case 2:
                    return userAnswer == A2 ? RIGHT : WRONG;
                case 3:
                    return userAnswer == A3 ? RIGHT : WRONG;
                default:
                    return NAQ;

            }
        }
    }
}
