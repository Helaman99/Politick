namespace Politick.Api.Models
{
    public class CreatePlayer : PlayerCredentials
    {
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public CreatePlayer() : base("", "")
        {
            SecurityQuestion = "";
            SecurityAnswer = "";
        }
        public CreatePlayer(string email, string password, string question, string answer) : base(email, password) 
        {
            SecurityQuestion = question;
            SecurityAnswer = answer;
        }
    }
}