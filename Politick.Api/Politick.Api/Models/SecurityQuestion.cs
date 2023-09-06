namespace Politick.Api.Models
{
    public class SecurityQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public SecurityQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
