namespace KatieSite.Models
{
    public class QuizVM
    {
        // This holds the user answers and if they are correct or not for the home/quiz form
        public string UserAnswer1 { get; set; }
        public string UserAnswer2 { get; set; }
        public string UserAnswer3 { get; set; }

        public string RightOrWrong1 { get; set; }
        public string RightOrWrong2 { get; set; }
        public string RightOrWrong3 { get; set; }

    }
}
